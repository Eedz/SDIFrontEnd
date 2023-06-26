using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Word = Microsoft.Office.Interop.Word;
using ITCLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class SurveyOverview : Form
    {
        
        public SurveyOverview()
        {
            InitializeComponent();
        }

        private void SurveyOverview_Load(object sender, EventArgs e)
        {

           
            cboSurvey.ValueMember = "SurveyCode";
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.DataSource =new List<Survey>( Globals.AllSurveys);
            
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            SurveyReport SO = new SurveyReport();
            ReportSurvey source = new ReportSurvey(DBAction.GetSurveyInfo(cboSurvey.GetItemText(cboSurvey.SelectedItem)));

            source.AddQuestions(DBAction.GetSurveyQuestions(source));
            SO.Surveys.Add(source);
            SO.Surveys[0].Qnum = true;
            SO.Surveys[0].Primary = true;
            
            foreach (ReportSurvey rs in SO.Surveys)
            {
                rs.VarLabelCol = true;
                if (chkTC.Checked)
                {
                    rs.TopicLabelCol = true;
                    rs.ContentLabelCol = true;
                }
            }
            SO.ShowAllQnums = true;
            SO.ShowAllVarNames = true;
            SO.ShowQuestion = false;

            SO.GenerateReport();
            SO.FileName = "\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\SDI\\Reports\\External\\";
            SO.OutputReportTableXML(source.SurveyCode + " Survey Overview");
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports");
        }
    }
}
