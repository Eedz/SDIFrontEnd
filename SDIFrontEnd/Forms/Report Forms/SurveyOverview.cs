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
    public partial class SurveyOverview : Form
    {
        public SurveyOverview()
        {
            InitializeComponent();
        }

        #region Methods 

        private void SetupForm()
        {
            cboSurvey.ValueMember = "SurveyCode";
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.SelectedItem = null;

            lstSelected.DisplayMember = "SurveyCode";
            lstSelected.ValueMember = "SID";
        }

        private void AddSurvey(Survey survey)
        {
            if (!lstSelected.Items.Contains(survey))
                lstSelected.Items.Add(survey);

            if (cboSurvey.SelectedIndex >= 0)
                cboSurvey.SelectedIndex++;
        }

        private void RemoveSurvey()
        {
            int sel = lstSelected.SelectedIndex; // retain last selected index

            lstSelected.Items.Remove(lstSelected.SelectedItem); // remove selected item

            // reselect the last selected index, or the last item if we removed the last item
            if (lstSelected.Items.Count > 0)
                if (sel >= lstSelected.Items.Count)
                    lstSelected.SelectedIndex = lstSelected.Items.Count - 1;
                else
                    lstSelected.SelectedIndex = sel;
        }

        private List<ReportSurvey> GetSurveys()
        {
            List<ReportSurvey> list = new List<ReportSurvey>();
            foreach (Survey survey in lstSelected.Items)
            {
                survey.Questions.Clear();
                survey.AddQuestions(DBAction.GetSurveyQuestions(survey));
                list.Add(new ReportSurvey(survey));
            }
            return list;
        }

        private void GenerateReport()
        {
            SurveyReport SO = new SurveyReport();
            var surveys = GetSurveys();
            string title = string.Join(", ", surveys.Select(x => x.SurveyCode).ToArray());

            foreach (ReportSurvey survey in surveys)
            {
                SO.Surveys.Add(survey);
            }
            
            SO.Surveys[0].Qnum = true;
            SO.Surveys[0].Primary = true;

            if (SO.Surveys.Count > 1)
            {
                SO.SurveyCompare = new Comparison();
                SO.CompareWordings = false; // wordings not include in this report
            }

            foreach (ReportSurvey rs in SO.Surveys)
            {
                rs.VarLabelCol = true;
                if (chkTC.Checked)
                {
                    rs.TopicLabelCol = true;
                    rs.ContentLabelCol = true;
                }
            }
            SO.ShowAllQnums = true;
            SO.ShowAllVarNames = true;
            SO.ShowQuestion = false;

            SO.GenerateReport();
            SO.FileName = "\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\SDI\\Reports\\External\\";
            SO.OutputReportTableXML(title + " Survey Overview");
        }
        #endregion

        #region Events

        private void SurveyOverview_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        private void SurveyOverview_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (lstSelected.Items.Count == 0)
                return;

            GenerateReport();
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports");
        }

        private void cmdAddSurvey_Click(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null) return;

            AddSurvey((Survey)cboSurvey.SelectedItem);

        }

        private void cmdRemoveSurvey_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem == null) return;

            RemoveSurvey();
        }
        #endregion

        



        
    }
}
