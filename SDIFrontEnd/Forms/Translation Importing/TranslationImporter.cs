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

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


using OpenXMLHelper;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SDIFrontEnd
{
    // TODO remove lists before importing

    public partial class TranslationImporter : Form
    {
        public enum ImportType { Single, Multi };

        #region Properties
        ImportType TypeOfImport;

        int VarNameColumn;
        int QuestionTextColumn;
        int SurveysColumn;

        public SurveyRecord TargetSurvey { get; set; }
        public StudyWaveRecord TargetWave { get; set; }
        public Language TargetLanguage { get; set; }
        public List<Language> AvailableLanguages { get; set; }
        
        public bool Bilingual { get; set; }
        public bool NonLatin { get; set; }

        public bool Expanded { get; set; }
        
        List<Translation> importedTranslations;
        List<Translation> empties;
        List<Translation> duplicates;
        List<Translation> failed;
        List<Translation> success;

        BindingSource bsForm;
        BindingSource bsMissing;
        BindingSource bsDuplicates;
        BindingSource bsImported;
        BindingSource bsSuccess;
        BindingSource bsFailed;



        bool errorsExist;
        #endregion

        public TranslationImporter()
        {
            InitializeComponent();

            TargetSurvey = null;
            TargetWave = null;
            TargetLanguage = new Language();

            importedTranslations = new List<Translation>();
            empties = new List<Translation>();
            duplicates = new List<Translation>();
            success = new List<Translation>();
            failed = new List<Translation>();

            bsForm = new BindingSource();
            bsForm.DataSource = this;

            AvailableLanguages = DBAction.ListLanguages();

            chkBilingual.DataBindings.Add("Checked", bsForm, "Bilingual");

            Expanded = false;
            
            optMulti.CheckedChanged += ImportType_CheckedChanged;
            optSingle.CheckedChanged += ImportType_CheckedChanged;
            optSingle.Checked = true;
            TypeOfImport = ImportType.Single;

            
            tabResults.TabPages.Remove(pageSuccess);
            tabResults.TabPages.Remove(pageFailed);
        }

        private void TranslationImporter_Load(object sender, EventArgs e)
        {
            ExpandForm();
        }

        #region Import Methods
        /// <summary>
        /// Opens the specified document and converts each row into a translation object.
        /// </summary>
        /// <param name="fileName"></param>
        private void ImportTranslation(string fileName)
        {
            importedTranslations.Clear();
            empties.Clear();
            duplicates.Clear();
            
            using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(fileName, false))
            {
                Body body = wdDoc.MainDocumentPart.Document.Body;

                Table table = body.Elements<Table>().ElementAt(0);

                TagBold(body);
                TagItalics(body);
                TagUnderline(body);

                var tables = body.Elements<Table>();
                float rowNum = 0;
                foreach (Table t in tables)
                {
                    var rows = t.Elements<TableRow>();
                    bool firstRow = true;
                    bool subset = false;
                    string question = "";
                    string varname = "";
                    foreach (TableRow row in rows)
                    {

                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }

                        var cells = row.Elements<TableCell>();

                        // if this is the first part of a series in subtable format, save the question text, set the subset flag and move to the next row
                        if (cells.Count() == 1) 
                        {
                            question =  GetContentFromCell(cells, 0, true);
                            subset = true;
                            continue; 
                        }
                        else
                        {
                            // save the VarName
                            varname = GetContentFromCell(cells, VarNameColumn, false);
                            varname = varname.Trim();

                            // if we are in a subset, insert the current question text into the previously saved question text
                            if (subset)
                            {
                                string seriesStartLitQ = GetContentFromCell(cells, QuestionTextColumn, true);
                                // insert this question text into the previously saved question text
                                question = GetSeriesStarterText(seriesStartLitQ, question);

                                // cancel the subset flag, the rest of the series will be imported as normal questions
                                subset = false;
                            }
                            else
                            {
                                question = GetContentFromCell(cells, QuestionTextColumn, true); //cells.ElementAt(QuestionTextColumn).GetCellText();//
                            }
                        }

                        Translation tq = new Translation();
                        tq.ID = DBAction.GetSurveyTranslation(TargetSurvey.SurveyCode, varname, TargetLanguage.LanguageName).ID;
                        tq.QID = DBAction.GetQuestionID(TargetSurvey.SurveyCode, varname);
                        tq.Language = TargetLanguage.LanguageName;
                        tq.Survey = TargetSurvey.SurveyCode;
                        tq.VarName = varname;
                        tq.TranslationText = FormatTranslation(question);
                        
                        // check VarName for empty or duplicate, if neither, add to import list
                        if (tq.QID == 0)
                        {
                            empties.Add(tq);
                        }
                        else if (importedTranslations.Any(x => x.QID == tq.QID))
                        {
                            duplicates.Add(tq);
                        }
                        else
                        {
                            importedTranslations.Add(tq);
                        }


                        rowNum++;
                    }
                }
            }

            MessageBox.Show("Table imported. Check the results before committing them to the database.");
        }

        

        /// <summary>
        /// Ensure that the spaces between response code and label are correct.
        /// </summary>
        /// <param name="translation"></param>
        /// <returns></returns>
        private string FormatTranslation(string translation)
        {
            try
            {
                
                string[] lines = translation.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
                

                for (int i = 0; i < lines.Length; i++)
                {
                    string l = lines[i];

                    if (Utilities.IsHebrew(l) || Utilities.IsArabic(l))
                    {
                        
                        l = Utilities.FixBiDirectionalString(l);
                        char[] ch = l.ToCharArray();

                        Match m = Regex.Match(l, "([0-9]+\\s{2,})|(\\s{2,}[0-9]+)");
                        if (m.Length == 0)
                            continue;

                        string code = l.Substring(m.Index, m.Length);
                        string label = l.Substring(m.Index + m.Length);

                        lines[i] = code.Trim() + "    " + label.Trim();
                        lines[i] = Utilities.FixBiDirectionalString(lines[i]);
                    }
                    else
                    {
                        Match m = Regex.Match(l, "^[0-9]+\\s+");
                        if (m.Length == 0)
                            continue;


                        int firstSpace = l.IndexOf(" ");
                        int lastSpace = m.Length - 1;


                        lines[i] = l.Substring(0, firstSpace) + "    " + l.Substring(lastSpace + 1);
                    }

                }

                return string.Join("<br>", lines) ;
            }catch (Exception)
            {
                return translation;
            }
        }


        /// <summary>
        /// Opens the specified document and converts each row into a translation object for each Survey specified in the Surveys column.
        /// </summary>
        /// <param name="fileName"></param>
        private void ImportMultiTranslation(string fileName)
        {

            importedTranslations.Clear();
            empties.Clear();
            duplicates.Clear();

            using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(fileName, false))
            {

                Body body = wdDoc.MainDocumentPart.Document.Body;


                Table table = body.Elements<Table>().ElementAt(0);

                TagBold(body);

                TagItalics(body);

                TagUnderline(body);


                var tables = body.Elements<Table>();

                foreach (Table t in tables)
                {
                    var rows = t.Elements<TableRow>();

                    bool firstRow = true;

                    foreach (TableRow row in rows)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }

                        string varname = "";
                        string questionText= "";
                        string surveys = "";
                        string[] surveyList;
                        
                        var cells = row.Elements<TableCell>();
                        
                        varname = GetContentFromCell(cells, VarNameColumn, false);
                        questionText = GetContentFromCell(cells, QuestionTextColumn, true);
                        surveys = GetContentFromCell(cells, SurveysColumn, false);

                        surveyList = surveys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string surv in surveyList)
                        {
                            string trimmed = Utilities.TrimString(surv, " ");
                            Translation tq = new Translation();
                            tq.ID = DBAction.GetSurveyTranslation(trimmed, varname, TargetLanguage.LanguageName).ID;
                            tq.QID = DBAction.GetQuestionID(trimmed, varname);
                            tq.Language = TargetLanguage.LanguageName;
                            tq.Survey = trimmed;
                            tq.VarName = varname;
                            tq.TranslationText = questionText;

                            if (tq.QID == 0)
                            {
                                empties.Add(tq);
                            }
                            else if (importedTranslations.Any(x => x.QID == tq.QID))
                            {
                                duplicates.Add(tq);
                            }
                            else
                            {
                                importedTranslations.Add(tq);
                            }
                        }

                    }
                }
            }

            MessageBox.Show("Table imported. Check the results before committing them to the database.");
        }

        // check file for 
        // locked
        // at least one table
        // varname column present
        // surveys column present, if Multi 
        private void CheckDocument(string fileName)
        {
            string errors = "";
            try
            {
                using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(fileName, false))
                {
                    Body body = wdDoc.MainDocumentPart.Document.Body;

                    int tableCount = body.Descendants<Table>().Count();

                    if (tableCount == 0)
                        errors += "The document needs to contain at least one table.\r\n";

                    GetHeaders(body);

                    if (VarNameColumn == -1)
                        errors += "VarName column not found.\r\n";

                    if (TypeOfImport == ImportType.Multi && SurveysColumn == -1)
                        errors += "Surveys column not found.\r\n";

                    if (QuestionTextColumn == -1)
                        errors += "Translation column not found.\r\n";
                }
            }
            catch (Exception)
            {
                errors += "Error opening the file.";
            }

            if (!string.IsNullOrEmpty(errors))
            {
                errorsExist = true;
                txtFileName.Text = "";
                MessageBox.Show("Errors found in document:\r\n\r\n" + errors);
            }
            else
            {
                errorsExist = false;
            }

            cmdImport.Enabled = !errorsExist;
        }

        

        /// <summary>
        /// Populate the Header list with values found in the header cells.
        /// </summary>
        /// <param name="headerCells"></param>
        private void GetHeaders(Body body)
        {
            var rows = body.Descendants<TableRow>();

            List<TableCell> headerCells = rows.ElementAt(0).Elements<TableCell>().ToList<TableCell>();

            VarNameColumn = -1;
            QuestionTextColumn = -1;
            SurveysColumn = -1;

            for (int i = 0; i < headerCells.Count(); i++)
            {
                string cellText = headerCells.ElementAt(i).GetCellText();
                cellText = cellText.Trim();

                switch (cellText)
                {
                    case "Q":
                    case "Qnum":
                    case "Q#":
                        break;
                    case "VarName":
                    case "Varname":
                    case "varname":
                        VarNameColumn = i;
                        break;
                    case "Survey":
                    case "survey":
                    case "Surveys":
                    case "surveys":
                        SurveysColumn = i;
                        break;
                    

                }

                if (TargetSurvey != null &&  cellText.Equals(TargetSurvey.SurveyCode))
                {
                    QuestionTextColumn = i;
                }
                else if (TargetSurvey != null && cellText.Equals(TargetSurvey.SurveyCode + " " + TargetLanguage.LanguageName))
                {
                    QuestionTextColumn = i;
                }
                else if (cellText.Equals(TargetLanguage.LanguageName))
                {
                    QuestionTextColumn = i;
                }
            }
            
            // it is too risky to assume which column contains the translation without enumerating every possible scenario
            // if varname is found, and there are 2 columns, 2nd column is question text 
            // if qnum and varname is found, and there are 3 columns, 3rd column is question text
            // if varname and surveys are found, and there are 3 columns, the other column is question text
        }

        /// <summary>
        /// Returns the text contents from the specified cell in a group of cells. If a cell doesn't exist at that index, an empty string is returned.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetContentFromCell(IEnumerable<TableCell> cells, int index, bool richText)
        {
            string text;
            try
            {
                text = cells.ElementAt(index).GetCellText();
                if (richText)
                    text = text.Replace("\r\n", "<br>");                    
            }
            catch (Exception)
            {
                text = "";
            }

            if (!richText)
                text = RemoveTags(text);

            return text;
        }

        private string GetSeriesStarterText(string litq, string rest)
        {
            string completeQuestion = "";

            Regex rx = new Regex("[0-9]*   ");

            MatchCollection m = rx.Matches(rest);
            if (m.Count > 0)
            {
                string before = rest.Substring(0, m[0].Index);
                string after = rest.Substring(m[0].Index);
                before = Utilities.TrimString(before, "\r\n");

                completeQuestion = before + "\r\n" + litq + "\r\n" + after;
            }
            else
            {
                // resp options not found
                completeQuestion = rest + "\r\n" + litq;
            }

            return completeQuestion;
        }

        private string RemoveTags(string input)
        {
            string text = input;
            text = text.Replace("<Font Color=Red>", "");
            text = text.Replace("<Font Color=Blue>", "");
            text = text.Replace("</Font>", "");
            text = text.Replace("<strong>", "").Replace("</strong>", "");
            text = text.Replace("<em>", "").Replace("</em>", "");
            text = text.Replace("<u>", "").Replace("</u>", "");
            return text;

        }

        /// <summary>
        /// Surround bold text with strong tags in body.
        /// </summary>
        /// <param name="body"></param>
        private void TagBold(Body body)
        {
            var boldRuns = body.Descendants<Run>().Where(x => x.Descendants<Bold>().Count() > 0);

            foreach (Run run in boldRuns)
                foreach (Text t in run.Elements<Text>())
                    t.Text = "<strong>" + t.Text + "</strong>";
        }

        /// <summary>
        /// Surround italicized text with em tags in body.
        /// </summary>
        /// <param name="body"></param>
        private void TagItalics(Body body)
        {
            var italicRuns = body.Descendants<Run>().Where(x => x.Descendants<Italic>().Count() > 0);

            foreach (Run run in italicRuns)
                foreach (Text t in run.Elements<Text>())
                    t.Text = "<em>" + t.Text + "</em>";
        }

        /// <summary>
        /// Surround underline text with u tags in body.
        /// </summary>
        /// <param name="body"></param>
        private void TagUnderline(Body body)
        {
            var underRuns = body.Descendants<Run>().Where(x => x.Descendants<Underline>().Count() > 0);

            foreach (Run run in underRuns)
                foreach (Text t in run.Elements<Text>())
                    t.Text = "<u>" + t.Text + "</u>";
        }
        #endregion

        #region Control Events

        /// <summary>
        ///  Begin the import process if all the criteria are met. Then show the results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdImport_Click(object sender, EventArgs e)
        {
            if (!CheckImport())
                return;

            string fileName = txtFileName.Text;

            if (TypeOfImport == ImportType.Single)
            {
                ImportTranslation(fileName);
            }
            else if (TypeOfImport == ImportType.Multi)
            {
                ImportMultiTranslation(fileName);
            }
            else
            {
                return;
            }

            if (TargetLanguage.PreferredFont != null)
                ChangeFont(TargetLanguage.PreferredFont);
            else
                ChangeFont("Tahoma");

            ShowResults();
            resultsPanel.Visible = true;
            cmdSave.Visible = true;
        }

        /// <summary>
        /// Open the form to add a new Survey Language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddLanguage_Click(object sender, EventArgs e)
        {
            if (TargetSurvey == null)
                return;

            frmSurveyLanguages frm = new frmSurveyLanguages(TargetSurvey);
            frm.ShowDialog();

            GetLanguages(TargetSurvey);
        }

        
        /// <summary>
        /// Update or Create translation records as needed. Surveys are unlocked if needed and confirmed by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool toLock = false;
            if (TypeOfImport == ImportType.Single)
            {
                if (TargetSurvey.Locked)
                    if (MessageBox.Show("This survey is locked. Do you want to unlock it before importing a translation?", "Locked Survey", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UnlockSurveys();
                        toLock = true;
                    }
                    else
                    {
                        return;
                    }


                if (MessageBox.Show("Do you want to overwrite the existing translations for " + TargetSurvey.SurveyCode + ": " + TargetLanguage.LanguageName, "Overwrite", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;


            }
            else if (TypeOfImport == ImportType.Multi)
            {
                TargetWave.Surveys = new BindingList<SurveyRecord>(DBAction.GetSurveys(TargetWave.ID));

                if (TargetWave.Surveys.Any(s => s.Locked))
                {
                    if (MessageBox.Show("This wave contains surveys that are locked. Do you want to unlock them before importing a translation?", "Locked Survey", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UnlockSurveys();
                        toLock = true;
                    }
                    else
                    {
                        return;
                    }

                    if (MessageBox.Show("Do you want to overwrite the existing " + TargetLanguage.LanguageName + " translations for any surveys found in the document?", "Overwrite", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    

                }
            }

            SaveTranslations();
            
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
            FileDialog fd = new OpenFileDialog();
            DialogResult result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFileName.Text = fd.FileName;

                CheckDocument(fd.FileName);

            }
            else
            {
                txtFileName.Text = "";
            }
        }

        /// <summary>
        /// Fill the language box with languages used by the selected survey or wave.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Expanded = false;
            ExpandForm();
            cmdSave.Visible = false;

            if ((sender as ComboBox).SelectedItem == null)
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
                if (TypeOfImport== ImportType.Single)
                {
                    TargetSurvey = (SurveyRecord)cboSurvey.SelectedItem;
                    SurveyRecord selectedSurvey = (SurveyRecord)cboSurvey.SelectedItem;
                    GetLanguages(selectedSurvey);
                    cmdAddLanguage.Enabled = true;
                }
                else if (TypeOfImport == ImportType.Multi)
                {
                    TargetWave = (StudyWaveRecord)cboSurvey.SelectedItem;
                    StudyWaveRecord selectedWave = (StudyWaveRecord)cboSurvey.SelectedItem;
                    GetLanguages(selectedWave);
                    cmdAddLanguage.Enabled = false;
                }
            }

            cmdBrowse.Enabled = TargetLanguage != null;
            
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

            if (sel == 1)
            {
                TypeOfImport = ImportType.Single;
                lblSurveyWave.Text = "Survey";
                cboSurvey.DataSource = Globals.AllSurveys;
                cboSurvey.DisplayMember = "SurveyCode";
                cboSurvey.ValueMember = "SID";
             
                cboSurvey.SelectedItem = null;
            }
            else if (sel == 2)
            {
                TypeOfImport = ImportType.Multi;
                lblSurveyWave.Text = "Wave";
                cboSurvey.DataSource = Globals.AllWaves;
                cboSurvey.DisplayMember = "WaveCode";
                cboSurvey.ValueMember = "WaveCode";
               
                cboSurvey.SelectedItem = null;
            }
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

            CheckQuestion(t);
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

            CheckQuestion(t);
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



        /// <summary>
        /// Returns true if the minimum required fields have been entered.
        /// </summary>
        /// <returns></returns>
        private bool CheckImport()
        {
            if (TargetSurvey == null && TypeOfImport == ImportType.Single)
            {
                MessageBox.Show("Choose a survey.");
                return false;
            }

            if (TargetWave == null && TypeOfImport == ImportType.Multi)
            {
                MessageBox.Show("Choose a wave.");
                return false;
            }

            if (TargetLanguage == null || string.IsNullOrEmpty(TargetLanguage.LanguageName))
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
        private void ShowResults()
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
            bsImported.DataSource = importedTranslations;
            navImported.BindingSource = bsImported;
            bsImported.PositionChanged += BsImported_PositionChanged;

            txtImportedVarName.DataBindings.Clear();
            rtbImportedTranslation.DataBindings.Clear();
            txtImportedVarName.DataBindings.Add(new Binding("Text", bsImported, "VarName"));

            txtImportedSurvey.DataBindings.Clear();
            txtImportedSurvey.DataBindings.Add(new Binding("Text", bsImported, "Survey"));

            txtImportedSurvey.Visible = TypeOfImport == ImportType.Multi;
            if (TargetLanguage.RTL) rtbImportedTranslation.RightToLeft = RightToLeft.Yes;


            if (importedTranslations.Count == 1)
            {
                UpdateTranslationText(rtbImportedTranslation, importedTranslations[0]);
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
                UpdateTranslationText(rtbMissingTranslation, empties[0]);
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
                UpdateTranslationText(rtbDuplicateTranslation, duplicates[0]);
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
                resultsPanel.Width = 10;
                this.Width = 475  + 10;

               
            }
            else
            {
                resultsPanel.Width = 430 +  10;
                this.Width = 910;
               
            }

            //Expanded = !Expanded;
        }

        /// <summary>
        /// Unlocks the surveys specified in the Target Survey or Wave.
        /// </summary>
        private void UnlockSurveys()
        {
            if (TypeOfImport == ImportType.Single)
                DBAction.UnlockSurvey(TargetSurvey, 5 * 60000);
            else
            {
                foreach (Survey s in TargetWave.Surveys)
                {
                    DBAction.UnlockSurvey(s, 5 * 60000);
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
        /// Show duplicates, if there are any.
        /// </summary>
        public void ProcessDuplicateVarNames()
        {
            if (duplicates.Count > 0)
            {
                MessageBox.Show(duplicates.Count + " rows with duplicate VarNames were found. These could now be imported.");
                ImportedDuplicates duplicatesForm = new ImportedDuplicates(duplicates);
                duplicatesForm.Left = this.Left + this.Width;
                duplicatesForm.Visible = true;
            }
        }

        /// <summary>
        /// Show empties, if there are any.
        /// </summary>
        public void ProcessEmptyVarNames()
        {
            if (empties.Count > 0)
            {

                MessageBox.Show(empties.Count + " rows with no VarName were found. These could not be imported.");
                ImportedEmpties emptiesForm = new ImportedEmpties(empties);
                emptiesForm.Visible = true;
            }

        }

        /// <summary>
        /// Given a translation object, use the Survey and VarName to determine if this question exists in the database. If found, add it to the "imported" list and remove it
        /// the duplicate and missing lists.
        /// </summary>
        /// <param name="t"></param>
        private void CheckQuestion(Translation t)
        {
            if (string.IsNullOrEmpty(t.Survey) || string.IsNullOrEmpty(t.VarName))
            {
                MessageBox.Show("Both Survey and VarName are required.");
                return;
            }

            t.QID = DBAction.GetQuestionID(t.Survey, t.VarName);
            if (t.QID != 0)
            {
                
                if (importedTranslations.Any(x=>x.QID == t.QID))
                {
                    MessageBox.Show("Question already exists in import list.");
                    return;
                }
                else
                {
                    MessageBox.Show("Question found! Added to import list.");
                    importedTranslations.Add(t);
                }
                
                if (empties.Contains(t))
                {
                    bsMissing.RemoveCurrent();
                    bsMissing.MoveNext();
                    bsMissing.MovePrevious();
                }
                else if (duplicates.Contains(t))
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
            List<Language> langs = DBAction.ListLanguages(selectedSurvey);
            langs.RemoveAll(x => x.LanguageName.Equals("English"));        

            cboLanguage.DataSource = langs;
            cboLanguage.DisplayMember = "LanguageName";
            cboLanguage.ValueMember = "ID";

            lblEnglishRouting.Visible = selectedSurvey.EnglishRouting;

            cboLanguage.Enabled = true;

            if (cboLanguage.Items.Count == 0)
                cboLanguage.DataSource = GetAllLanguages();

            if (cboLanguage.Items.Count == 1)
                cboLanguage.SelectedItem = cboLanguage.Items[0];
            else
                cboLanguage.SelectedItem = null;
        }

        /// <summary>
        /// Get a list of all languages used in any survey. English not included.
        /// </summary>
        /// <returns></returns>
        private List<Language> GetAllLanguages()
        {
            List<Language> langs = DBAction.ListLanguages();

            langs.RemoveAll(x => x.LanguageName.Equals("English"));
            return langs;
        }

        /// <summary>
        /// Get a list of laguages used by the specified wave. English not included.
        /// </summary>
        /// <param name="selectedWave"></param>
        private void GetLanguages(StudyWaveRecord selectedWave)
        {
            //List<string> languages = DBAction.GetLanguages(selectedSurvey);
            //languages.Remove("English");

            List<Language> langs = DBAction.ListLanguages(selectedWave);
            langs.RemoveAll(x => x.LanguageName.Equals("English"));
            

            cboLanguage.DataSource = langs;
            cboLanguage.DisplayMember = "LanguageName";
            cboLanguage.ValueMember = "ID";

            lblEnglishRouting.Visible = selectedWave.EnglishRouting;

            cboLanguage.Enabled = true;

            if (cboLanguage.Items.Count == 0)
                cboLanguage.DataSource = GetAllLanguages();

            if (cboLanguage.Items.Count == 1)
                cboLanguage.SelectedItem = cboLanguage.Items[0];
            else
                cboLanguage.SelectedItem = null;
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
        private void SaveTranslations()
        {
            failed.Clear();
            success.Clear();
            // insert each question into the database 
            foreach (Translation t in importedTranslations)
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

        private void TranslationImporter_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.RemovePopup(this);
        }
    }
}
