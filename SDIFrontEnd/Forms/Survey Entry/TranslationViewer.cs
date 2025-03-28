﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;
using HtmlRtfConverter;

namespace SDIFrontEnd
{   
    public partial class TranslationViewer : Form
    {
        List<TranslationRecord> Records;
        TranslationRecord CurrentRecord;

        Survey ParentSurvey;
        SurveyQuestion MainQuestion;

        BindingSource bs;
        BindingSource bsCurrent;
        
        public TranslationViewer(Survey survey, QuestionRecord question)
        {
            InitializeComponent();

            ParentSurvey = survey;
            MainQuestion = question.Item;

            FillLists();

            if (Records.Count == 0)
            {
                MessageBox.Show("No translations found for this question.");
                Close();
            }

            SetupBindingSources();

            BindProperties();
 
            CurrentRecord = (TranslationRecord)bs.Current;

            LockForm(!ParentSurvey.Locked);
            AdjustRouting();
            SetReadingDirection();
        }

        public TranslationViewer(Survey survey, QuestionRecord question, string lang) : this (survey,question)
        { 
            foreach (TranslationRecord r in Records)
            {
                if (!r.Item.LanguageName.LanguageName.Equals(lang))
                    bs.MoveNext();
            }
            UpdateForm(survey, question);
        }

        #region Events
        private void TranslationViewer_Load(object sender, EventArgs e)
        {
            CurrentRecord = (TranslationRecord)bs.Current;
            bs.ResetCurrentItem();
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (TranslationRecord)bs.Current;
            if (CurrentRecord == null) return;
            UpdateText();
        }

        private void BsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null)
                return;

            // get the paper record that was modified
            Translation modifiedRegion = (Translation)bsCurrent[e.NewIndex];
            TranslationRecord modifiedRecord = Records.Where(x => x.Item == modifiedRegion).FirstOrDefault();

            if (modifiedRecord == null)
                return;

            switch (e.PropertyDescriptor.Name)
            {
                default:
                    modifiedRecord.Dirty = true;
                    break;
            }
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;
        }

        private void TranslationViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveRecord() == 1)
            {
                if (MessageBox.Show("This record has unsaved changes. Are you sure you want to close this record and lose those changes?", "Confirm close.", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }

        }

        #region Navigator Events

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveFirst();
        }

        #endregion

        #endregion

        private void FillLists()
        {
            Records = new List<TranslationRecord>();

            foreach (Translation t in MainQuestion.Translations)
            {
                TranslationRecord tr = new TranslationRecord(t);
                if (t.ID == 0)
                    tr.NewRecord = true;
                Records.Add(tr);
            }
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource()
            {
                DataSource = bs
            };
            bsCurrent.DataMember = "Item";
            bsCurrent.ListChanged += BsCurrent_ListChanged;

            navTranslations.BindingSource = bs;
        }

        private void BindProperties()
        {
            txtSurvey.DataBindings.Add(new Binding("Text", bsCurrent, "Survey"));
            txtVarName.DataBindings.Add(new Binding("Text", bsCurrent, "VarName"));
            txtLanguage.DataBindings.Add(new Binding("Text", bsCurrent, "LanguageName.LanguageName"));
        }

        private void UpdateText()
        {
            extraRichTextBox1.Rtf = null;

            if (CurrentRecord == null) return;

            extraRichTextBox1.Rtf = Converter.HTMLToRtf(CurrentRecord.Item.TranslationText);
            rtbPreP.Rtf = null;
            rtbPreP.Rtf = Converter.HTMLToRtf(MainQuestion.PrePW.WordingText);
            rtbPstP.Rtf = null;
            rtbPstP.Rtf = Converter.HTMLToRtf(MainQuestion.PstPW.WordingText);
        }

        public void UpdateForm(Survey survey, QuestionRecord question, SurveyLanguage language = null)
        {
            ParentSurvey = survey;
            MainQuestion = question.Item;

            Records.Clear();
            FillLists();

            if (Records.Count() == 0 || ParentSurvey.Locked)
            {
                LockForm(false);
            }
            else
                LockForm(true);

            if (language!=null && !language.SurvLanguage.LanguageName.Equals("<All>"))
                bs.DataSource = Records.Where(x=>x.Item.Language.Equals(language.SurvLanguage.LanguageName));
            else
                bs.DataSource = Records;

            CurrentRecord = (TranslationRecord)bs.Current;
            bs.ResetCurrentItem();

            UpdateText();
            
            AdjustRouting();
            SetReadingDirection();
        }


        private void LockForm(bool locks)
        {
            txtSurvey.Enabled = locks;
            txtVarName.Enabled = locks;
            txtLanguage.Enabled = locks;
            rtbPreP.Enabled = locks;
            extraRichTextBox1.Enabled = locks;
            rtbPstP.Enabled = locks;
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
                extraRichTextBox1.Top = rtbPreP.Top + rtbPreP.Height + 5;
            }
            else
            {
                extraRichTextBox1.Top = rtbPreP.Top;
                extraRichTextBox1.Height += rtbPreP.Height + rtbPstP.Height;
            }
        }

        /// <summary>
        /// Set the reading direction based on the current language's RTL property.
        /// </summary>
        public void SetReadingDirection()
        {
            if (CurrentRecord != null && CurrentRecord.Item.LanguageName.RTL)
                extraRichTextBox1.RightToLeft = RightToLeft.Yes;
            else
                extraRichTextBox1.RightToLeft = RightToLeft.No;
        }

        private int SaveRecord()
        {
            if (CurrentRecord == null) return 0;

            if (ParentSurvey.Locked)
                return 0;

            bsCurrent.EndEdit();
            UpdatePlainText();
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
            string html = Converter.ConvertRTFtoHTML(extraRichTextBox1.Rtf);
            // now remove the extraneous tags
            html = HTMLUtilities.RemoveHtmlTag(html, "div");
            html = HTMLUtilities.RemoveEmptyParagraphsWithBr(html);
            html = HTMLUtilities.RemoveStyleAttribute(html, "p");
            html = html.Replace("<p>", "<br>");
            html = html.Replace("</p>", "");
            html = html.Replace("<span>", "");
            html = html.Replace("</span>", "");
            html = html.TrimAndRemoveAll("<br>");

            if (CurrentRecord == null) return;
            CurrentRecord.Item.TranslationText = html;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox("TYPE 'DELETE' TO CONFIRM", "WARNING", string.Empty);
            input.ShowDialog();
            if (input.userInput != "DELETE")
                return;

            DBAction.DeleteRecord(CurrentRecord.Item);
            MainQuestion.Translations.Remove(CurrentRecord.Item);
            bs.RemoveCurrent();
            UpdateText();
        }
    }
}
