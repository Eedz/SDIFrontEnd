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
    // TODO translation nagivagator position will not update or updates incorrectly.
    public partial class QuestionSearchResults : Form
    {

        List<SurveyQuestion> Results;
        BindingSource bs;
        BindingSource bsTranslations;
        SurveyQuestion CurrentQuestion;
        bool ShowTranslation;

        public QuestionSearchResults(List<SurveyQuestion> results, bool withTranslation)
        {
            InitializeComponent();

            Results = results;
            bs = new BindingSource();
            bs.DataSource = Results;

            bs.PositionChanged += Bs_PositionChanged;
            navResults.BindingSource = bs;

            bsTranslations = new BindingSource();
            bsTranslations.DataSource = bs;
            bsTranslations.DataMember = "Translations";
            bsTranslations.PositionChanged += BsTranslations_PositionChanged;
            nvgTranslations.BindingSource = bsTranslations;

            dataRepeater1.DataSource = bs;

            this.MouseWheel += QuestionSearchResults_MouseWheel;

            ShowTranslation = withTranslation;
            panelTranslations.Visible = ShowTranslation;
            lblTranslation.Visible = ShowTranslation;

            BindProperties();
        }

        #region Events
        private void QuestionSearchResults_Load(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;
            LoadQuestion();
        }

        private void BsTranslations_PositionChanged(object sender, EventArgs e)
        {
            var dataRepeaterItem = dataRepeater1.CurrentItem;
            var panel = (Panel)dataRepeaterItem.Controls.Find("panelGeneral", false)[0];
            var translationPanel = (Panel)panel.Controls.Find("panelTranslations", false)[0];
            var navigator = (BindingNavigator)translationPanel.Controls.Find("nvgTranslations", false)[0];
            var bindingsource = (BindingSource)navigator.BindingSource;

            Translation currentTranslation = (Translation)bindingsource.Current;

            
            var language = (TextBox)translationPanel.Controls.Find("txtLanguage", false)[0];
            language.Text = currentTranslation.LanguageName.LanguageName;

            var translation = (RichTextBox)translationPanel.Controls.Find("rtbTranslation", false)[0];
            translation.Rtf = "";
            translation.Rtf = currentTranslation.TranslationRTF;

            
            navigator.PositionItem.Text = (bindingsource.Position + 1).ToString();
            
        }

        private void QuestionSearchResults_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;
            LoadQuestion();
        }

        private void toolStripExport_Click(object sender, EventArgs e)
        {
            QuestionReport rpt = new QuestionReport();

            rpt.SelectedSurvey = null;
            rpt.IncludeSurvey = true;
            rpt.Questions = Results;
            rpt.IncludeTranslation = ShowTranslation;
            rpt.IncludeQuestion = true;

            rpt.CreateReport();
        }

        private void toolStripEditor_Click(object sender, EventArgs e)
        {
            SurveyEditor getFrm = (SurveyEditor)FormManager.GetForm("SurveyEditor", 6);
            if (getFrm!=null)
            {
                
                if (getFrm.CurrentSurvey.SurveyCode.Equals(CurrentQuestion.SurveyCode))
                    getFrm.GoToQuestion(CurrentQuestion.VarName.RefVarName);
                else
                {
                    getFrm.ChangeSurvey(CurrentQuestion.SurveyCode);
                    getFrm.GoToQuestion(CurrentQuestion.VarName.RefVarName);
                }
            }
            else
            {
                SurveyEditor frm = new SurveyEditor(CurrentQuestion.SurveyCode, CurrentQuestion.VarName.RefVarName);
                frm.Tag = 6;
                FormManager.Add(frm);
                frm.GoToQuestion(CurrentQuestion.VarName.RefVarName);
            }
            ((MainMenu)FormManager.GetForm("MainMenu")).SelectTab("SurveyEditor6");
        }

        private void toolStripHarmony_Click(object sender, EventArgs e)
        {
            List<RefVariableName> vars = new List<RefVariableName>();
            foreach (SurveyQuestion sq in Results)
                vars.Add(sq.VarName);

            if (FormManager.FormOpen("HarmonyReport"))
            {
                HarmonyReportForm f = (HarmonyReportForm) FormManager.GetForm("HarmonyReport");
                foreach (RefVariableName rv in vars)
                    f.AddVar(rv);
                
                ((MainMenu)FormManager.GetForm("MainMenu")).SelectTab("HarmonyReport1");
                return;
            }
            
            HarmonyReportForm frm = new HarmonyReportForm();
            foreach (RefVariableName rv in vars)
                frm.AddVar(rv);

            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.Remove(this);
        }
        #endregion

        #region Methods

        private void BindProperties()
        {
            txtSurvey.DataBindings.Add(new Binding("Text", bs, "SurveyCode"));
            txtQnum.DataBindings.Add(new Binding("Text", bs, "Qnum"));
            txtAltQnum.DataBindings.Add(new Binding("Text", bs, "AltQnum"));
            txtAltQnum2.DataBindings.Add(new Binding("Text", bs, "AltQnum2"));
            txtAltQnum3.DataBindings.Add(new Binding("Text", bs, "AltQnum3"));

            // rest of the bindings are done in the datarepeater's drawItem event
            
        }

        private void LoadQuestion()
        {
            rtbQuestion.Rtf = "";

            if (CurrentQuestion == null)
                return;

            
            rtbQuestion.Rtf = CurrentQuestion.GetQuestionTextRich();
        }

        #endregion

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var panel = (Panel)e.DataRepeaterItem.Controls.Find("panelGeneral", false)[0];
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = ((BindingSource)dataRepeater.DataSource);
            var currentQuestion = ((SurveyQuestion)datasource[e.DataRepeaterItem.ItemIndex]);

            var varname = (TextBox)panel.Controls.Find("txtVarName", false)[0];
            varname.Text = currentQuestion.VarName.VarName;

            var refvarname = (TextBox)panel.Controls.Find("txtRefVarName", false)[0];
            refvarname.Text = currentQuestion.VarName.RefVarName;

            var varlabel = (TextBox)panel.Controls.Find("txtVarLabel", false)[0];
            varlabel.Text = currentQuestion.VarName.VarLabel;

            var content = (TextBox)panel.Controls.Find("txtContent", false)[0];
            content.Text = currentQuestion.VarName.Content.LabelText;

            var topic = (TextBox)panel.Controls.Find("txtTopic", false)[0];
            topic.Text = currentQuestion.VarName.Topic.LabelText;

            var domain = (TextBox)panel.Controls.Find("txtDomain", false)[0];
            domain.Text = currentQuestion.VarName.Domain.LabelText;

            var product = (TextBox)panel.Controls.Find("txtProduct", false)[0];
            product.Text = currentQuestion.VarName.Product.LabelText;

            var question = (RichTextBox)panel.Controls.Find("rtbQuestion", false)[0];
            question.Rtf = "";
            question.Rtf = currentQuestion.GetQuestionTextRich(true);

            if (currentQuestion.Translations.Count > 0)
            {

                var translationPanel = (Panel)panel.Controls.Find("panelTranslations", false)[0];
                var language = (TextBox)translationPanel.Controls.Find("txtLanguage", false)[0];
                language.Text = currentQuestion.Translations[0].LanguageName.LanguageName;

                var translation = (RichTextBox)translationPanel.Controls.Find("rtbTranslation", false)[0];
                translation.Rtf = "";
                translation.Rtf = currentQuestion.Translations[0].TranslationRTF;
            }

        }

        private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
        {
            var dataRepeaterItem = dataRepeater1.CurrentItem;
            var panel = (Panel)dataRepeaterItem.Controls.Find("panelGeneral", false)[0];
            
            var datasource = ((BindingSource)dataRepeater1.DataSource);
            var currentQuestion = ((SurveyQuestion)datasource[dataRepeaterItem.ItemIndex]);


            var translationPanel = (Panel)panel.Controls.Find("panelTranslations", false)[0];
            var navigator = (BindingNavigator)translationPanel.Controls.Find("nvgTranslations", false)[0];
            var bindingsource = (BindingSource)navigator.BindingSource;
            bindingsource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
        {
            var dataRepeaterItem = dataRepeater1.CurrentItem;
            var panel = (Panel)dataRepeaterItem.Controls.Find("panelGeneral", false)[0];

            var datasource = ((BindingSource)dataRepeater1.DataSource);
            var currentQuestion = ((SurveyQuestion)datasource[dataRepeaterItem.ItemIndex]);


            var translationPanel = (Panel)panel.Controls.Find("panelTranslations", false)[0];
            var navigator = (BindingNavigator)translationPanel.Controls.Find("nvgTranslations", false)[0];
            var bindingsource = (BindingSource)navigator.BindingSource;
            bindingsource.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
        {
            var dataRepeaterItem = dataRepeater1.CurrentItem;
            var panel = (Panel)dataRepeaterItem.Controls.Find("panelGeneral", false)[0];

            var datasource = ((BindingSource)dataRepeater1.DataSource);
            var currentQuestion = ((SurveyQuestion)datasource[dataRepeaterItem.ItemIndex]);


            var translationPanel = (Panel)panel.Controls.Find("panelTranslations", false)[0];
            var navigator = (BindingNavigator)translationPanel.Controls.Find("nvgTranslations", false)[0];
            var bindingsource = (BindingSource)navigator.BindingSource;
            bindingsource.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
        {
            var dataRepeaterItem = dataRepeater1.CurrentItem;
            var panel = (Panel)dataRepeaterItem.Controls.Find("panelGeneral", false)[0];

            var datasource = ((BindingSource)dataRepeater1.DataSource);
            var currentQuestion = ((SurveyQuestion)datasource[dataRepeaterItem.ItemIndex]);


            var translationPanel = (Panel)panel.Controls.Find("panelTranslations", false)[0];
            var navigator = (BindingNavigator)translationPanel.Controls.Find("nvgTranslations", false)[0];
            var bindingsource = (BindingSource)navigator.BindingSource;
            bindingsource.MoveFirst();
        }

        private void dataRepeater1_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            //var panel = (Panel)e.DataRepeaterItem.Controls.Find("panelGeneral", false)[0];
            //var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            //var datasource = ((BindingSource)dataRepeater.DataSource);
            //var currentQuestion = ((SurveyQuestion)datasource[e.DataRepeaterItem.ItemIndex]);

            
            //var translationPanel = (Panel)panel.Controls.Find("panelTranslations", false)[0];
            //var navigator = (BindingNavigator)translationPanel.Controls.Find("nvgTranslations", false)[0];
            //var bindingsource = (BindingSource)navigator.BindingSource;

            //BindingSource bs = new BindingSource()
            //{
            //    DataSource = currentQuestion.Translations
            //};

            //navigator.BindingSource = bs;
        }
    }
}

