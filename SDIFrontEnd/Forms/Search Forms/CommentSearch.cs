﻿using System;
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
    public partial class CommentSearch : Form
    {
        BindingSource bsQuestionComments;
        List<QuestionComment> qComments;

        BindingSource bsSurveyComments;
        List<SurveyComment> sComments;

        BindingSource bsWaveComments;
        List<WaveComment> wComments;

        BindingSource bsDeletedComments;
        List<DeletedComment> dComments;

        BindingSource bsPraccingComments;
        List<PraccingIssue> pComments;

        BindingSource bsChangeComments;
        List<VarNameChange> cComments;

        BindingSource bsDraftComments;
        List<SurveyDraft> drComments;

        public CommentSearch()
        {
            InitializeComponent();

            qComments = new List<QuestionComment>();
            bsQuestionComments = new BindingSource();
            bsQuestionComments.DataSource = qComments;

            sComments = new List<SurveyComment>();
            bsSurveyComments = new BindingSource();
            bsSurveyComments.DataSource = sComments;

            wComments = new List<WaveComment>();
            bsWaveComments = new BindingSource();
            bsWaveComments.DataSource = wComments;

            dComments = new List<DeletedComment>();
            bsDeletedComments = new BindingSource();
            bsDeletedComments.DataSource = dComments;

            pComments = new List<PraccingIssue>();
            bsPraccingComments = new BindingSource();
            bsPraccingComments.DataSource = pComments;

            cComments = new List<VarNameChange>();
            bsChangeComments = new BindingSource();
            bsChangeComments.DataSource = cComments;

            drComments = new List<SurveyDraft>();
            bsDraftComments = new BindingSource();
            bsDraftComments.DataSource = drComments;

            tabResults.TabPages.Remove(pageChangeComments);

            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.SelectedItem = null;

            cboAuthor.DataSource = new List<Person>(Globals.AllPeople);
            cboAuthor.DisplayMember = "Name";
            cboAuthor.ValueMember = "ID";
            cboAuthor.SelectedItem = null;

            cboType.DataSource = new List<CommentType>(Globals.AllCommentTypes);
            cboType.DisplayMember = "TypeName";
            cboType.ValueMember = "ID";
            cboType.SelectedItem = null;

            BindProperties();
        }

        private List<QuestionComment> GetQuestionComments()
        {
            List<QuestionComment> results = new List<QuestionComment>();
            string surveyFilter=null;
            bool refvarname = false;
            string varnameFilter = null;
            DateTime? dateLowerFilter = null;
            DateTime? dateUpperFilter = null;
            int? authorFilter=null;
            string typeFilter=null ;
            string sourceFilter=null;
            string commentFilter = null;

            if (cboSurvey.SelectedItem != null)
                surveyFilter = ((Survey)cboSurvey.SelectedItem).SurveyCode;

            
            refvarname = optRefVarName.Checked;

            if (!string.IsNullOrEmpty(txtVarName.Text))
            {
                varnameFilter = txtVarName.Text;
            }

            if (dtpLower.Checked)
                dateLowerFilter = dtpLower.Value;

            if (dtpUpper.Checked)
                dateUpperFilter = dtpUpper.Value;

            if (cboType.SelectedItem != null)
            {
                CommentType type = (CommentType)cboType.SelectedItem;
                typeFilter = type.TypeName;
            }
            

            if (cboAuthor.SelectedItem != null)
                authorFilter = (int)cboAuthor.SelectedValue;

            if (!string.IsNullOrEmpty(txtSource.Text))
                sourceFilter = txtSource.Text;

            if (!string.IsNullOrEmpty(txtComment.Text))
                commentFilter = txtComment.Text;

            results = DBAction.GetQuesComments(surveyFilter, varnameFilter, refvarname, typeFilter, dateLowerFilter, dateUpperFilter, authorFilter, sourceFilter, commentFilter);

            return results;
        }

        private List<SurveyComment> GetSurveyComments()
        {
            string surveyFilter = null;
            DateTime? dateLowerFilter = null;
            DateTime? dateUpperFilter = null;
            int? authorFilter = null;
            string typeFilter = null;
            string sourceFilter = null;
            string commentFilter = null;

            if (cboSurvey.SelectedItem != null)
                surveyFilter = ((Survey)cboSurvey.SelectedItem).SurveyCode;

            if (dtpLower.Checked)
                dateLowerFilter = dtpLower.Value;

            if (dtpUpper.Checked)
                dateUpperFilter = dtpUpper.Value;

            if (cboType.SelectedItem != null)
                typeFilter = ((CommentType)cboType.SelectedItem).TypeName;

            if (cboAuthor.SelectedItem != null)
                authorFilter =  (int)cboAuthor.SelectedValue ;

            if (!string.IsNullOrEmpty(txtSource.Text))
                sourceFilter =  txtSource.Text ;

            if (!string.IsNullOrEmpty(txtComment.Text))
                commentFilter = txtComment.Text;

            return DBAction.GetSurveyComments(surveyFilter, typeFilter, dateLowerFilter, dateUpperFilter, authorFilter, sourceFilter, commentFilter);
        }

        private List<WaveComment> GetWaveComments()
        {
            List<WaveComment> results = new List<WaveComment>();
            string waveFilter = null;
            DateTime? dateLowerFilter = null;
            DateTime? dateUpperFilter = null;
            int? authorFilter = null;
            string typeFilter = null;
            string sourceFilter = null;
            string commentFilter = null;

            if (cboSurvey.SelectedItem != null)
                waveFilter = (Globals.AllWaves.Where(x=>x.ID  == ((Survey)cboSurvey.SelectedItem).WaveID).FirstOrDefault()).WaveCode;

            if (dtpLower.Checked)
                dateLowerFilter = dtpLower.Value;

            if (dtpUpper.Checked)
                dateUpperFilter = dtpUpper.Value;

            if (cboType.SelectedItem != null)
                typeFilter = ((CommentType)cboType.SelectedItem).TypeName;

            if (cboAuthor.SelectedItem != null)
                authorFilter = (int)cboAuthor.SelectedValue;

            if (!string.IsNullOrEmpty(txtSource.Text))
                sourceFilter = txtSource.Text;

            if (!string.IsNullOrEmpty(txtComment.Text))
                commentFilter = txtComment.Text;

            results = DBAction.GetWaveComments(waveFilter, typeFilter, dateLowerFilter, dateUpperFilter, authorFilter, sourceFilter, commentFilter);

            return results;
        }

        private List<DeletedComment> GetDeletedComments()
        {
            List<DeletedComment> results = new List<DeletedComment>();
            string surveyFilter = null;
            bool refvarname = false;
            string varnameFilter = null;
            DateTime? dateLowerFilter = null;
            DateTime? dateUpperFilter = null;
            int? authorFilter = null;
            string typeFilter = null;
            string sourceFilter = null;
            string commentFilter = null;

            if (cboSurvey.SelectedItem != null)
                surveyFilter = ((Survey)cboSurvey.SelectedItem).SurveyCode;


            refvarname = optRefVarName.Checked;

            if (!string.IsNullOrEmpty(txtVarName.Text))
                varnameFilter = txtVarName.Text;

            if (dtpLower.Checked)
                dateLowerFilter = dtpLower.Value;

            if (dtpUpper.Checked)
                dateUpperFilter = dtpUpper.Value;

            if (cboType.SelectedItem != null)
                typeFilter = ((CommentType)cboType.SelectedItem).TypeName;

            if (cboAuthor.SelectedItem != null)
                authorFilter = (int)cboAuthor.SelectedValue;

            if (!string.IsNullOrEmpty(txtSource.Text))
                sourceFilter = txtSource.Text;

            if (!string.IsNullOrEmpty(txtComment.Text))
                commentFilter = txtComment.Text;

            results = DBAction.GetDeletedComments(surveyFilter, varnameFilter, refvarname, typeFilter, dateLowerFilter, dateUpperFilter, authorFilter, sourceFilter, commentFilter);

            return results;
        }

        private List<PraccingIssue> GetPraccingComments()
        {
            List<PraccingIssue> results = new List<PraccingIssue>();
            string surveyFilter = null;
            
            string varnameFilter = null;
            DateTime? dateLowerFilter = null;
            DateTime? dateUpperFilter = null;
            int authorFilter = 0;
            string typeFilter = null;
            string sourceFilter = null;
            string commentFilter = null;

            if (cboSurvey.SelectedItem != null)
                surveyFilter = ((Survey)cboSurvey.SelectedItem).SurveyCode;

            if (!string.IsNullOrEmpty(txtVarName.Text))
            {
                varnameFilter = txtVarName.Text;
            }

            if (dtpLower.Checked)
                dateLowerFilter = dtpLower.Value;

            if (dtpUpper.Checked)
                dateUpperFilter = dtpUpper.Value;

            if (cboAuthor.SelectedItem != null)
                authorFilter = (int)cboAuthor.SelectedValue;
            else
                authorFilter = 0;

            if (!string.IsNullOrEmpty(txtSource.Text))
                sourceFilter = txtSource.Text;

            if (!string.IsNullOrEmpty(txtComment.Text))
                commentFilter = txtComment.Text;

            results = DBAction.GetPraccingIssues(surveyFilter, varnameFilter, typeFilter, dateLowerFilter, dateUpperFilter, authorFilter, commentFilter);

            return results;
        }

        private List<VarNameChange> GetVarNameChangeComments()
        {
            List<VarNameChange> results = new List<VarNameChange>();
            string surveyFilter = null;
            bool refvarname = false;
            string varnameFilter = null;
            DateTime? dateLowerFilter = null;
            DateTime? dateUpperFilter = null;
            int? authorFilter = null;
            string sourceFilter = null;
            string commentFilter = null;

            if (cboSurvey.SelectedItem != null)
                surveyFilter = ((Survey)cboSurvey.SelectedItem).SurveyCode;

            refvarname = optRefVarName.Checked;

            if (!string.IsNullOrEmpty(txtVarName.Text))
            {
                varnameFilter = txtVarName.Text;
            }

            if (dtpLower.Checked)
                dateLowerFilter = dtpLower.Value;

            if (dtpUpper.Checked)
                dateUpperFilter = dtpUpper.Value;

            if (cboAuthor.SelectedItem != null)
                authorFilter = (int)cboAuthor.SelectedValue;
            else
                authorFilter = null;

            if (!string.IsNullOrEmpty(txtSource.Text))
                sourceFilter = txtSource.Text;

            if (!string.IsNullOrEmpty(txtComment.Text))
                commentFilter = txtComment.Text;

            results = DBAction.GetVarChanges(surveyFilter, varnameFilter, refvarname, dateLowerFilter, dateUpperFilter, authorFilter, sourceFilter, commentFilter);
            
            return results;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            qComments = GetQuestionComments();
            sComments = GetSurveyComments();
            wComments = GetWaveComments();
            dComments = GetDeletedComments();
            pComments = GetPraccingComments();
            //cComments = GetVarNameChangeComments();

            bsQuestionComments.DataSource = qComments;
            tabResults.TabPages["pageQuestionComments"].Text = "Var Comments (" + qComments.Count + ")";
            dataRepeater1.DataSource = bsQuestionComments;
            
            bsSurveyComments.DataSource = sComments;
            tabResults.TabPages["pageSurveyComments"].Text = "Survey Comments (" + sComments.Count + ")";
            dataRepeater2.DataSource = bsSurveyComments;
 
            bsWaveComments.DataSource = wComments;
            tabResults.TabPages["pageWaveComments"].Text = "Wave Comments (" + wComments.Count + ")";
            dataRepeater3.DataSource = bsWaveComments;
                
            bsDeletedComments.DataSource = dComments;
            tabResults.TabPages["pageDeletedComments"].Text = "Deleted Var Comments (" + dComments.Count + ")";
            dataRepeater4.DataSource = bsDeletedComments;

            bsPraccingComments.DataSource = pComments;
            tabResults.TabPages["pagePraccingComments"].Text = "Praccing Comments (" + pComments.Count + ")";
            dataRepeater5.DataSource = bsPraccingComments;

            //bsChangeComments.DataSource = cComments;
            //tabResults.TabPages["pageChangeComments"].Text = "VarName Change Comments (" + cComments.Count + ")";
            //dataRepeater6.DataSource = bsChangeComments;
        }

        private void BindProperties()
        {
            txtQSurvey.DataBindings.Add("Text", bsQuestionComments, "Survey");
            txtQVarName.DataBindings.Add("Text", bsQuestionComments, "VarName");
            txtQNoteDate.DataBindings.Add("Text", bsQuestionComments, "NoteDate");
            txtQNoteType.DataBindings.Add("Text", bsQuestionComments, "NoteType");
            txtQAuthor.DataBindings.Add("Text", bsQuestionComments, "Author");
            txtQSource.DataBindings.Add("Text", bsQuestionComments, "Source");
            txtQSourceName.DataBindings.Add("Text", bsQuestionComments, "Authority");
            txtQComment.DataBindings.Add("Text", bsQuestionComments, "Notes");

            txtSSurvey.DataBindings.Add("Text", bsSurveyComments, "Survey");
            txtSNoteDate.DataBindings.Add("Text", bsSurveyComments, "NoteDate");
            txtSAuthor.DataBindings.Add("Text", bsSurveyComments, "Author");
            txtSNoteType.DataBindings.Add("Text", bsSurveyComments, "NoteType");
            txtSSource.DataBindings.Add("Text", bsSurveyComments, "Source");
            txtSSourceName.DataBindings.Add("Text", bsSurveyComments, "Authority");
            txtSComment.DataBindings.Add("Text", bsSurveyComments, "Notes");

            txtWave.DataBindings.Add("Text", bsWaveComments, "StudyWave");
            txtWNoteDate.DataBindings.Add("Text", bsWaveComments, "NoteDate");
            txtWAuthor.DataBindings.Add("Text", bsWaveComments, "Author");
            txtWNoteType.DataBindings.Add("Text", bsWaveComments, "NoteType");
            txtWSource.DataBindings.Add("Text", bsWaveComments, "Source");
            txtWSourceName.DataBindings.Add("Text", bsWaveComments, "Authority");
            txtWComment.DataBindings.Add("Text", bsWaveComments, "Notes");

            txtDSurvey.DataBindings.Add("Text", bsDeletedComments, "Survey");
            txtDVarName.DataBindings.Add("Text", bsDeletedComments, "VarName");
            txtDNoteDate.DataBindings.Add("Text", bsDeletedComments, "NoteDate");
            txtDNoteType.DataBindings.Add("Text", bsDeletedComments, "NoteType");
            txtDAuthor.DataBindings.Add("Text", bsDeletedComments, "Author");
            txtDSource.DataBindings.Add("Text", bsDeletedComments, "Source");
            txtDSourceName.DataBindings.Add("Text", bsDeletedComments, "Authority");
            txtDComment.DataBindings.Add("Text", bsDeletedComments, "Notes");

            txtPSurvey.DataBindings.Add("Text", bsPraccingComments, "Survey");
            txtPVarName.DataBindings.Add("Text", bsPraccingComments, "VarNames");
            txtPNoteDate.DataBindings.Add("Text", bsPraccingComments, "IssueDate");
            txtPNoteType.DataBindings.Add("Text", bsPraccingComments, "Category");
            txtPAuthorFrom.DataBindings.Add("Text", bsPraccingComments, "IssueFrom");
            txtPAuthorTo.DataBindings.Add("Text", bsPraccingComments, "IssueTo");
            txtPComment.DataBindings.Add("Text", bsPraccingComments, "Description");

            //txtChangeSurvey.DataBindings.Add("Text", bsChangeComments, "SurveyList");
            //txtOldVarName.DataBindings.Add("Text", bsChangeComments, "OldName");
            //txtNewVarName.DataBindings.Add("Text", bsChangeComments, "NewName");
            //txtChangeDate.DataBindings.Add("Text", bsChangeComments, "ChangeDate");
            //txtChangedBy.DataBindings.Add("Text", bsChangeComments, "ChangedBy");
            //txtChangeReason.DataBindings.Add("Text", bsChangeComments, "Rationale");
            //txtChangeAuth.DataBindings.Add("Text", bsChangeComments, "Authorization");
            //txtChangeSource.DataBindings.Add("Text", bsChangeComments, "Source");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
        }

        private void cmdGoToQuestion_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdQGoToComment_Click(object sender, EventArgs e)
        {

        }
    }
}
