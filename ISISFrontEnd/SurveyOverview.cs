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

namespace ISISFrontEnd
{
    public partial class SurveyOverview : Form
    {
        public MainMenu frmParent;
        public string key;
        
        
        public SurveyOverview()
        {
            InitializeComponent();
        }

        private void SurveyOverview_Load(object sender, EventArgs e)
        {

           
            cboSurvey.ValueMember = "SurveyCode";
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.DataSource = DBAction.GetAllSurveys();
            
            
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            SurveyReport SO = new SurveyReport();
            ReportSurvey source = new ReportSurvey(DBAction.GetSurveyInfo(cboSurvey.GetItemText(cboSurvey.SelectedItem)));
            SO.Surveys.Add(source);
            SO.Surveys[0].Qnum = true;

            foreach (ReportSurvey rs in SO.Surveys)
            {
                rs.VarLabelCol = true;
                rs.TopicLabelCol = true;
                rs.ContentLabelCol = true;
            }
            SO.ShowAllQnums = true;
            SO.ShowAllVarNames = true;
            SO.ShowQuestion = false;

            SO.GenerateReport();
                     
        }

        

        private void SurveyOverview_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
