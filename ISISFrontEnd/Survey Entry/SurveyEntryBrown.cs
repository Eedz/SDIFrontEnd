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
    public partial class SurveyEntryBrown : Form
    {
        SurveyQuestion CurrentQuestion;
        public SurveyEntry frmParent;
        private string SurveyGlob;
        BindingList<SurveyQuestion> Questions;
        BindingSource bs;
        BindingSource bsTranslations;
        public bool Pin { get; set; }

        public SurveyEntryBrown(string refVarName, string surveyGlob)
        {
            InitializeComponent();

            // hide translation panel
            

            Questions = new BindingList<SurveyQuestion>();
            SurveyGlob = surveyGlob;
            bs = new BindingSource()
            {
                DataSource = Questions
            };
            bs.PositionChanged += Bs_PositionChanged;
            navQuestions.BindingSource = bs;

            bsTranslations = new BindingSource()
            {
                DataSource = bs.Current,
                DataMember = "Translations"
            };
            navTranslations.BindingSource = bsTranslations;

            BindProperties();

            ColorForm();

            UpdateRefVarName(refVarName);
            CurrentQuestion = (SurveyQuestion)bs.Current;
            translationPanel.Height = 0;
            this.Height -= 260;
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;
            rtbQuestionText.Rtf = "";
            if (CurrentQuestion == null) return;

            rtbQuestionText.Rtf = CurrentQuestion.GetQuestionTextRich();
        }

        private void BindProperties()
        {
            txtVarName.DataBindings.Add("Text", bs, "VarName.FullVarName");
            txtSurvey.DataBindings.Add("Text", bs, "SurveyCode");
            txtQnum.DataBindings.Add("Text", bs, "Qnum");
            txtVarLabel.DataBindings.Add("Text", bs, "VarName.VarLabel");
            txtPrePNum.DataBindings.Add("Text", bs, "PrePNum");
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


        private void ColorForm()
        {
            Color temp = Color.FromArgb(0xC7B889);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;
        }

        public void UpdateForm(string refVarName)
        {
            SurveyQuestion currentQ = (SurveyQuestion)bs.Current;
            UpdateRefVarName(refVarName);
            UpdateTranslation();

            txtTranslationPreP.Visible = frmParent.CurrentSurvey.EnglishRouting;
            txtTranslationPstP.Visible = frmParent.CurrentSurvey.EnglishRouting;
            if (frmParent.CurrentSurvey.EnglishRouting)
            {
                rtbTranslation.Top = txtTranslationPreP.Top;
                // rtbTranslation.Height = Translation

            }
            else
            {
                rtbTranslation.Top = txtTranslationPreP.Top + 15;
            }
        }

        private void UpdateRefVarName(string refVarName)
        {
            Questions = new BindingList<SurveyQuestion>(DBAction.GetRefVarNameQuestionsGlob(refVarName, SurveyGlob));

            bs.DataSource = Questions;

            UpdateTranslation();
        }
        

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
                rtbTranslation.DataBindings.Add("RTF", bsTranslations, "TranslationText");
            }
        }

        private void SurveyEntryBrown_Load(object sender, EventArgs e)
        {

        }

        private void cmdViewTranslation_Click(object sender, EventArgs e)
        {
            if (translationPanel.Height == 0)
            {
                this.Height += 260;
                translationPanel.Height = 260;
            }
            else
            {
                this.Height -= 260;
                translationPanel.Height = 0;
            }
        }
    }
}
