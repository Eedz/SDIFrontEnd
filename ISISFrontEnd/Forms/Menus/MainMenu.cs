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
using System.IO;

// TODO CREATE USER SETTINGS FILE
namespace ISISFrontEnd
{
    public partial class MainMenu : Form
    {
        public UserPrefs CurrentUser;       

        public MainMenu()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            // 221, 241, 185 green


            // preload some objects from the database
            Globals.CreateWorld();
            // load the current user
            CurrentUser = Globals.CurrentUser;

            this.Tag = 1;
            FormManager.Add(this);

            // add this event to the FormManager handler so that it removes forms when we close their tab.
            FormManager.FormRemoved += this.FormRemovedHandler;
            FormManager.PopupRemoved += this.PopupRemovedHandler;

            // add this event to the FormManager handler so that it adds a tab with the form that was added to the collection.
            FormManager.FormAdded += FormManager_FormAdded;
            FormManager.PopupAdded += FormManager_PopupAdded;
        }

        private void FormManager_FormAdded(object sender, FormAddedEventArgs e)
        {
            AddTab(e.form, e.key, e.form.Name);
        }

        private void FormManager_PopupAdded(object sender, FormPopupAddedEventArgs e)
        {
            e.form.BringToFront();
            e.form.TopLevel = true;
            //e.form.FormBorderStyle = FormBorderStyle.None;
            e.form.Show();
        }

        public void FormRemovedHandler(object sender, FormRemovedEventArgs e)
        {
            CloseTab(e.key);
            LabelSurveyEditorButtons();
        }

        public void PopupRemovedHandler(object sender, FormPopupRemovedEventArgs e)
        {
           
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            CheckBackup();
            CheckAutoSurveys();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            LabelSurveyEditorButtons();

            // check for renumbered surveys
            if (Globals.RenumberedSurveys.Count > 0)
            {
                ShowRenumberSurveys frm = new ShowRenumberSurveys(Globals.RenumberedSurveys);
                frm.BringToFront();
                frm.TopLevel = true;
                frm.Owner = this;
                frm.Show();
            }
        }

        #region Main Menu Buttons

        //
        // Survey Editor Block
        // 
        private void cmdOpenSurveyEditor_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyEditor", 1))
            {
                tabControl1.SelectTab("SurveyEditor1");
                return;
            }
            
            SurveyEditor frm = new SurveyEditor(CurrentUser.SurveyEntryHistory[0].Key);
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor2_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyEditor", 2))
            {
                tabControl1.SelectTab("SurveyEditor2");
                return;
            }

            SurveyEditor frm = new SurveyEditor(CurrentUser.SurveyEntryHistory[1].Key);
            frm.Tag = 2;
            FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor3_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyEditor", 3))
            {
                tabControl1.SelectTab("SurveyEditor3");
                return;
            }

            SurveyEditor frm = new SurveyEditor(CurrentUser.SurveyEntryHistory[2].Key);
            frm.Tag = 3;
            FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor4_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyEditor", 4))
            {
                tabControl1.SelectTab("SurveyEditor4");
                return;
            }

            SurveyEditor frm = new SurveyEditor(CurrentUser.SurveyEntryHistory[3].Key);
            frm.Tag = 4;
            FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor5_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyEditor", 5))
            {
                tabControl1.SelectTab("SurveyEditor5");
                return;
            }

            SurveyEditor frm = new SurveyEditor(CurrentUser.SurveyEntryHistory[4].Key);
            frm.Tag = 5;
            FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor6_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyEditor", 6))
            {
                tabControl1.SelectTab("SurveyEditor6");
                return;
            }

