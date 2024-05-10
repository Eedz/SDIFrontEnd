using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    // TODO add series comment
    /// <summary>
    /// Entry point for comments. 
    /// </summary>
    public partial class CommentEntry : Form
    {
        List<NoteRecord> Records;
        List<NoteRecord> FilteredNotes;

        NoteRecord CurrentRecord;
        BindingSource bs;
        BindingSource bsCurrent;

        BindingSource bsStored;

        // lists to hold all the comment usages
        List<QuestionCommentRecord> QuestionComments;
        List<SurveyCommentRecord> SurveyComments;
        List<WaveCommentRecord> WaveComments;
        List<DeletedCommentRecord> DeletedComments;
        List<RefVarCommentRecord> RefVarComments;

        NoteScope Scope;

        List<dynamic> newComments;

        int firstPanelTop = 260;
        int secondPanelTop = 450;
        int thirdPanelTop = 642;

        private bool DirtyStored;

        public event EventHandler<QuestionCommentCreated> CreatedComment;

        QuestionComment editedQuestionComment;
        int questionCommentRow = -1;

        SurveyComment editedSurveyComment;
        int surveyCommentRow = -1;

        WaveComment editedWaveComment;
        int waveCommentRow = -1;

        RefVarComment editedRefVarComment;
        int refVarCommentRow = -1;

        DeletedComment editedDeletedComment;
        int deletedCommentRow = -1;

        bool rowCommit = true;

        public CommentEntry()
        {
            InitializeComponent();

            GetRecords();

            SetupBindingSources();

            FilteredNotes = new List<NoteRecord>();
            newComments = new List<dynamic>();

            SetupGrids();

            FillBoxes();

            BindProperties();

            // load the comment uses
            LoadComments();

            chkNewDetails.Checked = true;
        }

        public CommentEntry(SurveyQuestion question) : this ()
        {
            FillTargetQuestion(question);
            UpdateCreationCount();

            cboVarNameList.SelectedItem = question.VarName;

            if (question.Comments.Count == 0)
                return;            
        }

        public CommentEntry(NoteScope scope, List<SurveyQuestion> questions) : this()
        {
            Scope = scope;
            
            FillTargetSurveyList();
            ToggleTargetVarNameList();
            UpdateCreationCount();
            foreach (SurveyQuestion q in questions)
                FillTargetQuestion(q);

            cboVarNameList.SelectedItem = questions[0].VarName;
        }

        #region Form Setup

        /// <summary>
        /// Create records using the provided list of objects.
        /// </summary>
        /// <param name="notes"></param>
        private void GetRecords()
        {
            Records = new List<NoteRecord>();
            foreach (Note note in Globals.AllNotes)
            {
                Records.Add(new NoteRecord(note));
            }
            if (Records.Count == 0)
                Records.Add(new NoteRecord());
        }

        /// <summary>
        /// Create and populate binding sources and attached events.
        /// </summary>
        private void SetupBindingSources()
        {
            bs = new BindingSource
            {
                DataSource = Records
            };

            bs.PositionChanged += BindingSource_PositionChanged;

            bsCurrent = new BindingSource()
            {
                DataSource = bs,
                DataMember = "Item"
            };
            bsCurrent.ListChanged += BsCurrent_ListChanged;

            CurrentRecord = (NoteRecord)bs.Current;

            bsStored = new BindingSource();
            bsStored.DataSource = new List<Comment>(Globals.CurrentUser.SavedComments);

            repeaterStored.DataSource = bsStored;

            navNotes.BindingSource = bs;
        }

        /// <summary>
        /// Populate drop downs in the comment entry section.
        /// </summary>
        private void FillBoxes()
        {
            var scopes = new List<KeyValuePair<int, string>>();
            foreach (NoteScope s in Enum.GetValues(typeof(NoteScope)))
                scopes.Add(new KeyValuePair<int, string>((int)s, s.ToString()));

            cboCommentScope.DisplayMember = "Value";
            cboCommentScope.ValueMember = "Key";
            cboCommentScope.DataSource = scopes;

            cboNoteType.DisplayMember = "TypeName";
            cboNoteType.ValueMember = "TypeName";
            cboNoteType.DataSource = new List<CommentType>(Globals.AllCommentTypes);

            cboNoteAuthor.DisplayMember = "Name";
            cboNoteAuthor.ValueMember = "ID";
            cboNoteAuthor.DataSource = new List<Person>(Globals.AllPeople);

            cboNoteAuthority.ValueMember = "ID";
            cboNoteAuthority.DisplayMember = "Name";
            cboNoteAuthority.DataSource = new List<Person>(Globals.AllPeople);
            
            lstTargetSurvWave.DisplayMember = "SurveyCode";

            cboVarNameList.DisplayMember = "RefVarName";
            cboVarNameList.DataSource = new List<RefVariableName>(Globals.AllRefVarNames);
            
            lstTargetVar.DisplayMember = "RefVarName";

            FillTargetSurveyList();
        }

        /// <summary>
        /// Setup the comment usage grids.
        /// </summary>
        private void SetupGrids()
        {
            SetupQuestionCommentGrid();
            SetupSurveyCommentGrid();
            SetupWaveCommentGrid();
            SetupRefVarCommentGrid();
            SetupDeletedCommentGrid();
        }
        /// <summary>
        /// Setup Question Comment usage grid.
        /// </summary>
        private void SetupQuestionCommentGrid()
        {
            gridQuesComments.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn chQSurvey = new DataGridViewTextBoxColumn();
            chQSurvey.Name = "chQSurvey";
            chQSurvey.Width = 100;
            chQSurvey.HeaderText = "Survey";
            chQSurvey.ReadOnly = true;
            gridQuesComments.Columns.Add(chQSurvey);

            DataGridViewTextBoxColumn chQVarName = new DataGridViewTextBoxColumn();
            chQVarName.Name = "chQVarName";
            chQVarName.Width = 100;
            chQVarName.HeaderText = "VarName";
            chQVarName.ReadOnly = true;
            gridQuesComments.Columns.Add(chQVarName);

            CalendarColumn chQDate = new CalendarColumn();
            chQDate.Name = "chQDate";
            chQDate.HeaderText = "Date";
            chQDate.Width = 100;
            gridQuesComments.Columns.Add(chQDate);

            DataGridViewComboBoxColumn chQName = new DataGridViewComboBoxColumn();
            chQName.Name = "chQName";
            chQName.HeaderText = "Author";
            chQName.Width = 100;
            chQName.ValueMember = "ID";
            chQName.DisplayMember = "Name";
            chQName.DataSource = new List<Person>(Globals.AllPeople);
            gridQuesComments.Columns.Add(chQName);

            DataGridViewComboBoxColumn chQType = new DataGridViewComboBoxColumn();
            chQType.Name = "chQType";
            chQType.HeaderText = "Type";
            chQType.Width = 100;
            chQType.ValueMember = "ID";
            chQType.DisplayMember = "TypeName";
            chQType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            gridQuesComments.Columns.Add(chQType);

            DataGridViewTextBoxColumn chQSource = new DataGridViewTextBoxColumn();
            chQSource.Name = "chQSource";
            chQSource.HeaderText = "Source";
            chQSource.Width = 200;
            gridQuesComments.Columns.Add(chQSource);

            DataGridViewComboBoxColumn chQAuthority = new DataGridViewComboBoxColumn();
            chQAuthority.Name = "chQAuthority";
            chQAuthority.HeaderText = "Authority";
            chQAuthority.Width = 100;
            chQAuthority.ValueMember = "ID";
            chQAuthority.DisplayMember = "Name";
            chQAuthority.DataSource = new List<Person>(Globals.AllPeople);
            gridQuesComments.Columns.Add(chQAuthority);

            gridQuesComments.CellValueNeeded += gridQuesComments_CellValueNeeded;
            gridQuesComments.NewRowNeeded += gridQuesComments_NewRowNeeded;
            gridQuesComments.CellValuePushed += gridQuesComments_CellValuePushed;
            gridQuesComments.RowValidated += gridQuesComments_RowValidated;
            gridQuesComments.RowDirtyStateNeeded += gridQuesComments_RowDirtyStateNeeded;
            gridQuesComments.CancelRowEdit += gridQuesComments_CancelRowEdit;
            gridQuesComments.UserDeletingRow += gridQuesComments_UserDeletingRow;
            gridQuesComments.DataError += gridQuesComments_DataError;
        }
        /// <summary>
        /// Setup Survey Comment usage grid.
        /// </summary>
        private void SetupSurveyCommentGrid()
        {
            gridSurvComments.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn chSurvey = new DataGridViewTextBoxColumn();
            chSurvey.Name = "chSSurvey";
            chSurvey.Width = 100;
            chSurvey.HeaderText = "Survey";
            chSurvey.ReadOnly = true;
            gridSurvComments.Columns.Add(chSurvey);

            CalendarColumn chDate = new CalendarColumn();
            chDate.Name = "chSDate";
            chDate.HeaderText = "Date";
            chDate.Width = 100;
            gridSurvComments.Columns.Add(chDate);

            DataGridViewComboBoxColumn chName = new DataGridViewComboBoxColumn();
            chName.Name = "chSName";
            chName.HeaderText = "Author";
            chName.Width = 100;
            chName.ValueMember = "ID";
            chName.DisplayMember = "Name";
            chName.DataSource = new List<Person>(Globals.AllPeople);
            gridSurvComments.Columns.Add(chName);

            DataGridViewComboBoxColumn chType = new DataGridViewComboBoxColumn();
            chType.Name = "chSType";
            chType.HeaderText = "Type";
            chType.Width = 100;
            chType.ValueMember = "ID";
            chType.DisplayMember = "TypeName";
            chType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            gridSurvComments.Columns.Add(chType);

            DataGridViewTextBoxColumn chSource = new DataGridViewTextBoxColumn();
            chSource.Name = "chSSource";
            chSource.HeaderText = "Source";
            chSource.Width = 200;
            gridSurvComments.Columns.Add(chSource);

            DataGridViewComboBoxColumn chAuthority = new DataGridViewComboBoxColumn();
            chAuthority.Name = "chSAuthority";
            chAuthority.HeaderText = "Authority";
            chAuthority.Width = 100;
            chAuthority.ValueMember = "ID";
            chAuthority.DisplayMember = "Name";
            chAuthority.DataSource = new List<Person>(Globals.AllPeople);
            gridSurvComments.Columns.Add(chAuthority);

            gridSurvComments.CellValueNeeded += gridSurvComments_CellValueNeeded;
            gridSurvComments.NewRowNeeded += gridSurvComments_NewRowNeeded;
            gridSurvComments.CellValuePushed += gridSurvComments_CellValuePushed;
            gridSurvComments.RowValidated += gridSurvComments_RowValidated;
            gridSurvComments.RowDirtyStateNeeded += gridSurvComments_RowDirtyStateNeeded;
            gridSurvComments.CancelRowEdit += gridSurvComments_CancelRowEdit;
            gridSurvComments.UserDeletingRow += gridSurvComments_UserDeletingRow;
            gridSurvComments.DataError += gridSurvComments_DataError;
        }
        /// <summary>
        /// Setup Wave Comment usage grid.
        /// </summary>
        private void SetupWaveCommentGrid()
        {
            gridWaveComments.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn chWave = new DataGridViewTextBoxColumn();
            chWave.Name = "chWave";
            chWave.Width = 100;
            chWave.HeaderText = "Wave";
            chWave.ReadOnly = true;
            gridWaveComments.Columns.Add(chWave);

            CalendarColumn chDate = new CalendarColumn();
            chDate.Name = "chWDate";
            chDate.HeaderText = "Date";
            chDate.Width = 100;
            gridWaveComments.Columns.Add(chDate);

            DataGridViewComboBoxColumn chName = new DataGridViewComboBoxColumn();
            chName.Name = "chWName";
            chName.HeaderText = "Author";
            chName.Width = 100;
            chName.ValueMember = "ID";
            chName.DisplayMember = "Name";
            chName.DataSource = new List<Person>(Globals.AllPeople);
            gridWaveComments.Columns.Add(chName);

            DataGridViewComboBoxColumn chType = new DataGridViewComboBoxColumn();
            chType.Name = "chWType";
            chType.HeaderText = "Type";
            chType.Width = 100;
            chType.ValueMember = "ID";
            chType.DisplayMember = "TypeName";
            chType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            gridWaveComments.Columns.Add(chType);

            DataGridViewTextBoxColumn chSource = new DataGridViewTextBoxColumn();
            chSource.Name = "chWSource";
            chSource.HeaderText = "Source";
            chSource.Width = 200;
            gridWaveComments.Columns.Add(chSource);

            DataGridViewComboBoxColumn chAuthority = new DataGridViewComboBoxColumn();
            chAuthority.Name = "chWAuthority";
            chAuthority.HeaderText = "Authority";
            chAuthority.Width = 100;
            chAuthority.ValueMember = "ID";
            chAuthority.DisplayMember = "Name";
            chAuthority.DataSource = new List<Person>(Globals.AllPeople);
            gridWaveComments.Columns.Add(chAuthority);

            gridWaveComments.CellValueNeeded += gridWaveComments_CellValueNeeded;
            gridWaveComments.NewRowNeeded += gridWaveComments_NewRowNeeded;
            gridWaveComments.CellValuePushed += gridWaveComments_CellValuePushed;
            gridWaveComments.RowValidated += gridWaveComments_RowValidated;
            gridWaveComments.RowDirtyStateNeeded += gridWaveComments_RowDirtyStateNeeded;
            gridWaveComments.CancelRowEdit += gridWaveComments_CancelRowEdit;
            gridWaveComments.UserDeletingRow += gridWaveComments_UserDeletingRow;
            gridWaveComments.DataError += gridWaveComments_DataError;
        }
        /// <summary>
        /// Setup RefVarName Comment usage grid.
        /// </summary>
        private void SetupRefVarCommentGrid()
        {
            gridRefVarComments.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn chRefVar = new DataGridViewTextBoxColumn();
            chRefVar.Name = "chRefVar";
            chRefVar.Width = 100;
            chRefVar.HeaderText = "RefVarName";
            chRefVar.ReadOnly = true;
            gridRefVarComments.Columns.Add(chRefVar);

            CalendarColumn chDate = new CalendarColumn();
            chDate.Name = "chRDate";
            chDate.HeaderText = "Date";
            chDate.Width = 100;
            gridRefVarComments.Columns.Add(chDate);

            DataGridViewComboBoxColumn chName = new DataGridViewComboBoxColumn();
            chName.Name = "chRName";
            chName.HeaderText = "Author";
            chName.Width = 100;
            chName.ValueMember = "ID";
            chName.DisplayMember = "Name";
            chName.DataSource = new List<Person>(Globals.AllPeople);
            gridRefVarComments.Columns.Add(chName);

            DataGridViewComboBoxColumn chType = new DataGridViewComboBoxColumn();
            chType.Name = "chRType";
            chType.HeaderText = "Type";
            chType.Width = 100;
            chType.ValueMember = "ID";
            chType.DisplayMember = "TypeName";
            chType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            gridRefVarComments.Columns.Add(chType);

            DataGridViewTextBoxColumn chSource = new DataGridViewTextBoxColumn();
            chSource.Name = "chRSource";
            chSource.HeaderText = "Source";
            chSource.Width = 200;
            gridRefVarComments.Columns.Add(chSource);

            DataGridViewComboBoxColumn chAuthority = new DataGridViewComboBoxColumn();
            chAuthority.Name = "chRAuthority";
            chAuthority.HeaderText = "Authority";
            chAuthority.Width = 100;
            chAuthority.ValueMember = "ID";
            chAuthority.DisplayMember = "Name";
            chAuthority.DataSource = new List<Person>(Globals.AllPeople);
            gridRefVarComments.Columns.Add(chAuthority);

            gridRefVarComments.CellValueNeeded += gridRefVarComments_CellValueNeeded;
            gridRefVarComments.NewRowNeeded += gridRefVarComments_NewRowNeeded;
            gridRefVarComments.CellValuePushed += gridRefVarComments_CellValuePushed;
            gridRefVarComments.RowValidated += gridRefVarComments_RowValidated;
            gridRefVarComments.RowDirtyStateNeeded += gridRefVarComments_RowDirtyStateNeeded;
            gridRefVarComments.CancelRowEdit += gridRefVarComments_CancelRowEdit;
            gridRefVarComments.UserDeletingRow += gridRefVarComments_UserDeletingRow;
            gridRefVarComments.DataError += gridRefVarComments_DataError;
        }
        /// <summary>
        /// Setup Deleted Question Comment usage grid.
        /// </summary>
        private void SetupDeletedCommentGrid()
        {
            gridDeletedComments.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn chSurvey = new DataGridViewTextBoxColumn();
            chSurvey.Name = "chDSurvey";
            chSurvey.Width = 100;
            chSurvey.HeaderText = "Survey";
            chSurvey.ReadOnly = true;
            gridDeletedComments.Columns.Add(chSurvey);

            DataGridViewTextBoxColumn chVarName = new DataGridViewTextBoxColumn();
            chVarName.Name = "chDVarName";
            chVarName.Width = 100;
            chVarName.HeaderText = "VarName";
            chVarName.ReadOnly = true;
            gridDeletedComments.Columns.Add(chVarName);

            CalendarColumn chDate = new CalendarColumn();
            chDate.Name = "chDDate";
            chDate.HeaderText = "Date";
            chDate.Width = 100;
            gridDeletedComments.Columns.Add(chDate);

            DataGridViewComboBoxColumn chName = new DataGridViewComboBoxColumn();
            chName.Name = "chDName";
            chName.HeaderText = "Author";
            chName.Width = 100;
            chName.ValueMember = "ID";
            chName.DisplayMember = "Name";
            chName.DataSource = new List<Person>(Globals.AllPeople);
            gridDeletedComments.Columns.Add(chName);

            DataGridViewComboBoxColumn chType = new DataGridViewComboBoxColumn();
            chType.Name = "chDType";
            chType.HeaderText = "Type";
            chType.Width = 100;
            chType.ValueMember = "ID";
            chType.DisplayMember = "TypeName";
            chType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            gridDeletedComments.Columns.Add(chType);

            DataGridViewTextBoxColumn chSource = new DataGridViewTextBoxColumn();
            chSource.Name = "chDSource";
            chSource.HeaderText = "Source";
            chSource.Width = 200;
            gridDeletedComments.Columns.Add(chSource);

            DataGridViewComboBoxColumn chAuthority = new DataGridViewComboBoxColumn();
            chAuthority.Name = "chDAuthority";
            chAuthority.HeaderText = "Authority";
            chAuthority.Width = 100;
            chAuthority.ValueMember = "ID";
            chAuthority.DisplayMember = "Name";
            chAuthority.DataSource = new List<Person>(Globals.AllPeople);
            gridDeletedComments.Columns.Add(chAuthority);

            gridDeletedComments.CellValueNeeded += gridDeletedComments_CellValueNeeded;
            gridDeletedComments.NewRowNeeded += gridDeletedComments_NewRowNeeded;
            gridDeletedComments.CellValuePushed += gridDeletedComments_CellValuePushed;
            gridDeletedComments.RowValidated += gridDeletedComments_RowValidated;
            gridDeletedComments.RowDirtyStateNeeded += gridDeletedComments_RowDirtyStateNeeded;
            gridDeletedComments.CancelRowEdit += gridDeletedComments_CancelRowEdit;
            gridDeletedComments.UserDeletingRow += gridDeletedComments_UserDeletingRow;
            gridDeletedComments.DataError += gridDeletedComments_DataError;
        }
        /// <summary>
        /// Bind properties to controls.
        /// </summary>
        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bsCurrent, "ID");
            txtNoteText.DataBindings.Add("Text", bsCurrent, "NoteText");

            dtpStoredDate.DataBindings.Add("Value", bsStored, "NoteDate", true);
            txtStoredSource.DataBindings.Add("Text", bsStored, "Source");
        }
        #endregion

        #region Event Handlers
        private void CommentEntry_Load(object sender, EventArgs e)
        {
            CurrentRecord = (NoteRecord)bs.Current;

            ExpandForm();
        }

        private void CommentEntry_MouseWheel(object sender, MouseEventArgs e)
        {
            bs.EndEdit();

            if (SaveNote() == 1)
                return;

            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }

        private void CommentEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote();
        }

        private void CommentEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Modal)
                FM.FormManager.Remove(this);
        }

        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (NoteRecord)bs.Current;

            if (CurrentRecord == null)
                return;

            lblNewID.Visible = !(CurrentRecord.Item.ID > 0);

            LoadComments();
        }

        private void BsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            // item: bs[e.NewIndex]
            // property name: e.PropertyDescriptor.Name
            if (e.PropertyDescriptor != null)
            {
                // get the paper record that was modified
                Note modifiedNote = (Note)bsCurrent[e.NewIndex];
                NoteRecord modifiedRecord = Records.Where(x => x.Item == modifiedNote).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    default:
                        modifiedRecord.Dirty = true;
                        break;
                }
            }           
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            if (SaveNote() == 1)
            {
                return;
            }

            UpdateCreationCount();

            if (!InfoEntered())
            {
                MessageBox.Show("One or more required fields missing.");
                return;
            }

            SaveComments();

            LoadComments();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteNote();
        }

        private void cmdSearchClip_Click(object sender, EventArgs e)
        {
            SearchClip();
        }

        private void cmdSearchText_Click(object sender, EventArgs e)
        {
            SearchText();
        }

        private void cboCommentScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse<NoteScope>(cboCommentScope.SelectedValue.ToString(), out Scope);

            FillTargetSurveyList();
            ToggleTargetVarNameList();
            UpdateCreationCount();
        }

        private void chkSurvWave_CheckedChanged(object sender, EventArgs e)
        {
            FillTargetSurveyList();
        }

        private void  cmdAddSurvWave_Click(object sender, EventArgs e)
        {
            var selection = cboSurvWaveList.SelectedItem;

            if (selection is Survey)
                AddSurvey((Survey)selection);
            else if (selection is StudyWave)
                AddWave((StudyWave)selection);

            UpdateCreationCount();
        }

        private void cmdRemoveSurvWave_Click(object sender, EventArgs e)
        {
            lstTargetSurvWave.Items.Remove(lstTargetSurvWave.SelectedItem);

            UpdateCreationCount();
        }

        private void cmdAddVar_Click(object sender, EventArgs e)
        {
            RefVariableName selection = (RefVariableName) cboVarNameList.SelectedItem;
            AddVar(selection);

            UpdateCreationCount();
        }

        private void cmdRemoveVar_Click(object sender, EventArgs e)
        {
            lstTargetVar.Items.Remove(lstTargetVar.SelectedItem);
            UpdateCreationCount();
        }

        private void cmdUserSources_Click(object sender, EventArgs e)
        {
            SavedSources frm = new SavedSources(Globals.CurrentUser.SavedSources);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtNoteSource.Text = frm.SelectedSource;
            }
        }

        private void chkAssignedDetails_CheckedChanged(object sender, EventArgs e)
        {
            AssignedDetails(GetTopComment());
            ToggleAutoDetails(1);
            ExpandForm();
        }

        private void AutoDetails2_CheckedChanged(object sender, EventArgs e)
        {
            LastUsedComment(Globals.CurrentUser.LastUsedComment);
            ToggleAutoDetails(2);
            ExpandForm();
        }

        private void AutoDetails3_CheckedChanged(object sender, EventArgs e)
        {
            NewComment();
            ToggleAutoDetails(3);
            ExpandForm();
        }

        private void chkStoredComments_CheckedChanged(object sender, EventArgs e)
        {
            ExpandForm();
        }

        private void cmdStoreComment_Click(object sender, EventArgs e)
        {
            Comment newStored = new Comment();

            newStored.Notes = CurrentRecord.Item;
            newStored.NoteDate = dtpNoteDate.Value;
            newStored.NoteType = (CommentType)cboNoteType.SelectedItem;
            newStored.Author = (Person)cboNoteAuthor.SelectedItem;
            newStored.Authority = (Person)cboNoteAuthority.SelectedItem;
            newStored.Source = txtNoteSource.Text;

            SaveStored(newStored, 1);
            bsStored.ResetBindings(false);
        }

        #region Navigation Bar
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveNote() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveNote() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveNote() == 1)
                return;

            bs.MoveFirst();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveNote() == 1)
                return;

            bs.MoveLast();
        }
        #endregion

        #endregion

        #region Methods

        private void LoadComments()
        {
            if (CurrentRecord == null)
                return;

            LoadQuestionComments();

            LoadSurveyComments();

            LoadWaveComments();

            LoadRefVarComments();

            LoadDeletedComments();
        }

        private void LoadQuestionComments()
        {
            QuestionComments = new List<QuestionCommentRecord>();
            var comments = DBAction.GetQuesCommentsByCID(CurrentRecord.Item.ID);
            foreach (QuestionComment c in comments)
            {
                QuestionComments.Add(new QuestionCommentRecord(c));
            }
            gridQuesComments.RowCount =  QuestionComments.Count;
            pageQuestion.Text = "Variable (" + QuestionComments.Count + ")";
        }

        private void LoadSurveyComments()
        {
            SurveyComments = new List<SurveyCommentRecord>();
            var comments = DBAction.GetSurvCommentsByCID(CurrentRecord.Item.ID);
            foreach (SurveyComment c in comments)
            {
                SurveyComments.Add(new SurveyCommentRecord(c));
            }
            
            gridSurvComments.RowCount = SurveyComments.Count;
            pageSurvey.Text = "Survey (" + SurveyComments.Count + ")";
        }

        private void LoadWaveComments()
        {
            WaveComments = new List<WaveCommentRecord>();
            var comments = DBAction.GetWaveCommentsByCID(CurrentRecord.Item.ID);
            foreach (WaveComment c in comments)
            {
                WaveComments.Add(new WaveCommentRecord(c));
            }

            gridWaveComments.RowCount = WaveComments.Count;
            pageWave.Text = "Wave (" + WaveComments.Count + ")";
        }

        private void LoadDeletedComments()
        {
            DeletedComments = new List<DeletedCommentRecord>();
            var comments = DBAction.GetDeletedCommentsByCID(CurrentRecord.Item.ID);
            foreach (DeletedComment c in comments)
            {
                DeletedComments.Add(new DeletedCommentRecord(c));
            }

            gridDeletedComments.RowCount = DeletedComments.Count;
            pageDeleted.Text = "Deleted Vars (" + DeletedComments.Count + ")";
        }

        private void LoadRefVarComments()
        {
            RefVarComments = new List<RefVarCommentRecord>();
            var comments = DBAction.GetRefVarCommentsByCID(CurrentRecord.Item.ID);
            foreach (RefVarComment c in comments)
            {
                RefVarComments.Add(new RefVarCommentRecord(c));
            }

            gridRefVarComments.RowCount = RefVarComments.Count;
            pageRefVar.Text = "RefVar (" + RefVarComments.Count + ")";
        }

        private void FillTargetSurveyList()
        {
            bool enable = Scope != NoteScope.RefVar;
            cboSurvWaveList.Enabled = enable;
            lstTargetSurvWave.Enabled = enable;
            cmdRemoveSurvWave.Enabled = enable;
            cmdAddSurvWave.Enabled = enable;

            if (!enable)
                return;

            lstTargetSurvWave.Items.Clear();
            if (Scope == NoteScope.Wave || chkSurvWave.Checked)
            {

                cboSurvWaveList.DataSource = new List<StudyWave>(Globals.AllWaves);
                cboSurvWaveList.DisplayMember = "WaveCode";
                cboSurvWaveList.ValueMember = "ID";

            }
            else
            {
                cboSurvWaveList.DataSource = new List<Survey>(Globals.AllSurveys);
                cboSurvWaveList.DisplayMember = "SurveyCode";
                cboSurvWaveList.ValueMember = "SID";

            }
        }

        private void ToggleTargetVarNameList()
        {
            bool enable = Scope == NoteScope.Variable || Scope == NoteScope.RefVar || Scope == NoteScope.Deleted;

            cboVarNameList.Enabled = enable;
            lstTargetVar.Enabled = enable;
            cmdRemoveVar.Enabled = enable;
            cmdAddVar.Enabled = enable;

        }

        private void MoveRecord(int count)
        {
            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }
        }

        private void AddNote()
        {
            if (CurrentRecord.NewRecord)
                return;

            lblNewID.Left = txtID.Left;
            lblNewID.Top = txtID.Top;
            lblNewID.Visible = true;

            bs.DataSource = Records;

            if (Records.Last().NewRecord)
                bs.MoveLast();
            else
            {
                CurrentRecord = (NoteRecord)bs.AddNew();
                CurrentRecord.NewRecord = true;
            }
        }

        private void DeleteNote()
        {
            bs.EndEdit();

            if (MessageBox.Show("Are you sure you want to delete this comment and all of its uses?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (DBAction.DeleteRecord(CurrentRecord.Item) == 1)
            {
                MessageBox.Show("Error deleting note.");
            }
            else
            {
                Globals.AllNotes.Remove(CurrentRecord.Item);
                bs.RemoveCurrent();
                LoadComments();
            }
        }

        private void SearchClip()
        {
            string searchTerm = Clipboard.GetText();
            FilterForNote(searchTerm);
        }

        private void SearchText()
        {
            InputBox input = new InputBox("Search for:", "Search");
            input.ShowDialog();

            string searchTerm = input.userInput;

            if (!string.IsNullOrEmpty(searchTerm))
                FilterForNote(searchTerm);
        }

        private void FilterForNote(string searchCriteria)
        {
            var foundNotes = Records.Where (x => x.Item.NoteText.Contains(searchCriteria)).ToList();

            if (foundNotes.Count==0)
            {
                MessageBox.Show("No matches found.");
                return;
            }

            bs.DataSource = foundNotes; 
            navNotes.BindingSource = null;
            navNotes.BindingSource = bs;
        }

        private bool IsEmptyRecord(NoteRecord n)
        {
            if (string.IsNullOrEmpty(n.Item.NoteText) && n.NewRecord)
                return true;
            else
                return false;
        }

        private int SaveNote()
        {
            bsCurrent.EndEdit();

            if (CurrentRecord.Item.ID == 0 && string.IsNullOrEmpty(CurrentRecord.Item.NoteText))
            {
                bs.RemoveCurrent();
                return 0;
            }

            bool newRec = CurrentRecord.NewRecord;

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save note.");
                return 1;
            }
            else
            {
                if (newRec)
                    Globals.AllNotes.Add(CurrentRecord.Item);
            }

            lblNewID.Visible = false;

            return 0;
        }

        private bool InfoEntered()
        {
            if (Scope != NoteScope.RefVar && cboSurvWaveList.Items.Count == 0)
                return false;

            if (cboNoteType.SelectedItem == null)
                return false;

            return true;
        }

        private void UpdateCreationCount()
        {
            int count = 0;

            switch (Scope)
            {
                case NoteScope.Variable:
                    count = CountVariableComments();
                    break;
                case NoteScope.Survey:
                    count = CountSurveyComments();
                    break;
                case NoteScope.Wave:
                    count = CountWaveComments();
                    break;
                case NoteScope.Deleted:
                    count = CountDeletedComments();
                    break;
                case NoteScope.RefVar:
                    count = CountRefVarComments();
                    break;
            }

            lblNumberCreated.Text = count + " comment(s) will be created.";
        }

        private int CountVariableComments()
        {
            int count = 0;
            newComments.Clear();

            List<Survey> surveys = lstTargetSurvWave.Items.Cast<Survey>().ToList();
            List<RefVariableName> varnames = lstTargetVar.Items.Cast<RefVariableName>().ToList();

            for (int i = 0; i < surveys.Count; i++)
            {
                for (int j = 0; j < varnames.Count; j++)
                {
                    string fullVar = Utilities.ChangeCC(varnames[j].RefVarName, surveys[i].CountryCode);
                    SurveyQuestion sq = new SurveyQuestion();
                    sq.SurveyCode = surveys[i].SurveyCode;
                    sq.VarName.VarName = fullVar;
                    int qid = DBAction.GetQuestionID(sq.SurveyCode, sq.VarName.VarName);
                    if (qid != 0 && !DBAction.QuestionCommentExists(sq, CurrentRecord.Item.ID))
                    {
                        QuestionCommentRecord c = new QuestionCommentRecord();

                        c.NewRecord = true;
                        c.Item.QID = qid;
                        c.Item.Survey = surveys[i].SurveyCode;
                        c.Item.VarName = fullVar;
                        c.Item.Author = (Person)cboNoteAuthor.SelectedItem;
                        c.Item.NoteType = (CommentType)cboNoteType.SelectedItem;
                        c.Item.NoteDate = dtpNoteDate.Value;
                        c.Item.Authority = (Person)cboNoteAuthority.SelectedItem;
                        c.Item.Source = txtNoteSource.Text;
                        c.Item.Notes = CurrentRecord.Item;

                        newComments.Add(c);
                        count++;
                    }
                }
            }
            return count;
        }

        private int CountSurveyComments()
        {
            int count = 0;
            newComments.Clear();
            foreach (Survey s in lstTargetSurvWave.Items)
                if (!DBAction.SurveyCommentExists(s, CurrentRecord.Item.ID))
                {
                    SurveyCommentRecord c = new SurveyCommentRecord();

                    c.NewRecord = true;
                    c.Item.Survey = s.SurveyCode;
                    c.Item.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.Item.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.Item.NoteDate = dtpNoteDate.Value;
                    c.Item.Authority = (Person)cboNoteAuthority.SelectedItem;
                    c.Item.Source = txtNoteSource.Text;
                    c.Item.Notes = CurrentRecord.Item;

                    newComments.Add(c);

                    count++;
                }
            return count;
        }

        private int CountWaveComments()
        {
            int count = 0;
            newComments.Clear();
            foreach (StudyWave w in lstTargetSurvWave.Items)
                if (!DBAction.WaveCommentExists(w, CurrentRecord.Item.ID))
                {
                    WaveCommentRecord c = new WaveCommentRecord();

                    c.NewRecord = true;
                    c.Item.StudyWave = w.WaveCode;
                    c.Item.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.Item.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.Item.NoteDate = dtpNoteDate.Value;
                    c.Item.Authority = (Person)cboNoteAuthority.SelectedItem;
                    c.Item.Source = txtNoteSource.Text;
                    c.Item.Notes = CurrentRecord.Item;

                    newComments.Add(c);

                    count++;
                }
            return count;
        }

        private int CountDeletedComments()
        {
            int count = 0;
            newComments.Clear();
            List<Survey> surveys = lstTargetSurvWave.Items.Cast<Survey>().ToList();
            List<RefVariableName> varnames = lstTargetVar.Items.Cast<RefVariableName>().ToList();

            for (int i = 0; i < surveys.Count; i++)
            {
                for (int j = 0; j < varnames.Count; j++)
                {
                    string fullVar = Utilities.ChangeCC(varnames[j].RefVarName, surveys[i].CountryCode);
                    DeletedQuestion sq = new DeletedQuestion();
                    sq.SurveyCode = surveys[i].SurveyCode;
                    sq.VarName = fullVar;
                    if (!DBAction.DeletedCommentExists(sq, CurrentRecord.Item.ID))
                    {
                        DeletedCommentRecord c = new DeletedCommentRecord();

                        c.NewRecord = true;
                        c.Item.Survey = surveys[i].SurveyCode;
                        c.Item.VarName = fullVar;
                        c.Item.Author = (Person)cboNoteAuthor.SelectedItem;
                        c.Item.NoteType = (CommentType)cboNoteType.SelectedItem;
                        c.Item.NoteDate = dtpNoteDate.Value;
                        c.Item.Authority = (Person)cboNoteAuthority.SelectedItem;
                        c.Item.Source = txtNoteSource.Text;
                        c.Item.Notes = CurrentRecord.Item;

                        newComments.Add(c);
                        count++;
                    }
                }
            }
            return count;
        }

        private int CountRefVarComments()
        {
            int count = 0;
            newComments.Clear();
            List<RefVariableName> varnames = lstTargetVar.Items.Cast<RefVariableName>().ToList();
            for (int j = 0; j < varnames.Count; j++)
            {
                if (!DBAction.RefVarCommentExists(varnames[j].RefVarName, CurrentRecord.Item.ID))
                {
                    RefVarCommentRecord c = new RefVarCommentRecord();

                    c.NewRecord = true;
                    c.Item.RefVarName = varnames[j].RefVarName;
                    c.Item.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.Item.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.Item.NoteDate = dtpNoteDate.Value;
                    c.Item.Authority = (Person)cboNoteAuthority.SelectedItem;
                    c.Item.Source = txtNoteSource.Text;
                    c.Item.Notes = CurrentRecord.Item;

                    newComments.Add(c);
                    count++;
                }

            }
            return count;
        }

        private void SaveComments()
        {
            switch (Scope)
            {
                case NoteScope.Variable:
                    {
                        List<QuestionCommentRecord> created = new List<QuestionCommentRecord>();
                        foreach (QuestionCommentRecord qc in newComments)
                        {
                            if (DBAction.InsertQuestionComment(qc.Item) == 1)
                                continue;

                            created.Add(qc);

                            QuestionComments.Add(qc);
                            
                            gridQuesComments.RowCount = QuestionComments.Count;
                            pageQuestion.Text = "Variable (" + QuestionComments.Count + ")";
                        }
                        CreatedComment?.Invoke(null, new QuestionCommentCreated() { comments = created });

                        break;
                    }
                case NoteScope.Survey:
                    {
                        foreach (SurveyCommentRecord sc in newComments)
                        {
                            if (DBAction.InsertSurveyComment(sc.Item) == 1)
                                continue;

                            SurveyComments.Add(sc);
                            
                            gridSurvComments.RowCount = SurveyComments.Count;
                            pageSurvey.Text = "Survey (" + SurveyComments.Count + ")";
                        }
                        break;
                    }
                case NoteScope.Wave:
                    {
                        foreach (WaveCommentRecord wc in newComments)
                        {
                            if (DBAction.InsertWaveComment(wc.Item) == 1)
                                continue;

                            WaveComments.Add(wc);
                           
                            gridWaveComments.RowCount = WaveComments.Count;
                            pageWave.Text = "Wave (" + WaveComments.Count + ")";
                        }
                        break;
                    }
                case NoteScope.Deleted:
                    {
                        foreach (DeletedCommentRecord dc in newComments)
                        {
                            if (DBAction.InsertDeletedComment(dc.Item) == 1)
                                continue;

                            DeletedComments.Add(dc);
                            
                            gridDeletedComments.RowCount = DeletedComments.Count;
                            pageDeleted.Text = "Deleted Vars (" + DeletedComments.Count + ")";
                        }
                        break;
                    }
                case NoteScope.RefVar:
                    {
                        foreach (RefVarCommentRecord rc in newComments)
                        {
                            if (DBAction.InsertRefVarComment(rc.Item) == 1)
                                continue;

                            RefVarComments.Add(rc);
                            
                            gridRefVarComments.RowCount = RefVarComments.Count;
                            pageRefVar.Text = "RefVar (" + RefVarComments.Count + ")";
                        }
                        break;
                    }
            }

            if (newComments.Count > 0)
            {
                DBAction.InsertLastUsedComment(Globals.CurrentUser, (Comment)newComments.First().Item);
                Globals.CurrentUser.LastUsedComment = newComments.First().Item;
            }

            UpdateCreationCount();
        }

        private Comment GetTopComment()
        {
            Comment c = new Comment();
            if (QuestionComments.Count > 0)
            {
                c.NoteType = QuestionComments[0].Item.NoteType;
                c.Author = QuestionComments[0].Item.Author;
                c.Source = QuestionComments[0].Item.Source;
                c.SourceName = QuestionComments[0].Item.SourceName;
            }
            else if (SurveyComments.Count > 0)
            {
                c.NoteType = SurveyComments[0].Item.NoteType;
                c.Author = SurveyComments[0].Item.Author;
                c.Source = SurveyComments[0].Item.Source;
                c.SourceName = SurveyComments[0].Item.SourceName;
            }
            else if (WaveComments.Count > 0)
            {
                c.NoteType = WaveComments[0].Item.NoteType;
                c.Author = WaveComments[0].Item.Author;
                c.Source = WaveComments[0].Item.Source;
                c.SourceName = WaveComments[0].Item.SourceName;
            }
            else if (RefVarComments.Count > 0)
            {
                c.NoteType = RefVarComments[0].Item.NoteType;
                c.Author = RefVarComments[0].Item.Author;
                c.Source = RefVarComments[0].Item.Source;
                c.SourceName = RefVarComments[0].Item.SourceName;
            }
            else if (DeletedComments.Count > 0)
            {
                c.NoteType = DeletedComments[0].Item.NoteType;
                c.Author = DeletedComments[0].Item.Author;
                c.Source = DeletedComments[0].Item.Source;
                c.SourceName = DeletedComments[0].Item.SourceName;
            }
            return c;
        }

        private void LastUsedComment(Comment comment)
        {
            if (comment.NoteDate == null)
                dtpNoteDate.Value = DateTime.Today;
            else
                dtpNoteDate.Value = comment.NoteDate.Value;

            cboNoteAuthor.SelectedItem = comment.Author;
            cboNoteType.SelectedItem = comment.NoteType;
            txtNoteSource.Text = comment.Source;

            cboNoteAuthority.SelectedIndex = cboNoteAuthority.FindString(comment.SourceName);
        }

        public void AssignedDetails(Comment comment)
        {
            if (comment.NoteDate == null)
                dtpNoteDate.Value = DateTime.Today;
            else
                dtpNoteDate.Value = comment.NoteDate.Value;

            cboNoteAuthor.SelectedItem = comment.Author;
            cboNoteType.SelectedItem = comment.NoteType;
            txtNoteSource.Text = comment.Source;

            if (cboNoteAuthority.Items.Contains(comment.SourceName))
                cboNoteAuthority.SelectedItem = comment.SourceName;
            else
                cboNoteAuthority.SelectedValue = 0;
        }

        public void NewComment()
        {
            dtpNoteDate.Value = DateTime.Today;
            cboNoteAuthor.SelectedValue = Globals.CurrentUser.userid;

            cboNoteType.SelectedItem = null;
            txtNoteSource.Text = string.Empty;
            cboNoteAuthority.SelectedValue = 0;
        }

        private void ToggleAutoDetails(int num)
        {
            chkAssignedDetails.CheckedChanged -= chkAssignedDetails_CheckedChanged;
            chkLastUsedDetails.CheckedChanged -= AutoDetails2_CheckedChanged;
            chkNewDetails.CheckedChanged -= AutoDetails3_CheckedChanged;

            switch (num)
            {
                case 1:
                    {
                        chkLastUsedDetails.Checked = false;
                        chkNewDetails.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chkAssignedDetails.Checked = false;
                        chkNewDetails.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chkAssignedDetails.Checked = false;
                        chkLastUsedDetails.Checked = false;
                        break;
                    }
            }

            chkAssignedDetails.CheckedChanged += chkAssignedDetails_CheckedChanged;
            chkLastUsedDetails.CheckedChanged += AutoDetails2_CheckedChanged;
            chkNewDetails.CheckedChanged += AutoDetails3_CheckedChanged;

        }

        // if details are to show, expand detail panel, and form to show it
        // if stored comments are to show, expand stored panel, and form to show it
        // move tab control panel accordingly
        private void ExpandForm()
        {
            bool details = chkAssignedDetails.Checked || chkLastUsedDetails.Checked || chkNewDetails.Checked;
            bool stored = chkStoredComments.Checked;

            panelDetails.Visible = details;
            panelStored.Visible = stored;

            if (details && stored)
            {
                panelDetails.Top = firstPanelTop;
                panelUses.Top = secondPanelTop;
                panelStored.Top = thirdPanelTop;

                this.Height = thirdPanelTop + 185 + navNotes.Height + 50;
            }
            else if (details && !stored)
            {
                panelDetails.Top = firstPanelTop;
                panelUses.Top = secondPanelTop;

                this.Height = secondPanelTop + 185 + navNotes.Height + 50;

            }
            else if (!details && stored)
            {
                panelUses.Top = firstPanelTop;
                panelStored.Top = secondPanelTop;

                this.Height = secondPanelTop + 185 + navNotes.Height + 50;
            }
            else if (!details && !stored)
            {
                panelUses.Top = firstPanelTop;

                this.Height = firstPanelTop + 185 + navNotes.Height + 50;
            }
        }

        public void UpdateForm(SurveyQuestion question)
        {
            lstTargetSurvWave.Items.Clear();
            lstTargetVar.Items.Clear();
            FillTargetQuestion(question);
            if (question.Comments.Count == 0)
            {
                AddNote();
                return;
            }
            else
            {
                lblNewID.Visible = false;
            }

            var commentIDs = question.Comments.Select(x => x.Notes.ID);
            bs.DataSource = Records.Where(x => commentIDs.Contains(x.Item.ID)).ToList();

            GoToComment(question.Comments[0].Notes.ID);
            CurrentRecord = (NoteRecord)bs.Current;
            LoadComments();

        }

        private void GoToComment(int cid)
        {
            int index = -1;
            if (Records.Any(x => x.Item.ID == cid))
            {
                foreach (NoteRecord n in Records)
                {
                    index++;
                    if (n.Item.ID == cid)
                        break;
                }
            }
            if (index > -1)
                bs.Position = index;
        }

        private void FillTargetQuestion(SurveyQuestion question)
        {
            AddSurvey(Globals.AllSurveys.Where(x => x.SurveyCode.Equals(question.SurveyCode)).FirstOrDefault());
            AddVar(question.VarName);
        }

        private void AddSurvey(Survey survey)
        {
            if (survey == null)
                return;

            if (!lstTargetSurvWave.Items.Contains(survey))
                lstTargetSurvWave.Items.Add(survey);
        }

        private void AddWave(StudyWave wave)
        {
            if (wave == null)
                return;

            if (!lstTargetSurvWave.Items.Contains(wave))
                lstTargetSurvWave.Items.Add(wave);
        }

        private void AddVar(RefVariableName variable)
        {
            if (variable == null)
                return;

            if (!lstTargetVar.Items.Contains(variable))
                lstTargetVar.Items.Add(variable);
        }

        #endregion

        #region Stored Comments
        private void repeaterStored_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboStoredName", false)[0];
            //Set the data source
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
            combo.DataSource = new List<Person>(Globals.AllPeople);

            var combo2 = (ComboBox)e.DataRepeaterItem.Controls.Find("cboStoredType", false)[0];
            //Set the data source
            combo2.DisplayMember = "TypeName";
            combo2.ValueMember = "ID";
            combo2.DataSource = new List<CommentType>(Globals.AllCommentTypes);

            var combo3 = (ComboBox)e.DataRepeaterItem.Controls.Find("cboStoredAuthority", false)[0];
            //Set the data source
            combo3.DisplayMember = "Name";
            combo3.ValueMember = "ID";
            combo3.DataSource = new List<Person>(Globals.AllPeople);
        }

        private void repeaterStored_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = ((BindingSource)dataRepeater.DataSource);
            var currentStored = ((Comment)datasource[e.DataRepeaterItem.ItemIndex]);

            var noteInit = (ComboBox)e.DataRepeaterItem.Controls.Find("cboStoredName", false)[0];
            var noteType = (ComboBox)e.DataRepeaterItem.Controls.Find("cboStoredType", false)[0];
            var noteAuthority = (ComboBox)e.DataRepeaterItem.Controls.Find("cboStoredAuthority", false)[0];
            var noteText = (TextBox)e.DataRepeaterItem.Controls.Find("txtStoredComment", false)[0];
            
            noteInit.SelectedItem = currentStored.Author;
            noteType.SelectedItem = currentStored.NoteType;
            noteAuthority.SelectedItem = currentStored.Authority;
            noteText.Text = currentStored.Notes.NoteText;

        }

        private void cboStoredName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<Comment>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].Author = (Person)combo.SelectedItem;

            
        }

        private void cboStoredType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<Comment>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].NoteType = (CommentType)combo.SelectedItem;

            
        }

        private void cboStoredAuthority_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<Comment>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].Authority = (Person)combo.SelectedItem;

            
        }

        private void repeaterStored_ItemTemplate_Leave(object sender, EventArgs e)
        {
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)sender;
            var source = (List<Comment>)((BindingSource)repeaterStored.DataSource).DataSource;
            Comment comment = source[dataRepeaterItem.ItemIndex];

            int index = dataRepeaterItem.ItemIndex + 1;
            if (DirtyStored)
                SaveStored(comment, index);
        }

        private void SaveStored(Comment storedComment, int index)
        {
            if (DBAction.UpdateStoredComment(Globals.CurrentUser.userid, storedComment, index) == 1)
            {
                MessageBox.Show("Error saving stored comment.");
                return;
            }
            Globals.CurrentUser.SavedComments[index-1] = storedComment;
            DirtyStored = false;
        }

        private void cmdUseStored_Click(object sender, EventArgs e)
        {
            var datasource = ((BindingSource)repeaterStored.DataSource);
            var currentStored = ((Comment)datasource[repeaterStored.CurrentItemIndex]);

            UseStoredComment(currentStored);
        }

        private void cmdDeleteStored_Click(object sender, EventArgs e)
        {
            var datasource = ((BindingSource)repeaterStored.DataSource);
            var currentStored = ((Comment)datasource[repeaterStored.CurrentItemIndex]);

            DeleteStoredComment(currentStored);
        }

        private void UseStoredComment(Comment comment)
        {
            FilterForNote(comment.Notes.NoteText);
            CurrentRecord = (NoteRecord)bs.Current;
            LoadComments();

            if (comment.NoteDate == null)
                dtpNoteDate.Value = DateTime.Today;
            else
                dtpNoteDate.Value = comment.NoteDate.Value;

            cboNoteAuthor.SelectedItem = comment.Author;
            cboNoteType.SelectedItem = comment.NoteType;
            txtNoteSource.Text = comment.Source;

            if (cboNoteAuthority.Items.Contains(comment.SourceName))
                cboNoteAuthority.SelectedItem = comment.SourceName;
            else
                cboNoteAuthority.SelectedValue = 0;
        }

        public void DeleteStoredComment(Comment comment)
        {
            var datasource = ((BindingSource)repeaterStored.DataSource);
            var currentStored = ((Comment)datasource[repeaterStored.CurrentItemIndex]);

            currentStored.NoteDate = DateTime.Today;
            currentStored.Author = new Person();
            currentStored.NoteType = new CommentType();
            currentStored.Source = string.Empty;
            currentStored.Authority = new Person();
            currentStored.Notes = new Note();

            bsStored.ResetBindings(false);
        }

        private void Stored_Validated(object sender, EventArgs e)
        {
            DirtyStored = true;
        }
        #endregion

        #region DataGridView events
        private void gridQuesComments_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedQuestionComment = new QuestionComment();
            this.questionCommentRow = this.gridQuesComments.Rows.Count - 1;
        }

        private void gridQuesComments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If the there are no items, no values are needed.
            if (QuestionComments.Count == 0) return;

            QuestionComment tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == questionCommentRow)
            {
                tmp = editedQuestionComment;
            }
            else
            {
                tmp = QuestionComments[e.RowIndex].Item;
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chQSurvey":
                    e.Value = tmp.Survey;
                    break;
                case "chQVarName":
                    e.Value = tmp.VarName;
                    break;
                case "chQDate":
                    e.Value = tmp.NoteDate;
                    break;
                case "chQName":
                    e.Value = tmp.Author.ID;
                    break;
                case "chQType":
                    e.Value = tmp.NoteType.ID;
                    break;
                case "chQSource":
                    e.Value = tmp.Source;
                    break;
                case "chQAuthority":
                    e.Value = tmp.Authority.ID;
                    break;
            }
        }

        private void gridQuesComments_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            QuestionComment tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < QuestionComments.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedQuestionComment == null)
                    editedQuestionComment = new QuestionComment()
                    {
                        ID = QuestionComments[e.RowIndex].Item.ID,
                        QID = QuestionComments[e.RowIndex].Item.QID,
                        Survey = QuestionComments[e.RowIndex].Item.Survey,
                        VarName = QuestionComments[e.RowIndex].Item.VarName,
                        NoteDate = QuestionComments[e.RowIndex].Item.NoteDate,
                        Author = QuestionComments[e.RowIndex].Item.Author,
                        NoteType = QuestionComments[e.RowIndex].Item.NoteType,
                        Notes = QuestionComments[e.RowIndex].Item.Notes,
                        Source = QuestionComments[e.RowIndex].Item.Source,
                        Authority = QuestionComments[e.RowIndex].Item.Authority
                    };

                tmp = this.editedQuestionComment;
                this.questionCommentRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedQuestionComment;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chQSurvey":
                case "chQVarName":
                    break;
                case "chQDate":
                    tmp.NoteDate = (DateTime)e.Value;
                    break;
                case "chQName":
                    // DataGridViewComboBoxCell nameCell = (DataGridViewComboBoxCell) dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    tmp.Author.ID = (int)e.Value;
                    // tmp.Author.Name = (string)nameCell.EditedFormattedValue;
                    break;
                case "chQType":
                    tmp.NoteType.ID = (int)e.Value;
                    break;
                case "chQSource":
                    tmp.Source = (string)e.Value;
                    break;
                case "chQAuthority":
                    tmp.Authority.ID = (int)e.Value;
                    break;
            }
        }

        private void gridQuesComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedQuestionComment != null && e.RowIndex >= QuestionComments.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                QuestionComments.Add(new QuestionCommentRecord(editedQuestionComment) { NewRecord = true });

                editedQuestionComment = null;
                questionCommentRow = -1;
            }
            else if (editedQuestionComment != null && e.RowIndex < QuestionComments.Count)
            {
                DBAction.UpdateQuestionComment(editedQuestionComment);
            }
            else if (dgv.ContainsFocus)
            {
                editedQuestionComment = null;
                questionCommentRow = -1;
            }
        }

        private void gridQuesComments_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void gridQuesComments_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (questionCommentRow == dgv.Rows.Count - 2 && questionCommentRow == QuestionComments.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedQuestionComment = new QuestionComment();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedQuestionComment = null;
                questionCommentRow = -1;
            }
        }

        private void gridQuesComments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.QuestionComments.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this question comment?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    QuestionComment record = QuestionComments[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove the corresponding object from the data store.
                    this.QuestionComments.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.questionCommentRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.questionCommentRow = -1;
                this.editedQuestionComment = null;
            }
        }

        private void gridQuesComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void gridSurvComments_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedSurveyComment = new SurveyComment();
            this.surveyCommentRow = this.gridSurvComments.Rows.Count - 1;
        }

        private void gridSurvComments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If the there are no items, no values are needed.
            if (SurveyComments.Count == 0) return;

            SurveyComment tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == surveyCommentRow)
            {
                tmp = editedSurveyComment;
            }
            else
            {
                tmp = SurveyComments[e.RowIndex].Item;
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSSurvey":
                    e.Value = tmp.Survey;
                    break;
                case "chSDate":
                    e.Value = tmp.NoteDate;
                    break;
                case "chSName":
                    e.Value = tmp.Author.ID;
                    break;
                case "chSType":
                    e.Value = tmp.NoteType.ID;
                    break;
                case "chSSource":
                    e.Value = tmp.Source;
                    break;
                case "chSAuthority":
                    e.Value = tmp.Authority.ID;
                    break;
            }
        }

        private void gridSurvComments_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SurveyComment tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < SurveyComments.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedSurveyComment == null)
                    editedSurveyComment = new SurveyComment()
                    {
                        ID = SurveyComments[e.RowIndex].Item.ID,
                        SurvID = SurveyComments[e.RowIndex].Item.SurvID,
                        Survey = SurveyComments[e.RowIndex].Item.Survey,
                        NoteDate = SurveyComments[e.RowIndex].Item.NoteDate,
                        Author = SurveyComments[e.RowIndex].Item.Author,
                        NoteType = SurveyComments[e.RowIndex].Item.NoteType,
                        Notes = SurveyComments[e.RowIndex].Item.Notes,
                        Source = SurveyComments[e.RowIndex].Item.Source,
                        Authority = SurveyComments[e.RowIndex].Item.Authority
                    };

                tmp = this.editedSurveyComment;
                this.surveyCommentRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedSurveyComment;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSSurvey":
                    break;
                case "chSDate":
                    tmp.NoteDate = (DateTime)e.Value;
                    break;
                case "chSName":
                    // DataGridViewComboBoxCell nameCell = (DataGridViewComboBoxCell) dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    tmp.Author.ID = (int)e.Value;
                    // tmp.Author.Name = (string)nameCell.EditedFormattedValue;
                    break;
                case "chSType":
                    tmp.NoteType.ID = (int)e.Value;
                    break;
                case "chSSource":
                    tmp.Source = (string)e.Value;
                    break;
                case "chSAuthority":
                    tmp.Authority.ID = (int)e.Value;
                    break;
            }
        }

        private void gridSurvComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedSurveyComment != null && e.RowIndex >= SurveyComments.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                SurveyComments.Add(new SurveyCommentRecord(editedSurveyComment) { NewRecord = true });

                editedSurveyComment = null;
                surveyCommentRow = -1;
            }
            else if (editedSurveyComment != null && e.RowIndex < SurveyComments.Count)
            {
                DBAction.UpdateSurveyComment(editedSurveyComment);
            }
            else if (dgv.ContainsFocus)
            {
                editedSurveyComment = null;
                surveyCommentRow = -1;
            }
        }

        private void gridSurvComments_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void gridSurvComments_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (surveyCommentRow == dgv.Rows.Count - 2 && surveyCommentRow == SurveyComments.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedSurveyComment = new SurveyComment();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedSurveyComment = null;
                surveyCommentRow = -1;
            }
        }

        private void gridSurvComments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.SurveyComments.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this survey comment?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SurveyComment record = SurveyComments[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove the corresponding object from the data store.
                    this.SurveyComments.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.surveyCommentRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.surveyCommentRow = -1;
                this.editedSurveyComment = null;
            }
        }

        private void gridSurvComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void gridWaveComments_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedWaveComment = new WaveComment();
            this.waveCommentRow = this.gridWaveComments.Rows.Count - 1;
        }

        private void gridWaveComments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If the there are no items, no values are needed.
            if (WaveComments.Count == 0) return;

            WaveComment tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == waveCommentRow)
            {
                tmp = editedWaveComment;
            }
            else
            {
                tmp = WaveComments[e.RowIndex].Item;
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chWave":
                    e.Value = tmp.StudyWave;
                    break;
                case "chWDate":
                    e.Value = tmp.NoteDate;
                    break;
                case "chWName":
                    e.Value = tmp.Author.ID;
                    break;
                case "chWType":
                    e.Value = tmp.NoteType.ID;
                    break;
                case "chWSource":
                    e.Value = tmp.Source;
                    break;
                case "chWAuthority":
                    e.Value = tmp.Authority.ID;
                    break;
            }
        }

        private void gridWaveComments_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            WaveComment tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < WaveComments.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedWaveComment == null)
                    editedWaveComment = new WaveComment()
                    {
                        ID = WaveComments[e.RowIndex].Item.ID,
                        WaveID = WaveComments[e.RowIndex].Item.WaveID,
                        StudyWave = WaveComments[e.RowIndex].Item.StudyWave,
                        NoteDate = WaveComments[e.RowIndex].Item.NoteDate,
                        Author = WaveComments[e.RowIndex].Item.Author,
                        NoteType = WaveComments[e.RowIndex].Item.NoteType,
                        Notes = WaveComments[e.RowIndex].Item.Notes,
                        Source = WaveComments[e.RowIndex].Item.Source,
                        Authority = WaveComments[e.RowIndex].Item.Authority
                    };

                tmp = this.editedWaveComment;
                this.waveCommentRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedWaveComment;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chWave":
                    break;
                case "cWDate":
                    tmp.NoteDate = (DateTime)e.Value;
                    break;
                case "chWName":
                    // DataGridViewComboBoxCell nameCell = (DataGridViewComboBoxCell) dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    tmp.Author.ID = (int)e.Value;
                    // tmp.Author.Name = (string)nameCell.EditedFormattedValue;
                    break;
                case "chWType":
                    tmp.NoteType.ID = (int)e.Value;
                    break;
                case "chWSource":
                    tmp.Source = (string)e.Value;
                    break;
                case "chWAuthority":
                    tmp.Authority.ID = (int)e.Value;
                    break;
            }
        }

        private void gridWaveComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedWaveComment != null && e.RowIndex >= WaveComments.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                WaveComments.Add(new WaveCommentRecord(editedWaveComment) { NewRecord = true });

                editedWaveComment = null;
                waveCommentRow = -1;
            }
            else if (editedWaveComment != null && e.RowIndex < WaveComments.Count)
            {
                DBAction.UpdateWaveComment(editedWaveComment);
            }
            else if (dgv.ContainsFocus)
            {
                editedWaveComment = null;
                waveCommentRow = -1;
            }
        }

        private void gridWaveComments_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void gridWaveComments_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (waveCommentRow == dgv.Rows.Count - 2 && waveCommentRow == WaveComments.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedWaveComment = new WaveComment();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedWaveComment = null;
                waveCommentRow = -1;
            }
        }

        private void gridWaveComments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.WaveComments.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this wave comment?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    WaveComment record = WaveComments[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove the corresponding object from the data store.
                    this.WaveComments.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.waveCommentRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.waveCommentRow = -1;
                this.editedWaveComment = null;
            }
        }

        private void gridWaveComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void gridRefVarComments_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedRefVarComment = new RefVarComment();
            this.refVarCommentRow = this.gridRefVarComments.Rows.Count - 1;
        }

        private void gridRefVarComments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If the there are no items, no values are needed.
            if (RefVarComments.Count == 0) return;

            RefVarComment tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == refVarCommentRow)
            {
                tmp = editedRefVarComment;
            }
            else
            {
                tmp = RefVarComments[e.RowIndex].Item;
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chRefVar":
                    e.Value = tmp.RefVarName;
                    break;
                case "chRDate":
                    e.Value = tmp.NoteDate;
                    break;
                case "chRName":
                    e.Value = tmp.Author.ID;
                    break;
                case "chRType":
                    e.Value = tmp.NoteType.ID;
                    break;
                case "chRSource":
                    e.Value = tmp.Source;
                    break;
                case "chRAuthority":
                    e.Value = tmp.Authority.ID;
                    break;
            }
        }

        private void gridRefVarComments_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            RefVarComment tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < RefVarComments.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedRefVarComment == null)
                    editedRefVarComment = new RefVarComment()
                    {
                        ID = RefVarComments[e.RowIndex].Item.ID,
                        RefVarName = RefVarComments[e.RowIndex].Item.RefVarName,
                        NoteDate = RefVarComments[e.RowIndex].Item.NoteDate,
                        Author = RefVarComments[e.RowIndex].Item.Author,
                        NoteType = RefVarComments[e.RowIndex].Item.NoteType,
                        Notes = RefVarComments[e.RowIndex].Item.Notes,
                        Source = RefVarComments[e.RowIndex].Item.Source,
                        Authority = RefVarComments[e.RowIndex].Item.Authority
                    };

                tmp = this.editedRefVarComment;
                this.refVarCommentRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedRefVarComment;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chRefVar":
                    break;
                case "cRDate":
                    tmp.NoteDate = (DateTime)e.Value;
                    break;
                case "chRName":
                    // DataGridViewComboBoxCell nameCell = (DataGridViewComboBoxCell) dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    tmp.Author.ID = (int)e.Value;
                    // tmp.Author.Name = (string)nameCell.EditedFormattedValue;
                    break;
                case "chRType":
                    tmp.NoteType.ID = (int)e.Value;
                    break;
                case "chRSource":
                    tmp.Source = (string)e.Value;
                    break;
                case "chRAuthority":
                    tmp.Authority.ID = (int)e.Value;
                    break;
            }
        }

        private void gridRefVarComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedRefVarComment != null && e.RowIndex >= RefVarComments.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                RefVarComments.Add(new RefVarCommentRecord(editedRefVarComment) { NewRecord = true });

                editedRefVarComment = null;
                refVarCommentRow = -1;
            }
            else if (editedRefVarComment != null && e.RowIndex < RefVarComments.Count)
            {
                DBAction.UpdateRefVarComment(editedRefVarComment);
            }
            else if (dgv.ContainsFocus)
            {
                editedRefVarComment = null;
                refVarCommentRow = -1;
            }
        }

        private void gridRefVarComments_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void gridRefVarComments_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (refVarCommentRow == dgv.Rows.Count - 2 && refVarCommentRow == RefVarComments.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedRefVarComment = new RefVarComment();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedRefVarComment = null;
                refVarCommentRow = -1;
            }
        }

        private void gridRefVarComments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.RefVarComments.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this refVarName comment?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RefVarComment record = RefVarComments[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove the corresponding object from the data store.
                    this.RefVarComments.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.refVarCommentRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.refVarCommentRow = -1;
                this.editedRefVarComment = null;
            }
        }

        private void gridRefVarComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void gridDeletedComments_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedDeletedComment = new DeletedComment();
            this.deletedCommentRow = this.gridDeletedComments.Rows.Count - 1;
        }

        private void gridDeletedComments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If the there are no items, no values are needed.
            if (DeletedComments.Count == 0) return;

            DeletedComment tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == deletedCommentRow)
            {
                tmp = editedDeletedComment;
            }
            else
            {
                tmp = DeletedComments[e.RowIndex].Item;
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chDSurvey":
                    e.Value = tmp.Survey;
                    break;
                case "chDVarName":
                    e.Value = tmp.VarName;
                    break;
                case "chDDate":
                    e.Value = tmp.NoteDate;
                    break;
                case "chDName":
                    e.Value = tmp.Author.ID;
                    break;
                case "chDType":
                    e.Value = tmp.NoteType.ID;
                    break;
                case "chDSource":
                    e.Value = tmp.Source;
                    break;
                case "chDAuthority":
                    e.Value = tmp.Authority.ID;
                    break;
            }
        }

        private void gridDeletedComments_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            DeletedComment tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < DeletedComments.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedDeletedComment == null)
                    editedDeletedComment = new DeletedComment()
                    {
                        ID = DeletedComments[e.RowIndex].Item.ID,
                        Survey = DeletedComments[e.RowIndex].Item.Survey,
                        VarName = DeletedComments[e.RowIndex].Item.VarName,
                        NoteDate = DeletedComments[e.RowIndex].Item.NoteDate,
                        Author = DeletedComments[e.RowIndex].Item.Author,
                        NoteType = DeletedComments[e.RowIndex].Item.NoteType,
                        Notes = DeletedComments[e.RowIndex].Item.Notes,
                        Source = DeletedComments[e.RowIndex].Item.Source,
                        Authority = DeletedComments[e.RowIndex].Item.Authority
                    };

                tmp = this.editedDeletedComment;
                this.deletedCommentRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedDeletedComment;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSurvey":
                case "chVarName":
                    break;
                case "cDDate":
                    tmp.NoteDate = (DateTime)e.Value;
                    break;
                case "chDName":
                    // DataGridViewComboBoxCell nameCell = (DataGridViewComboBoxCell) dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    tmp.Author.ID = (int)e.Value;
                    // tmp.Author.Name = (string)nameCell.EditedFormattedValue;
                    break;
                case "chDType":
                    tmp.NoteType.ID = (int)e.Value;
                    break;
                case "chDSource":
                    tmp.Source = (string)e.Value;
                    break;
                case "chDAuthority":
                    tmp.Authority.ID = (int)e.Value;
                    break;
            }
        }

        private void gridDeletedComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedDeletedComment != null && e.RowIndex >= DeletedComments.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                DeletedComments.Add(new DeletedCommentRecord(editedDeletedComment) { NewRecord = true });

                editedDeletedComment = null;
                deletedCommentRow = -1;
            }
            else if (editedDeletedComment != null && e.RowIndex < DeletedComments.Count)
            {
                DBAction.UpdateDeletedQuestionComment(editedDeletedComment);
            }
            else if (dgv.ContainsFocus)
            {
                editedDeletedComment = null;
                deletedCommentRow = -1;
            }
        }

        private void gridDeletedComments_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void gridDeletedComments_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (deletedCommentRow == dgv.Rows.Count - 2 && deletedCommentRow == RefVarComments.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedDeletedComment = new DeletedComment();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedDeletedComment = null;
                deletedCommentRow = -1;
            }
        }

        private void gridDeletedComments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.DeletedComments.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this deleted question comment?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeletedComment record = DeletedComments[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove the corresponding object from the data store.
                    this.DeletedComments.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.deletedCommentRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.deletedCommentRow = -1;
                this.editedDeletedComment = null;
            }
        }

        private void gridDeletedComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion
    }
}
