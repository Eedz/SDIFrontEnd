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
    public partial class MoveIssue : Form
    {
        List<int> IssueNums;
        public int TargetIssueNum;

        public MoveIssue(List<int> issueNums)
        {
            InitializeComponent();

            IssueNums = issueNums;

            cboIssueNo.DataSource = IssueNums;
        }

        #region Events

        private void cmdOK_Click(object sender, EventArgs e)
        {
            TargetIssueNum = (int)cboIssueNo.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
