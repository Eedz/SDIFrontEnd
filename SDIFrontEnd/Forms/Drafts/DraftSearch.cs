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
    public partial class DraftSearch : Form
    {
        List<SurveyDraft> DraftList;
        BindingSource bs;

        int QWidth = 240;
        int CWidth = 240;
        int E1Width = 100;
        int E2Width = 100;
        int E3Width = 100;
        int E4Width = 100;
        int E5Width = 100;

        public DraftSearch()
        {
            InitializeComponent();

            bs = new BindingSource();

            DraftList = DBAction.ListSurveyDrafts();

            FillBoxes();
        }

        #region Form Setup
        private void FillBoxes()
        {
            cboSurveyFilter.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurveyFilter.DisplayMember = "SurveyCode";
            cboSurveyFilter.ValueMember = "SID";
            cboSurveyFilter.SelectedItem = null;
            cboSurveyFilter.SelectedIndexChanged += CboSurveyFilter_SelectedIndexChanged;

            cboInvestigatorFilter.DataSource = new List<PersonRecord>(Globals.AllPeople);
            cboInvestigatorFilter.DisplayMember = "Name";
            cboInvestigatorFilter.ValueMember = "ID";
            cboInvestigatorFilter.SelectedItem = null;
        }
        #endregion

        #region Methods
        private void NewSearch()
        {
            cboSurveyFilter.SelectedItem = null;
            cboDateFilter.SelectedItem = null;
            txtRefVarFilter.Text = string.Empty;
            txtQuestionFilter.Text = string.Empty;
            txtCommentFilter.Text = string.Empty;

            repeaterRecords.DataSource = null;

        }

        public void GoToDraft(int survid, int draftid)
        {
            cboSurveyFilter.SelectedValue = survid;
            cboDateFilter.SelectedValue = draftid;
            cboInvestigatorFilter.SelectedItem = null;
            txtRefVarFilter.Text = string.Empty;
            txtQuestionFilter.Text = string.Empty;
            txtCommentFilter.Text = string.Empty;
            SearchDrafts();
        }

        private void SearchDrafts()
        {
            int? survID = null;
            int? investigatorID = null;
            int? date = null;
            string varname = null;
            string question = null;
            string comment = null;

            if (cboSurveyFilter.SelectedItem != null)
                survID = (int)cboSurveyFilter.SelectedValue;

            if (cboInvestigatorFilter.SelectedItem != null)
                investigatorID = (int)cboSurveyFilter.SelectedValue;

            if (cboDateFilter.SelectedItem != null)
            {
                SurveyDraft item = (SurveyDraft)cboDateFilter.SelectedItem;

                date = item.ID;
            }

            if (!string.IsNullOrWhiteSpace(txtRefVarFilter.Text))
                varname = txtRefVarFilter.Text;

            if (!string.IsNullOrWhiteSpace(txtQuestionFilter.Text))
                question = txtQuestionFilter.Text;

            if (!string.IsNullOrWhiteSpace(txtCommentFilter.Text))
                comment = txtCommentFilter.Text;

            List<DraftQuestion> results = DBAction.GetDraftQuestions(survID, varname, date, investigatorID, question, comment);

            if (results.Count == 0)
            {
                MessageBox.Show("No results found!");
                return;
            }
            UnbindProperties();
            BindProperties();

            ResizeExtraFields(results);

            bs.DataSource = results;
            bindingNavigator1.BindingSource = bs;
            repeaterRecords.DataSource = null;
            repeaterRecords.DataSource = bs;

            AlignLabels();


        }

        private void BindProperties()
        {
            txtQnum.DataBindings.Add("Text", bs, "Qnum");
            txtAltQnum.DataBindings.Add("Text", bs, "AltQnum");
            txtVarName.DataBindings.Add("Text", bs, "VarName");
            chkNewRow.DataBindings.Add("Checked", bs, "Inserted");
            chkDeleted.DataBindings.Add("Checked", bs, "Deleted");


        }

        private void UnbindProperties()
        {
            txtQnum.DataBindings.Clear();
            txtAltQnum.DataBindings.Clear();
            txtVarName.DataBindings.Clear();
            chkNewRow.DataBindings.Clear();
            chkDeleted.DataBindings.Clear();

        }

        private void ResizeExtraFields(List<DraftQuestion> records)
        {
            double availableWidth = 1500;
            int count = 2;
            bool extra1 = false;
            bool extra2 = false;
            bool extra3 = false;
            bool extra4 = false;
            bool extra5 = false;

            // find out which extra fields are needed
            if (records.Any(x => !string.IsNullOrWhiteSpace(x.Extra1)))
            {
                extra1 = true;
                count++;
            }

            if (records.Any(x => !string.IsNullOrWhiteSpace(x.Extra2)))
            {
                extra2 = true;
                count++;
            }

            if (records.Any(x => !string.IsNullOrWhiteSpace(x.Extra3)))
            {
                extra3 = true;
                count++;
            }

            if (records.Any(x => !string.IsNullOrWhiteSpace(x.Extra4)))
            {
                extra4 = true;
                count++;
            }

            if (records.Any(x => !string.IsNullOrWhiteSpace(x.Extra5)))
            {
                extra5 = true;
                count++;
            }

            if (count == 0)
            {
                E1Width = 0;
                E2Width = 0;
                E3Width = 0;
                E4Width = 0;
                E5Width = 0;

                QWidth = (int)(availableWidth / 2);
                CWidth = (int)(availableWidth / 2);

                return;
            }

            QWidth = (int)(availableWidth / count);
            CWidth = (int)(availableWidth / count);

            if (extra1)
            {
                E1Width = (int)(availableWidth / count);
            }
            else E1Width = 0;

            if (extra2)
            {
                E2Width = (int)(availableWidth / count);
            }
            else E2Width = 0;


            if (extra3)
            {
                E3Width = (int)(availableWidth / count);
            }
            else E3Width = 0;

            if (extra4)
            {
                E4Width = (int)(availableWidth / count);
            }
            else E4Width = 0;


            if (extra5)
            {
                E5Width = (int)(availableWidth / count);
            }
            else E5Width = 0;


        }

        private void AlignLabels()
        {
            lblEF1.Visible = (E1Width != 0);
            lblEF2.Visible = (E2Width != 0);
            lblEF3.Visible = (E3Width != 0);
            lblEF4.Visible = (E4Width != 0);
            lblEF5.Visible = (E5Width != 0);

            if (cboDateFilter.SelectedItem != null)
            {
                SurveyDraft surveyDraftRecord = (SurveyDraft)cboDateFilter.SelectedItem;

                foreach (SurveyDraftExtraField ef in surveyDraftRecord.ExtraFields)
                {
                    switch (ef.FieldNumber)
                    {
                        case 1:
                            lblEF1.Text = ef.Label;
                            break;
                        case 2:
                            lblEF2.Text = ef.Label;
                            break;
                        case 3:
                            lblEF3.Text = ef.Label;
                            break;
                        case 4:
                            lblEF4.Text = ef.Label;
                            break;
                        case 5:
                            lblEF5.Text = ef.Label;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Menu Items
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSearch();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDrafts();
        }

        #endregion

        #region Events
        private void DraftSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            SearchDrafts();
        }

        private void CboSurveyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the draft dates for this survey (or all)
            if (cboSurveyFilter.SelectedItem == null)
                cboDateFilter.DataSource = DraftList;
            else
                cboDateFilter.DataSource = DraftList.Where(x => x.SurvID == (int)cboSurveyFilter.SelectedValue).ToList();

            cboDateFilter.DisplayMember = "DateAndTitle";
            cboDateFilter.ValueMember = "ID";
        }

        private void repeaterRecords_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)e.DataRepeaterItem;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = ((BindingSource)dataRepeater.DataSource);
            var currentQuestion = ((DraftQuestion)datasource[e.DataRepeaterItem.ItemIndex]);

            var questionText = (RichTextBox)item.Controls.Find("rtbQuestionText", false)[0];
            questionText.Width = QWidth;
            questionText.Rtf = currentQuestion.QuestionTextRTF;

            lblQuestionText.Left = panelResults.Left + repeaterRecords.Left + repeaterRecords.ItemHeaderSize + questionText.Left;
            lblQuestionText.Width = QWidth;

            var commentText = (RichTextBox)item.Controls.Find("rtbComments", false)[0];
            commentText.Width = CWidth;
            commentText.Left = questionText.Left + questionText.Width + 5;
            commentText.Rtf = currentQuestion.CommentsRTF;

            lblComments.Left = panelResults.Left + repeaterRecords.Left + repeaterRecords.ItemHeaderSize + commentText.Left;
            lblComments.Width = CWidth;

            var extra1Text = (RichTextBox)item.Controls.Find("rtbExtra1", false)[0];
            extra1Text.Width = E1Width;
            extra1Text.Left = commentText.Left + commentText.Width + 5;
            extra1Text.Rtf = currentQuestion.Extra1RTF;

            lblEF1.Left = panelResults.Left + repeaterRecords.Left + repeaterRecords.ItemHeaderSize + extra1Text.Left;
            lblEF1.Width = E1Width;


            var extra2Text = (RichTextBox)item.Controls.Find("rtbExtra2", false)[0];
            extra2Text.Width = E2Width;
            extra2Text.Left = extra1Text.Left + extra1Text.Width + 5;
            extra2Text.Rtf = currentQuestion.Extra2RTF;

            lblEF2.Left = panelResults.Left + repeaterRecords.Left + repeaterRecords.ItemHeaderSize + extra2Text.Left;
            lblEF2.Width = E2Width;

            var extra3Text = (RichTextBox)item.Controls.Find("rtbExtra3", false)[0];
            extra3Text.Width = E3Width;
            extra3Text.Left = extra2Text.Left + extra2Text.Width + 5;
            extra3Text.Rtf = currentQuestion.Extra3RTF;

            lblEF3.Left = panelResults.Left + repeaterRecords.Left + repeaterRecords.ItemHeaderSize + extra3Text.Left;
            lblEF3.Width = E3Width;

            var extra4Text = (RichTextBox)item.Controls.Find("rtbExtra4", false)[0];
            extra4Text.Width = E4Width;
            extra4Text.Left = extra3Text.Left + extra3Text.Width + 5;
            extra4Text.Rtf = currentQuestion.Extra4RTF;

            lblEF4.Left = panelResults.Left + repeaterRecords.Left + repeaterRecords.ItemHeaderSize + extra4Text.Left;
            lblEF4.Width = E4Width;

            var extra5Text = (RichTextBox)item.Controls.Find("rtbExtra5", false)[0];
            extra5Text.Width = E5Width;
            extra5Text.Left = extra4Text.Left + extra4Text.Width + 5;
            extra5Text.Rtf = currentQuestion.Extra5RTF;

            lblEF5.Left = panelResults.Left + repeaterRecords.Left + repeaterRecords.ItemHeaderSize + extra5Text.Left;
            lblEF5.Width = E5Width;

            var draftTitleLabel = (Label)item.Controls.Find("lblDraftTitle", false)[0];
            draftTitleLabel.Text = DraftList.Where(x => x.ID == currentQuestion.DraftID).First().DraftTitle;
        }

        private void cmdGoToDraft_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)button.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;
            var datasource = (List<DraftQuestion>)((BindingSource)dataRepeater.DataSource).DataSource;
            DraftQuestion item = datasource[dataRepeaterItem.ItemIndex];
        }

        private void cmdQuestions_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)button.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;
            var datasource = (List<DraftQuestion>)((BindingSource)dataRepeater.DataSource).DataSource;
            DraftQuestion item = datasource[dataRepeaterItem.ItemIndex];
        }
        #endregion

      

        

        
    }
}
