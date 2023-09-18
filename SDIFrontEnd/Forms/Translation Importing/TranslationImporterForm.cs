using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

using FM = FormManager;

namespace SDIFrontEnd
{
    // TODO remove lists before importing

    public partial class TranslationImporterForm : Form
    {
        #region Properties
        ImportType TypeOfImport;

        public object Target { get; set; }
        public Survey TargetSurvey { get; set; }
        public StudyWave TargetWave { get; set; }
        public Language TargetLanguage { get; set; }
        public List<Language> AvailableLanguages { get; set; }
        
        public bool Expanded { get; set; }
        
        List<Translation> failed;
        List<Translation> success;

        BindingSource bsImporter;
        BindingSource bsMissing;
        BindingSource bsDuplicates;
        BindingSource bsImported;
        BindingSource bsSuccess;
        BindingSource bsFailed;

        int narrowWidth = 560;
        int wideWidth = 1045;

        SurveyTranslationImporter SurveyImporter;
        WaveTranslationImporter WaveImporter;

        #endregion

        public TranslationImporterForm()
        {
            InitializeComponent();

            Setup();
        }

        /// <summary>
        /// Open a form to add a new language
        /// </summary>
        private void AddNewLanguage()
        {
            Languages frm = new Languages();

            frm = new Languages();
            frm.ShowDialog();

            AvailableLanguages = new List<Language>(Globals.AllLanguages.OrderBy(x => x.LanguageName));

            if (Target == null)
                return;

            if (TypeOfImport == ImportType.Single)
                GetLanguages((Survey)Target);
            else
                GetLanguages((StudyWave)TargetWave);
        }

        /// <summary>
        /// Check for errors in the document.
        /// </summary>
        /// <param name="fileName"></param>
        private void CheckDocument(string fileName)
        {
            if (TypeOfImport == ImportType.Single)
            {
                string errors = SurveyImporter.ErrorsExist(fileName);

                if (string.IsNullOrEmpty(errors))
                    cmdImport.Enabled = true;
                else
                {
                    txtFileName.Text = "";
                    MessageBox.Show("Errors found in document:\r\n\r\n" + errors);
                    cmdImport.Enabled = false;
                }
            }
            else
            {
                string errors =WaveImporter.ErrorsExist(fileName);

                if (string.IsNullOrEmpty(errors))
                    cmdImport.Enabled = true;
                else
                {
                    txtFileName.Text = "";
                    MessageBox.Show("Errors found in document:\r\n\r\n" + errors);
                    cmdImport.Enabled = false;
                }
            }

            
        }



