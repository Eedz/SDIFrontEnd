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
    public partial class frmCodeGenerator : Form
    {
        public frmCodeGenerator()
        {
            InitializeComponent();

            List<SurveyRecord> surveyList = DBAction.GetAllSurveysInfo();

            lstSurveys.DisplayMember = "SurveyCode";
            lstSurveys.ValueMember = "SID";
            lstSurveys.DataSource = surveyList;

            cboJump.DisplayMember = "SurveyCode";
            cboJump.ValueMember = "SID";
            cboJump.DataSource = surveyList;

            txtSavePath.Text = @"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Data Templates\";
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (lstSurveys.SelectedItem == null)
            {
                MessageBox.Show("Select a survey.");
                return;
            }

            SyntaxReport code = new SyntaxReport();
            code.OutputPath = txtSavePath.Text;

            SyntaxFormat format;
            code.VarNameInLabel = chkShowVarName.Checked;
            code.QnumInLabel = chkShowQnum.Checked;
            code.UseQnum = rbQnum.Checked;

            if (rbSAS.Checked)
                format = SyntaxFormat.SAS;
            else if (rbSPSS.Checked)
                format = SyntaxFormat.SPSS;
            else if (rbEpi.Checked)
                format = SyntaxFormat.EpiData;
            else
                format = SyntaxFormat.SAS;

            ReportSurvey rs = new ReportSurvey((Survey)lstSurveys.SelectedItem);

            DBAction.FillQuestions(rs);

            try
            {
                code.CreateSyntax(rs, format);
                MessageBox.Show("Done!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }


        }
    }
}
