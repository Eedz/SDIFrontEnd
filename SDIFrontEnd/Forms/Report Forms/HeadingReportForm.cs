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
    public partial class HeadingReportForm : Form
    {
        public HeadingReportForm()
        {
            InitializeComponent();

            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";

            lstSelected.DisplayMember = "SurveyCode";
            lstSelected.ValueMember = "SID";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.RemovePopup(this);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null) return;

            AddSurvey((Survey)cboSurvey.SelectedItem);
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem == null) return;

            int sel = lstSelected.SelectedIndex; // retain last selected index

            lstSelected.Items.Remove(lstSelected.SelectedItem); // remove selected item

            // reselect the last selected index, or the last item if we removed the last item
            if (lstSelected.Items.Count > 0)
                if (sel >= lstSelected.Items.Count)
                    lstSelected.SelectedIndex = lstSelected.Items.Count - 1;
                else
                    lstSelected.SelectedIndex = sel;
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            // get heading list for each survey
            List<Survey> surveys = lstSelected.Items.Cast<Survey>().ToList();
            List<List<Heading>> headingLists = new List<List<Heading>>();

            foreach (Survey survey in surveys)
            {
                List<Heading> headingList = DBAction.GetHeadingQuestions(survey);
                headingLists.Add(headingList);
            }

            HeadingReport report = new HeadingReport(headingLists);
            report.SelectedSurveys = lstSelected.Items.Cast<Survey>().ToList();
            report.IncludeQnum = chkIncludeQnum.Checked;
            report.IncludeFirstVarName = chkIncludeVarNames.Checked;
            report.IncludeLastVarName = chkIncludeVarNames.Checked;
            report.MatchStyle = ReportMatching.None;
            report.CreateReport();
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports");
        }

        public void AddSurvey(Survey survey)
        {
            if (!lstSelected.Items.Contains(survey))
                lstSelected.Items.Add(survey);

            if (cboSurvey.SelectedIndex >= 0)
                cboSurvey.SelectedIndex++;
        }

        
    }
}
