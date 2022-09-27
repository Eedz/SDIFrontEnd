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

namespace SDIFrontEnd
{
    // TODO editing existing comments
    // TODO test adding all comment types
    // TODO add series comment
    /// <summary>
    /// Entry point for comments. 
    /// </summary>
    public partial class CommentEntry : Form
    {
        #region Properties
        List<NoteRecord> Notes;
        List<NoteRecord> FilteredNotes;

        NoteRecord CurrentNote;
        BindingSource bs;
        BindingSource bsStored;

        BindingSource bsQues;
        List<QuestionCommentRecord> QuestionComments;
        BindingSource bsSurv;
        List<SurveyCommentRecord> SurveyComments;
        BindingSource bsWave;
        List<WaveCommentRecord> WaveComments;
        BindingSource bsDel;
        List<DeletedCommentRecord> DeletedComments;
        BindingSource bsRef;
        List<RefVarCommentRecord> RefVarComments;

        NoteScope Scope;

        List<dynamic> newComments;

        int firstPanelTop = 260;
        int secondPanelTop = 450;
        int thirdPanelTop = 642;

        private bool DirtyStored;

        public event EventHandler<QuestionCommentCreated> CreatedComment;

        #endregion

        #region Constructors

        public CommentEntry()
        {
            InitializeComponent();


            Notes = Globals.AllNotes;
            FilteredNotes = new List<NoteRecord>();
            newComments = new List<dynamic>();
            this.MouseWheel += CommentEntry_MouseWheel;
            txtNoteText.MouseWheel += CommentEntry_MouseWheel;

            bs = new BindingSource
            {
                DataSource = Notes
            };

            bs.PositionChanged += BindingSource_PositionChanged;
            bs.ListChanged += Bs_ListChanged;

            CurrentNote = (NoteRecord)bs.Current;

            bsStored = new BindingSource();
            bsStored.DataSource = Globals.CurrentUser.SavedComments;

            repeaterStored.DataSource = bsStored;

            navNotes.BindingSource = bs;

            gridQuesComments.AutoGenerateColumns = false;
            gridSurvComments.AutoGenerateColumns = false;
            gridWaveComments.AutoGenerateColumns = false;
            gridRefVarComments.AutoGenerateColumns = false;
            gridDeletedComments.AutoGenerateColumns = false;

            FillBoxes();

            BindProperties();

            // load the comment uses
            LoadComments();

            chkNewDetails.Checked = true;
        }

        public CommentEntry(int cid) :this()
        {
            GoToComment(cid);           
        }

        public CommentEntry(SurveyQuestion question) : this()
        {
            FillTargetQuestion(question);
            UpdateCreationCount();

            if (question.Comments.Count == 0)
                return;

            foreach (Comment c in question.Comments)
            {
                NoteRecord n = new NoteRecord() { ID = c.Notes.ID, NoteText = c.Notes.NoteText };
                FilteredNotes.Add(n);
            }
            bs.DataSource = FilteredNotes;
        }

        public CommentEntry(NoteScope scope, List<QuestionRecord> questions) : this()
        {
            Scope = scope;
            
            FillTargetSurveyList();
            ToggleTargetVarNameList();
            UpdateCreationCount();
            foreach (SurveyQuestion q in questions)
                FillTargetQuestion(q);            
            
        }
        #endregion

        #region Event Handlers
        private void CommentEntry_Load(object sender, EventArgs e)
        {
            CurrentNote = (NoteRecord)bs.Current;

            

            ExpandForm();
        }

        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            CurrentNote = (NoteRecord)bs.Current;

            lblNewID.Visible = !(CurrentNote.ID > 0);
            
            LoadComments();
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.NewIndex == -1) return;
            if (e.NewIndex >= bs.Count) return;
            if (e.ListChangedType == ListChangedType.ItemDeleted) return;

            ((NoteRecord)bs[e.NewIndex]).Dirty = true;
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
            UpdateVars();
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
        #endregion



