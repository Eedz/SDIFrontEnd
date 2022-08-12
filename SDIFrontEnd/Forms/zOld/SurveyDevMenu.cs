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
    public partial class SurveyDevMenu : Form
    {
        public SurveyDevMenu()
        {
            InitializeComponent();
        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.Remove(this);
        }

        private void cmdOpenDraftManager_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("DraftManager"))
            {
                ((MainMenu)this.Parent.Parent.Parent).SelectTab("DraftManager1");
                return;
            }

            DraftManager frm = new DraftManager();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenDraftSearch_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("DraftSearch"))
            {
                ((MainMenu)this.Parent.Parent.Parent).SelectTab("DraftSearch1");
                return;
            }

            DraftSearch frm = new DraftSearch();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenDraftReport_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("DraftReport"))
            {
                return;
            }
            DraftReportForm frm = new DraftReportForm();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void cmdOpenDraftImport_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("SurveyDraftImportForm"))
            {
                return;
            }

            SurveyDraftImportForm frm = new SurveyDraftImportForm();
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }
    }
}