        /// <summary>
        /// Returns true if the minimum required fields have been entered.
        /// </summary>
        /// <returns></returns>
        private bool CheckImport()
        {
            if (cboSurvey.SelectedItem == null && TypeOfImport == ImportType.Single)
            {
                MessageBox.Show("Choose a survey.");
                return false;
            }

            if (cboSurvey.SelectedItem == null && TypeOfImport == ImportType.Multi)
            {
                MessageBox.Show("Choose a wave.");
                return false;
            }

            if (cboLanguage == null || string.IsNullOrEmpty(TargetLanguage.LanguageName))
            {
                MessageBox.Show("Choose a language.");
                return false;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Choose a file to import.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Dispaly the results of the import.
        /// </summary>
        private void ShowResults(List<Translation> imported, List<Translation>duplicates, List<Translation> empties)
        {
            // VarNames that were blank
            bsMissing = new BindingSource();
            bsMissing.DataSource = empties;
            navMissing.BindingSource = bsMissing;
            bsMissing.PositionChanged += BsMissing_PositionChanged;

            txtMissingVarName.DataBindings.Clear();
            rtbMissingTranslation.DataBindings.Clear();
            txtMissingVarName.DataBindings.Add(new Binding("Text", bsMissing, "VarName"));

            txtMissingSurvey.DataBindings.Clear();
            txtMissingSurvey.DataBindings.Add(new Binding("Text", bsMissing, "Survey"));

            txtMissingSurvey.Visible = TypeOfImport == ImportType.Multi;
            if (TargetLanguage.RTL) rtbMissingTranslation.RightToLeft = RightToLeft.Yes;

            // VarNames that appeared more than once
            bsDuplicates = new BindingSource();
            bsDuplicates.DataSource = duplicates;
            navDuplicates.BindingSource = bsDuplicates;
            bsDuplicates.PositionChanged += BsDuplicates_PositionChanged;

            txtDuplicateVarName.DataBindings.Clear();
            rtbDuplicateTranslation.DataBindings.Clear();
            txtDuplicateVarName.DataBindings.Add(new Binding("Text", bsDuplicates, "VarName"));

            txtDuplicateSurvey.DataBindings.Clear();
            txtDuplicateSurvey.DataBindings.Add(new Binding("Text", bsDuplicates, "Survey"));

            txtDuplicateSurvey.Visible = TypeOfImport == ImportType.Multi;
            if (TargetLanguage.RTL) rtbDuplicateTranslation.RightToLeft = RightToLeft.Yes;

            // successfully imported VarNames
            bsImported = new BindingSource();
            bsImported.DataSource = imported;
            navImported.BindingSource = bsImported;
            bsImported.PositionChanged += BsImported_PositionChanged;

            txtImportedVarName.DataBindings.Clear();
            rtbImportedTranslation.DataBindings.Clear();
            txtImportedVarName.DataBindings.Add(new Binding("Text", bsImported, "VarName"));

            txtImportedSurvey.DataBindings.Clear();
            txtImportedSurvey.DataBindings.Add(new Binding("Text", bsImported, "Survey"));

            txtImportedSurvey.Visible = TypeOfImport == ImportType.Multi;
            if (TargetLanguage.RTL) rtbImportedTranslation.RightToLeft = RightToLeft.Yes;


            if (imported.Count == 1)
            {
                UpdateTranslationText(rtbImportedTranslation, (Translation)imported[0]);
                tabResults.SelectedTab = pageImported;
            }
            else
            {
                bsImported.Position = 1;
                bsImported.Position = 0;
                tabResults.SelectedTab = pageImported;

            }

            if (empties.Count == 0)
            {
                pageEmpties.Hide();

            }
            else if (empties.Count == 1)
            {
                UpdateTranslationText(rtbMissingTranslation, (Translation)empties[0]);
                tabResults.SelectedTab = pageEmpties;
            }
            else
            {
                bsMissing.Position = 1;
                bsMissing.Position = 0;
                tabResults.SelectedTab = pageEmpties;
            }

            if (duplicates.Count == 0)
            {
                pageDuplicates.Hide();
            }
            else if (duplicates.Count == 1)
            {
                UpdateTranslationText(rtbDuplicateTranslation, (Translation)duplicates[0]);
                tabResults.SelectedTab = pageDuplicates;
            }
            else
            {
                bsDuplicates.Position = 1;
                bsDuplicates.Position = 0;
                tabResults.SelectedTab = pageDuplicates;
            }

            Expanded = true;
            ExpandForm();

            //pageSuccess.Hide();
            //pageFailed.Hide();
        }

        /// <summary>
        /// Dispaly the results of the save.
        /// </summary>
        private void ShowSavedResults()
        {
            // VarNames that were successfully saved

            bsSuccess = new BindingSource();
            bsSuccess.DataSource = success;
            navSuccess.BindingSource = bsSuccess;
            bsSuccess.PositionChanged += BsSuccess_PositionChanged;

            txtSuccessVarName.DataBindings.Clear();
            rtbSuccess.DataBindings.Clear();
            txtSuccessVarName.DataBindings.Add(new Binding("Text", bsSuccess, "VarName"));

            // VarNames that failed to save
            bsFailed = new BindingSource();
            bsFailed.DataSource = failed;
            navFailed.BindingSource = bsFailed;
            bsFailed.PositionChanged += BsFailed_PositionChanged;

            txtFailedVarName.DataBindings.Clear();
            rtbFailed.DataBindings.Clear();
            txtFailedVarName.DataBindings.Add(new Binding("Text", bsFailed, "VarName"));

            bsSuccess.Position = 1;
            bsSuccess.Position = 0;
            bsFailed.Position = 1;
            bsFailed.Position = 0;

            MessageBox.Show("Translations Saved: " + success.Count + "\r\n" + "Translations failed to save: " + failed.Count);
        }

        /// <summary>
        /// Expand the form to show the results panel.
        /// </summary>
        private void ExpandForm()
        {
            if (!Expanded)
            {
                this.Width = narrowWidth;
            }
            else
            {
                this.Width = wideWidth;
            }

            //Expanded = !Expanded;
        }

        /// <summary>
        /// Unlocks the surveys specified in the Target Survey or Wave.
        /// </summary>
        private void UnlockSurveys()
        {
            if (TypeOfImport == ImportType.Single)
                DBAction.UnlockSurvey(TargetSurvey.SurveyCode, 5 * 60000);
            else
            {
                foreach (Survey s in TargetWave.Surveys)
                {
                    DBAction.UnlockSurvey(s.SurveyCode, 5 * 60000);
                }
            }
        }

        /// <summary>
        /// Locks the surveys specified in the Target Survey or Wave.
        /// </summary>
        private void LockSurveys()
        {
            if (TypeOfImport == ImportType.Single)
                DBAction.LockSurvey(TargetSurvey);
            else
            {
                foreach (Survey s in TargetWave.Surveys)
                {
                    DBAction.LockSurvey(s);
                }
            }
        }

        /// <summary>
        /// Given a translation object, use the Survey and VarName to determine if this question exists in the database. If found, add it to the "imported" list and remove it
        /// the duplicate and missing lists.
        /// </summary>
        /// <param name="t"></param>
        private void CheckQuestion(SurveyTranslationImporter Importer, Translation t)
        {
            if (string.IsNullOrEmpty(t.Survey) || string.IsNullOrEmpty(t.VarName))
            {
                MessageBox.Show("Both Survey and VarName are required.");
                return;
            }

            t.QID = DBAction.GetQuestionID(t.Survey, t.VarName);
            if (t.QID != 0)
            {

                if (Importer.imported.Any(x => x.QID == t.QID))
                {
                    MessageBox.Show("Question already exists in import list.");
                    return;
                }
                else
                {
                    MessageBox.Show("Question found! Added to import list.");
                    Importer.imported.Add(t);
                }

                if (Importer.empties.Contains(t))
                {
                    bsMissing.RemoveCurrent();
                    bsMissing.MoveNext();
                    bsMissing.MovePrevious();
                }
                else if (Importer.duplicates.Contains(t))
                {
                    bsDuplicates.RemoveCurrent();
                    bsDuplicates.MoveNext();
                    bsDuplicates.MovePrevious();
                }
            }
            else
            {
                MessageBox.Show("Question not found, could not add to import list.");
            }
        }

        /// <summary>
        /// Get a list of laguages used by the specified survey. English not included.
        /// </summary>
        /// <param name="selectedSurvey"></param>
        private void GetLanguages(Survey selectedSurvey)
        {
            // get all languages
            List<Language> allLanguages = AvailableLanguages;
            // get all survey languages
            List<Language> surveyLanguages = Globals.AllSurveys.First(x => x.SID == selectedSurvey.SID).LanguageList.Select(x => x.SurvLanguage).ToList();
            surveyLanguages.RemoveAll(x => x.LanguageName.Equals("English"));

            if (surveyLanguages.Count > 0)
            {
                // remove survey languages from main list
                allLanguages = allLanguages.Except(surveyLanguages).ToList();

                // add a "spacer" dummy language
                allLanguages.Insert(0, new Language() { ID = -1, LanguageName = "-----" });

                // add survey languages to the top
                foreach (Language l in surveyLanguages)
                {
                    allLanguages.Insert(0, l);
                }
            }

            allLanguages.RemoveAll(x => x.LanguageName.Equals("English"));

            // fill list
            cboLanguage.DataSource = allLanguages;
            cboLanguage.DisplayMember = "LanguageName";
            cboLanguage.ValueMember = "ID";

            // select first item
            if (surveyLanguages.Count > 0)
                cboLanguage.SelectedIndex = 0;
            else
                cboLanguage.SelectedItem = null;

            lblEnglishRouting.Visible = selectedSurvey.EnglishRouting;

            cboLanguage.Enabled = true;
        }

        /// <summary>
        /// Get a list of laguages used by the specified wave. English not included.
        /// </summary>
        /// <param name="selectedWave"></param>
        private void GetLanguages(StudyWave selectedWave)
        {
            // get all languages
            List<Language> allLanguages = AvailableLanguages;
            // get all survey languages
            List<Language> surveyLanguages = DBAction.ListLanguages(selectedWave);
            surveyLanguages.RemoveAll(x => x.LanguageName.Equals("English"));

            if (surveyLanguages.Count > 0)
            {
                // remove survey languages from main list
                allLanguages = allLanguages.Except(surveyLanguages).ToList();

                // add a "spacer" dummy language
                allLanguages.Insert(0, new Language() { ID = -1, LanguageName = "-----" });

                // add survey languages to the top
                foreach (Language l in surveyLanguages)
                {
                    allLanguages.Insert(0, l);
                }
            }

            // fill list
            cboLanguage.DataSource = allLanguages;
            cboLanguage.DisplayMember = "LanguageName";
            cboLanguage.ValueMember = "ID";

            // select first item
            if (surveyLanguages.Count > 0)
                cboLanguage.SelectedIndex = 0;
            else
                cboLanguage.SelectedItem = null;

            lblEnglishRouting.Visible = selectedWave.EnglishRouting;

            cboLanguage.Enabled = true;
        }

        /// <summary>
        /// Change the font of the rich text boxes to the specified font.
        /// </summary>
        /// <param name="font"></param>
        private void ChangeFont(string font)
        {
            rtbDuplicateTranslation.Font = new System.Drawing.Font(font, 10);
            rtbMissingTranslation.Font = new System.Drawing.Font(font, 10);
            rtbImportedTranslation.Font = new System.Drawing.Font(font, 10);
            rtbSuccess.Font = new System.Drawing.Font(font, 10);
            rtbFailed.Font = new System.Drawing.Font(font, 10);
        }

        /// <summary>
        /// Updates the RTF property of the specified RichTextBox control.
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="t"></param>
        private void UpdateTranslationText(RichTextBox rtb, Translation t)
        {
            rtb.Rtf = "";
            if (t != null)
            {
                rtb.Rtf = t.TranslationRTF;
            }
        }

        /// <summary>
        /// For each translation in the imported list, either create or update the database record.
        /// </summary>
        private void SaveTranslations(List<Translation> imported)
        {
            failed.Clear();
            success.Clear();
            // insert each question into the database 
            foreach (Translation t in imported)
            {
                if (t.ID > 0)
                    if (DBAction.UpdateTranslation(t) == 1)
                    {
                        failed.Add(t);
                    }
                    else
                    {
                        success.Add(t);
                    }
                else 
                    if (DBAction.InsertTranslation(t) == 1)
                    {
                        failed.Add(t);
                    }
                    else
                    {
                        success.Add(t);
                    }
            }
        }

        private void Setup()
        {
            TargetSurvey = null;
            TargetWave = null;
            TargetLanguage = new Language();

            success = new List<Translation>();
            failed = new List<Translation>();

            AvailableLanguages = new List<Language>(Globals.AllLanguages);

            Expanded = false;

            optMulti.CheckedChanged += ImportType_CheckedChanged;
            optSingle.CheckedChanged += ImportType_CheckedChanged;
            optSingle.Checked = true;
            TypeOfImport = ImportType.Single;

            tabResults.TabPages.Remove(pageSuccess);
            tabResults.TabPages.Remove(pageFailed);

            SurveyImporter = new SurveyTranslationImporter();
            WaveImporter = new WaveTranslationImporter();
        }

        /// <summary>
        /// Begin the import process if all the criteria are met. Then show the results.
        /// </summary>
        private void ImportTranslations()
        {
            if (!CheckImport())
                return;

            Sync();

            // create list of  translations
            if (TypeOfImport == ImportType.Single)
            {
                SurveyImporter.Import();
                ShowResults(SurveyImporter.imported, SurveyImporter.duplicates, SurveyImporter.empties);
            }
            else
            {
                WaveImporter.Import();
                ShowResults(WaveImporter.imported, WaveImporter.duplicates, WaveImporter.empties);
            }

            if (TargetLanguage.PreferredFont != null)
                ChangeFont(TargetLanguage.PreferredFont);
            else
                ChangeFont("Tahoma");

            MessageBox.Show("Table imported. Check the results before committing them to the database.");
            resultsPanel.Visible = true;
            cmdSave.Visible = true;
        }

        private void GetSourceFile()
        {
            FileDialog fd = new OpenFileDialog();
            DialogResult result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFileName.Text = fd.FileName;
                Sync();
                CheckDocument(fd.FileName);
            }
            else
            {
                txtFileName.Text = string.Empty;
            }
        }

        private bool AnyLocked()
        {
            switch (TypeOfImport)
            {
                case ImportType.Single:
                    if (SurveyImporter.TargetSurvey.Locked)
                        return true;
                    break;
                case ImportType.Multi:
                    if (WaveImporter.TargetWave.Surveys.Any(x => x.Locked))
                        return true;
                    break;
            }
            return false;
        }

        private void Sync()
        {
            if (TypeOfImport == ImportType.Single)
            {
                SurveyImporter = new SurveyTranslationImporter();
                SurveyImporter.fileName = txtFileName.Text;
                SurveyImporter.TargetSurvey = (Survey)cboSurvey.SelectedItem;
                SurveyImporter.TargetLanguage = (Language)cboLanguage.SelectedItem;
            }
            else
            {
                WaveImporter = new WaveTranslationImporter();
                WaveImporter.fileName = txtFileName.Text;
                WaveImporter.TargetWave = (StudyWave)cboSurvey.SelectedItem;
                WaveImporter.TargetLanguage = (Language)cboLanguage.SelectedItem;
            }
            
        }

        #region Events

        private void TranslationImporter_Load(object sender, EventArgs e)
        {
            ExpandForm();
        }

        private void TranslationImporter_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.RemovePopup(this);
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            ImportTranslations();
        }

