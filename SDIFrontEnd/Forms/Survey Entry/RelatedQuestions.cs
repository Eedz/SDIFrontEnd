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

namespace SDIFrontEnd
{
 
    public partial class RelatedQuestions : Form
    {
        QuestionRecord MainQuestion;    // reference to the question displayed in the main form
        QuestionRecord CurrentQuestion;

        private string SurveyGlob;      // survey code pattern, could be a complete survey code or partial with wildcards, or empty
        private int FormNumber;

        List<QuestionRecord> Records;
        BindingSource bs;
        BindingSource bsCurrent;
        BindingSource bsTranslations;

        public bool Pin { get; set; }

        private int CollapsedHeight = 500;
        private int ExpandedHeight = 730;
        private int TranslationHeight = 235;

        public RelatedQuestions(QuestionRecord mainQuestion, int formNumber)
        {
            InitializeComponent();

            AddMouseWheelEvents();

            MainQuestion = mainQuestion;
            FormNumber = formNumber;

            SurveyGlob = Globals.CurrentUser.GetFilter("sfrmSurveyEntryBrown", FormNumber);
            SurveyGlob = SurveyGlob == "" || SurveyGlob == null ? "*" : SurveyGlob;

            Records = new List<QuestionRecord>();

            SetupBindingSource();

            FillBoxes();

            BindProperties();

            UpdateRefVarName(MainQuestion.Item.VarName.RefVarName);

            SetupFilter();
            
            // hide translation panel
            translationPanel.Height = 0;
            this.Height = CollapsedHeight;
        }

        #region Form Setup

        private void AddMouseWheelEvents()
        {
            cboSurveyFilter.MouseWheel += ComboBox_MouseWheel;
            cboPreP.MouseWheel += ComboBox_MouseWheel;
            cboPreI.MouseWheel += ComboBox_MouseWheel;
            cboPreA.MouseWheel += ComboBox_MouseWheel;
            cboLitQ.MouseWheel += ComboBox_MouseWheel;
            cboPstI.MouseWheel += ComboBox_MouseWheel;
            cboPstP.MouseWheel += ComboBox_MouseWheel;
            cboRO.MouseWheel += ComboBox_MouseWheel;
            cboNR.MouseWheel += ComboBox_MouseWheel;          
        }

        private void SetupBindingSource()
        {
            bs = new BindingSource()
            {
                DataSource = Records
            };
            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource()
            {
                DataSource = bs,
                DataMember = "Item"
            };
            bsCurrent.ListChanged += RelatedQuestions_ListChanged;

            bsTranslations = new BindingSource()
            {
                DataSource = bsCurrent,
                DataMember = "Translations"
            };
            bsTranslations.PositionChanged += BsTranslations_PositionChanged;

            navQuestions.BindingSource = bs;
            navTranslations.BindingSource = bsTranslations;
        }

        private void FillBoxes()
        {
            cboPreP.DisplayMember = "WordID";
            cboPreP.ValueMember = "WordID";
            cboPreP.DataSource = Globals.AllPreP;          

            cboPreI.DisplayMember = "WordID";
            cboPreI.ValueMember = "WordID";
            cboPreI.DataSource = Globals.AllPreI;

            cboPreA.DisplayMember = "WordID";
            cboPreA.ValueMember = "WordID";
            cboPreA.DataSource = Globals.AllPreA;

            cboLitQ.DisplayMember = "WordID";
            cboLitQ.ValueMember = "WordID";
            cboLitQ.DataSource = Globals.AllLitQ;

            cboPstI.DisplayMember = "WordID";
            cboPstI.ValueMember = "WordID";
            cboPstI.DataSource = Globals.AllPstI;

            cboPstP.DisplayMember = "WordID";
            cboPstP.ValueMember = "WordID";
            cboPstP.DataSource = Globals.AllPstP;

            cboRO.DisplayMember = "RespSetName";
            cboRO.ValueMember = "RespSetName";
            cboRO.DataSource = Globals.AllRespOptions;

            cboNR.DisplayMember = "RespSetName";
            cboNR.ValueMember = "RespSetName";
            cboNR.DataSource = Globals.AllNRCodes;
        }

