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

// TODO CREATE USER SETTINGS FILE
// TODO PRELOAD wordings and response sets?
// then when a form needs to view the wording, it can query the global list
namespace ISISFrontEnd
{
    

    public partial class MainMenu : Form
    {
        public UserPrefs currentUser;
        public MainMenu()
        {
            InitializeComponent();
            Globals.CreateWorld();
            currentUser = DBAction.GetUser(Environment.UserName);
            // DBAction.FillUserSurveyFilters(currentUser);
            LabelSurveyEntryButtons();
            
        }

        public void LabelSurveyEntryButtons()
        {
            currentUser.SurveyEntryCodes.Clear();
            DBAction.FillUserSurveyFilters(currentUser);
            cmdOpenSurveyEntry.Text = currentUser.SurveyEntryCodes[0];
            cmdOpenSurveyEntry2.Text = currentUser.SurveyEntryCodes[1];
            cmdOpenSurveyEntry3.Text = currentUser.SurveyEntryCodes[2];
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }
        #region Main Menu Buttons

        private void cmdOpenSurveyEntry_Click(object sender, EventArgs e)
        {
            if (GetTab("Survey Entry") != null)
            {
                tabControl1.SelectTab("Survey Entry");
                return;
            }
            string surveyFilter = currentUser.SurveyEntryCodes[0];
            SurveyEntry frm = new SurveyEntry(surveyFilter);
            frm.frmParent = this;
            frm.key = "Survey Entry";
            frm.index = 1;

            try
            {
                AddTab(frm, "Survey Entry", "Survey Entry");
                tabControl1.TabPages[frm.key].Text = "Entry - " + surveyFilter;
            }
            catch
            {
                
            }

        }

        private void cmdOpenSurveyEntry2_Click(object sender, EventArgs e)
        {
            if (GetTab("Survey Entry 2") != null)
            {
                tabControl1.SelectTab("Survey Entry 2");
                return;
            }
            string surveyFilter = currentUser.SurveyEntryCodes[1];
            SurveyEntry frm = new SurveyEntry(surveyFilter);
            frm.frmParent = this;
            frm.key = "Survey Entry 2";
            frm.index = 2;

            try
            {
                AddTab(frm, "Survey Entry 2", "Survey Entry 2");
                tabControl1.TabPages[frm.key].Text = "Entry - " + surveyFilter;
            }
            catch { }
        }

        private void cmdOpenSurveyEntry3_Click(object sender, EventArgs e)
        {
            if (GetTab("Survey Entry 3") != null)
            {
                tabControl1.SelectTab("Survey Entry 3");
                return;
            }
            string surveyFilter = currentUser.SurveyEntryCodes[2];
            SurveyEntry frm = new SurveyEntry(surveyFilter);
            frm.frmParent = this;
            frm.key = "Survey Entry 3";
            frm.index = 3;

            try
            {
                AddTab(frm, "Survey Entry 3", "Survey Entry 3");
                tabControl1.TabPages[frm.key].Text = "Entry - " + surveyFilter;
            }
            catch { }
        }

        private void cmdOpenSurveyOverview_Click(object sender, EventArgs e)
        {

            if (GetTab("Survey Overview") != null)
            {
                tabControl1.SelectTab("Survey Overview");
                return;
            }

            SurveyOverview frm = new SurveyOverview();
            frm.frmParent = this;
            frm.key = "Survey Overview";

            AddTab(frm, "Survey Overview", "Survey Overview");
            
        }

        private void cmdOpenCreateSurvey_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CreateSurvey>().Count() == 1)
                Application.OpenForms.OfType<CreateSurvey>().First().Close();



            CreateSurvey frm = new CreateSurvey();
            frm.frmParent = this;
            frm.key = "Edit - ";