        private void cmdAddLanguage_Click(object sender, EventArgs e)
        {
            AddNewLanguage();
        }

        /// <summary>
        /// Update or Create translation records as needed. Surveys are unlocked if needed and confirmed by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool toLock = false;

            // if any surveys are locked, ask to unlock
            if (AnyLocked())
            {
                if (MessageBox.Show("Locked survey(s) detected. Do you want to unlock the survey(s) before importing?", "Locked Survey(s)", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    UnlockSurveys();
                    toLock = true;
                }else
                {
                    return;
                }
            }

            if (MessageBox.Show("Do you want to overwrite the existing translations? Only the imported VarNames will be overwritten", "Overwrite", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (TypeOfImport == ImportType.Single)
            {
                SaveTranslations(SurveyImporter.imported);
            }else
            {
                SaveTranslations(WaveImporter.imported);
            }

            if (toLock)
                LockSurveys();

            ShowSavedResults();

            // TODO add survey comment about imported survey
            // TODO add survey processing record for imported survey
        }

        


        /// <summary>
        /// Open a Select File dialog, saving the resulting path in the Source Document text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>If the user selects a file, check it for required components.</remarks>
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            GetSourceFile();
        }

        /// <summary>
        /// Fill the language box with languages used by the selected survey or wave.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;

            Expanded = false;
            ExpandForm();
            cmdSave.Visible = false;

            if (cbo.SelectedItem == null)
            {
                TargetSurvey = null;
                TargetWave = null;

                cboSurvey.ResetText();
                cboLanguage.ResetText();
                cboLanguage.Enabled = false;
                cmdAddLanguage.Enabled = false;
            }
            else
            {
                if (TypeOfImport == ImportType.Single)
                {                   
                    Survey selectedSurvey = (Survey)cboSurvey.SelectedItem;
                    GetLanguages(selectedSurvey);
                    cmdAddLanguage.Enabled = true;
                }
                else if (TypeOfImport == ImportType.Multi)
                {                   
                    StudyWave selectedWave = (StudyWave)cboSurvey.SelectedItem;
                    GetLanguages(selectedWave);
                    cmdAddLanguage.Enabled = false;
                }
            }

        }

