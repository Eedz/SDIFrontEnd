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
    public partial class CohortList : Form
    {
        private List<SurveyCohortRecord> Records;

        SurveyCohort editedCohort;
        int cohortRow = -1;
        bool rowCommit = true;

        public CohortList()
        {
            InitializeComponent();

            Records = new List<SurveyCohortRecord>();
            
            foreach (SurveyCohort cohort in Globals.AllCohorts)
            {
                Records.Add(new SurveyCohortRecord(cohort));
            }

            dgvCohort.RowCount = Records.Count + 1;
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            dgvCohort.FirstDisplayedScrollingRowIndex = dgvCohort.Rows.Count-1;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Grid events

        private void dgvCohort_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new QuestionTimeFrame object when the user edits the row for new records.
            this.editedCohort = new SurveyCohort();
            this.cohortRow = this.dgvCohort.Rows.Count - 1;
        }

        private void dgvCohort_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If there are not records, no values are needed.
            if (Records.Count == 0) return;

            SurveyCohort tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == cohortRow)
            {
                tmp = editedCohort;
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
                case "chCohort":
                    e.Value = tmp.Cohort;
                    break;
                case "chCode":
                    e.Value = tmp.Code;
                    break;
                case "chWebName":
                    e.Value = tmp.WebName;
                    break;
            }
        }

        private void dgvCohort_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SurveyCohort tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedCohort == null)
                    editedCohort = new SurveyCohort()
                    {
                        ID = Records[e.RowIndex].Item.ID,
                        Cohort = Records[e.RowIndex].Item.Cohort,
                        Code = Records[e.RowIndex].Item.Code,
                        WebName = Records[e.RowIndex].Item.Code
                    };

                tmp = this.editedCohort;
                this.cohortRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedCohort;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chID":
                    break;
                case "chCohort":
                    tmp.Cohort = (string)e.Value;
                    break;
                case "chCode":
                    tmp.Code = (string)e.Value;
                    break;
                case "chWebName":
                    tmp.WebName = (string)e.Value;
                    break;
            }
        }

        private void dgvCohort_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedCohort != null && e.RowIndex >= Records.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                SurveyCohortRecord newRecord = new SurveyCohortRecord(editedCohort);
                newRecord.NewRecord = true;
                newRecord.SaveRecord();
                Records.Add(newRecord);
                Globals.AllCohorts.Add(editedCohort);
                dgv.Refresh();

                editedCohort = null;
                cohortRow = -1;
            }
            else if (editedCohort != null && e.RowIndex < Records.Count)
            {
                // update object in the data store
                Records[e.RowIndex].Item = editedCohort;
                Records[e.RowIndex].Dirty = true;
                Records[e.RowIndex].SaveRecord();

                editedCohort = null;
                cohortRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedCohort = null;
                cohortRow = -1;
            }
        }

        private void dgvCohort_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvCohort_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (cohortRow == dgv.Rows.Count - 2 && cohortRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedCohort = new SurveyCohort();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedCohort = null;
                cohortRow = -1;
            }
        }

        private void dgvCohort_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.Records.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this cohort?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SurveyCohort record = Records[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove thecorresponding object from the data store.
                    DBAction.DeleteRecord(record);
                    Globals.AllCohorts.Remove(record);
                    this.Records.RemoveAt(e.Row.Index);
                    
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.cohortRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.cohortRow = -1;
                this.editedCohort = null;
            }
        }

        private void dgvCohort_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion




    }
}
