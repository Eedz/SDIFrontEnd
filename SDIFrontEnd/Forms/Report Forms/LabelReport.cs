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

using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class LabelReport : Form
    {
        TopicContentReport Report;

        public LabelReport()
        {
            InitializeComponent();

            Report = new TopicContentReport();

            cmdAddSurvey.Text = char.ConvertFromUtf32(0x2192);
            cmdRemoveSurvey.Text = char.ConvertFromUtf32(0x2190);

            cboSurveys.ValueMember = "SID";
            cboSurveys.DisplayMember = "SurveyCode";
            cboSurveys.DataSource = new List<Survey>(Globals.AllSurveys);

            lstSelectedSurveys.DisplayMember = "SurveyCode";
            lstSelectedSurveys.ValueMember = "SID";
            lstSelectedSurveys.DataSource = Report.Surveys;

            optTC.Checked = true;
            optTCP.DataBindings.Add("Checked", Report, "ProductCrosstab", true, DataSourceUpdateMode.OnPropertyChanged);
            chkIncludePlainFilters.DataBindings.Add("Checked", Report, "PlainFilters", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LabelReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            FM.FormManager.RemovePopup(this);
        }

        private void AddSurvey_Click(object sender, EventArgs e)
        {
            // add survey to the SurveyReport object
            ReportSurvey s;
            try
            {
                s = new ReportSurvey((Survey)cboSurveys.SelectedItem);
            }
            catch (Exception)
            {
                MessageBox.Show("Survey not found.");
                return;
            }

            if (cboSurveys.SelectedIndex < cboSurveys.Items.Count - 1)
                cboSurveys.SelectedIndex++;

            AddSurvey(s);
        }

        private void RemoveSurvey_Click(object sender, EventArgs e)
        {
            RemoveSurvey((ReportSurvey)lstSelectedSurveys.SelectedItem);
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void cmdOpenReportFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports\ISR");
        }

        /// <summary>
        /// Add a survey to the report.
        /// </summary>
        /// <param name="s">ReportSurvey object being added to the report.</param>
        private void AddSurvey(ReportSurvey s)
        {
            if (Report.HasSurvey(s))
            {
                return;
            }

            Report.AddSurvey(s);

            // show the options tabs if at least one survey is chosen
            if (lstSelectedSurveys.Items.Count > 0)
            {
                grpLabels.Enabled = true;
                cmdOpenReportFolder.Visible = true;
                cmdGenerate.Visible = true;
            }
        }

        /// <summary>
        /// Remove a survey from the report.
        /// </summary>
        /// <param name="s">ReportSurvey object being removed from the report.</param>
        private void RemoveSurvey(ReportSurvey s)
        {
            // remove survey from the SurveyReport object
            Report.RemoveSurvey((ReportSurvey)lstSelectedSurveys.SelectedItem);
            GC.Collect();

            // hide the options tabs no surveys are chosen
            if (lstSelectedSurveys.Items.Count < 1)
            {
                cmdOpenReportFolder.Visible = false;
                cmdGenerate.Visible = false;               
            }
        }

        private void RunReport()
        {
            int result;

            // get the survey data for all chosen surveys
            PopulateSurveys();
            Report.LayoutOptions.PaperSize = PaperSizes.Legal;
            Report.LayoutOptions.BlankColumn = true;
            Report.FileName = new UserPrefs().ReportPath;

            result = Report.GenerateLabelReport();

            switch (result)
            {
                case 1:
                    MessageBox.Show("One or more surveys contain no records.");
                    // TODO if a backup was chosen, show a form for selecting a different survey code from that date
                    break;
                default:
                    break;
            }


            // output report to Word/PDF
            Report.OutputReportTableXML();
        }

        /// <summary>
        /// For each survey in the report, fill the question list, comments and translations as needed.
        /// </summary>
        private void PopulateSurveys()
        {
            // populate the survey and extra fields
            foreach (ReportSurvey rs in Report.Surveys)
            {
                rs.Questions.Clear();
                rs.SurveyNotes.Clear();
                rs.VarChanges.Clear();

                // questions
                if (rs.Backend.Date != DateTime.Today)
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetBackupQuestions(rs, rs.Backend)));
                else
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetSurveyQuestions(rs)));

                List<QuestionTimeFrame> timeframes = DBAction.GetTimeFrames(rs.SurveyCode);
                foreach (SurveyQuestion question in rs.Questions)
                {
                    question.TimeFrames = timeframes.Where(x => x.QID == question.ID).ToList();
                }

                // survey notes
                if (Report.SurvNotes)
                    rs.SurveyNotes = DBAction.GetSurvComments(rs);

                // comments
                if (rs.CommentFields.Count > 0)
                {
                    DBAction.FillCommentsBySurvey(rs);
                }

                // translations
                if (rs.Backend.Date != DateTime.Today)
                    DBAction.FillBackupTranslation(rs, rs.Backend.Date, rs.TransFields);
                else
                {
                    foreach (string language in rs.TransFields)
                    {
                        var translations = DBAction.GetSurveyTranslation(rs.SurveyCode, language);

                        foreach (Translation t in translations)
                            rs.QuestionByID(t.QID).Translations.Add(t);
                    }
                }

                // filters
                if (rs.FilterCol)
                    rs.MakeFilterList();

                // varchanges (for appendix)
                if (Report.VarChangesApp)
                    rs.VarChanges = new List<VarNameChange>(DBAction.GetVarNameChanges(rs).Where(x => x.PreFWChange != Report.ExcludeTempChanges));


            }
        }

        
    }
}
