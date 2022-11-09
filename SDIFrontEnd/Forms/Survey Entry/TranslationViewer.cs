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
     
    public partial class TranslationViewer : Form
    {
       
        List<TranslationRecord> Translations;
        Survey ParentSurvey;
        BindingSource bs;
        SurveyQuestion MainQuestion;
        TranslationRecord CurrentRecord;
        
        public TranslationViewer(Survey survey, QuestionRecord question)
        {
            InitializeComponent();

            ParentSurvey = survey;
            Translations = new List<TranslationRecord>(question.Translations);

            if (Translations.Count == 0)
            {
                MessageBox.Show("No translations found for this question.");
                Close();
            }

            bs = new BindingSource();
            bs.DataSource = Translations;
            bs.ListChanged += Bs_ListChanged;
            bs.PositionChanged += Bs_PositionChanged;
            navTranslations.BindingSource = bs;
            MainQuestion = question;

            txtSurvey.DataBindings.Add(new Binding("Text", bs, "Survey"));
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName"));
            txtLanguage.DataBindings.Add(new Binding("Text", bs, "Language"));
            rtbPreP.Rtf = MainQuestion.PrepRTF;
            rtbPstP.Rtf = MainQuestion.PstpRTF;

            rtbTranslationText.DataBindings.Add(new Binding("Rtf", bs, "TranslationRTF"));


            AdjustRouting();
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (TranslationRecord)bs.Current;
        }

        #region Events
        private void TranslationViewer_Load(object sender, EventArgs e)
        {
            CurrentRecord = (TranslationRecord)bs.Current;
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
                CurrentRecord.Dirty = true;
        }

        private void cmdBold_Click(object sender, EventArgs e)
        {
            Font oldFont = rtbTranslationText.SelectionFont;
            Font newFont;

            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            rtbTranslationText.SelectionFont = newFont;
        }

        private void cmdItalic_Click(object sender, EventArgs e)
        {
            Font oldFont = rtbTranslationText.SelectionFont;
            Font newFont;

            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            rtbTranslationText.SelectionFont = newFont;
        }

        private void cmdUnderline_Click(object sender, EventArgs e)
        {
            Font oldFont = rtbTranslationText.SelectionFont;
            Font newFont;

            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            rtbTranslationText.SelectionFont = newFont;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            UpdatePlainText();
            if (SaveRecord() == 1)
                return;
        }

        private void TranslationViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            bs.EndEdit();
            UpdatePlainText();
            if (SaveRecord() == 1)
            {
                if (MessageBox.Show("This record has unsaved changes. Are you sure you want to close this record and lose those changes?", "Confirm close.", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }

        }

        

        #region Navigator Events

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            bs.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            bs.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            bs.MoveFirst();
        }

        #endregion

        #endregion

        public void UpdateForm(Survey survey, QuestionRecord question, SurveyLanguage language = null)
        {
            ParentSurvey = survey;
            MainQuestion = question;
            Translations = question.Translations;

            if (language!=null && !language.SurvLanguage.LanguageName.Equals("<All>"))
                bs.DataSource = Translations.Where(x=>x.Language.Equals(language.SurvLanguage.LanguageName));
            else
                bs.DataSource = Translations;

            rtbPreP.Rtf = MainQuestion.PrepRTF;
            rtbPstP.Rtf = MainQuestion.PstpRTF;

            CurrentRecord = (TranslationRecord)bs.Current;

            AdjustRouting();

            SetReadingDirection();
        }

        /// <summary>
        /// Adjust the size and position of the translation box to show/hide the English skips and routing.
        /// </summary>
        public void AdjustRouting()
        {
            rtbPreP.Visible = ParentSurvey.EnglishRouting;
            rtbPstP.Visible = ParentSurvey.EnglishRouting;

            if (ParentSurvey.EnglishRouting)
            {
                rtbTranslationText.Top = rtbPreP.Top + rtbPreP.Height + cmdBold.Height + 5;
            }
            else
            {

                cmdBold.Top = rtbPreP.Top;
                cmdItalic.Top = rtbPreP.Top;
                cmdUnderline.Top = rtbPreP.Top;
                rtbTranslationText.Top = rtbPreP.Top + rtbPreP.Height;
                rtbTranslationText.Height += rtbPreP.Height + rtbPreP.Height;
            }
        }

        /// <summary>
        /// Set the reading direction based on the current language's RTL property.
        /// </summary>
        public void SetReadingDirection()
        {
            if (CurrentRecord != null && CurrentRecord.LanguageName.RTL)
                rtbTranslationText.RightToLeft = RightToLeft.Yes;
            else
                rtbTranslationText.RightToLeft = RightToLeft.No;
        }

        private int SaveRecord()
        { 
            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return 1;
            }

            return 0;
        }

        

        

        private void UpdatePlainText()
        {
            // change RTF tags to HTML tags
            rtbTranslationText.Rtf = Utilities.FormatRTF(rtbTranslationText.Rtf);
            // now get plain text which includes the HTML tags we've inserted
            string plain = rtbTranslationText.Text;

            CurrentRecord.TranslationText = plain;
            CurrentRecord.Dirty = true;
            bs.ResetCurrentItem();
        }

        private void rtbTranslationText_Validated(object sender, EventArgs e)
        {
            UpdatePlainText();
        }
    }
}
