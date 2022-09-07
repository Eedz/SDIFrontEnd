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
    /// <summary>
    /// Search form for response option sets.
    /// </summary>
    public partial class ResponseSetSearch : Form
    {
        public List<ResponseSet> Records;
        public BindingSource bs;

        public ResponseSetSearch()
        {
            InitializeComponent();

            bs = new BindingSource();

            txtRespName.DataBindings.Add("Text", bs, "RespSetName");
            txtRespOptions.DataBindings.Add("Text", bs, "RespList");
        }

        #region Events 

        private void ResponseSetSearch_Load(object sender, EventArgs e)
        {
            cboResponseType.SelectedItem = "RespOptions";
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCriteria.Text))
                return;

            if (cboResponseType.SelectedItem == null)
                return;

            string type = (string)cboResponseType.SelectedItem;
            List<string> criteria = txtCriteria.Lines.ToList();

            Search(type, criteria);
        }

        private void cmdViewUsage_Click(object sender, EventArgs e)
        {
            var item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)((Button)sender).Parent;
            var datasource = ((BindingSource)repeaterResults.DataSource);
            int index = repeaterResults.CurrentItemIndex;
            ResponseSet itemRecord = (ResponseSet)datasource[index];

            ResponseOptionUsage frm = new ResponseOptionUsage(itemRecord);
            frm.ShowDialog();
        }

        #endregion

        #region Menu Bar
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.Remove(this);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Records = null;
            
            repeaterResults.DataSource = null;
            
            txtCriteria.Text = string.Empty;
            cboResponseType.SelectedItem = "RespOptions";
        }

        #endregion

        #region Methods
        private void Search(string field, List<string> criteria)
        {
            if (field.Equals("RespOptions"))
                Records = DBAction.GetResponseSets(criteria);
            else if (field.Equals("NonRespOptions"))
                Records = DBAction.GetNonResponseSets(criteria);
            else
                return;

            if (Records.Count == 0)
            {
                lblResultCount.Text = "No records found.";
                return;
            }

            lblResultCount.Text = Records.Count + " records found.";
            lblResultCount.Visible = true;

            bs.DataSource = Records;
            repeaterResults.DataSource = bs;

            repeaterResults.Visible = true;
        }
        #endregion

    }
}
