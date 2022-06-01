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
    // TODO save only if changed
    public partial class UserPreferencesForm : Form
    {
        public MainMenu frmParent;
        public string key;

        public UserPrefs user;
        BindingSource bs;
        public UserPreferencesForm()
        {
            InitializeComponent();
        }

        public UserPreferencesForm(UserPrefs u)
        {
            user = u;

            InitializeComponent();


            dgvSurveys.DataSource = user.SurveyEntryHistory;

        }

        private void UserPreferencesForm_Load(object sender, EventArgs e)
        {
            bs = new BindingSource();
            bs.DataSource = user;
            cboAccessLevel.DataSource = Enum.GetValues(typeof(AccessLevel));
            txtUserName.DataBindings.Add("Text", bs, "Username", true);
            txtReportDestination.DataBindings.Add("Text", bs, "ReportPath", true);
            cboAccessLevel.DataBindings.Add("SelectedItem", bs, "accessLevel");
            chkReportPrompt.DataBindings.Add("Checked", bs, "reportPrompt");
            chkWordingNumbers.DataBindings.Add("Checked", bs, "wordingNumbers");
            cboCommentDetails.DataSource = Enum.GetValues(typeof(CommentDetails));
            cboCommentDetails.DataBindings.Add("SelectedItem", bs, "commentDetails");
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DBAction.UpdateUser(user);
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserPreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.RemovePopup(this);
        }

        private void dgvSurveys_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSurveys.Columns[0].HeaderText = "Survey";
            dgvSurveys.Columns[1].HeaderText = "Record";
        }
    }
}
