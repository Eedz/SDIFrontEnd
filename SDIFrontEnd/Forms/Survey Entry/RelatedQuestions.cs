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

        BindingList<QuestionRecord> Questions;
        BindingSource bs;
        BindingSource bsTranslations;

        public bool Pin { get; set; }

        private int CollapsedHeight = 500;
        private int ExpandedHeight = 730;
        private int TranslationHeight = 235;

        public RelatedQuestions(QuestionRecord mainQuestion, int formNumber)
        {
            InitializeComponent();

            MainQuestion = mainQuestion;
            FormNumber = formNumber;

            SurveyGlob = Globals.CurrentUser.GetFilter("sfrmSurveyEntryBrown", FormNumber);
            SurveyGlob = SurveyGlob == "" || SurveyGlob == null ? "%" : SurveyGlob;

            Questions = new BindingList<QuestionRecord>();

            SetupBindingSource();

            BindProperties();
           
            UpdateRefVarName(MainQuestion.VarName.RefVarName);

            SetupFilter();
            
            // hide translation panel
            translationPanel.Height = 0;
            this.Height = CollapsedHeight;
        }

        #region Form Setup

        private void SetupBindingSource()
        {
            bs = new BindingSource()
            {
                DataSource = Questions
            };
            CurrentQuestion = (QuestionRecord)bs.Current;
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += RelatedQuestions_ListChanged;

            navQuestions.BindingSource = bs;

            bsTranslations = new BindingSource()
            {
                DataSource = bs.Current,
                DataMember = "Translations"
            };
            navTranslations.BindingSource = bsTranslations;
            bsTranslations.PositionChanged += BsTranslations_PositionChanged;
        }

        private void BindProperties()
        {
            txtVarName.DataBindings.Add("Text", bs, "VarName.VarName");
            txtSurvey.DataBindings.Add("Text", bs, "SurveyCode");
            txtQnum.DataBindings.Add("Text", bs, "Qnum");
            txtVarLabel.DataBindings.Add(new Binding("Text", bs, "VarName.VarLabel"));
            txtPrePNum.DataBindings.Add(new Binding("Text", bs, "PrePNum"));
            txtPreINum.DataBindings.Add("Text", bs, "PreINum");
            txtPreANum.DataBindings.Add("Text", bs, "PreANum");
            txtLitQNum.DataBindings.Add("Text", bs, "LitQNum");
            txtPstINum.DataBindings.Add("Text", bs, "PstINum");
            txtPstPNum.DataBindings.Add("Text", bs, "PstPNum");
            txtRespName.DataBindings.Add("Text", bs, "RespName");
            txtNRName.DataBindings.Add("Text", bs, "NRName");


            // translation panel
            txtTranslationPreP.DataBindings.Add("Text", bs, "PreP");
            //txtLanguage.DataBindings.Add("Text", bsTranslations, "Language");
            //rtbTranslation.DataBindings.Add("RTF", bsTranslations, "TranslationText");
            txtTranslationPstP.DataBindings.Add("Text", bs, "PstP");
        }

        private void SetupFilter()
        {
            // set up survey filter box
            foreach (string surveycode in Globals.AllSurveys.Select(x => x.SurveyCode).ToList<string>())
                cboSurveyFilter.Items.Add(surveycode);

            if (SurveyGlob.Contains("%"))
                cboSurveyFilter.Items.Add(SurveyGlob.Replace("%", "*"));

            cboSurveyFilter.SelectedItem = SurveyGlob;
            cboSurveyFilter.SelectedIndexChanged += cboSurveyFilter_SelectedIndexChanged;
        }

        #endregion

        #region Events 

        private void RelatedQuestions_Load(object sender, EventArgs e)
        {
            UpdateQuestion();
        }

        /// <summary>
        /// Update the question text and CurrentQuestion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            UpdateQuestion();
        }


        /// <summary>
        /// Update the translation text and CurrentTranslation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsTranslations_PositionChanged(object sender, EventArgs e)
        {
            Translation CurrentTranslation = (Translation)bsTranslations.Current;
            if (CurrentTranslation != null)
                rtbTranslation.Rtf = CurrentTranslation.TranslationRTF;
        }

        private void RelatedQuestions_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;

            switch (e.PropertyDescriptor.Name)
            {
                case "PrePNum":
                    CurrentQuestion.PreP = DBAction.GetWordingText("PreP", CurrentQuestion.PrePNum);
                    break;
                case "PreINum":
                    CurrentQuestion.PreI = DBAction.GetWordingText("PreI", CurrentQuestion.PreINum);
                    break;
                case "PreANum":
                    CurrentQuestion.PreA = DBAction.GetWordingText("PreA", CurrentQuestion.PreANum);
                    break;
                case "LitQNum":
                    CurrentQuestion.LitQ = DBAction.GetWordingText("LitQ", CurrentQuestion.LitQNum);
                    break;
                case "PstINum":
                    CurrentQuestion.PstI = DBAction.GetWordingText("PstI", CurrentQuestion.PstINum);
                    break;
                case "PstPNum":
                    CurrentQuestion.PstP = DBAction.GetWordingText("PstP", CurrentQuestion.PstPNum);
                    break;
                case "RespName":
                    CurrentQuestion.RespOptions = DBAction.GetResponseText(CurrentQuestion.RespName);
                    break;
                case "NRName":
                    CurrentQuestion.NRCodes = DBAction.GetNonResponseText(CurrentQuestion.NRName);
                    break;
            }
            bs.ResetBindings(false);
            UpdateQuestion();

            CurrentQuestion.Dirty = true;
        }

        /// <summary>
        /// Toggle the visibility of the translation section.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdViewTranslation_Click(object sender, EventArgs e)
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

                    case "VarName":
                    case "SurveyCode":
                        dgvDS.Columns[i].HeaderText = "Survey";
                        break;
                    case "Qnum":
                    case "RespName":
                    case "NRName":
                        break;
                    case "PrePNum":
                        dgvDS.Columns[i].HeaderText = "PreP#";
                        break;
                    case "PreINum":
                        dgvDS.Columns[i].HeaderText = "PreI#";
                        break;
                    case "PreANum":
                        dgvDS.Columns[i].HeaderText = "PreA#";
                        break;
                    case "LitQNum":
                        dgvDS.Columns[i].HeaderText = "LitQ#";
                        break;
                    case "PstINum":
                        dgvDS.Columns[i].HeaderText = "PstI#";
                        break;
                    case "PstPNum":
                        dgvDS.Columns[i].HeaderText = "PstP#";
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
            if (cboSurveyFilter.SelectedItem == null)
            {
                SurveyGlob = "%";
            }
            else
            {
                SurveyGlob = ((string)cboSurveyFilter.SelectedItem).Replace("*", "%");
            }

            UpdateRefVarName(MainQuestion.VarName.RefVarName);
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

            string enteredValue = cboSurveyFilter.Text;

            if (!cboSurveyFilter.Items.Contains(enteredValue))
                cboSurveyFilter.Items.Add(enteredValue);

            cboSurveyFilter.SelectedItem = enteredValue;

        }

        private void cboSurveyFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (cboSurveyFilter.Text == null)
                    return;

                string enteredValue = cboSurveyFilter.Text;

                if (!cboSurveyFilter.Items.Contains(enteredValue))
                    cboSurveyFilter.Items.Add(enteredValue);

                cboSurveyFilter.SelectedItem = enteredValue;
            }
        }

        private void cmdToEditor_Click(object sender, EventArgs e)
        {
            ExportWordings(CurrentQuestion);
        }

        private void cmdFromEditor_Click(object sender, EventArgs e)
        {
            ImportWordings(MainQuestion);
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
                    CurrentQuestion.SaveRecord();
            }
        }

        private void RelatedQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormStateRecord state = Globals.CurrentUser.FormStates.Where(x => x.FormName.Equals("sfrmSurveyEntryBrown") && x.FormNum == FormNumber).FirstOrDefault();
            state.Filter = (string)cboSurveyFilter.SelectedItem;
            state.RecordPosition = 0;
            state.Dirty = true;
            state.SaveRecord();
            
            bs.Dispose();
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
            
            UpdateRefVarName(record.VarName.RefVarName);
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
        }

        /// <summary>
        /// Compares the beginning of the translation text to the PreP text. Returns true if CurrentQuestion's TranslationText does not begin with PreP
        /// </summary>
        /// <returns></returns>
        private bool UsesEnglishRouting()
        {
            if (CurrentQuestion == null)
                return false;

            if (CurrentQuestion.Translations.Count == 0)
                return false;

            string prep = CurrentQuestion.PreP;
            string translation = CurrentQuestion.Translations[0].TranslationText;

            return !translation.StartsWith(prep);
        }

        /// <summary>
        /// Refreshes the list of questions to be displayed in the form.
        /// </summary>
        /// <param name="refVarName"></param>
        public void UpdateRefVarName(string refVarName)
        {
            Questions = new BindingList<QuestionRecord>(DBAction.GetRefVarNameQuestionsGlob(refVarName, SurveyGlob));
            foreach (QuestionRecord q in Questions)
            {
                q.Translations = DBAction.GetQuestionTranslationRecords(q.ID);
            }
            bs.DataSource = Questions;
            bs.ResetBindings(false);

            CurrentQuestion = (QuestionRecord)bs.Current;

            dgvDS.DataSource = Questions;
        }

        /// <summary>
        /// Refreshes the RichTextBox displaying the complete question text.
        /// </summary>
        private void UpdateQuestion()
        {
            CurrentQuestion = (QuestionRecord)bs.Current;
            rtbQuestionText.Rtf = "";

            if (CurrentQuestion != null)
                rtbQuestionText.Rtf = CurrentQuestion.GetQuestionTextRich(true);

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
            bsTranslations.DataSource = bs.Current;
            bsTranslations.DataMember = "Translations";
            if (bsTranslations.Count > 0)
            {
                txtLanguage.DataBindings.Add("Text", bsTranslations, "Language");
                rtbTranslation.DataBindings.Add("RTF", bsTranslations, "TranslationRTF");
            }
        }

        /// <summary>
        /// Updates MainQuestion's field to wnum.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="wnum"></param>
        public void ExportWording(string field, int wnum)
        {
            switch (field)
            {
                case "PreP":
                    MainQuestion.PrePNum = wnum;
                    break;
                case "PreI":
                    MainQuestion.PreINum = wnum;
                    break;
                case "PreA":
                    MainQuestion.PreANum = wnum;
                    break;
                case "LitQ":
                    MainQuestion.LitQNum = wnum;
                    break;
                case "PstI":
                    MainQuestion.PstINum = wnum;
                    break;
                case "PstP":
                    MainQuestion.PstPNum = wnum;
                    break;
            }
        }

        /// <summary>
        /// Updates MainQuestion's field to respname.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="respname"></param>
        public void ExportWording(string field, string respname)
        {
            switch (field)
            {
                case "RespOptions":
                    MainQuestion.RespName = respname;
                    break;
                case "NRCodes":
                    MainQuestion.NRName = respname;
                    break;
            }
        }

        /// <summary>
        /// Updates the CurrentQuestion's field to wnum.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="wnum"></param>
        public void ImportWording(string field, int wnum)
        {
            switch (field)
            {
                case "PreP":
                    CurrentQuestion.PrePNum = wnum;
                    break;
                case "PreI":
                    CurrentQuestion.PreINum = wnum;
                    break;
                case "PreA":
                    CurrentQuestion.PreANum = wnum;
                    break;
                case "LitQ":
                    CurrentQuestion.LitQNum = wnum;
                    break;

                case "PstI":
                    CurrentQuestion.PstINum = wnum;
                    break;
                case "PstP":
                    CurrentQuestion.PstPNum = wnum;
                    break;
            }
        }

        /// <summary>
        /// Updates the CurrentQuestion's field to respname.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="respname"></param>
        public void ImportWording(string field, string respname)
        {
            switch (field)
            {
                case "RespOptions":
                    CurrentQuestion.RespName = respname;
                    break;
                case "NRCodes":
                    CurrentQuestion.NRName = respname;
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

            ImportWording("PreP", question.PrePNum);
            ImportWording("PreI", question.PreINum);
            ImportWording("PreA", question.PreANum);
            ImportWording("LitQ", question.LitQNum);
            ImportWording("PstI", question.PstINum);
            ImportWording("PstP", question.PstPNum);
            ImportWording("RespOptions", question.RespName);
            ImportWording("NRCodes", question.NRName);
        }

        /// <summary>
        /// Updates all fields in MainQuestion to match question.
        /// </summary>
        /// <param name="question"></param>
        public void ExportWordings(SurveyQuestion question)
        {
            if (question == null) return;

            ExportWording("PreP", question.PrePNum);
            ExportWording("PreI", question.PreINum);
            ExportWording("PreA", question.PreANum);
            ExportWording("LitQ", question.LitQNum);
            ExportWording("PstI", question.PstINum);
            ExportWording("PstP", question.PstPNum);
            ExportWording("RespOptions", question.RespName);
            ExportWording("NRCodes", question.NRName);
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

        #endregion

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentQuestion.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            MoveRecord(1);

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentQuestion.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentQuestion.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentQuestion.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            bs.MoveFirst();
        }


        #endregion

        
    }
}
