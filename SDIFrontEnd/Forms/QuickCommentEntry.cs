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
    public partial class QuickCommentEntry : Form
    {
        NoteScope Scope;

        public QuickCommentEntry()
        {
            InitializeComponent();

            FillBoxes();
        }

        public QuickCommentEntry(NoteScope scope) :this()
        {
            
            Scope = scope;
            ChangeScope();
        }

        public QuickCommentEntry(SurveyQuestion q) :this()
        {
            cboCommentScope.SelectedValue = NoteScope.Variable;
            cboSurvWaveList.SelectedItem = Globals.AllSurveys.Where(x => x.SurveyCode.Equals(q.SurveyCode));
            cboVarName.SelectedItem = Globals.AllRefVarNames.Where(x => x.RefVarName.Equals(q.VarName.RefVarName));
            cboNoteAuthor.SelectedValue = Globals.CurrentUser.userid;
        }

        public QuickCommentEntry(NoteScope s, SurveyQuestion q) : this()
        {
            cboCommentScope.SelectedValue = s;
            cboSurvWaveList.SelectedItem = Globals.AllSurveys.Where(x => x.SurveyCode.Equals(q.SurveyCode));
            cboVarName.SelectedItem = Globals.AllRefVarNames.Where(x => x.RefVarName.Equals(q.VarName.RefVarName));
            cboNoteAuthor.SelectedValue = Globals.CurrentUser.userid;
        }


        private void FillBoxes()
        {

            cboVarName.DataSource = new List<RefVariableName>(Globals.AllRefVarNames);
            cboVarName.DisplayMember = "RefVarName";
            cboVarName.ValueMember = "ID";

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
           
        }

        

        private void ChangeScope()
        {
            bool enableSurv = false;
            bool enableVar = false;
          
            switch (Scope)
            {
                case NoteScope.Variable:
                case NoteScope.RefVar:
                case NoteScope.Deleted:
                    enableVar = true;
                    break;
                case NoteScope.Survey:
                    cboSurvWaveList.DataSource = new List<SurveyRecord>(Globals.AllSurveys);
                    cboSurvWaveList.DisplayMember = "SurveyCode";
                    cboSurvWaveList.ValueMember = "SID";
                    enableSurv = true;
                    break;
                case NoteScope.Wave:
                    cboSurvWaveList.DataSource = new List<StudyWaveRecord>(Globals.AllWaves);
                    cboSurvWaveList.DisplayMember = "WaveCode";
                    cboSurvWaveList.ValueMember = "WaveID";
                    enableSurv = true;
                    break;
            }
            cboSurvWaveList.Enabled = enableSurv;
            cboVarName.Enabled = enableVar;


          
        }

        

        private void QuickCommentEntry_Load(object sender, EventArgs e)
        {

        }

        private void cboCommentScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            Scope = (NoteScope)cboCommentScope.SelectedItem;
            ChangeScope();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string survey = ((Survey)(((ComboBox)sender).SelectedItem)).SurveyCode;
            string varname = ((RefVariableName)(((ComboBox)sender).SelectedItem)).RefVarName;

            switch (Scope)
            {
                case NoteScope.Variable:
                    QuestionComment NewVarComment = new QuestionComment();
                    NewVarComment.QID = GetQID(survey, varname);
                    NewVarComment.Author = (Person)cboNoteAuthor.SelectedItem;
                    NewVarComment.NoteType = (CommentType)cboNoteType.SelectedItem;
                    NewVarComment.NoteDate = dtpNoteDate.Value;
                    NewVarComment.Authority = (Person)cboNoteAuthority.SelectedItem;
                    NewVarComment.Notes.NoteText = txtComment.Text;
                    NewVarComment.Source = txtSource.Text;
                    DBAction.InsertQuestionComment(NewVarComment);
                    break;

                case NoteScope.RefVar:
                    RefVarComment NewRefComment = new RefVarComment();
                    NewRefComment.Author = (Person)cboNoteAuthor.SelectedItem;
                    NewRefComment.NoteType = (CommentType)cboNoteType.SelectedItem;
                    NewRefComment.NoteDate = dtpNoteDate.Value;
                    NewRefComment.Authority = (Person)cboNoteAuthority.SelectedItem;
                    NewRefComment.Notes.NoteText = txtComment.Text;
                    NewRefComment.Source = txtSource.Text;
                    DBAction.InsertRefVarComment(NewRefComment);
                    break;
                case NoteScope.Deleted:
                    DeletedComment NewDelComment = new DeletedComment();
                    NewDelComment.Author = (Person)cboNoteAuthor.SelectedItem;
                    NewDelComment.NoteType = (CommentType)cboNoteType.SelectedItem;
                    NewDelComment.NoteDate = dtpNoteDate.Value;
                    NewDelComment.Authority = (Person)cboNoteAuthority.SelectedItem;
                    NewDelComment.Notes.NoteText = txtComment.Text;
                    NewDelComment.Source = txtSource.Text;
                    DBAction.InsertDeletedComment(NewDelComment);
                    break;
                case NoteScope.Survey:
                    SurveyComment NewSurvComment = new SurveyComment();
                    NewSurvComment.Author = (Person)cboNoteAuthor.SelectedItem;
                    NewSurvComment.NoteType = (CommentType)cboNoteType.SelectedItem;
                    NewSurvComment.NoteDate = dtpNoteDate.Value;
                    NewSurvComment.Authority = (Person)cboNoteAuthority.SelectedItem;
                    NewSurvComment.Notes.NoteText = txtComment.Text;
                    NewSurvComment.Source = txtSource.Text;
                    DBAction.InsertSurveyComment(NewSurvComment);
                    break;
                case NoteScope.Wave:
                    WaveComment NewWaveComment = new WaveComment();
                    NewWaveComment.Author = (Person)cboNoteAuthor.SelectedItem;
                    NewWaveComment.NoteType = (CommentType)cboNoteType.SelectedItem;
                    NewWaveComment.NoteDate = dtpNoteDate.Value;
                    NewWaveComment.Authority = (Person)cboNoteAuthority.SelectedItem;
                    NewWaveComment.Notes.NoteText = txtComment.Text;
                    NewWaveComment.Source = txtSource.Text;
                    DBAction.InsertWaveComment(NewWaveComment);
                    break;
            }
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int GetQID(string survey, string varname)
        {
            
            return DBAction.GetQuestionID(survey, varname);
        }
    }
}