            SurveyEditor frm = new SurveyEditor(CurrentUser.SurveyEntryHistory[5].Key);
            frm.Tag = 6;
            FormManager.Add(frm);
        }

        //
        // Search
        //

        private void cmdOpenQuestionSearch_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("QuestionSearch"))
            {
                tabControl1.SelectTab("QuestionSearch");
                return;
            }

            QuestionSearch frm = new QuestionSearch();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenRespOptionSearch_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("RespOptionSearch"))
            {
                tabControl1.SelectTab("RespOptionSearch");
                return;
            }

            ResponseSetSearch frm = new ResponseSetSearch();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenCommentSearch_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("CommentSearch"))
            {
                tabControl1.SelectTab("CommentSearch1");
                return;
            }

            CommentSearch frm = new CommentSearch();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        

        //
        // Variable Info
        // 

        private void cmdOpenAssignLabels_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("AssignLabels"))
            {
                tabControl1.SelectTab("AssignLabels1");
                return;
            }
            
            AssignLabels2 frm = new AssignLabels2();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenAssignLabelsJIT_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("AssignLabelsJIT"))
            {
                tabControl1.SelectTab("AssignLabelsJIT1");
                return;
            }

            AssignLabels frm = new AssignLabels();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenVarUsage_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("VarNameUsage"))
            {
                
                return;
            }

            VarNameUsage frm = new VarNameUsage();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenRenameVars_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("RenameVars"))
            {
                return;
            }

            RenameVars frm = new RenameVars();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenVariableInfo_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("VariableInformation"))
            {
                tabControl1.SelectTab("VariableInformation1");
                return;
            }

            VariableInformation frm = new VariableInformation();
            frm.Tag = 1;
            FormManager.Add(frm);

        }

        private void cmdOpenPrefixList_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("PrefixList"))
            {
                tabControl1.SelectTab("PrefixList1");
                return;
            }

            PrefixList frm = new PrefixList();
            frm.Tag = 1;
            FormManager.Add(frm);
        }



        // 
        // Reports
        // 

        private void cmdExternalReportsMenu_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("ExternalReportsMenu"))
            {
                tabControl1.SelectTab("ExternalReportsMenu1");
                return;
            }

            ExternalReportsMenu frm = new ExternalReportsMenu();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenHarmonyReport_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("HarmonyReport"))
            {
               // tabControl1.SelectTab("HarmonyReport1");
                return;
            }

            HarmonyReportForm frm = new HarmonyReportForm();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenProductCrosstab_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("ProductCrosstab"))
            {
                tabControl1.SelectTab("ProductCrosstab1");
                return;
            }

            ProductCrosstab frm = new ProductCrosstab();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        //
        // Drafts
        //
        private void cmdOpenDraftImporter_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyDraftImportForm"))
            {
                return;
            }

            SurveyDraftImportForm frm = new SurveyDraftImportForm();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        //
        // General
        //

        private void cmdOpenRegionInfo_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("RegionManager"))
            {
                tabControl1.SelectTab("RegionManager1");
                return;
            }

            RegionManager frm = new RegionManager();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenStudyInfo_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("StudyManager"))
            {
                tabControl1.SelectTab("StudynManager1");
                return;
            }

            StudyManager frm = new StudyManager();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenWaveInfo_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("WaveManager"))
            {
                tabControl1.SelectTab("WaveManager1");
                return;
            }

            WaveManager frm = new WaveManager();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenStudyAttributes_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyManager"))
            {
                tabControl1.SelectTab("SurveyManager1");
                return;
            }

            SurveyManager frm = new SurveyManager();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenTranslationImporter_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("TranslationImporter"))
            {
                return;
            }

            TranslationImporter frm = new TranslationImporter();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenSurveyChecks_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyChecksMenu"))
            {
                tabControl1.SelectTab("SurveyChecksMenu1");
                return;
            }

            SurveyChecksForm frm = new SurveyChecksForm();
            frm.Tag = 1;
            FormManager.Add(frm);           
        }

        private void cmdOpenCommentUsage_Click(object sender, EventArgs e)
        {

            if (FormManager.FormOpen("CommentEntry"))
            {
                
                return;
            }

            CommentEntry frm = new CommentEntry();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenPraccingMenu_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("PraccingMenu"))
            {
                tabControl1.SelectTab("PraccingMenu1");
                return;
            }

            PraccingMenu frm = new PraccingMenu();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenSurveyProcessing_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyProcessingEntry"))
            {
                tabControl1.SelectTab("SurveyProcessingEntry1");
                return;
            }
            SurveyProcessingEntry frm = new SurveyProcessingEntry();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenQuestionHistory_Click(object sender, EventArgs e)
        {
            //if (FormManager.FormOpen("QuestionHistory"))
            //{
            //    tabControl1.SelectTab("QuestionHistory1");
            //    return;
            //}
            //QuestionHistory.QuestionHistory frm = new QuestionHistory.QuestionHistory();
            //frm.Tag = 1;
            //FormManager.Add(frm);
        }



        #endregion

        #region Menu Bar

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStudyEntry frm = new NewStudyEntry();
            frm.ShowDialog();
        }

        private void projectWaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewWaveEntry frm = new NewWaveEntry();
            frm.ShowDialog();
        }

        private void surveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSurveyEntry frm = new NewSurveyEntry();
            frm.ShowDialog();
        }

        private void LabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLabelLibrary frm = new frmLabelLibrary();
            
            frm.ShowDialog();
        }

        private void CohortListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CohortList frm = new CohortList();
            
            frm.ShowDialog();
        }

        private void UserGroupListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserStateList frm = new UserStateList();
            
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonnelForm frm = new PersonnelForm();
            frm.ShowDialog();
        }

        private void canonicalVarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("CanonVarsEntry"))
            {
                tabControl1.SelectTab("CanonVarsEntry1");
                return;
            }

            CanonVarsEntry frm = new CanonVarsEntry(Globals.AllCanonVars);
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserPreferencesForm frm = new UserPreferencesForm(CurrentUser);

            frm.ShowDialog();
        }

        private void alternativeSpellingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimilarWordsList frm = new SimilarWordsList();
            frm.ShowDialog();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SMG Documentation\Big Book of SMG\MAIN ENTRANCE.onetoc2");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SDI FrontEnd Ver 4.0");
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        public void OpenForm(Form frm, bool withTab, string tabTitle = "")
        {
            FormManager.Add(frm);
            if (string.IsNullOrEmpty(tabTitle))
                tabTitle = frm.Text;

            if (withTab)
                AddTab(frm, frm.Name, tabTitle);
            else
                OpenPopup(frm, frm.Name, tabTitle);

        }

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
            tabControl1.TabPages[key].Text = frm.Text;
            tabControl1.SelectTab(key);
        }

        public void SelectTab (string key)
        {
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
            try
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages[key]);
            }catch
            {

            }
        }

        #endregion

        #region Popup Related Methods
        /// <summary>
        /// Adds a new tab to the main tab control and adds the provided form to the tab.
        /// </summary>
        /// <param name="frm"></param>
        public void OpenPopup(Form frm, string key, string name)
        {

            frm.BringToFront();
            frm.TopLevel = true;
            //frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

            
        }
        #endregion

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            TabControl t = (TabControl)sender;
            if (t.SelectedIndex != 0)
            { 
                Form f = (Form)t.TabPages[t.SelectedIndex].Controls[0];
                f.Activate();
            }
        }

        /// <summary>
        /// Change the Survey Editor labels to this user's last 6 surveys
        /// </summary>
        public void LabelSurveyEditorButtons()
        {
            cmdOpenSurveyEditor.Text = CurrentUser.SurveyEntryHistory[0].Key;
            cmdOpenSurveyEditor2.Text = CurrentUser.SurveyEntryHistory[1].Key;
            cmdOpenSurveyEditor3.Text = CurrentUser.SurveyEntryHistory[2].Key;
            cmdOpenSurveyEditor4.Text = CurrentUser.SurveyEntryHistory[3].Key;
            cmdOpenSurveyEditor5.Text = CurrentUser.SurveyEntryHistory[4].Key;
            cmdOpenSurveyEditor6.Text = CurrentUser.SurveyEntryHistory[5].Key;
        }


        private void CheckBackup()
        {
            DateTime lastWorkDay = DateTime.Today;
            if (DateTime.Today.Date.DayOfWeek == DayOfWeek.Monday) 
                lastWorkDay = lastWorkDay.AddDays(-3);
            else
                lastWorkDay = lastWorkDay.AddDays(-1);

            string path = Globals.BackupPath + lastWorkDay.Date.ToString("yyyy-MM-dd") + ".7z";
            if (File.Exists(path))
                lblBackupStatus.Text = "Backup for yesterday (" + lastWorkDay.ToString("g") + ") missing.";
            else
                lblBackupStatus.Visible = false;

        }

        private void CheckAutoSurveys()
        {
            DateTime lastWorkDay = DateTime.Today;
            if (DateTime.Today.Date.DayOfWeek == DayOfWeek.Monday)
                lastWorkDay = lastWorkDay.AddDays(-3);
            else
                lastWorkDay = lastWorkDay.AddDays(-1);

            List<Survey> changedSurveys = DBAction.GetChangedSurveys(lastWorkDay);

            if (changedSurveys.Count() == 0)
            {
                lblAutoSurveys.Text = "No surveys were changed " + lastWorkDay.Date.DayOfWeek + " (" + lastWorkDay.ToString("d") + ").";
                lblAutoSurveys.Visible = false;
                return;
            }

            List<string> missing = new List<string>();
            foreach (Survey s in changedSurveys)
            {
                string lastWkDay = Globals.AutoSurveysPath + s.SurveyCode + ", " + lastWorkDay.Date.ToString("d").Replace("-", "") + ".docx";
                string today = Globals.AutoSurveysPath + s.SurveyCode + ", " + lastWorkDay.ToString("d").Replace("-", "") + ".docx";
                if (!File.Exists(lastWkDay) && (!File.Exists(today)))
                {
                    missing.Add(s.SurveyCode);
                }
            }

            if (missing.Count > 0)
            {
                lblAutoSurveys.Text = "Automatic Surveys for " + lastWorkDay.Date.DayOfWeek + " (" + lastWorkDay.ToString("d") + ") are missing.";
                lblAutoSurveys.Visible = true;
            }
        }

        private void pageMain_Click(object sender, EventArgs e)
        {

        }
    }
}
