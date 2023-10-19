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
    public partial class CodeGenerator : Form
    {
        public CodeGenerator()
        {
            InitializeComponent();

            FillBoxes();

            txtSavePath.Text = @"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Data Templates\";
        }

        #region Form Setup
        private void FillBoxes()
        {
            lstSurveys.DisplayMember = "SurveyCode";
            lstSurveys.ValueMember = "SID";
            lstSurveys.DataSource = new List<Survey>(Globals.AllSurveys);

            cboJump.DisplayMember = "SurveyCode";
            cboJump.ValueMember = "SID";
            cboJump.DataSource = new List<Survey>(Globals.AllSurveys);
        }
        #endregion

        #region Methods
        private void Generate()
        {
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

            rs.AddQuestions(new List<SurveyQuestion>(DBAction.GetSurveyQuestions(rs)));

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
        #endregion

        #region Events
        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (lstSurveys.SelectedItem == null)
            {
                MessageBox.Show("Select a survey.");
                return;
            }

            Generate();
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Data Templates");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboJump_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboJump.SelectedItem == null)
                return;

            lstSurveys.SelectedItem = cboJump.SelectedItem;
        }

        private void frmCodeGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }
        #endregion

    }
}
