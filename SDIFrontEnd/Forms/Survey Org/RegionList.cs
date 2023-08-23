using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace SDIFrontEnd
{
    public partial class RegionList : Form
    {
        List<Region> Records;
       
        Region editedRegion;
        int regionRow = -1;
        bool rowCommit = true;

        public RegionList(List<RegionRecord> list)
        {
            InitializeComponent();
            Records = list.Select(x=>x.Item).ToList();

            SetupGrid();
        }

        private void SetupGrid()
        {
            dgv.AutoGenerateColumns = false;

            dgv.CellValueNeeded += dgv_CellValueNeeded;
            dgv.CellValuePushed+= dgv_CellValuePushed;
            dgv.RowValidated += dgv_RowValidated;
            dgv.RowDirtyStateNeeded += dgv_RowDirtyStateNeeded;
            dgv.CancelRowEdit += dgv_CancelRowEdit;
            dgv.DataError += dgv_DataError;

            dgv.RowCount = Records.Count;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // if there are no records, no values needed
            if (Records.Count==0) return;

            Region tmp = null;

            // Store a reference to the Region object for the row being painted.
            if (e.RowIndex == regionRow)
            {
                tmp = editedRegion;
            }
            else
            {
                tmp = Records[e.RowIndex];
            }

            if (tmp == null) return;
            
            // Set the cell value to paint using the Region object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chRegionName":
                    e.Value = tmp.RegionName;
                    break;
                case "chTempVarPrefix":
                    e.Value = tmp.TempVarPrefix; 
                    break;
            }
        }

        private void dgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Region tmp = null;
            // Store a reference to the Region object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row (not THE new row), create a new Region object and reference the row's data.
                if (editedRegion == null)
                    editedRegion = new Region()
                    {
                        ID = Records[e.RowIndex].ID,
                        RegionName = Records[e.RowIndex].RegionName,
                        TempVarPrefix = Records[e.RowIndex].TempVarPrefix
                    };

                tmp = this.editedRegion;
                this.regionRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedRegion == null ? new ITCLib.Region() : this.editedRegion;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chRegionName":
                    tmp.RegionName = (string)e.Value;
                    break;
                case "chTempVarPrefix":
                    tmp.TempVarPrefix = (string)e.Value;
                    break;
            }
        }

        private void dgv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited
            // Region object if there is one.
            if (editedRegion != null && e.RowIndex < Records.Count)
            {
                DBAction.UpdateRegion(editedRegion);
                Records[e.RowIndex].RegionName = editedRegion.RegionName;
                Records[e.RowIndex].TempVarPrefix = editedRegion.TempVarPrefix;
                editedRegion = null;
                regionRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedRegion = null;
                regionRow = -1;
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

            if (regionRow == dgv.Rows.Count - 2 && regionRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding Region object with a new, empty one.
                editedRegion = new Region();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding Region object.
                editedRegion = null;
                regionRow = -1;
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
