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
using System.IO;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class MainMenu : Form
    {
        public UserRecord CurrentUser;
        string autoSurveyStatus;
        string backupStatus;

        public MainMenu()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            // 221, 241, 185 green
            // 232, 202, 193 red

            // load the current user
            CurrentUser = Globals.CurrentUser;

            this.Tag = 1;
            FM.FormManager.Add(this);

            // add this event to the FormManager handler so that it removes forms when we close their tab.
            FM.FormManager.FormRemoved += this.FormRemovedHandler;
            FM.FormManager.PopupRemoved += this.PopupRemovedHandler;

            // add this event to the FormManager handler so that it adds a tab with the form that was added to the collection.
            FM.FormManager.FormAdded += FormManager_FormAdded;
            FM.FormManager.PopupAdded += FormManager_PopupAdded;

            this.worker.DoWork += BackgroundWorker1_DoWork;
            worker.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }


        private void FormManager_FormAdded(object sender, FM.FormAddedEventArgs e)
        {
            AddTab(e.form, e.key, e.form.Name);
        }

        private void FormManager_PopupAdded(object sender, FM.FormPopupAddedEventArgs e)
        {
            e.form.BringToFront();
            e.form.TopLevel = true;
            e.form.Show();
        }

        public void FormRemovedHandler(object sender, FM.FormRemovedEventArgs e)
        {
            // check if survey entry, if so, refresh SE buttons
            CloseTab(e.key);
            LabelSurveyEditorButtons();
        }

        public void PopupRemovedHandler(object sender, FM.FormPopupRemovedEventArgs e)
        {
           
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;

            backupStatus = BackupStatus();
            autoSurveyStatus = AutoSurveysStatus();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            lblBackupStatus.Text = backupStatus;
            lblBackupStatus.Visible = !string.IsNullOrEmpty(lblBackupStatus.Text);
            lblAutoSurveys.Text = autoSurveyStatus;
            lblAutoSurveys.Visible = !string.IsNullOrEmpty(lblAutoSurveys.Text);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();

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

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            worker.CancelAsync();
            Application.Exit();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            TabControl t = (TabControl)sender;
            if (t.SelectedIndex != 0)
            {
                Form f = (Form)t.TabPages[t.SelectedIndex].Controls[0];
                f.Activate();
            }
        }

        #region Menu Bar

        #region File
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

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Edit
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
            if (FM.FormManager.FormOpen("CanonVarsEntry"))
            {
                tabControl1.SelectTab("CanonVarsEntry1");
                return;
            }

            CanonVarsEntry frm = new CanonVarsEntry(Globals.AllCanonVars);
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }
        #endregion

        #region View

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("RegionManager"))
            {
                tabControl1.SelectTab("RegionManager1");
                return;
            }

            RegionManager frm = new RegionManager();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void studiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("StudyManager"))
            {
                tabControl1.SelectTab("StudynManager1");
                return;
            }

            StudyManager frm = new StudyManager();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void wavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("WaveManager"))
            {
                tabControl1.SelectTab("WaveManager1");
                return;
            }

            WaveManager frm = new WaveManager();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void surveysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("SurveyManager"))
            {
                tabControl1.SelectTab("SurveyManager1");
                return;
            }

            SurveyManager frm = new SurveyManager();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }
        #endregion

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewSurveyEntry frm = new NewSurveyEntry();
            frm.ShowDialog();
        }

        private void unlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("UnlockSurvey"))
            {

                return;
            }
            UnlockSurvey frm = new UnlockSurvey();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void viewTempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("TempVarViewer"))
            {

                return;
            }
            TempVarViewer frm = new TempVarViewer();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void viewOrphansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrphanVarForm();
        }

        #region Tools
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
        #endregion

        #region Help

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SMG Documentation\Big Book of SMG\MAIN ENTRANCE.onetoc2");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SDI FrontEnd Ver 4.0");
        }
        #endregion



        #endregion

        #region Survey Editor Block

        //
        // Survey Editor Block
        // 
        private void cmdOpenSurveyEditor_Click(object sender, EventArgs e)
        {
            int survID = CurrentUser.GetFilterID("frmSurveyEntry", 1);
            // check if a tab exists for this Survey
            foreach (Form se in FM.FormManager.List)
            {
                if (se is SurveyEditor && ((SurveyEditor)se).CurrentSurvey.SID == survID)
                {
                    tabControl1.SelectTab("SurveyEditor" + se.Tag);
                    return;
                }
            }
            // check if a tab exists for this SurveyEditor instance number
            if (FM.FormManager.FormOpen("SurveyEditor", 1))
            {
                tabControl1.SelectTab("SurveyEditor1");
                return;
            }
            
            SurveyEditor frm = new SurveyEditor(survID);
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor2_Click(object sender, EventArgs e)
        {
            int survID = CurrentUser.GetFilterID("frmSurveyEntry", 2);
            // check if a tab exists for this Survey
            foreach (Form se in FM.FormManager.List)
            {
                if (se is SurveyEditor && ((SurveyEditor)se).CurrentSurvey.SID == survID)
                {
                    tabControl1.SelectTab("SurveyEditor" + se.Tag);
                    return;
                }
            }
            // check if a tab exists for this SurveyEditor instance number
            if (FM.FormManager.FormOpen("SurveyEditor", 2))
            {
                tabControl1.SelectTab("SurveyEditor2");
                return;
            }
            
            SurveyEditor frm = new SurveyEditor(survID);
            frm.Tag = 2;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor3_Click(object sender, EventArgs e)
        {
            int survID = CurrentUser.GetFilterID("frmSurveyEntry", 3);
            // check if a tab exists for this Survey
            foreach (Form se in FM.FormManager.List)
            {
                if (se is SurveyEditor && ((SurveyEditor)se).CurrentSurvey.SID == survID)
                {
                    tabControl1.SelectTab("SurveyEditor" + se.Tag);
                    return;
                }
            }
            // check if a tab exists for this SurveyEditor instance number
            if (FM.FormManager.FormOpen("SurveyEditor", 3))
            {
                tabControl1.SelectTab("SurveyEditor3");
                return;
            }

            SurveyEditor frm = new SurveyEditor(survID);
            frm.Tag = 3;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor4_Click(object sender, EventArgs e)
        {
            int survID = CurrentUser.GetFilterID("frmSurveyEntry", 4);
            // check if a tab exists for this Survey
            foreach (Form se in FM.FormManager.List)
            {
                if (se is SurveyEditor && ((SurveyEditor)se).CurrentSurvey.SID == survID)
                {
                    tabControl1.SelectTab("SurveyEditor" + se.Tag);
                    return;
                }
            }
            // check if a tab exists for this SurveyEditor instance number
            if (FM.FormManager.FormOpen("SurveyEditor", 4))
            {
                tabControl1.SelectTab("SurveyEditor4");
                return;
            }

            SurveyEditor frm = new SurveyEditor(survID);
            frm.Tag = 4;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor5_Click(object sender, EventArgs e)
        {
            int survID = CurrentUser.GetFilterID("frmSurveyEntry", 5);
            // check if a tab exists for this Survey
            foreach (Form se in FM.FormManager.List)
            {
                if (se is SurveyEditor && ((SurveyEditor)se).CurrentSurvey.SID == survID)
                {
                    tabControl1.SelectTab("SurveyEditor" + se.Tag);
                    return;
                }
            }
            // check if a tab exists for this SurveyEditor instance number
            if (FM.FormManager.FormOpen("SurveyEditor", 5))
            {
                tabControl1.SelectTab("SurveyEditor5");
                return;
            }

            SurveyEditor frm = new SurveyEditor(survID);
            frm.Tag = 5;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenSurveyEditor6_Click(object sender, EventArgs e)
        {
            int survID = CurrentUser.GetFilterID("frmSurveyEntry", 6);
            // check if a tab exists for this Survey
            foreach (Form se in FM.FormManager.List)
            {
                if (se is SurveyEditor && ((SurveyEditor)se).CurrentSurvey.SID == survID)
                {
                    tabControl1.SelectTab("SurveyEditor" + se.Tag);
                    return;
                }
            }
            // check if a tab exists for this SurveyEditor instance number
            if (FM.FormManager.FormOpen("SurveyEditor", 6))
            {
                tabControl1.SelectTab("SurveyEditor6");
                return;
            }

            SurveyEditor frm = new SurveyEditor(survID);
            frm.Tag = 6;
            FM.FormManager.Add(frm);
        }

        #endregion

        #region Survey Info Forms
        //
        // Survey Info
        // 

        private void cmdOpenStudyAttributes_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("SurveyManager"))
            {
                tabControl1.SelectTab("SurveyManager1");
                return;
            }

            SurveyManager frm = new SurveyManager();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenSurveyProcessing_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("SurveyProcessingEntry"))
            {
                tabControl1.SelectTab("SurveyProcessingEntry1");
                return;
            }
            SurveyProcessingEntry frm = new SurveyProcessingEntry();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenSurveyChecks_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("SurveyChecksMenu"))
            {
                tabControl1.SelectTab("SurveyChecksMenu1");
                return;
            }

            SurveyChecksForm frm = new SurveyChecksForm();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenTranslationImporter_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("TranslationImporter"))
            {
                return;
            }

            TranslationImporterForm frm = new TranslationImporterForm();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        #endregion

        #region Search Forms
        //
        // Search
        //

        private void cmdOpenQuestionSearch_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("QuestionSearch"))
            {
                tabControl1.SelectTab("QuestionSearch1");
                return;
            }

            QuestionSearch frm = new QuestionSearch();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenRespOptionSearch_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("ResponseSetSearch"))
            {
                tabControl1.SelectTab("ResponseSetSearch1");
                return;
            }

            ResponseSetSearch frm = new ResponseSetSearch();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenCommentSearch_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("CommentSearch"))
            {
                tabControl1.SelectTab("CommentSearch1");
                return;
            }

            CommentSearch frm = new CommentSearch();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        #endregion

        #region Variable Info Forms
        //
        // Variable Info
        // 

        private void cmdOpenVarChangesMenu_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("VarChangesMenu"))
            {
                tabControl1.SelectTab("VarChangesMenu1");
                return;
            }

            VarNameMenu frm = new VarNameMenu();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenAssignLabelsJIT_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("AssignLabels"))
            {
                tabControl1.SelectTab("AssignLabels1");
                return;
            }

            AssignLabels frm = new AssignLabels();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenVariableInfo_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("VariableInformation"))
            {
                tabControl1.SelectTab("VariableInformation1");
                return;
            }

            VariableInformation frm = new VariableInformation();
            frm.Tag = 1;
            FM.FormManager.Add(frm);

        }

        private void cmdOpenCommentUsage_Click(object sender, EventArgs e)
        {

            if (FM.FormManager.FormOpen("CommentEntry"))
            {

                return;
            }

            CommentEntry frm = new CommentEntry();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenPrefixList_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("PrefixList"))
            {
                tabControl1.SelectTab("PrefixList1");
                return;
            }

            PrefixList frm = new PrefixList(Globals.AllPrefixes);
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdParallelQuestions_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("ParallelQuestions"))
            {
                tabControl1.SelectTab("ParallelQuestions1");
                return;
            }

            ParallelQuestions frm = new ParallelQuestions();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenQuestionHistory_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("QuestionHistory"))
            {
                tabControl1.SelectTab("QuestionHistory1");
                return;
            }
            QuestionHistory frm = new QuestionHistory();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        #endregion

        #region Report Forms
        // 
        // Reports
        // 

        private void cmdExternalReportsMenu_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("ExternalReportsMenu"))
            {
                tabControl1.SelectTab("ExternalReportsMenu1");
                return;
            }

            ExternalReportsMenu frm = new ExternalReportsMenu();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenHarmonyReport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("HarmonyReport"))
            {
               // tabControl1.SelectTab("HarmonyReport1");
                return;
            }

            HarmonyReportForm frm = new HarmonyReportForm();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenProductCrosstab_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("ProductCrosstab"))
            {
                return;
            }

            ProductCrosstab frm = new ProductCrosstab();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenParallelVarReport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("ParallelVarReport"))
            {
                return;
            }

            ParallelVarReport frm = new ParallelVarReport();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenTCReport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("LabelReport"))
            {
                return;
            }

            LabelReport frm = new LabelReport();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        #endregion

        #region Praccing Forms
        private void cmdOpenPraccingEntry_Click(object sender, EventArgs e)
        {

            if (FM.FormManager.FormOpen("PraccingEntry", 1))
            {
                ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("PraccingEntry1");
                return;
            }

            var state = Globals.CurrentUser.FormStates.Where(x => x.FormName.Equals("frmIssuesTracking") && x.FormNum == 1).First();
            int survID = 899;
            if (state != null) survID = state.FilterID;
            PraccingEntry frm = new PraccingEntry(survID);

            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenIssuesImport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("frmPraccingIssuesImport", 1))
            {
                tabControl1.SelectTab("frmPraccingIssuesImport1");
                return;
            }

            frmPraccingIssuesImport frm = new frmPraccingIssuesImport();

            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenPraccingReport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("PraccingReportForm", 1))
            {
                tabControl1.SelectTab("PraccingReportForm1");
                return;
            }

            PraccingReportForm frm = new PraccingReportForm();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdPraccingSheet_Click(object sender, EventArgs e)
        {
            PraccingSheet frm = new PraccingSheet();
            frm.ShowDialog();
           
        }

        private void cmdPraccingForm_Click(object sender, EventArgs e)
        {
            PraccingReportBlank report = new PraccingReportBlank();

            report.CreateReport();
        }

        #endregion

        #region Draft Forms
        //
        // Drafts
        //

        private void cmdOpenDraftManager_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("DraftManager"))
            {
                ((MainMenu)this.Parent.Parent.Parent).SelectTab("DraftManager1");
                return;
            }

            DraftManager frm = new DraftManager();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenDraftSearch_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("DraftSearch"))
            {
                ((MainMenu)this.Parent.Parent.Parent).SelectTab("DraftSearch1");
                return;
            }

            DraftSearch frm = new DraftSearch();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenDraftReport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("DraftReport"))
            {
                return;
            }

            DraftReportForm frm = new DraftReportForm();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenDraftImporter_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("SurveyDraftImportForm"))
            {
                return;
            }

            SurveyDraftImportForm frm = new SurveyDraftImportForm();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
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

            try
            {
                frm.Show();
                tabControl1.TabPages.Add(key, name);
                tabControl1.TabPages[key].Controls.Add(frm);
                tabControl1.TabPages[key].Text = frm.Text;
                tabControl1.TabPages[key].AutoScroll = true;
                tabControl1.SelectTab(key);
            }
            catch
            {

            }

            
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

        

        /// <summary>
        /// Change the Survey Editor labels to this user's last 6 surveys
        /// </summary>
        public void LabelSurveyEditorButtons()
        {
            cmdOpenSurveyEditor.Text = GetEditorCode(1);
            cmdOpenSurveyEditor2.Text = GetEditorCode(2);
            cmdOpenSurveyEditor3.Text = GetEditorCode(3);
            cmdOpenSurveyEditor4.Text = GetEditorCode(4);
            cmdOpenSurveyEditor5.Text = GetEditorCode(5);
            cmdOpenSurveyEditor6.Text = GetEditorCode(6);
        }

        public string GetEditorCode(int formNum)
        {
            int survID = CurrentUser.GetFilterID("frmSurveyEntry", formNum);
            string surveyCode = string.Empty;
            var survey = Globals.AllSurveys.Where(x => x.SID == survID).FirstOrDefault();
            if (survey != null)
                surveyCode = survey.SurveyCode;

            return surveyCode;
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
                lblBackupStatus.Text = "Backup for yesterday (" + lastWorkDay.ShortDate() + ") missing.";
            else
                lblBackupStatus.Visible = false;

        }

        private string BackupStatus()
        {
            DateTime lastWorkDay = DateTime.Today;
            if (DateTime.Today.Date.DayOfWeek == DayOfWeek.Monday)
                lastWorkDay = lastWorkDay.AddDays(-3);
            else
                lastWorkDay = lastWorkDay.AddDays(-1);

            string path = Globals.BackupPath + lastWorkDay.Date.ToString("yyyy-MM-dd") + ".7z";
            if (!File.Exists(path))
                return "Backup for yesterday (" + lastWorkDay.ShortDate() + ") missing.";
            else
                return string.Empty;

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

        private string AutoSurveysStatus()
        {
            DateTime lastWorkDay = DateTime.Today;
            if (DateTime.Today.Date.DayOfWeek == DayOfWeek.Monday)
                lastWorkDay = lastWorkDay.AddDays(-3);
            else
                lastWorkDay = lastWorkDay.AddDays(-1);

            List<Survey> changedSurveys = DBAction.GetChangedSurveys(lastWorkDay);

            if (changedSurveys.Count() == 0)
            {
                return "No surveys were changed " + lastWorkDay.Date.DayOfWeek + " (" + lastWorkDay.ToString("d") + ").";
            }

            int count = 0;
            foreach (Survey s in changedSurveys)
            {
                string lastWkDay = Globals.AutoSurveysPath + s.SurveyCode + ", " + lastWorkDay.Date.ToString("d").Replace("-", "") + ".docx";
                string today = Globals.AutoSurveysPath + s.SurveyCode + ", " + lastWorkDay.ToString("d").Replace("-", "") + ".docx";
                if (!File.Exists(lastWkDay) && (!File.Exists(today)))
                    count++;               
            }

            if (count > 0)
            {
                return "Automatic Surveys for " + lastWorkDay.Date.DayOfWeek + " (" + lastWorkDay.ToString("d") + ") are missing.";
            }else
            {
                return string.Empty;
            }

        }

        

        private void OpenOrphanVarForm()
        {
            Form newfrm = new Form();
            newfrm.Text = "Orphan Variables";

            DataGridView dgv = new DataGridView();
            newfrm.Controls.Add(dgv);

            dgv.Dock = DockStyle.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn chVarName = new DataGridViewTextBoxColumn();
            chVarName.HeaderText = "VarName";
            chVarName.DataPropertyName = "VarName";
            DataGridViewTextBoxColumn chVarLabel = new DataGridViewTextBoxColumn();
            chVarLabel.HeaderText = "VarLabel";
            chVarLabel.DataPropertyName = "VarLabel";
            DataGridViewTextBoxColumn chContent = new DataGridViewTextBoxColumn();
            chContent.HeaderText = "Content";
            chContent.DataPropertyName = "Content";
            DataGridViewTextBoxColumn chTopic = new DataGridViewTextBoxColumn();
            chTopic.HeaderText = "Topic";
            chTopic.DataPropertyName = "Topic";
            DataGridViewTextBoxColumn chDomain = new DataGridViewTextBoxColumn();
            chDomain.HeaderText = "Domain";
            chDomain.DataPropertyName = "Domain";
            DataGridViewTextBoxColumn chProduct = new DataGridViewTextBoxColumn();
            chProduct.HeaderText = "Product";
            chProduct.DataPropertyName = "Product";

            dgv.Columns.Add(chVarName);
            dgv.Columns.Add(chVarLabel);
            dgv.Columns.Add(chContent);
            dgv.Columns.Add(chTopic);
            dgv.Columns.Add(chDomain);
            dgv.Columns.Add(chProduct);

            dgv.DataSource = DBAction.GetOrphanVarNames();

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                switch (dgv.Columns[i].Name)
                {
                    case "ID":
                    case "CountryCode":
                    case "StandardForm":
                    case "Prefix":
                    case "Number":
                    case "Suffix":
                    case "RefVarLabel":
                    case "RefVarName":
                        dgv.Columns[i].Visible = false;
                        break;
                }
            }
            newfrm.FormBorderStyle = FormBorderStyle.FixedSingle;
            newfrm.Width = 900;
            newfrm.Height = 600;

            newfrm.Show();
        }
    }
}
