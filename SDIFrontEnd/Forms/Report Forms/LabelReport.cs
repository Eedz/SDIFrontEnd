using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        List<ProductLabel> SelectedProducts;
        List<string> SelectedFields;

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
            
            SelectedFields = new List<string>();

            lstWordingFields.Items.Add("PreP");
            lstWordingFields.Items.Add("PreI");
            lstWordingFields.Items.Add("PreA");
            lstWordingFields.Items.Add("LitQ");
            lstWordingFields.Items.Add("PstI");
            lstWordingFields.Items.Add("PstP");
            lstWordingFields.Items.Add("RespOptions");
            lstWordingFields.Items.Add("NRCodes");
            for (int i = 0; i < lstWordingFields.Items.Count; i++)
                lstWordingFields.SetSelected(i, true);

            var products = DBAction.ListProductLabels();
            products.Remove(products[0]);
            products.Insert(0, new ProductLabel(-1, "<All>"));
            lstProducts.DataSource = products;

            lstProducts.Tag = true;
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
            if (Report.Surveys.Count==0) return;
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

            if (!lstProducts.GetSelected(0))
                SelectedProducts = lstProducts.SelectedItems.Cast<ProductLabel>().ToList();
            else
                SelectedProducts = new List<ProductLabel>();

            SelectedFields = lstWordingFields.SelectedItems.Cast<string>().ToList();

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
                var questions = DBAction.GetSurveyQuestions(rs);

                rs.ContentOptions.StdFieldsChosen = new ObservableCollection<string>(SelectedFields);

                if (Report.ProductCrosstab && SelectedProducts.Count > 0)
                {
                    rs.Questions.AddRange(questions.Where(x => SelectedProducts.Contains(x.VarName.Product)).ToList());
                }else
                {
                    rs.Questions.AddRange(questions);
                }

                List<QuestionTimeFrame> timeframes = DBAction.GetTimeFrames(rs.SurveyCode);
                foreach (SurveyQuestion question in rs.Questions)
                {
                    question.TimeFrames = timeframes.Where(x => x.QID == question.ID).ToList();
                }

                // comments
                if (rs.ContentOptions.CommentOptions.CommentFields.Count > 0)
                {
                    DBAction.FillCommentsBySurvey(rs);
                }

                // filters
                if (rs.ContentOptions.HasColumn("Filters"))
                    rs.MakeFilterList();

            }
        }

        private void optTCP_CheckedChanged(object sender, EventArgs e)
        {
            lstProducts.Enabled = optTCP.Checked;            
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstProducts_SelectedIndexChanged;

            if (lst.SelectedItems.Count == 0)
            {
                lst.SetSelected(0, true);
                lst.Tag = true;
            }

            int count = lst.SelectedItems.Count;

            if (count > 1 && (bool)lst.Tag)
            {
                lst.SelectedItems.Remove(lst.Items[0]);
                lst.Tag = false;
            }
            else if (count > 1 && lst.SelectedIndices.Contains(0))
            {
                lst.SelectedItems.Clear();
                lst.SelectedItems.Add(lst.Items[0]);
                lst.Tag = true;
            }

            lst.SelectedIndexChanged += lstProducts_SelectedIndexChanged;
        }
    }
}