        #region Methods

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "ID");
            txtNoteText.DataBindings.Add("Text", bs, "NoteText");

            dtpStoredDate.DataBindings.Add("Value", bsStored, "NoteDate", true);

            txtStoredSource.DataBindings.Add("Text", bsStored, "Source");

            // question comment grid
            bsQues = new BindingSource();
            bsQues.DataSource = QuestionComments;
            chQVarName.DataPropertyName = "VarName";
            chQSurvey.DataPropertyName = "Survey";
            chQDate.DataPropertyName = "NoteDate";
            chQSource.DataPropertyName = "Source";
            chQAuthority.DataPropertyName = "SourceName";

            // survey comment grid
            bsSurv = new BindingSource();
            bsSurv.DataSource = SurveyComments;
            chSSurvey.DataPropertyName = "Survey";
            chSDate.DataPropertyName = "NoteDate";
            chSSource.DataPropertyName = "Source";
            chSAuthority.DataPropertyName = "SourceName";

            // wave comment grid
            bsWave = new BindingSource();
            bsWave.DataSource = WaveComments;
            chWWave.DataPropertyName = "StudyWave";
            chWDate.DataPropertyName = "NoteDate";
            chWSource.DataPropertyName = "Source";
            chWAuthority.DataPropertyName = "SourceName";

            // refvar comment grid
            bsRef = new BindingSource();
            bsRef.DataSource = RefVarComments;
            chRVarName.DataPropertyName = "RefVarName";
            chRDate.DataPropertyName = "NoteDate";
            chRSource.DataPropertyName = "Source";
            chRAuthority.DataPropertyName = "SourceName";

            // deleted comment grid
            bsDel = new BindingSource();
            bsDel.DataSource = DeletedComments;
            chDVarName.DataPropertyName = "VarName";
            chDSurvey.DataPropertyName = "Survey";
            chDDate.DataPropertyName = "NoteDate";
            chDSource.DataPropertyName = "Source";
            chDAuthority.DataPropertyName = "SourceName";
        }

        private void LoadComments()
        {
            QuestionComments = DBAction.GetQuesCommentsByCID(CurrentNote.ID);
            gridQuesComments.DataSource = QuestionComments;
            pageQuestion.Text = "Variable (" + QuestionComments.Count + ")";

            SurveyComments = DBAction.GetSurvCommentsByCID(CurrentNote.ID);
            gridSurvComments.DataSource = SurveyComments;
            pageSurvey.Text = "Survey (" + SurveyComments.Count + ")";

            WaveComments = DBAction.GetWaveCommentsByCID(CurrentNote.ID);
            gridWaveComments.DataSource = WaveComments;
            pageWave.Text = "Wave (" + WaveComments.Count + ")";

            RefVarComments = DBAction.GetRefVarCommentsByCID(CurrentNote.ID);
            gridRefVarComments.DataSource = RefVarComments;
            pageRefVar.Text = "RefVar (" + RefVarComments.Count + ")";

            DeletedComments = DBAction.GetDeletedCommentsByCID(CurrentNote.ID);
            gridDeletedComments.DataSource = DeletedComments;
            pageDeleted.Text = "Deleted Vars (" + DeletedComments.Count + ")";

           
        }

        private void FillBoxes()
        {

            // entry section
            var scopes = new List<KeyValuePair<int, string>>();
            foreach (NoteScope s in Enum.GetValues(typeof(NoteScope)))
                scopes.Add(new KeyValuePair<int, string>((int)s, s.ToString()));

            cboCommentScope.DataSource = scopes;
            cboCommentScope.DisplayMember = "Value";
            cboCommentScope.ValueMember = "Key";

            cboNoteType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            cboNoteType.DisplayMember = "TypeName";
            cboNoteType.ValueMember = "TypeName";

            cboNoteAuthor.DataSource = new List<Person>(Globals.AllPeople);
            cboNoteAuthor.DisplayMember = "Name";
            cboNoteAuthor.ValueMember = "ID";

            cboNoteAuthority.DataSource = new List<Person>(Globals.AllPeople);
            cboNoteAuthority.ValueMember = "ID";
            cboNoteAuthority.DisplayMember = "Name";

            lstTargetSurvWave.DisplayMember = "SurveyCode";
            cboVarNameList.DataSource = new List<RefVariableName>(Globals.AllRefVarNames);
            cboVarNameList.DisplayMember = "RefVarName";
            lstTargetVar.DisplayMember = "RefVarName";

            FillTargetSurveyList();

            // grid views

            chQName.DataSource = new List<Person>(Globals.AllPeople);
            chQName.ValueMember = "ID";
            chQName.DisplayMember = "Name";
            chQName.DataPropertyName = "Author";

            chQType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            chQType.ValueMember = "TypeName";
            chQType.DisplayMember = "TypeName";
            chQType.DataPropertyName = "NoteType";

            chSName.DataSource = new List<Person>(Globals.AllPeople);
            chSName.ValueMember = "ID";
            chSName.DisplayMember = "Name";
            chSName.DataPropertyName = "Author";

            chSType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            chSType.ValueMember = "TypeName";
            chSType.DisplayMember = "TypeName";
            chSType.DataPropertyName = "NoteType";

            chWName.DataSource = new List<Person>(Globals.AllPeople);
            chWName.ValueMember = "ID";
            chWName.DisplayMember = "Name";
            chWName.DataPropertyName = "Author";

            chWType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            chWType.ValueMember = "TypeName";
            chWType.DisplayMember = "TypeName";
            chWType.DataPropertyName = "NoteType";

            chRName.DataSource = new List<Person>(Globals.AllPeople);
            chRName.ValueMember = "ID";
            chRName.DisplayMember = "Name";
            chRName.DataPropertyName = "Author";

            chRType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            chRType.ValueMember = "TypeName";
            chRType.DisplayMember = "TypeName";
            chRType.DataPropertyName = "NoteType";

            chDName.DataSource = new List<Person>(Globals.AllPeople);
            chDName.ValueMember = "ID";
            chDName.DisplayMember = "Name";
            chDName.DataPropertyName = "Author";

            chDType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            chDType.ValueMember = "TypeName";
            chDType.DisplayMember = "TypeName";
            chDType.DataPropertyName = "NoteType";
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

                cboSurvWaveList.DataSource = Globals.AllWaves;
                cboSurvWaveList.DisplayMember = "WaveCode";
                cboSurvWaveList.ValueMember = "ID";

            }
            else
            {
                cboSurvWaveList.DataSource = Globals.AllSurveys;
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
            lblNewID.Left = txtID.Left;
            lblNewID.Top = txtID.Top;
            lblNewID.Visible = true;

            bs.DataSource = Notes;
            CurrentNote = (NoteRecord)bs.AddNew();
            CurrentNote.NewRecord = true;
        }

        private void DeleteNote()
        {
            bs.EndEdit();

            if (MessageBox.Show("Are you sure you want to delete this comment and all of its uses?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (DBAction.DeleteNote(CurrentNote.ID) == 1)
            {
                MessageBox.Show("Error deleting note.");
            }
            else
            {
                Globals.AllNotes.Remove(CurrentNote);
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
            var foundNotes = Notes.Where (x => x.NoteText.Contains(searchCriteria)).ToList();

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
            if (string.IsNullOrEmpty(n.NoteText) && n.NewRecord)
                return true;
            else
                return false;
        }
        #endregion

        #region Navigation Bar
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveNote() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveNote() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveNote() == 1)
                return;

            bs.MoveFirst();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveNote() == 1)
                return;

            bs.MoveLast();
        }
        #endregion

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

        private int SaveNote()
        {
            if (CurrentNote.ID == 0 && string.IsNullOrEmpty(CurrentNote.NoteText))
            {
                bs.RemoveCurrent();
                return 0;
            }
             

                if (CurrentNote.SaveRecord() == 1)
            {
                
                MessageBox.Show("Unable to save note.");
                return 1;
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
                    if (DBAction.GetQuestionID(sq.SurveyCode, sq.VarName.VarName) != 0 && !DBAction.QuestionCommentExists(sq, CurrentNote.ID))
                    {
                        QuestionCommentRecord c = new QuestionCommentRecord();

                        c.NewRecord = true;
                        c.Survey = surveys[i].SurveyCode;
                        c.VarName = fullVar;
                        c.Author = (Person)cboNoteAuthor.SelectedItem;
                        
                        c.NoteType = (CommentType)cboNoteType.SelectedItem;

                        c.NoteDate = dtpNoteDate.Value;
                        c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                        c.Authority = (Person)cboNoteAuthority.SelectedItem;
                        if (c.SourceName == null)
                            c.SourceName = "";

                        c.Source = txtNoteSource.Text;
                        c.Notes = CurrentNote;

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
                if (!DBAction.SurveyCommentExists(s, CurrentNote.ID))
                {
                    SurveyCommentRecord c = new SurveyCommentRecord();

                    c.NewRecord = true;
                    c.Survey = s.SurveyCode;
                    c.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.NoteDate = dtpNoteDate.Value;
                    c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                    if (c.SourceName == null)
                        c.SourceName = "";
                    c.Authority = (Person)cboNoteAuthority.SelectedItem;
                    c.Source = txtNoteSource.Text;
                    c.Notes = CurrentNote;

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
                if (!DBAction.WaveCommentExists(w, CurrentNote.ID))
                {
                    WaveCommentRecord c = new WaveCommentRecord();

                    c.NewRecord = true;
                    c.StudyWave = w.WaveCode;
                    c.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.NoteDate = dtpNoteDate.Value;
                    c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                    if (c.SourceName == null)
                        c.SourceName = "";
                    c.Authority = (Person)cboNoteAuthority.SelectedItem;
                    c.Source = txtNoteSource.Text;
                    c.Notes = CurrentNote;

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
                    if (!DBAction.DeletedCommentExists(sq, CurrentNote.ID))
                    {
                        DeletedCommentRecord c = new DeletedCommentRecord();

                        c.NewRecord = true;
                        c.Survey = surveys[i].SurveyCode;
                        c.VarName = fullVar;
                        c.Author = (Person)cboNoteAuthor.SelectedItem;
                        c.NoteType = (CommentType)cboNoteType.SelectedItem;
                        c.NoteDate = dtpNoteDate.Value;
                        c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                        if (c.SourceName == null)
                            c.SourceName = "";
                        c.Authority = (Person)cboNoteAuthority.SelectedItem;
                        c.Source = txtNoteSource.Text;
                        c.Notes = CurrentNote;

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
                if (!DBAction.RefVarCommentExists(varnames[j].RefVarName, CurrentNote.ID))
                {
                    RefVarCommentRecord c = new RefVarCommentRecord();

                    c.NewRecord = true;
                    c.RefVarName = varnames[j].RefVarName;
                    c.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.NoteDate = dtpNoteDate.Value;
                    c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                    if (c.SourceName == null)
                        c.SourceName = "";
                    c.Authority = (Person)cboNoteAuthority.SelectedItem;
                    c.Source = txtNoteSource.Text;
                    c.Notes = CurrentNote;

                    newComments.Add(c);
                    count++;
                }
                    
            }
            return count;
        }

        private void SaveComments()
        {
            switch(Scope)
            {
                case NoteScope.Variable:
                    {
                        List<QuestionCommentRecord> created = new List<QuestionCommentRecord>();
                        foreach (QuestionCommentRecord qc in newComments)
                        {
                            if (DBAction.InsertQuestionComment(qc) == 1)
                                continue;

                            created.Add(qc);

                            QuestionComments.Add(qc);
                            gridQuesComments.DataSource = null;
                            gridQuesComments.DataSource = QuestionComments;
                            pageQuestion.Text = "Variable (" + QuestionComments.Count + ")";
                        }
                        CreatedComment?.Invoke(null, new QuestionCommentCreated() { comments = created });

                        break;
                    }
                case NoteScope.Survey:
                    {
                        foreach (SurveyCommentRecord sc in newComments)
                        {
                            if (DBAction.InsertSurveyComment(sc) == 1)
                                continue;

                            SurveyComments.Add(sc);
                            gridSurvComments.DataSource = null;
                            gridSurvComments.DataSource = SurveyComments;
                            pageSurvey.Text = "Survey (" + SurveyComments.Count + ")";
                        }
                        break;
                    }
                case NoteScope.Wave:
                    {
                        foreach (WaveCommentRecord wc in newComments)
                        {
                            if (DBAction.InsertWaveComment(wc) == 1)
                                continue;

                            WaveComments.Add(wc);
                            gridWaveComments.DataSource = null;
                            gridWaveComments.DataSource = WaveComments;
                            pageWave.Text = "Wave (" + WaveComments.Count + ")";
                        }
                        break;
                    }
                case NoteScope.Deleted:
                    {
                        foreach (DeletedCommentRecord dc in newComments)
                        {
                            if (DBAction.InsertDeletedComment(dc) == 1)
                                continue;

                            DeletedComments.Add(dc);
                            gridDeletedComments.DataSource = null;
                            gridDeletedComments.DataSource = DeletedComments;
                            pageDeleted.Text = "Deleted Vars (" + DeletedComments.Count + ")";
                        }
                        break;
                    }
                case NoteScope.RefVar:
                    {
                        foreach (RefVarCommentRecord rc in newComments)
                        {
                            if (DBAction.InsertRefVarComment(rc) == 1)
                                continue;

                            RefVarComments.Add(rc);
                            gridRefVarComments.DataSource = null;
                            gridRefVarComments.DataSource = RefVarComments;
                            pageRefVar.Text = "RefVar (" + RefVarComments.Count + ")";
                        }
                        break;
                    }
            }

            UpdateCreationCount();
        }

        #region Grid View formatting
        private void gridQuesComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridSurvComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridWaveComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridRefVarComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridDeletedComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

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
            //newStored.CID = CurrentNote.ID;
            newStored.Notes = CurrentNote;
            newStored.NoteDate = dtpNoteDate.Value;
            newStored.NoteType = (CommentType)cboNoteType.SelectedItem;
            newStored.Author = (Person)cboNoteAuthor.SelectedItem;
            newStored.Authority = (Person)cboNoteAuthority.SelectedItem;
            newStored.Source = txtNoteSource.Text;

            SaveStored(newStored, 1);
            bsStored.ResetBindings(false);
        }

        private Comment GetTopComment()
        {
            Comment c = new Comment();
            if (QuestionComments.Count>0)
            {                
                c.NoteType = QuestionComments[0].NoteType;
                c.Author = QuestionComments[0].Author;
                c.Source = QuestionComments[0].Source;
                c.SourceName = QuestionComments[0].SourceName;
            }
            else if (SurveyComments.Count > 0)
            {
                c.NoteType = SurveyComments[0].NoteType;
                c.Author = SurveyComments[0].Author;
                c.Source = SurveyComments[0].Source;
                c.SourceName = SurveyComments[0].SourceName;
            }
            else if (WaveComments.Count > 0)
            {
                c.NoteType = WaveComments[0].NoteType;
                c.Author = WaveComments[0].Author;
                c.Source = WaveComments[0].Source;
                c.SourceName = WaveComments[0].SourceName;
            }
            else if (RefVarComments.Count > 0)
            {
                c.NoteType = RefVarComments[0].NoteType;
                c.Author = RefVarComments[0].Author;
                c.Source = RefVarComments[0].Source;
                c.SourceName = RefVarComments[0].SourceName;
            }
            else if (DeletedComments.Count > 0)
            {
                c.NoteType = DeletedComments[0].NoteType;
                c.Author = DeletedComments[0].Author;
                c.Source = DeletedComments[0].Source;
                c.SourceName = DeletedComments[0].SourceName;
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

            if (cboNoteAuthority.Items.Contains(comment.SourceName))
                cboNoteAuthority.SelectedItem = comment.SourceName;
            else
                cboNoteAuthority.SelectedValue = 0;
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

            FilteredNotes.Clear();
            foreach (Comment c in question.Comments)
            {
                NoteRecord n = new NoteRecord() { ID = c.Notes.ID, NoteText = c.Notes.NoteText };
                FilteredNotes.Add(n);
            }
            bs.DataSource = FilteredNotes;

            GoToComment(question.Comments[0].Notes.ID);
            


        }

        private void GoToComment(int cid)
        {
            int index = -1;
            if (Notes.Any(x => x.ID == cid))
            {
                foreach (Note n in Notes)
                {
                    index++;
                    if (n.ID == cid)
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

        private void UpdateVars()
        { 

        }

        

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
            CurrentNote = (NoteRecord)bs.Current;
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

        private void CommentEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Modal)
                FormManager.Remove(this);
        }


        #region Unused
        private void CreateQuestionComments()
        {
            List<Survey> surveys = lstTargetSurvWave.Items.Cast<Survey>().ToList();
            List<string> varnames = lstTargetVar.Items.Cast<VariableName>().Select(x => x.VarName).ToList();

            for (int i = 0; i < surveys.Count; i++)
            {
                for (int j = 0; j < varnames.Count; j++)
                {
                    QuestionComment c = new QuestionComment();

                    c.Survey = surveys[i].SurveyCode;
                    c.VarName = Utilities.ChangeCC(varnames[j], surveys[i].CountryCode);
                    c.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.NoteDate = dtpNoteDate.Value;
                    c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                    if (c.SourceName == null)
                        c.SourceName = "";

                    c.Source = txtNoteSource.Text;
                    c.Notes = CurrentNote;

                    newComments.Add(c);
                }
            }
        }

        private void CreateSurveyComments()
        {
            List<string> surveys = lstTargetSurvWave.Items.Cast<Survey>().Select(x => x.SurveyCode).ToList();

            for (int i = 0; i < surveys.Count; i++)
            {
                SurveyComment c = new SurveyComment();

                c.Survey = surveys[i];
                c.Author = (Person)cboNoteAuthor.SelectedItem;
                c.NoteType = (CommentType)cboNoteType.SelectedItem;
                c.NoteDate = dtpNoteDate.Value;
                c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                if (c.SourceName == null)
                    c.SourceName = "";

                c.Source = txtNoteSource.Text;
                c.Notes = CurrentNote;

                newComments.Add(c);
            }
        }

        private void CreateWaveComments()
        {
            List<string> waves = lstTargetSurvWave.Items.Cast<StudyWave>().Select(x => x.WaveCode).ToList();

            for (int i = 0; i < waves.Count; i++)
            {
                WaveComment c = new WaveComment();

                c.StudyWave = waves[i];
                c.Author = (Person)cboNoteAuthor.SelectedItem;
                c.NoteType = (CommentType)cboNoteType.SelectedItem;
                c.NoteDate = dtpNoteDate.Value;
                c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                if (c.SourceName == null)
                    c.SourceName = "";
                c.Source = txtNoteSource.Text;
                c.Notes = CurrentNote;

                newComments.Add(c);
            }
        }

        private void CreateDeletedComments()
        {
            List<string> surveys = lstTargetSurvWave.Items.Cast<Survey>().Select(x => x.SurveyCode).ToList();
            List<string> varnames = lstTargetVar.Items.Cast<VariableName>().Select(x => x.VarName).ToList();

            for (int i = 0; i < surveys.Count; i++)
            {
                for (int j = 0; j < varnames.Count; j++)
                {
                    DeletedComment c = new DeletedComment();

                    c.Survey = surveys[i];
                    c.VarName = varnames[j];
                    c.Author = (Person)cboNoteAuthor.SelectedItem;
                    c.NoteType = (CommentType)cboNoteType.SelectedItem;
                    c.NoteDate = dtpNoteDate.Value;
                    c.SourceName = ((Person)cboNoteAuthority.SelectedItem).Name;
                    if (c.SourceName == null)
                        c.SourceName = "";
                    c.Source = txtNoteSource.Text;
                    c.Notes = CurrentNote;

                    newComments.Add(c);
                }
            }
        }

        #endregion

        
    }

    
}