        private void BindProperties()
        {
            txtVarName.DataBindings.Add("Text", bsCurrent, "VarName.VarName");
            txtSurvey.DataBindings.Add("Text", bsCurrent, "SurveyCode");
            txtQnum.DataBindings.Add("Text", bsCurrent, "Qnum");
            txtVarLabel.DataBindings.Add("Text", bsCurrent, "VarName.VarLabel");
           
            cboPreP.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "PrePW"));
            cboPreI.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "PreIW"));
            cboPreA.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "PreAW"));
            cboLitQ.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "LitQW"));
            cboPstI.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "PstIW"));
            cboPstP.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "PstPW"));
            cboRO.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "RespOptionsS"));
            cboNR.DataBindings.Add(new Binding("SelectedItem", bsCurrent, "NRCodesS"));

            // translation panel
            txtTranslationPreP.DataBindings.Add("Text", bsCurrent, "PrePW.WordingText");
            txtTranslationPstP.DataBindings.Add("Text", bsCurrent, "PstPW.WordingText");
        }

        private void SetupFilter()
        {
            // set up survey filter box
            foreach (string surveycode in Globals.AllSurveys.Select(x => x.SurveyCode).ToList<string>())
                cboSurveyFilter.Items.Add(surveycode);

            if (SurveyGlob.Contains("*"))
                cboSurveyFilter.Items.Add(SurveyGlob);

            cboSurveyFilter.SelectedItem = SurveyGlob;
            cboSurveyFilter.SelectedIndexChanged += cboSurveyFilter_SelectedIndexChanged;
        }

        #endregion

        #region Events 

        private void RelatedQuestions_Load(object sender, EventArgs e)
        {
            UpdateQuestion();
            UpdateTranslation();
        }

        protected void RelatedQuestions_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// Update the question text and CurrentQuestion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            UpdateQuestion();
            UpdateTranslation();

            if (CurrentQuestion == null)
                return;

            bool locked = Globals.AllSurveys.First(x => x.SurveyCode.Equals(CurrentQuestion.Item.SurveyCode)).Locked;
            LockForm(locked);
        }

        /// <summary>
        /// Update the translation text and CurrentTranslation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsTranslations_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentTranslation();
        }

        private void RelatedQuestions_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;

            // get the question record that was modified
            SurveyQuestion modifiedQuestion = (SurveyQuestion)bsCurrent[e.NewIndex];
            QuestionRecord modifiedRecord = Records.Where(x => x.Item == modifiedQuestion).FirstOrDefault();

            int index = bs.IndexOf(modifiedRecord);

            if (modifiedRecord == null)
                return;

            bs.ResetBindings(false);
            UpdateQuestion();

            Records[index].Dirty = true;
        }

        /// <summary>
        /// Toggle the visibility of the translation section.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdViewTranslation_Click(object sender, EventArgs e)
        {
            ToggleTranslation();
        }       

        /// <summary>
        /// Hide unneccesary columns and rename others.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvDS.ColumnCount; i++)
            {
                switch (dgvDS.Columns[i].Name)
                {
                    case "SurveyCode":
                        dgvDS.Columns[i].HeaderText = "Survey";
                        break;
                    case "VarName":
                    case "Qnum":
                        break;
                    case "PrePW":
                        dgvDS.Columns[i].HeaderText = "PreP";
                        break;
                    case "PreIW":
                        dgvDS.Columns[i].HeaderText = "PreI";
                        break;
                    case "PreAW":
                        dgvDS.Columns[i].HeaderText = "PreA";
                        break;
                    case "LitQW":
                        dgvDS.Columns[i].HeaderText = "LitQ";
                        break;
                    case "PstIW":
                        dgvDS.Columns[i].HeaderText = "PstI";
                        break;
                    case "PstPW":
                        dgvDS.Columns[i].HeaderText = "PstP";
                        break;
                    case "RespOptionsS":
                        dgvDS.Columns[i].HeaderText = "RespOptions";
                        break;
                    case "NRCodesS":
                        dgvDS.Columns[i].HeaderText = "NRCodes";
                        break;
                    default:
                        dgvDS.Columns[i].Visible = false;
                        break;
                }
            }
            dgvDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Update the form after selecting a survey filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSurveyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        /// <summary>
        /// If a user entered a custom filter, add it to the list and select it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSurveyFilter_Leave(object sender, EventArgs e)
        {
            if (cboSurveyFilter.Text == null)
                return;

            CheckForNewFilter();
        }

        private void cboSurveyFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (cboSurveyFilter.Text == null)
                    return;

                CheckForNewFilter();
            }
        }

        private void cmdToEditor_Click(object sender, EventArgs e)
        {
            ExportWordings(CurrentQuestion.Item);
        }

        private void cmdFromEditor_Click(object sender, EventArgs e)
        {
            ImportWordings(MainQuestion.Item);
            UpdateQuestion();
        }

        private void RelatedQuestions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentQuestion == null)
                return;

            if (CurrentQuestion.Dirty)
            {
                DialogResult result = MessageBox.Show("This question has unsaved changes. Save them now?", "Confirm save.", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    e.Cancel = true;
                else if (result == DialogResult.Yes)
                    SaveChanges();
            }
        }

        private void RelatedQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormStateRecord state = Globals.CurrentUser.FormStates.Where(x => x.FormName.Equals("sfrmSurveyEntryBrown") && x.FormNum == FormNumber).FirstOrDefault();
            state.Filter = SurveyGlob;
            state.RecordPosition = 0;
            state.Dirty = true;
            state.SaveRecord();
            
            bs.Dispose();
            bsCurrent.Dispose();
            bsTranslations.Dispose();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Refresh the form to display refVarNames matching record. Save the current record before refreshing.
        /// </summary>
        /// <param name="record"></param>
        public void UpdateForm(QuestionRecord record)
        {
            if (CurrentQuestion !=null && CurrentQuestion.Dirty)
                CurrentQuestion.SaveRecord();

            CurrentQuestion = (QuestionRecord)bs.Current;
            MainQuestion = record;
            
            UpdateRefVarName(record.Item.VarName.RefVarName);
            UpdateQuestion();               // update question text
            UpdateTranslation();

            // toggle english routing
            bool englishRouting = UsesEnglishRouting();
            txtTranslationPreP.Visible = englishRouting;
            txtTranslationPstP.Visible = englishRouting;
            if (englishRouting)
            {
                rtbTranslation.Top = txtTranslationPreP.Top + txtTranslationPreP.Height + 10;
                rtbTranslation.Height = 100;
            }
            else
            {
                rtbTranslation.Top = txtTranslationPreP.Top;
                rtbTranslation.Height = 160;
            }

            bool locked = Globals.AllSurveys.First(x => x.SurveyCode.Equals(CurrentQuestion.Item.SurveyCode)).Locked;
            LockForm(locked);
        }

        /// <summary>
        /// Compares the beginning of the translation text to the PreP text. Returns true if CurrentQuestion's TranslationText does not begin with PreP
        /// </summary>
        /// <returns></returns>
        private bool UsesEnglishRouting()
        {
            if (CurrentQuestion == null)
                return false;

            if (CurrentQuestion.Item.Translations.Count == 0)
                return false;

            //string prep = CurrentQuestion.Item.PreP;
            string prep = CurrentQuestion.Item.PrePW.WordingText;
            string translation = CurrentQuestion.Item.Translations[0].TranslationText;

            return !translation.StartsWith(prep);
        }

        /// <summary>
        /// Refreshes the list of questions to be displayed in the form.
        /// </summary>
        /// <param name="refVarName"></param>
        public void UpdateRefVarName(string refVarName)
        {
            Records.Clear();
            var qs = DBAction.GetRefVarNameQuestionsGlob(refVarName, SurveyGlob.Replace("*", "%"));
            foreach (SurveyQuestion q in qs)
                Records.Add(new QuestionRecord(q));

            foreach (QuestionRecord q in Records)
            {
                q.Item.Translations = DBAction.GetQuestionTranslations(q.Item.ID);
            }
            bs.DataSource = Records;
            bs.ResetBindings(false);

            CurrentQuestion = (QuestionRecord)bs.Current;
            UpdateTranslation();

            dgvDS.DataSource = Records.Select(x => x.Item).ToList();
        }

        /// <summary>
        /// Refreshes the RichTextBox displaying the complete question text.
        /// </summary>
        private void UpdateQuestion()
        {
            CurrentQuestion = (QuestionRecord)bs.Current;
            rtbQuestionText.Rtf = "";

            if (CurrentQuestion != null)
                rtbQuestionText.Rtf = RTFUtilities.QuestionToRTF(CurrentQuestion.Item); //.GetQuestionTextRich(true);
        }

        /// <summary>
        /// Refreshes the translation panel's control bindings.
        /// </summary>
        private void UpdateTranslation()
        {
            txtLanguage.DataBindings.Clear();
            txtLanguage.Text = "";
            rtbTranslation.DataBindings.Clear();
            rtbTranslation.Rtf = "";
            bsTranslations.DataSource = bsCurrent;
            bsTranslations.DataMember = "Translations";
            if (bsTranslations.Count > 0)
            {
                
                txtLanguage.DataBindings.Add("Text", bsTranslations, "LanguageName.LanguageName");
                rtbTranslation.DataBindings.Add("RTF", bsTranslations, "TranslationRTF");
            }
        }

        /// <summary>
        /// Updates MainQuestion's field to wording.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="wnum"></param>
        public void ExportWording(Wording wording)
        {
            switch (wording.Type)
            {
                case WordingType.PreP:
                    MainQuestion.Item.PrePW = new Wording(wording.WordID, WordingType.PreP, wording.WordingText);
                    break;
                case WordingType.PreI:
                    MainQuestion.Item.PreIW = new Wording(wording.WordID, WordingType.PreI, wording.WordingText); ;
                    break;
                case WordingType.PreA:
                    MainQuestion.Item.PreAW = new Wording(wording.WordID, WordingType.PreA, wording.WordingText); ;
                    break;
                case WordingType.LitQ:
                    MainQuestion.Item.LitQW = new Wording(wording.WordID, WordingType.LitQ, wording.WordingText); ;
                    break;
                case WordingType.PstI:
                    MainQuestion.Item.PstIW = new Wording(wording.WordID, WordingType.PstI, wording.WordingText); ;
                    break;
                case WordingType.PstP:
                    MainQuestion.Item.PstPW = new Wording(wording.WordID, WordingType.PstP, wording.WordingText); ;
                    break;
            }
        }

        /// <summary>
        /// Updates MainQuestion's field to respname.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="respname"></param>
        public void ExportWording(ResponseSet respset)
        {
            switch (respset.Type)
            {
                case ResponseType.RespOptions:
                    MainQuestion.Item.RespOptionsS = new ResponseSet(respset.RespSetName, ResponseType.RespOptions, respset.RespList);
                    break;
                case ResponseType.NRCodes:
                    MainQuestion.Item.NRCodesS = new ResponseSet(respset.RespSetName, ResponseType.NRCodes, respset.RespList); ;
                    break;
            }
        }

        public void ImportWording(Wording wording)
        {
            switch (wording.Type)
            {
                case WordingType.PreP:
                    CurrentQuestion.Item.PrePW= new Wording(wording.WordID, WordingType.PreP, wording.WordingText);
                    break;
                case WordingType.PreI:
                    CurrentQuestion.Item.PreIW = new Wording(wording.WordID, WordingType.PreI, wording.WordingText);
                    break;
                case WordingType.PreA:
                    CurrentQuestion.Item.PreAW = new Wording(wording.WordID, WordingType.PreA, wording.WordingText);
                    break;
                case WordingType.LitQ:
                    CurrentQuestion.Item.LitQW = new Wording(wording.WordID, WordingType.LitQ, wording.WordingText);
                    break;
                case WordingType.PstI:
                    CurrentQuestion.Item.PstIW = new Wording(wording.WordID, WordingType.PstI, wording.WordingText);
                    break;
                case WordingType.PstP:
                    CurrentQuestion.Item.PstPW = new Wording(wording.WordID, WordingType.PstP, wording.WordingText);
                    break;
            }
        }

        public void ImportWording(ResponseSet respset)
        {
            switch (respset.Type)
            {
                case ResponseType.RespOptions:
                    CurrentQuestion.Item.RespOptionsS = new ResponseSet(respset.RespSetName, ResponseType.RespOptions, respset.RespList);
                    break;
                case ResponseType.NRCodes:
                    CurrentQuestion.Item.NRCodesS = new ResponseSet(respset.RespSetName, ResponseType.NRCodes, respset.RespList);
                    break;
            }
        }

        /// <summary>
        /// Updates all fields in CurrentQuestion to match question.
        /// </summary>
        /// <param name="question"></param>
        public void ImportWordings(SurveyQuestion question)
        {
            if (question == null) return;

            ImportWording(question.PrePW);
            ImportWording(question.PreIW);
            ImportWording(question.PreAW);
            ImportWording(question.LitQW);
            ImportWording(question.PstIW);
            ImportWording(question.PstPW);
            ImportWording(question.RespOptionsS);
            ImportWording(question.NRCodesS);
        }

        /// <summary>
        /// Updates all fields in MainQuestion to match question.
        /// </summary>
        /// <param name="question"></param>
        public void ExportWordings(SurveyQuestion question)
        {
            if (question == null) return;

            ExportWording(question.PrePW);
            ExportWording(question.PreIW);
            ExportWording(question.PreAW);
            ExportWording(question.LitQW);
            ExportWording(question.PstIW);
            ExportWording(question.PstPW);
            ExportWording(question.RespOptionsS);
            ExportWording(question.NRCodesS);
        }

        private void MoveRecord(int count)
        {
            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }
        }

        private void SaveChanges()
        {
            bs.EndEdit();

            if (CurrentQuestion.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }
        }

        private void RefreshCurrentTranslation()
        {
            Translation CurrentTranslation = (Translation)bsTranslations.Current;
            if (CurrentTranslation != null)
                rtbTranslation.Rtf = RTFUtilities.FormatRTF_FromText(CurrentTranslation.TranslationText);
        }

        private void ToggleTranslation()
        {
            if (translationPanel.Height == 0)
            {
                this.Height = ExpandedHeight;
                translationPanel.Height = TranslationHeight;
            }
            else
            {
                this.Height = CollapsedHeight;
                translationPanel.Height = 0;
            }
        }

        private void UpdateFilter()
        {
            if (cboSurveyFilter.SelectedItem == null)
            {
                SurveyGlob = "*";
            }
            else
            {
                SurveyGlob = (string)cboSurveyFilter.SelectedItem;
            }

            UpdateRefVarName(MainQuestion.Item.VarName.RefVarName);
        }

        private void CheckForNewFilter()
        {
            string enteredValue = cboSurveyFilter.Text;

            if (!cboSurveyFilter.Items.Contains(enteredValue))
                cboSurveyFilter.Items.Add(enteredValue);

            cboSurveyFilter.SelectedItem = enteredValue;
        }

        private void LockForm(bool locked)
        {
            cboPreP.Enabled = !locked;
            cboPreI.Enabled = !locked;
            cboPreA.Enabled = !locked;
            cboLitQ.Enabled = !locked;
            cboPstI.Enabled = !locked;
            cboPstP.Enabled = !locked;
            cboRO.Enabled = !locked;
            cboNR.Enabled = !locked;
        }
        #endregion

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SaveChanges();
            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveChanges();
            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SaveChanges();
            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveChanges();
            bs.MoveFirst();
        }

        private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
        {
            bsTranslations.MoveNext();
        }

        private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
        {
            bsTranslations.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
        {
            bsTranslations.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
        {
            bsTranslations.MoveFirst();
        }
        #endregion


    }
}
