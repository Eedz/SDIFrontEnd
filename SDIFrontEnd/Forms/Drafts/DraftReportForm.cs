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
using ITCReportLib;

using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class DraftReportForm : Form
    {
        enum DraftReportSource { ByDraft, ByDate, ByInvestigator, Undefined }
        List<SurveyDraft> DraftList;
        DraftReportSource ReportSource;
        public DraftReportForm()
        {
            InitializeComponent();

            DraftList = DBAction.ListSurveyDrafts();

            FillLists();
            
        }

        #region Setup
        private void FillLists()
        {
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.SelectedItem = null;
            cboSurvey.SelectedIndexChanged += cboSurvey_SelectedIndexChanged;

            cboInvestigator.DataSource = new List<Person>(Globals.AllPeople);
            cboInvestigator.DisplayMember = "Name";
            cboInvestigator.ValueMember = "ID";
        }
        #endregion

        #region Methods
        /// <summary>
        /// Show drafts for this survey.
        /// </summary>
        /// <param name="survey"></param>
        private void FilterBySurvey(Survey survey)
        {
            cboDraft.DataSource = DraftList.Where(x => x.SurvID == survey.SID).ToList();
            cboDraft.DisplayMember = "DateAndTitle";
            cboDraft.ValueMember = "ID";
            cboDraft.SelectedItem = null;
        }
        
        private bool CheckQnumRange(string txt)
        {
            if (!int.TryParse(txt, out int lower))
            {
                MessageBox.Show("Enter a number.");
                return false;
            }
            return true;
        }

        private void Generate()
        {
            string qnumRangeLower = txtQnumLower.Text;
            string qnumRangeUpper = txtQnumUpper.Text;
            bool singleDraft = rbDraft.Checked;
            Survey survey = (Survey)cboSurvey.SelectedItem;

            List<DraftQuestion> records = GetReportData();

            if (!string.IsNullOrWhiteSpace(qnumRangeLower) || !string.IsNullOrWhiteSpace(qnumRangeUpper))
                records = FilterForQnum(records);

            if (records.Count == 0)
            {
                MessageBox.Show("No records found!");
                return;
            }
            
            DraftReport report = new DraftReport();

            report.SelectedSurvey = survey;

            if (singleDraft)
            {
                SurveyDraft draft = (SurveyDraft)cboDraft.SelectedItem;
                draft.ExtraFields.AddRange(draft.ExtraFields);
                report.DraftInfo = draft;
            }

            report.Questions = records;
            report.CreateReport();
        }

        private bool HasCriteria()
        {
            if (cboSurvey.SelectedItem == null)
                return false;

            if (rbDraft.Checked && cboDraft.SelectedItem != null)
                return true;
            else if (rbDate.Checked && (dtpLower.Value != null || dtpUpper.Value != null))
                return true;
            else if (rbInvestigator.Checked && cboInvestigator.SelectedItem != null)
                return true;
            else
                return false;

        }

        private List<DraftQuestion> GetReportData()
        {
            Survey survID = (Survey)cboSurvey.SelectedItem;
            List<DraftQuestion> reportRecords;
            switch (ReportSource)
            {
                case DraftReportSource.ByDraft:
                    int draftID = (int)cboDraft.SelectedValue;
                    reportRecords = DBAction.GetDraftQuestions(survID, draftID);
                    break;
                case DraftReportSource.ByDate:
                    DateTime lower = dtpLower.Value;
                    DateTime upper = dtpUpper.Value;
                    reportRecords = DBAction.GetDraftQuestions(survID, lower, upper);
                    break;
                case DraftReportSource.ByInvestigator:
                    Person investigator = (Person)cboInvestigator.SelectedItem;
                    reportRecords = DBAction.GetDraftQuestions(survID, investigator);
                    break;
                default:
                    reportRecords = new List<DraftQuestion>();
                    break;
            }

            return reportRecords;
        }

        private List<DraftQuestion> FilterForQnum(List<DraftQuestion> records)
        {
            List<DraftQuestion> lowResults = new List<DraftQuestion>();
            bool low = false, high = false;
            if (!string.IsNullOrWhiteSpace(txtQnumLower.Text))
            {
                low = true;
                Int32.TryParse(txtQnumLower.Text, out int lower);

                foreach (DraftQuestion dq in records)
                {
                    if (Int32.TryParse(dq.Qnum.Substring(0, 3), out int qnum) && qnum >= lower)
                        lowResults.Add(dq);
                }
            }

            List<DraftQuestion> highResults = new List<DraftQuestion>();
            if (!string.IsNullOrWhiteSpace(txtQnumUpper.Text))
            {
                high = true;
                Int32.TryParse(txtQnumUpper.Text, out int upper);

                foreach (DraftQuestion dq in records)
                {
                    if (Int32.TryParse(dq.Qnum.Substring(0, 3), out int qnum) && qnum <= upper)
                        highResults.Add(dq);
                }
            }

            if (low && high)
            {
                records = lowResults.Intersect(highResults).ToList();
            }
            else if (low)
                records = lowResults;
            else if (high)
                records = highResults;

            return records;
        }

        private void UpdateReportType()
        {
            if (rbDraft.Checked)
                ReportSource = DraftReportSource.ByDraft;
            else if (rbDate.Checked)
                ReportSource = DraftReportSource.ByDate;
            else if (rbInvestigator.Checked)
                ReportSource = DraftReportSource.ByInvestigator;
            else
                ReportSource = DraftReportSource.Undefined;

            cboDraft.Enabled = rbDraft.Checked;
            dtpLower.Enabled = rbDate.Checked;
            dtpUpper.Enabled = rbDate.Checked;
            cboInvestigator.Enabled = rbInvestigator.Checked;
        }
        #endregion

        #region Menu Items
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Events
        private void DraftReport_Load(object sender, EventArgs e)
        {
            rbDraft.Checked = true;
            UpdateReportType();
        }

        private void DraftReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.RemovePopup(this);
        }

        private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null)
                return;

            Survey survey = (Survey)cboSurvey.SelectedItem;

            FilterBySurvey(survey);
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (!HasCriteria())
            {
                MessageBox.Show("Please select some criteria!");
                return;
            }

            if (ReportSource.Equals(DraftReportSource.Undefined))
            {
                MessageBox.Show("Invalid report source.");
                return;
            }

            Generate();
        }
        

        private void FilterType_Click(object sender, EventArgs e)
        {
            UpdateReportType();
        }

        private void Qnum_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                return;

            if (!CheckQnumRange(txt.Text))
                e.Cancel = true;
        }
        #endregion
       
    }
}
