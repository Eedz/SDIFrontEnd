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
    public partial class SurveyEditorSearch : Form
    {
        SurveyEditor mainForm;
        bool NewSearch = false;

        public SurveyEditorSearch(SurveyEditor main)
        {
            InitializeComponent();

            mainForm = main;
            cboField.SelectedItem = "<All>";
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtSearchText.Text = string.Empty;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
            mainForm.frmSearch = null;
        }

        private void cmdPrev_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchText.Text) || cboField.SelectedItem ==null)
                return;

            mainForm.FindPreviousQuestion(txtSearchText.Text, (string)cboField.SelectedItem, NewSearch);
            NewSearch = false;
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchText.Text) || cboField.SelectedItem == null)
                return;

            mainForm.FindNextQuestion(txtSearchText.Text, (string)cboField.SelectedItem, NewSearch);
            NewSearch = false;
        }

        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewSearch = true;
        }
    }
}
