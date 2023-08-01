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
    public partial class PrefixListSheet : Form
    {
        List<VariablePrefixRecord> Records;
        VariablePrefixRecord CurrentRecord;

        int prefixRow = -1;
        VariablePrefix editedPrefix;

        int rangeRow = -1;
        VariableRange editedRange;

        bool rowCommit = true;

        public PrefixListSheet(List<VariablePrefix> prefixes)
        {
            InitializeComponent();

            Records = new List<VariablePrefixRecord>();
            foreach (VariablePrefix prefix in prefixes)
            {
                Records.Add(new VariablePrefixRecord(prefix));
            }

            SetupGrids();

            ResizeColumns();
        }

        #region Events

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void formViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormView();
        }

        private void PrefixListSheet_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void dgvPrefixes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentRecord != null)
                CurrentRecord.SaveRecord();

            if (e.RowIndex >= Records.Count)
                return;

            CurrentRecord = Records[e.RowIndex];

            dgvRanges.Rows.Clear();
            dgvRanges.RowCount = CurrentRecord.Item.Ranges.Count + 1;
        }

        private void dgv_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedRange = new VariableRange();
            this.rangeRow = dgv.Rows.Count - 1;
        }

        private void dgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // if this is the row for new records, no values needed
            if (e.RowIndex == dgv.RowCount - 1) return;
            // if there are no records, no values needed
            if (Records.Count == 0) return;

            VariablePrefix tmp = null;

            // Store a reference to the Survey object for the row being painted.
            if (e.RowIndex == prefixRow)
            {
                tmp = editedPrefix;
            }
            else
            {
                tmp = Records[e.RowIndex].Item;
            }

            if (tmp == null) return;

            // Set the cell value to paint using the Survey object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chPrefix":
                    e.Value = tmp.Prefix;
                    break;
                case "chPrefixName":
                    e.Value = tmp.PrefixName; 
                    break;
                case "chProductType":
                    e.Value = tmp.ProductType; 
                    break;
                case "chRelatedPrefix":
                    e.Value = tmp.RelatedPrefixes;
                    break;
                case "chDescription":
                    e.Value = tmp.Description;
                    break;
                case "chComments":
                    e.Value = tmp.Comments;
                    break;
                case "chInactive":
                    e.Value = tmp.Inactive;
                    break;
            }
        }

        private void dgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VariablePrefix tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row (not THE new row), create a new object and reference the row's data.
                if (editedPrefix == null)
                    editedPrefix = new VariablePrefix()
                    {
                        ID = Records[e.RowIndex].Item.ID,
                        Prefix = Records[e.RowIndex].Item.Prefix,
                        PrefixName = Records[e.RowIndex].Item.PrefixName,
                        ProductType = Records[e.RowIndex].Item.ProductType,
                        RelatedPrefixes = Records[e.RowIndex].Item.RelatedPrefixes,
                        Description = Records[e.RowIndex].Item.Description,
                        Comments = Records[e.RowIndex].Item.Comments,
                        Inactive = Records[e.RowIndex].Item.Inactive

                    };

                tmp = this.editedPrefix;
                this.prefixRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedPrefix == null ? new ITCLib.VariablePrefix() : this.editedPrefix;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chPrefix":
                    tmp.Prefix = (string)e.Value;
                    break;
                case "chPrefixName":
                    tmp.PrefixName = (string)e.Value;
                    break;
                case "chProductType":
                    tmp.ProductType = (string)e.Value;
                    break;
                case "chRelatedPrefix":
                    tmp.RelatedPrefixes = (string)e.Value;
                    break;
                case "chDescription":
                    tmp.Description = (string)e.Value;
                    break;
                case "chComments":
                    tmp.Comments = (string)e.Value;
                    break;
                case "chInactive":
                    tmp.Inactive = (bool)e.Value;
                    break;
            }
        }

        private void dgv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Save row changes if any were made and release the edited object if there is one.
            if (editedPrefix != null && e.RowIndex >= Records.Count &&
                e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                VariablePrefixRecord newRec = new VariablePrefixRecord(editedPrefix);
                newRec.NewRecord = true;
                Records.Add(newRec);
                Globals.AllPrefixes.Add(newRec.Item);
                CurrentRecord = newRec;

                editedPrefix = null;
                prefixRow = -1;
            }
            if (editedPrefix != null && e.RowIndex < Records.Count)
            {
                Records[e.RowIndex].Item = editedPrefix;
                Records[e.RowIndex].Dirty = true;

                editedPrefix = null;
                prefixRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedPrefix = null;
                prefixRow = -1;
            }
        }

        private void dgv_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgv_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (prefixRow == dgv.Rows.Count - 2 && prefixRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding Survey object with a new, empty one.
                editedRange = new VariableRange();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding Survey object.
                editedPrefix = null;
                prefixRow = -1;
            }
        }

        private void dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VariablePrefix record = Records[e.Row.Index].Item;
                // If the user has deleted an existing row, remove the
                // corresponding object from the data store.
                this.Records.RemoveAt(e.Row.Index);
                DBAction.DeleteRecord(record);
                Globals.AllPrefixes.Remove(record);
            }
            else
            {
                e.Cancel = true;
            }

            if (e.Row.Index == this.prefixRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.prefixRow = -1;
                this.editedPrefix = null;
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvRanges_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedRange = new VariableRange();
            this.rangeRow = dgv.Rows.Count - 1;
        }

        private void dgvRanges_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // if this is the row for new records, no values needed
            if (e.RowIndex == dgv.RowCount - 1) return;
            // if there are no records, no values needed
            if (CurrentRecord.Item.Ranges.Count == 0) return;

            VariableRange tmp = null;

            // Store a reference to the Survey object for the row being painted.
            if (e.RowIndex == rangeRow)
            {
                tmp = editedRange;
            }
            else
            {
                tmp = CurrentRecord.Item.Ranges[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the Survey object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLower":
                    e.Value = tmp.Lower;
                    break;
                case "chUpper":
                    e.Value = tmp.Upper; break;
                case "chRangeDescription":
                    e.Value = tmp.Description; break;

            }
        }

        private void dgvRanges_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VariableRange tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.Ranges.Count)
            {
                // If the user is editing a new row (not THE new row), create a new object and reference the row's data.
                if (editedRange == null)
                    editedRange = new VariableRange()
                    {
                        ID = CurrentRecord.Item.Ranges[e.RowIndex].ID,
                        PrefixID = CurrentRecord.Item.Ranges[e.RowIndex].PrefixID,
                        Lower = CurrentRecord.Item.Ranges[e.RowIndex].Lower,
                        Upper = CurrentRecord.Item.Ranges[e.RowIndex].Upper,
                        Description = CurrentRecord.Item.Ranges[e.RowIndex].Description

                    };

                tmp = this.editedRange;
                this.rangeRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedRange == null ? new ITCLib.VariableRange() : this.editedRange;
                tmp.PrefixID = CurrentRecord.Item.ID;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLower":
                    tmp.Lower = (string)e.Value;
                    break;
                case "chUpper":
                    tmp.Upper = (string)e.Value;
                    break;
                case "chRangeDescription":
                    tmp.Description = (string)e.Value;
                    break;
            }
        }

        private void dgvRanges_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Save row changes if any were made and release the edited object if there is one.
            if (editedRange != null && e.RowIndex >= CurrentRecord.Item.Ranges.Count &&
                e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.Ranges.Add(editedRange);
                CurrentRecord.AddedRanges.Add(editedRange);
                editedRange = null;
                rangeRow = -1;
            }
            if (editedRange != null && e.RowIndex < CurrentRecord.Item.Ranges.Count)
            {
                CurrentRecord.EditedRanges.Add(editedRange);
                CurrentRecord.Item.Ranges[e.RowIndex] = editedRange;
                editedRange = null;
                rangeRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedRange = null;
                rangeRow = -1;
            }
        }

        private void dgvRanges_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvRanges_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (rangeRow == dgv.Rows.Count - 2 && rangeRow == CurrentRecord.Item.Ranges.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding Survey object with a new, empty one.
                editedRange = new VariableRange();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding Survey object.
                editedRange = null;
                rangeRow = -1;
            }
        }

        private void dgvRanges_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvRanges_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VariableRange record = CurrentRecord.Item.Ranges[e.Row.Index];
                // If the user has deleted an existing row, remove the
                // corresponding object from the data store.
                this.CurrentRecord.Item.Ranges.RemoveAt(e.Row.Index);
                CurrentRecord.DeletedRanges.Add(record);
            }
            else
            {
                e.Cancel = true;
            }

            if (e.Row.Index == this.rangeRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.rangeRow = -1;
                this.editedRange = null;
            }
        }

        #endregion

        #region Methods

        private void SetupGrids()
        {
            dgvPrefixes.AutoGenerateColumns = false;
            dgvPrefixes.NewRowNeeded += dgv_NewRowNeeded;
            dgvPrefixes.CellValueNeeded += dgv_CellValueNeeded;
            dgvPrefixes.CellValuePushed += dgv_CellValuePushed;
            dgvPrefixes.RowValidated += dgv_RowValidated;
            dgvPrefixes.RowDirtyStateNeeded += dgv_RowDirtyStateNeeded;
            dgvPrefixes.CancelRowEdit += dgv_CancelRowEdit;
            dgvPrefixes.UserDeletingRow += dgv_UserDeletingRow;
            dgvPrefixes.DataError += dgv_DataError;

            dgvRanges.AutoGenerateColumns = false;
            dgvRanges.NewRowNeeded += dgvRanges_NewRowNeeded;
            dgvRanges.CellValueNeeded += dgvRanges_CellValueNeeded;
            dgvRanges.CellValuePushed += dgvRanges_CellValuePushed;
            dgvRanges.RowValidated += dgvRanges_RowValidated;
            dgvRanges.RowDirtyStateNeeded += dgvRanges_RowDirtyStateNeeded;
            dgvRanges.CancelRowEdit += dgvRanges_CancelRowEdit;
            dgvRanges.UserDeletingRow += dgvRanges_UserDeletingRow;
            dgvRanges.DataError += dgvRanges_DataError;

            dgvPrefixes.RowCount = Records.Count + 1;
        }

        private void ResizeColumns()
        {
            chPrefix.Width = 75;
            chPrefixName.Width = 100;
            chProductType.Width = 150;
            chRelatedPrefix.Width = 100;
            chDescription.Width = (int)(dgvPrefixes.Width * 0.40);
            chComments.Width = (int)(dgvPrefixes.Width * 0.4);
            chInactive.Width = 75;

        }

        private void OpenFormView()
        {
            PrefixList getFrm = (PrefixList)FM.FormManager.GetForm("PrefixList", 1);
            if (getFrm == null)
            {
                PrefixList frm = new PrefixList(Globals.AllPrefixes);
                frm.Tag = 1;
                FM.FormManager.Add(frm);
            }
            ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("PrefixList1");
        }

        #endregion

        
    }
}
