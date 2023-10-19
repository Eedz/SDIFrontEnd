using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class ExternalReportsMenu : Form
    {
        public ExternalReportsMenu()
        {
            InitializeComponent();
        }

        private void cmdOpenVariableList_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("VariableListReportForm"))
            {
                return;
            }

            VariableListReportForm frm = new VariableListReportForm();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenSectionsTable_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("HeadingReportForm"))
            {
                return;
            }

            HeadingReportForm frm = new HeadingReportForm();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenSurveyOverview_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("SurveyOverview"))
            {
                return;
            }

            SurveyOverview frm = new SurveyOverview();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenSyntaxForm_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("frmCodeGenerator"))
            {
                return;
            }

            CodeGenerator frm = new CodeGenerator();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExternalReportsMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        
    }
}
