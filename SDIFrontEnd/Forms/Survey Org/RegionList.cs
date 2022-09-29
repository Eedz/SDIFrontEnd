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
    public partial class RegionList : Form
    {
        List<RegionRecord> Regions;
       
        bool rowEdited;
        BindingSource bs;

        public RegionList(List<RegionRecord> list)
        {
            InitializeComponent();
            Regions = list;

            bs = new BindingSource();
            bs.DataSource = Regions;

            SetupGrid();
        }

        private void SetupGrid()
        {
            chRegionName.DataPropertyName = "RegionName";
            chTempVarPrefix.DataPropertyName = "TempVarPrefix";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bs;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region DataGrid Events

        private void dgvSurveys_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string headerText = dgv.Columns[e.ColumnIndex].HeaderText;
        }

        private void dgvSurveys_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            RegionRecord editedRegion = (RegionRecord)dgv.Rows[e.RowIndex].DataBoundItem;

            if (rowEdited)
            {
                // update region
                if (DBAction.UpdateRegion(editedRegion) == 1)
                {
                    MessageBox.Show("Error updating region.");
                    return;
                }
            }
            rowEdited = false;
        }

        private void dgvSurveys_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.IsCurrentRowDirty)
                rowEdited = true;
        }

        private void dgvSurveys_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

    }
}
