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
using FM = FormManager;

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

            List<string> criteria;
            if (rbMatchExact.Checked)
            {
                criteria = new List<string>() { txtCriteria.Text };
            }
            else
            {
                criteria = txtCriteria.Lines.ToList();
            }
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
        
        private void repeaterResults_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = ((BindingSource)dataRepeater.DataSource);
            var responseSet = ((ResponseSet)datasource[e.DataRepeaterItem.ItemIndex]);

            var rtb = (RichTextBox)e.DataRepeaterItem.Controls.Find("rtbResponseOptions", false)[0];
            rtb.Rtf = HtmlRtfConverter.Converter.HTMLToRtf(responseSet.RespList);
        }
        #endregion

        #region Menu Bar
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
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
            bool exactMatch = rbMatchExact.Checked;

            if (field.Equals("RespOptions")) 
                Records = DBAction.GetResponseSets(criteria, exactMatch);
            else if (field.Equals("NonRespOptions"))
                Records = DBAction.GetNonResponseSets(criteria, exactMatch);
            else
                return;

            if (Records.Count == 0)
            {
                lblResultCount.Text = "No records found.";
                repeaterResults.Visible = false;
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
