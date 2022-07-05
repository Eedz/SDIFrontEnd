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
    public partial class HeadingReportForm : Form
    {
        public HeadingReportForm()
        {
            InitializeComponent();

            cboSurvey.DataSource = new List<SurveyRecord>(Globals.AllSurveys);
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";

            lstSelected.DisplayMember = "SurveyCode";
            lstSelected.ValueMember = "SID";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.RemovePopup(this);
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
            List<SurveyRecord> surveys = lstSelected.Items.Cast<SurveyRecord>().ToList();
            List<List<SurveyQuestion>> headingLists = new List<List<SurveyQuestion>>();
            foreach (SurveyRecord survey in surveys)
            {
                List<SurveyQuestion> headingList = DBAction.GetHeadingQuestions(survey.SurveyCode);
                headingLists.Add(headingList);
            }
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