            AddTab(frm, "Edit - ", "Edit - ");

            
        }

        private void cmdOpenAssignLabels_Click(object sender, EventArgs e)
        {

            if (GetTab("Assign Labels") != null)
            {
                tabControl1.SelectTab("Assign Labels");
                return;
            }
            AssignLabels frm = new AssignLabels();

            frm.frmParent = this;
            frm.key = "Assign Labels";

            AddTab(frm, "Assign Labels", "Assign Labels");
        }

        private void cmdOpenRegionInfo_Click(object sender, EventArgs e)
        {
            RegionDetails frm = new RegionDetails();
            frm.frmParent = this;
            frm.key = "Region Details";

            AddTab(frm, "Region Details", "Region Details");
        }

        private void cmdOpenStudyInfo_Click(object sender, EventArgs e)
        {
            StudyDetails frm = new StudyDetails();
            frm.frmParent = this;
            frm.key = "Study Details";

            AddTab(frm, "Study Details", "Study Details");
        }

        private void cmdOpenWaveInfo_Click(object sender, EventArgs e)
        {
            WaveDetails frm = new WaveDetails();
            frm.frmParent = this;
            frm.key = "Wave Details";

            AddTab(frm, "Wave Details", "Wave Details");
        }

        private void cmdOpenStudyAttributes_Click(object sender, EventArgs e)
        {
            SurveyDetails frm = new SurveyDetails();
            frm.frmParent = this;
            frm.key = "Survey Details";

            AddTab(frm, "Survey Details", "Survey Details");
        }

        private void cmdOpenSurveyChecks_Click(object sender, EventArgs e)
        {
            SurveyCheckTracking frm = new SurveyCheckTracking();
            frm.frmParent = this;
            frm.key = "Survey Check Tracking";

            AddTab(frm, "Survey Check Tracking", "Survey Check Tracking");

        }

        private void cmdOpenCommentUsage_Click(object sender, EventArgs e)
        {
            CommentEntry frm = new CommentEntry();


            frm.Show();
        }

        private void cmdOpenSurveyEditor_Click(object sender, EventArgs e)
        {
            SurveyEditor frm = new SurveyEditor("4CV3");
            frm.frmParent = this;
            frm.key = "Survey Editor";
            AddTab(frm, "Survey Editor", "Survey Editor");
        }

        #endregion

        #region Menu Bar

        private void CountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // new country
        }


        private void ProjectWaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetTab("User Preferences") != null)
            {
                tabControl1.SelectTab("User Preferences");
                return;
            }

            UserPreferencesForm frm = new UserPreferencesForm(currentUser);
            frm.frmParent = this;
            frm.key = "User Preferences";

            AddTab(frm, "User Preferences", "User Preferences");

            frm.Show();
        }
        
        private void LabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabelManager frm = new LabelManager();
            frm.frmParent = this;
            frm.key = "Label Manager";

            AddTab(frm, "Label Manager", "Label Manager");

            frm.Show();
        }

        private void CohortListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CohortList frm = new CohortList();
            frm.frmParent = this;
            frm.key = "Cohort list";

            AddTab(frm, "Cohort list", "Cohort list");

            frm.Show();
        }

        private void UserGroupListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupList frm = new GroupList();
            frm.frmParent = this;
            frm.key = "Group list";

            AddTab(frm, "Group list", "Group list");

            frm.Show();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Show help screen, or open big book of SMG?");
            // open help screen? SMG big book?
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ISIS FrontEnd Ver 1.0");
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Tab-related methods
        /// <summary>
        /// Adds a new tab to the main tab control and adds the provided form to the tab.
        /// </summary>
        /// <param name="frm"></param>
        public void AddTab(Form frm, string key, string name)
        {

            frm.BringToFront();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

            tabControl1.TabPages.Add(key, name);
            tabControl1.TabPages[key].Controls.Add(frm);
            tabControl1.SelectTab(key);
        }

        public TabPage GetTab(string key)
        {
            return tabControl1.TabPages[key];
        }

        /// <summary>
        /// Removes the specified tab from the main tab control.
        /// </summary>
        /// <param name="key"></param>
        public void CloseTab(string key)
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[key]);
        }

        #endregion

        
    }
}
