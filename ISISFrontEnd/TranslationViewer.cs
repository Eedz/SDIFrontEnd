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
    // TODO format unicode translations 
    public partial class TranslationViewer : Form
    {
        public SurveyEntry frmParent;
        List<Translation> Translations;
        BindingSource bs;
        

        public TranslationViewer(int QID)
        {
            InitializeComponent();

            Translations = DBAction.GetQuestionTranslations(QID);

            if (Translations.Count == 0)
            {
                MessageBox.Show("No translations found for this question.");
                Close();
            }


            bs = new BindingSource();
            bs.DataSource = Translations;

            navTranslations.BindingSource = bs;

            txtSurvey.DataBindings.Add(new Binding("Text", bs, "Survey"));
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName"));
            txtLanguage.DataBindings.Add(new Binding("Text", bs, "Language"));
            Translation t = (Translation)bs.Current;
            
            rtbTranslationText.DataBindings.Add(new Binding("Rtf", bs, "TranslationRTF"));
        }

        public void UpdateForm(int QID)
        {
            SurveyQuestion currentQ = (SurveyQuestion)bs.Current;

            Translations = DBAction.GetQuestionTranslations(QID);

            bs.DataSource = Translations;

            txtPreP.Visible = frmParent.CurrentSurvey.EnglishRouting;
            txtPstP.Visible = frmParent.CurrentSurvey.EnglishRouting;
            if (frmParent.CurrentSurvey.EnglishRouting)
            {
                rtbTranslationText.Top = txtPreP.Top;
                // rtbTranslation.Height = Translation

            }
            else
            {
                rtbTranslationText.Top = txtPreP.Top + 15;
            }
        }

        static string GetRtfUnicodeEscapedString(string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c == '\\' || c == '{' || c == '}')
                    sb.Append(@"\" + c);
                else if (c <= 0x7f)
                    sb.Append(c);
                else
                    sb.Append("\\u" + Convert.ToUInt32(c) + "?");
            }
            return sb.ToString();
        }
    }

    
}
