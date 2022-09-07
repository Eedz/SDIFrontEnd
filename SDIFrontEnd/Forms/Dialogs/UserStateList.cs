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
    public partial class UserStateList : Form
    {
        private List<UserStateRecord> records;
        private BindingSource bs;

        public UserStateList()
        {
            InitializeComponent();

            records = Globals.AllUserStates;
            
            bs = new BindingSource
            {
                DataSource = records
            };
            
            dgvUserStates.DataSource = bs;
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            bs.AddNew();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (records.Any(x => (string.IsNullOrEmpty(x.UserStateName) && (x.NewRecord || x.Dirty))))
                if (MessageBox.Show("One or more edited User States is blank. Do you want to go fill them in?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return;

            foreach (UserStateRecord record in records)
            {
                record.SaveRecord();
            }
            Close();
        }

        #region Grid events

        private void dgvUserStates_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            UserStateRecord newState = (UserStateRecord)dgv.Rows[e.RowIndex].DataBoundItem;

            if (newState == null)
                return;

            if (e.RowIndex+1 == records.Count())
                newState.NewRecord = true;
            else if (dgv.IsCurrentRowDirty)
                newState.Dirty = true;

        }

        private void dgvUserStates_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserStateRecord userstate = (UserStateRecord)e.Row.DataBoundItem;
                DBAction.DeleteUserState(userstate.ID);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvUserStates_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                switch (grid.Columns[i].Name)
                {
                    case "NewRecord":
                    case "Dirty":
                        grid.Columns[i].Visible = false;
                        break;
                }
            }
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        #endregion

        

        
    }
}
