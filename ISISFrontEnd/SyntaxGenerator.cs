using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using ITCLib;

namespace ISISFrontEnd
{
    public partial class Form1 : Form
    {
        SyntaxReport SR;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionStringTest"].ConnectionString);
        string dataTemplateFolder = "\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Data Templates\\";
        public Form1()
        {
            SR = new SyntaxReport();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sql;
            DataTable surveyList = new DataTable();
            sql = new SqlDataAdapter("SELECT Survey FROM qrySurveys ORDER BY ISO_Code, Wave, Survey", conn);

            conn.Open();
            sql.Fill(surveyList);
            conn.Close();

            lstSurveys.ValueMember = "Survey";
            lstSurveys.DisplayMember = "Survey";
            lstSurveys.DataSource = surveyList;
            

        }

        private void Generate_Click(object sender, EventArgs e)
        {
            if (lstSurveys.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select at least one survey.");
                return;
            }
            // check field info is complete



            for (int i = 0; i < lstSurveys.SelectedItems.Count; i++)
            {
                ReportSurvey s = (ReportSurvey) DBAction.GetSurveyInfo(lstSurveys.GetItemText(lstSurveys.SelectedItems[i]));
                DBAction.FillQuestions(s);


                SR.CreateSyntax(s, SyntaxFormat.EpiData);

            }
        }

       
    }      
}
