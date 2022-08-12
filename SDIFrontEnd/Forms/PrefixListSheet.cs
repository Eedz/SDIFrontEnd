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

namespace ISISFrontEnd
{
    public partial class PrefixListSheet : Form
    {
        public PrefixListSheet()
        {
            InitializeComponent();

            BindingSource bs = new BindingSource();

            List<VariablePrefixRecord> Prefixes = Globals.AllPrefixes;
            bs.DataSource = Prefixes;

            BindingSource bsRanges = new BindingSource();
            bsRanges.DataSource = bs;
            bsRanges.DataMember = "Ranges";

            dgvPrefixes.AutoGenerateColumns = false;
            chPrefix.DataPropertyName = "Prefix";
            chPrefixName.DataPropertyName = "PrefixName";
            chProductType.DataPropertyName = "ProductType";
            chRelatedPrefix.DataPropertyName = "RelatedPrefixes";
            chDescription.DataPropertyName = "Description";
            chComments.DataPropertyName = "Comments";
            chInactive.DataPropertyName = "Inactive";

            dgvPrefixes.DataSource = bs;
            

            dgvRanges.DataSource = bsRanges;

            ResizeColumns();
        }

        #region Events
        private void dgvPrefixes_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VariablePrefixRecord record = (VariablePrefixRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvPrefixes_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VariablePrefixRecord record = (VariablePrefixRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (record == null)
                return;
            record.SaveRecord();
        }

        private void dgvPrefixes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                switch (grid.Columns[i].Name)
                {
                    case "NewRecord":
                    case "Dirty":
                    case "ID":
                    case "PrefixID":
                        grid.Columns[i].Visible = false;
                        break;
                }
            }
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.Remove(this);
        }



        private void PrefixListSheet_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods

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
        #endregion
    }
}