        /// <summary>
        /// Save the selected language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLanguage.SelectedItem != null)
                TargetLanguage = (Language)cboLanguage.SelectedItem;
            else
                TargetLanguage = null;

            if (TargetLanguage != null && TargetLanguage.ID == -1)
            {
                TargetLanguage = null;
                cboLanguage.SelectedIndex = 0;
            }

            cmdBrowse.Enabled = TargetLanguage != null;
        }

        /// <summary>
        /// Change the list of surveys/waves when the type of import changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int sel = Convert.ToInt32(rb.Tag);

            cboSurvey.SelectedIndexChanged -= cboSurvey_SelectedIndexChanged;

            if (sel == 1)
            {
                TypeOfImport = ImportType.Single;
                lblSurveyWave.Text = "Survey";

                cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
                cboSurvey.DisplayMember = "SurveyCode";
                cboSurvey.ValueMember = "SID";
                cboSurvey.SelectedItem = null;
            }
            else if (sel == 2)
            {
                TypeOfImport = ImportType.Multi;
                lblSurveyWave.Text = "Wave";

                cboSurvey.DataSource = new List<StudyWave>(Globals.AllWaves);
                cboSurvey.DisplayMember = "WaveCode";
                cboSurvey.ValueMember = "WaveCode";
                cboSurvey.SelectedItem = null;
            }

