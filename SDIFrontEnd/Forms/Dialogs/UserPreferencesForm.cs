using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ITCLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class UserPreferencesForm : Form
    {
        public UserPrefsRecord User;
        BindingSource bs;

        public UserPreferencesForm(UserPrefs u)
        {
            InitializeComponent();

            User = new UserPrefsRecord(u);

            foreach (FormState fs in User.Item.FormStates)
            {
                var survey = Globals.AllSurveys.Where(x => x.SID == fs.FilterID).FirstOrDefault();
                string surveycode = "";
                if (survey != null)
                    surveycode = survey.SurveyCode;

                dgvFormStates.Rows.Add(fs.FormName, fs.FormNum, surveycode, fs.Filter, fs.RecordPosition);
            }
        }

        private void UserPreferencesForm_Load(object sender, EventArgs e)
        {
            bs = new BindingSource();
            bs.DataSource = User;
            bs.DataMember = "Item";

            cboAccessLevel.DataSource = Enum.GetValues(typeof(AccessLevel));
            txtUserName.DataBindings.Add("Text", bs, "Username", true);
            txtReportDestination.DataBindings.Add("Text", bs, "ReportPath", true);
            cboAccessLevel.DataBindings.Add("SelectedItem", bs, "accessLevel");
            chkReportPrompt.DataBindings.Add("Checked", bs, "reportPrompt");
            chkWordingNumbers.DataBindings.Add("Checked", bs, "wordingNumbers");
            cboCommentDetails.DataSource = Enum.GetValues(typeof(CommentDetails));
            cboCommentDetails.DataBindings.Add("SelectedItem", bs, "commentDetails");
        }

        private void cmdBrowseFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.txtReportDestination.Text = fbd.SelectedPath;
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            User.Dirty = true;
            User.SaveRecord();
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserPreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.RemovePopup(this);
        }
    }
}
