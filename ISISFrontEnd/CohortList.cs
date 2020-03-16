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

namespace ISISFrontEnd
{
    public partial class CohortList : Form
    {
        public MainMenu frmParent;
        public string key;

        private List<SurveyCohort> cohorts;
        private BindingSource bs;

        public CohortList()
        {
            InitializeComponent();

            cohorts = DBAction.GetCohortInfo();

            bs = new BindingSource
            {
                DataSource = cohorts
            };
            navCohort.BindingSource = bs;


            txtID.DataBindings.Add("Text", bs, "ID");
            txtCohort.DataBindings.Add("Text", bs, "Cohort");
            txtCode.DataBindings.Add("Text", bs, "Code");
            txtWebName.DataBindings.Add("Text", bs, "WebName");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CohortList_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }
    }
}