            cboSurvey.SelectedIndexChanged += cboSurvey_SelectedIndexChanged;
        }

        /// <summary>
        /// Check if the current item in the missing panel exists.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCheckMissing_Click(object sender, EventArgs e)
        {
            Translation t = (Translation)bsMissing.Current;

            if (t == null)
                return;

            CheckQuestion(SurveyImporter, t);
        }

        /// <summary>
        /// Check if the current item in the duplicates panel exists.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCheckDuplicate_Click(object sender, EventArgs e)
        {
            Translation t = (Translation)bsDuplicates.Current;

            if (t == null)
                return;

            CheckQuestion(SurveyImporter, t);
        }

        /// <summary>
        /// Update translation text for current item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsImported_PositionChanged(object sender, EventArgs e)
        {
            Translation t = (Translation)bsImported.Current;

            UpdateTranslationText(rtbImportedTranslation, t);
        }


        /// <summary>
        /// Update translation text for current item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsDuplicates_PositionChanged(object sender, EventArgs e)
        {
            Translation t = (Translation)bsDuplicates.Current;

            UpdateTranslationText(rtbDuplicateTranslation, t);
        }

        /// <summary>
        /// Update translation text for current item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsMissing_PositionChanged(object sender, EventArgs e)
        {
            Translation t = (Translation)bsMissing.Current;

            UpdateTranslationText(rtbMissingTranslation, t);
        }

        /// <summary>
        /// Update translation text for current item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsSuccess_PositionChanged(object sender, EventArgs e)
        {
            Translation t = (Translation)bsSuccess.Current;

            rtbSuccess.Rtf = "";
            if (t != null)
                rtbSuccess.Rtf = Utilities.GetRtfUnicodeEscapedString(t.TranslationRTF); ;
        }

        /// <summary>
        /// Update translation text for current item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsFailed_PositionChanged(object sender, EventArgs e)
        {
            Translation t = (Translation)bsFailed.Current;

            rtbFailed.Rtf = "";
            if (t != null)
                rtbFailed.Rtf = Utilities.GetRtfUnicodeEscapedString(t.TranslationRTF); ;
        }

        /// <summary>
        /// Close the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion  
    }
}
