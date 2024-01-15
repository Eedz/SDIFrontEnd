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

namespace SDIFrontEnd
{
    public partial class BrowseIssues : Form
    {
        public PraccingEntry frmParent;
        List<PraccingIssue> IssueList;
        BindingSource bs;
        public int SelectedIssueNo;
        public PraccingIssue SelectedIssue;

        public BrowseIssues(List<PraccingIssue> list)
        {
            InitializeComponent();

            IssueList = list;

            SetupBindingSource();

            FillLists();

            BindProperties();
        }

        #region Form Setup
        private void SetupBindingSource()
        {
            bs = new BindingSource();
            bs.DataSource = IssueList;

            dataRepeater1.DataSource = bs;
        }

        private void FillLists()
        {
            cboToCriteria.DisplayMember = "Name";
            cboToCriteria.ValueMember = "ID";
            cboToCriteria.DataSource = new List<Person>(Globals.AllPeople);
            cboToCriteria.SelectedItem = null;
        }

        private void BindProperties()
        {
            txtSurvey.DataBindings.Add(new Binding("Text", bs, "Survey.SurveyCode"));
            txtIssueNo.DataBindings.Add(new Binding("Text", bs, "IssueNo"));
            txtVarNames.DataBindings.Add(new Binding("Text", bs, "VarNames"));
            txtFrom.DataBindings.Add(new Binding("Text", bs, "IssueFrom.Name"));
            txtTo.DataBindings.Add(new Binding("Text", bs, "IssueTo.Name"));
            dtpIssueDate.DataBindings.Add(new Binding("Value", bs, "IssueDate", true));

            rtbDescription.DataBindings.Add(new Binding("Rtf", bs, "DescriptionRTF"));
        }
        #endregion

        #region Methods
        private void CheckForIssues(string varnames, Person to)
        {
            IEnumerable<PraccingIssue> query = IssueList;

            if (!string.IsNullOrEmpty(varnames))
                query = query.Where(x => x.VarNames.ToLower().Contains(varnames));
            if (to != null)
                query = query.Where(x => x.IssueTo.ID == to.ID);

            if (query.Count() == 0)
            {
                MessageBox.Show("No matches found!");
                return;
            }


            bs.DataSource = query.ToList();
        }

        #endregion


        #region Events
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdCheckForIssues_Click(object sender, EventArgs e)
        {
            string varnames = txtVarNameCriteria.Text.ToLower();
            Person to = (Person)cboToCriteria.SelectedItem;

            CheckForIssues(varnames, to);
        }

        private void cmdCreateNew_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void cmdSelectIssue_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)btn.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)btn.Parent.Parent;
            var source = (List<PraccingIssue>)((BindingSource)dataRepeater.DataSource).DataSource;

            SelectedIssueNo = source[dataRepeaterItem.ItemIndex].IssueNo;
            SelectedIssue = source[dataRepeaterItem.ItemIndex];
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// After Item is cloned, draw item. The index is now available to select the proper data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<PraccingIssue>)((BindingSource)dataRepeater.DataSource).DataSource;

            var fromBox = (TextBox)e.DataRepeaterItem.Controls.Find("txtFrom", false)[0];
            fromBox.Text = datasource[e.DataRepeaterItem.ItemIndex].IssueFrom.Name;

            var toBox = (TextBox)e.DataRepeaterItem.Controls.Find("txtTo", false)[0];
            toBox.Text = datasource[e.DataRepeaterItem.ItemIndex].IssueTo.Name;
        }
        #endregion

        
    }
}
