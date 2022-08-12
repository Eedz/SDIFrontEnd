using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISISFrontEnd
{
    public partial class ExternalReportsMenu : Form
    {
        public ExternalReportsMenu()
        {
            InitializeComponent();
        }

        private void cmdOpenVariableList_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("VariableListReportForm"))
            {
                return;
            }

            VariableListReportForm frm = new VariableListReportForm();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenSectionsTable_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("HeadingReportForm"))
            {
                return;
            }

            HeadingReportForm frm = new HeadingReportForm();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenSurveyOverview_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyOverview"))
            {
                return;
            }

            SurveyOverview frm = new SurveyOverview();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenSyntaxForm_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("frmCodeGenerator"))
            {
                return;
            }

            frmCodeGenerator frm = new frmCodeGenerator();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExternalReportsMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Remove(this);
        }

        
    }
}
