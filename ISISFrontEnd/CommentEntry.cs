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

namespace ISISFrontEnd
{
    /// <summary>
    /// Entry point for comments. 
    /// </summary>
    public partial class CommentEntry : Form
    {
        #region Properties
        SurveyEntry frmParentSE;
        BindingList<Note> Notes;
        Note CurrentNote;
        BindingSource bs;

        BindingList<QuestionComment> QuestionComments;
        BindingList<SurveyComment> SurveyComments;
        BindingList<WaveComment> WaveComments;
        BindingList<Comment> DeletedComments;
        BindingList<Comment> RefVarComments;

        private bool _dirty;
        private bool Dirty
        {
            get
            {
                return _dirty;
            }
            set
            {
                _dirty = value;
                if (_dirty)
                    lblTitle.Text = "Comment Usage*";
                else
                    lblTitle.Text = "Comment Usage";
            }
        }

        private bool NewRecord { get; set; }
        #endregion

        #region Constructors
        public CommentEntry()
        {
            InitializeComponent();

            Notes = new BindingList<Note>(DBAction.GetNotes());

            this.MouseWheel += CommentEntry_MouseWheel;
            txtNoteText.MouseWheel += CommentEntry_MouseWheel;

            bs = new BindingSource
            {
                DataSource = Notes
            };

            bs.PositionChanged += BindingSource_PositionChanged;
            bs.CurrentItemChanged += Bs_CurrentItemChanged;

            bs.ListChanged += Bs_ListChanged; 

            navNotes.BindingSource = bs;

            BindProperties();
        }
        #endregion

        #region Event Handlers
        private void CommentEntry_Load(object sender, EventArgs e)
        {
            CurrentNote = (Note)bs.Current;

           


            // load the comments
            LoadComments();

            // add combo boxes to datagrid view
        }

        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            CurrentNote = (Note)bs.Current;
            LoadComments();


        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            Dirty = true;
        }

        private void Bs_CurrentItemChanged(object sender, EventArgs e)
        {
            
        }

        private void CommentEntry_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }
        #endregion

        #region Methods

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "ID");
            txtNoteText.DataBindings.Add("Text", bs, "NoteText");
        }

        private void LoadComments()
        {
            QuestionComments = new BindingList<QuestionComment> (DBAction.GetQuesCommentsByCID(CurrentNote.ID));
            gridQuesComments.DataSource = QuestionComments;
            pageQuestion.Text = "Variable (" + QuestionComments.Count + ")";

            SurveyComments = new BindingList<SurveyComment>(DBAction.GetSurvCommentsByCID(CurrentNote.ID));
            gridSurvComments.DataSource = SurveyComments;
            pageSurvey.Text = "Survey (" + SurveyComments.Count + ")";

            ////Adding  Item ComboBox

            //DataGridViewComboBoxColumn ColumnSurvey = new DataGridViewComboBoxColumn();
            //ColumnSurvey.DataPropertyName = "Survey";
            //ColumnSurvey.HeaderText = "Item";
            //ColumnSurvey.Width = 120;

            //ColumnSurvey.DataSource = DBAction.GetSurveyList();
            //ColumnSurvey.ValueMember = "ID";
            //ColumnSurvey.DisplayMember = "Survey";

            //gridQuestions.Columns.Add(ColumnSurvey);
        }

        private int SaveRecord()
        {

            if (NewRecord)
            {

                if (DBAction.InsertNote(CurrentNote.NoteText) == 1)
                    return 1;

                NewRecord = false;
                Dirty = false;
            }
            else if (Dirty)
            {

               // if (DBAction.UpdateQuestionWordings(CurrentNote) == 1)
                //    return 1;

                //if (DBAction.UpdateLabels (CurrentNote) == 1) 
                //  return 1;

                Dirty = false;
            }

            return 0;
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

        
        #endregion

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            NewRecord = true;
            Dirty = true;

            bs.AddNew();


        }

        private void cmdDelete_Click(object sender, EventArgs e)
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
                bs.RemoveCurrent();
            }
        }

        private void cmdSearchClip_Click(object sender, EventArgs e)
        {
            string searchTerm = Clipboard.GetText();

            bs.DataSource = Notes.Where(x => x.NoteText.Contains(searchTerm));
            navNotes.BindingSource = null;
            navNotes.BindingSource = bs;
        }

        private void cmdSearchText_Click(object sender, EventArgs e)
        {

        }

        private bool IsEmptyRecord(Note n)
        {
            if (string.IsNullOrEmpty(n.NoteText) && NewRecord)
                return true;
            else
                return false;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {

        }

        #region Grid View formatting
        private void gridQuesComments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gridQuesComments.ColumnCount; i++)
            {
                switch (gridQuesComments.Columns[i].Name)
                {
                    
                    case "VarName":
                        break;
                    case "Survey":
                        break;
                    case "NoteDate":
                        gridQuesComments.Columns[i].HeaderText = "Date";
                        break;
                    case "Name":
                        gridQuesComments.Columns[i].HeaderText = "Init";
                        break;
                    case "NoteType":
                        gridQuesComments.Columns[i].HeaderText = "Type";
                        break;
                    case "Source":
                        break;
                    case "SourceName":
                        gridQuesComments.Columns[i].HeaderText = "Source Name";
                        
                        break;
                    default:
                        gridQuesComments.Columns[i].Visible = false;
                        break;

                }

            }
            gridQuesComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void gridSurvComments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gridSurvComments.ColumnCount; i++)
            {
                switch (gridSurvComments.Columns[i].Name)
                {

                    case "Survey":
                        break;
                    case "NoteDate":
                        gridSurvComments.Columns[i].HeaderText = "Date";
                        break;
                    case "Name":
                        gridSurvComments.Columns[i].HeaderText = "Init";
                        break;
                    case "NoteType":
                        gridSurvComments.Columns[i].HeaderText = "Type";
                        break;
                    case "Source":
                    case "SourceName":
                        gridSurvComments.Columns[i].HeaderText = "Source Name";

                        break;
                    default:
                        gridSurvComments.Columns[i].Visible = false;
                        break;

                }

            }
            gridQuesComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        private void chkAssignedDetails_CheckedChanged(object sender, EventArgs e)
        {

            // uncheck others if this one is to be checked

            bool details = chkAssignedDetails.Checked || chkLastUsedDetails.Checked || chkNewDetails.Checked;
            ExpandForm(details, chkStoredComments.Checked);
        
        }

        // if details are to show, expand detail panel, and form to show it
        // if stored comments are to show, expand stored panel, and form to show it
        // move tab control panel accordingly
        private void ExpandForm(bool details, bool stored)
        {
            if (details && stored)
            {
                panelDetails.Height = 160;
                this.Height += 160;
            }
            else if (details && !stored)
            {
                panelDetails.Height = 160;
                this.Height += 160;

            } else if (!details && stored)
            {
                panelDetails.Height = 0;
                this.Height -= 160;
            } else if (!details && !stored)
            {
                panelDetails.Height = 0;
                this.Height -= 160;
            }
        } 
    }
}
