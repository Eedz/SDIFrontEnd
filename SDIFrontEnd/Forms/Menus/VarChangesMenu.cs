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
    public partial class VarNameMenu : Form
    {
        public VarNameMenu()
        {
            InitializeComponent();
        }

        private void VarNameMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdOpenRenameSingle_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("RenameVars"))
            {
                return;
            }
            RenameVars frm = new RenameVars();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenRenameBulk_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("RenameVarsBulk"))
            {
                return;
            }
            RenameVarsBulk frm = new RenameVarsBulk();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenVarChangeTracking_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("VarChangeTracking"))
            {
                return;
            }
            VarChangeTracking frm = new VarChangeTracking();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void cmdOpenVarNameChangeReport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("VarNameChangeReportForm"))
            {
                return;
            }
            VarNameChangeReportForm frm = new VarNameChangeReportForm();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenVarUsage_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("VarNameUsage"))
            {
                return;
            }

            VarNameUsage frm = new VarNameUsage();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }

        private void cmdOpenVarUsageReport_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("VarNameUsageReport"))
            {
                return;
            }

            VarNameUsageReport frm = new VarNameUsageReport();
            frm.Tag = 1;
            FM.FormManager.AddPopup(frm);
        }
    }
}
