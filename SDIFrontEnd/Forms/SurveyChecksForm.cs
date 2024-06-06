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
using HtmlRtfConverter;
using FM = FormManager;

namespace SDIFrontEnd
{
    // TODO wave checks - sections check
    // TODO survey checks - translation varnames
    // TODO output each check 
    // TODO button on each check to make a record
    public partial class SurveyChecksForm : Form
    {
        int resultsX = 325;
        int resultsY = 30;

        SurveyChecker surveyChecker;

        BindingSource bsRouting;
        List<RoutingCheckQuestion> RoutingVars;
        List<SurveyQuestion> SeriesWithin;
        List<string> SeriesAcross;
        List<SurveyQuestion> BlankLabels;
        List<SurveyQuestion> YQnums;
        List<CanonicalRefVarName> CanonVars;
        List<SurveyQuestion> TranslationVars;


        public SurveyChecksForm()
        {
            InitializeComponent();

            RoutingVars = new List<RoutingCheckQuestion>();

            bsRouting = new BindingSource()
            {
                DataSource = RoutingVars
            };
            bsRouting.PositionChanged += BsRouting_PositionChanged;

            rbSurvey.Checked = true;

            cboSurvey2.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey2.DisplayMember = "SurveyCode";
            cboSurvey2.ValueMember = "SID";
            cboSurvey2.MouseWheel += ComboBox_MouseWheel;

            cboSource.MouseWheel += ComboBox_MouseWheel;

            BindProperties();
            tabResults.TabPages.Remove(pageTranslationVars);
        }

        #region Events 
        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void ScopeChanged(object sender, EventArgs e)
        {
            if (rbSurvey.Checked)
            {
                lblSource.Text = "Survey";
                cboSource.DataSource = new List<Survey>(Globals.AllSurveys);
                cboSource.DisplayMember = "SurveyCode";
                cboSource.ValueMember = "SID";

                tabResults.Left = resultsX;
                tabResults.Top = resultsY;
            }
            else if (rbWave.Checked)
            {
                lblSource.Text = "Wave";
                cboSource.DataSource = new List<StudyWave>(Globals.AllWaves);
                cboSource.DisplayMember = "WaveCode";
                cboSource.ValueMember = "WaveCode";

                cmdSectionsCheck.Left = resultsX;
                cmdSectionsCheck.Top = resultsY;

            }

            cmdRunChecks.Visible = rbSurvey.Checked;
            tabResults.Visible = rbSurvey.Checked;
            cmdSectionsCheck.Visible = rbWave.Checked;
        }

        private void cboSource_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rbWave.Checked)
            {
                StudyWave selectedWave = (StudyWave)cboSource.SelectedItem;
                if (selectedWave.Surveys.Count == 1)
                {
                    MessageBox.Show("This wave has only 1 survey. Unable to perform wave checks.");
                    ToggleWaveChecks(false);
                }
                else
                {
                    ToggleWaveChecks(true);
                }

                return;
            }

