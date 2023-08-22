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
    public partial class AuditFeed : Form
    {
        public AuditFeed()
        {
            InitializeComponent();

            RefreshFeed();
           
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshFeed();
        }

        private void RefreshFeed()
        {
            List<AuditEntry> feed = DBAction.GetMostRecentChanges(1000);
            BindingSource bs = new BindingSource();
            bs.DataSource = feed;

            dgvFeed.DataSource = null;
            dgvFeed.AutoGenerateColumns = true;
            dgvFeed.DataSource = bs;
            dgvFeed.Refresh();

            lblLastUpdate.Text = "Last update: " + DateTime.Now.ToString("F");
        }
    }
}
