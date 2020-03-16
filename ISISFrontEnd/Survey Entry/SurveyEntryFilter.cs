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
    public partial class SurveyEntryFilter : Form
    {
        public SurveyEntry frmParent;

        public SurveyEntryFilter()
        {
            InitializeComponent();

            cboMain.DataSource = DBAction.GetSurveyList();
            cboSurveys.DataSource = DBAction.GetSurveyList();

            
        }

        private void SurveyEntryFilter_Load(object sender, EventArgs e)
        {
            cboMain.SelectedItem = frmParent.frmParent.currentUser.SurveyEntryCodes[frmParent.index-1];
            txtBrown.Text = string.Join(",", frmParent.frmParent.currentUser.SurveyEntryBrown[frmParent.index-1]);
            txtGreen.Text = string.Join(",", frmParent.frmParent.currentUser.SurveyEntryGreen[frmParent.index-1]);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            cboMain.SelectedItem = null;
            txtBrown.Text = "";
            txtGreen.Text = "";
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            frmParent.ChangeSurvey(cboMain.Text);

            UserPrefs u = frmParent.frmParent.currentUser;
            u.SurveyEntryCodes[frmParent.index - 1] = cboMain.Text;
            
            u.SurveyEntryBrown[frmParent.index - 1] = txtBrown.Text;
            u.SurveyEntryBrown[frmParent.index - 1] = txtGreen.Text;
            Close();

        }

        private void cmdAddBrown_Click(object sender, EventArgs e)
        {
            Survey s = (Survey)cboSurveys.SelectedItem;
            txtBrown.Text += s.SurveyCode;
        }

        private void cmdAddGreen_Click(object sender, EventArgs e)
        {
            Survey s = (Survey)cboSurveys.SelectedItem;
            txtGreen.Text += s.SurveyCode;
        }

        private void cmdAddAll_Click(object sender, EventArgs e)
        {
            Survey s = (Survey)cboSurveys.SelectedItem;
            txtBrown.Text += s.SurveyCode;
            txtGreen.Text += s.SurveyCode;
        }

        
    }
}
