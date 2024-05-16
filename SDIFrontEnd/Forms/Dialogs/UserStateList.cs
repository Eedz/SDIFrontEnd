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
        private List<UserStateRecord> Records;

        UserState editedState;
        int stateRow = -1;
        bool rowCommit = true;

        public UserStateList()
        {
            InitializeComponent();

            Records = new List<UserStateRecord>();

            foreach (UserState cohort in Globals.AllUserStates)
            {
                Records.Add(new UserStateRecord(cohort));
            }

            dgvUserStates.RowCount = Records.Count + 1;
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            dgvUserStates.FirstDisplayedScrollingRowIndex = dgvUserStates.Rows.Count - 1;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Grid events

        private void dgvUserStates_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedState = new UserState();
            this.stateRow = this.dgvUserStates.Rows.Count - 1;
        }

        private void dgvUserStates_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If there are not records, no values are needed.
            if (Records.Count == 0) return;

            UserState tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == stateRow)
            {
                tmp = editedState;
            }
            else
            {
                tmp = Records[e.RowIndex].Item;
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chID":
                    e.Value = tmp.ID;
                    break;
                case "chUserState":
                    e.Value = tmp.UserStateName;
                    break;
            }
        }

        private void dgvUserStates_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            UserState tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedState == null)
                    editedState = new UserState()
                    {
                        ID = Records[e.RowIndex].Item.ID,
                        UserStateName = Records[e.RowIndex].Item.UserStateName,
                    };

                tmp = this.editedState;
                this.stateRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedState;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chID":
                    break;
                case "chUserState":
                    tmp.UserStateName = (string)e.Value;
                    break;
            }
        }

        private void dgvUserStates_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedState != null && e.RowIndex >= Records.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                UserStateRecord newRecord = new UserStateRecord(editedState);
                newRecord.NewRecord = true;
                newRecord.SaveRecord();
                Records.Add(newRecord);
                Globals.AllUserStates.Add(editedState);
                dgv.Refresh();

                editedState = null;
                stateRow = -1;
            }
            else if (editedState != null && e.RowIndex < Records.Count)
            {
                // update object in the data store
                Records[e.RowIndex].Item = editedState;
                Records[e.RowIndex].Dirty = true;
                Records[e.RowIndex].SaveRecord();

                editedState = null;
                stateRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedState = null;
                stateRow = -1;
            }
        }

        private void dgvUserStates_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvUserStates_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (stateRow == dgv.Rows.Count - 2 && stateRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedState = new UserState();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedState = null;
                stateRow = -1;
            }
        }

        private void dgvUserStates_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.Records.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this user state?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    UserState record = Records[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove thecorresponding object from the data store.
                    DBAction.DeleteRecord(record);
                    Globals.AllUserStates.Remove(record);
                    this.Records.RemoveAt(e.Row.Index);

                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.stateRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.stateRow = -1;
                this.editedState = null;
            }
        }

        private void dgvUserStates_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion




    }
}