            Survey selected = (Survey)cboSource.SelectedItem;
            // if not an english routing survey, enable translation variable check options
            if (Globals.AllWaves.Any(x=>x.Surveys.Contains(selected) && !x.EnglishRouting))
            {
                cboLanguage.Enabled = true;
                cboLanguage.DataSource = selected.LanguageList;
                cboLanguage.DisplayMember = "SurvLanguage.LanguageName";
                cboLanguage.DisplayMember = "SurvLanguage.ID";
            }
            else
            {
                cboLanguage.Enabled = false;
            }
        }

        private void cmdRunChecks_Click(object sender, EventArgs e)
        {
            RunAllChecks();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SurveyChecksMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void lstSeriesErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            SurveyQuestion selected = (SurveyQuestion)lstSeriesErrors.SelectedItem;
            lblSeriesError.Text = selected.VarName.RefVarName + "/" + selected.Qnum;
            SurveyQuestion starter = surveyChecker.QuestionList.Where(x => x.Qnum.Equals(selected.Qnum.Substring(0, 3) + "a")).FirstOrDefault();
            lblSeriesStarter.Text = starter.VarName.RefVarName + "/" + starter.Qnum;

            rtbSeriesErrorPreP.Rtf = Converter.HTMLToRtf(selected.PrePW.WordingText);
            if (selected.PrePW.Equals(starter.PrePW))
                rtbSeriesErrorPreP.BackColor = Color.LightGreen;
            else
                rtbSeriesErrorPreP.BackColor = Color.Red;

            rtbSeriesErrorPreI.Rtf = Converter.HTMLToRtf(selected.PreIW.WordingText);
            if (selected.PreIW.Equals(starter.PreIW))
                rtbSeriesErrorPreI.BackColor = Color.LightGreen;
            else
                rtbSeriesErrorPreI.BackColor = Color.Red;

            rtbSeriesErrorPreA.Rtf = null;
            rtbSeriesErrorPreA.Rtf = Converter.HTMLToRtf(selected.PreAW.WordingText);
            if (selected.PreAW.Equals(starter.PreAW))
                rtbSeriesErrorPreA.BackColor = Color.LightGreen;
            else
                rtbSeriesErrorPreA.BackColor = Color.Red;

            rtbSeriesErrorLitQ.Rtf = null;
            rtbSeriesErrorLitQ.Rtf = Converter.HTMLToRtf(selected.LitQW.WordingText);

            rtbSeriesErrorRO.Rtf = null;
            rtbSeriesErrorRO.Rtf = Converter.HTMLToRtf(selected.RespOptionsS.RespList);
            if (selected.RespOptionsS.Equals(starter.RespOptionsS))
                rtbSeriesErrorRO.BackColor = Color.LightGreen;
            else
                rtbSeriesErrorRO.BackColor = Color.Red;

            rtbSeriesErrorNR.Rtf = null;
            rtbSeriesErrorNR.Rtf = Converter.HTMLToRtf(selected.NRCodesS.RespList); 
            if (selected.NRCodesS.Equals(starter.NRCodesS))
                rtbSeriesErrorNR.BackColor = Color.LightGreen;
            else
                rtbSeriesErrorNR.BackColor = Color.Red;

            rtbSeriesErrorPstI.Rtf = Converter.HTMLToRtf(selected.PstIW.WordingText);
            if (selected.PstIW.Equals(starter.PstIW))
                rtbSeriesErrorPstI.BackColor = Color.LightGreen;
            else
                rtbSeriesErrorPstI.BackColor = Color.Red;

            rtbSeriesErrorPstP.Rtf = Converter.HTMLToRtf(selected.PstPW.WordingText);
            if (selected.PstPW.Equals(starter.PstPW))
                rtbSeriesErrorPstP.BackColor = Color.LightGreen;
            else
                rtbSeriesErrorPstP.BackColor = Color.Red;

            rtbSeriesStarterPreP.Rtf = Converter.HTMLToRtf(starter.PrePW.WordingText);
            rtbSeriesStarterPreI.Rtf = Converter.HTMLToRtf(starter.PreIW.WordingText);
            rtbSeriesStarterPreA.Rtf = Converter.HTMLToRtf(starter.PreAW.WordingText);
            rtbSeriesStarterLitQ.Rtf = Converter.HTMLToRtf(starter.LitQW.WordingText);
            rtbSeriesStarterRO.Rtf = Converter.HTMLToRtf(starter.RespOptionsS.RespList);
            rtbSeriesStarterNR.Rtf = Converter.HTMLToRtf(starter.NRCodesS.RespList);
            rtbSeriesStarterPstI.Rtf = Converter.HTMLToRtf(starter.PstIW.WordingText);
            rtbSeriesStarterPstP.Rtf = Converter.HTMLToRtf(starter.PstPW.WordingText);

        }

        #endregion

        #region Survey Check Events

        private void BsRouting_PositionChanged(object sender, EventArgs e)
        {
            lstMissingPreP.DataSource = ((RoutingCheckQuestion)bsRouting.Current).MissingPrePVars;
            lstMissingPstP.DataSource = ((RoutingCheckQuestion)bsRouting.Current).MissingPstPVars;
            lstLatePreP.DataSource = ((RoutingCheckQuestion)bsRouting.Current).LatePrePVars;
            lstEarlyPstP.DataSource = ((RoutingCheckQuestion)bsRouting.Current).EarlyPstPVars;

            rtbRoutingQuestion.Rtf = null;
            rtbRoutingQuestion.Rtf = Converter.HTMLToRtf(((RoutingCheckQuestion)bsRouting.Current).GetQuestionTextHTML());

        }

        private void cmdPrintLabelCheck_Click(object sender, EventArgs e)
        {
            VariableListReport rpt = new VariableListReport();
            foreach (SurveyQuestion sq in BlankLabels)
            {
                rpt.VarNames.Add(sq.VarName);
            }

            rpt.IncludeVarLabel = true;
            rpt.IncludeContent = true;
            rpt.IncludeTopic = true;
            rpt.IncludeDomain = true;
            rpt.IncludeProduct = true;
            rpt.CreateReport();
        }

        #endregion

        #region Wave Check Events
        private void cmdSectionsCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wave check not yet implemented.");

            //StudyWave wave = (StudyWave)cboSource.SelectedItem;

            //var surveys = wave.Surveys.OrderByDescending(x => x.Questions.Count);

            //foreach (Survey s in surveys)
            //{

            //}
        }

        #endregion

        #region Methods
        private void RunAllChecks()
        {
            List<SurveyQuestion> sourceList = new List<SurveyQuestion>(DBAction.GetSurveyQuestions((Survey)cboSource.SelectedItem));
            List<SurveyQuestion> refList = new List<SurveyQuestion>(DBAction.GetSurveyQuestions((Survey)cboSurvey2.SelectedItem));

            surveyChecker = new SurveyChecker(sourceList);
            surveyChecker.CanonVars = new List<CanonicalRefVarName>(Globals.AllCanonVars);

            RoutingVars = surveyChecker.GetRoutingCheckResults();

            bsRouting.DataSource = RoutingVars;
            navRouting.BindingSource = bsRouting;
            pageRoutingCheck.Text = "Routing Check (" + RoutingVars.Count + ")";

            SeriesWithin = surveyChecker.SeriesHomogeneityCheck();
            lstSeriesErrors.DataSource = SeriesWithin;
            lstSeriesErrors.DisplayMember = "VarName.RefVarName";
            pageSeriesConsistency.Text = "Series Check (" + SeriesWithin.Count + ")";

            SeriesAcross = surveyChecker.SeriesCompare(refList);
            lstSeriesCompare.DataSource = SeriesAcross;
            pageSeriesConsistency2.Text = "Series Compare (" + SeriesAcross.Count + ")";

            BlankLabels = surveyChecker.GetBlankLabels();
            foreach (SurveyQuestion sq in BlankLabels)
            {
                lstBlankLabels.Items.Add(new ListViewItem(new string[] { sq.VarName.VarName, sq.VarName.VarLabel, sq.VarName.Content.LabelText, sq.VarName.Topic.LabelText,
                    sq.VarName.Domain.LabelText, sq.VarName.Product.LabelText }));
            }
            pageBlankLabels.Text = "Blank Labels (" + BlankLabels.Count + ")";

            YQnums = surveyChecker.GetYQnums();
            foreach (SurveyQuestion sq in YQnums)
            {
                lstYQnums.Items.Add(new ListViewItem(new string[] { sq.VarName.VarName, sq.Qnum }));
            }
            pageYQnums.Text = "'y' Qnums (" + YQnums.Count + ")";

            CanonVars = surveyChecker.GetMissingCanonicalVars();
            lstCanonVars.DataSource = CanonVars;
            pageCanonVars.Text = "Canonical Vars (" + CanonVars.Count + ")";

            TranslationVars = surveyChecker.TranslationVarsCheck();
           // pageTranslationVars.Text = "Translation Vars (" + TranslationVars.Count + ")";
            
        }

        private void BindProperties()
        {
            txtRoutingVarName.DataBindings.Add("Text", bsRouting, "VarName.VarName");
            txtRoutingQnum.DataBindings.Add("Text", bsRouting, "Qnum");

            
        }

        private void ToggleWaveChecks(bool enable)
        {
            cmdSectionsCheck.Enabled = enable;
        }
        #endregion




    }
}
