﻿using System;
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
    public partial class SimilarWordsList : Form
    {
        private List<SimilarWordsRecord> records;
        private BindingSource bs;

        public SimilarWordsList()
        {
            InitializeComponent();

            records = Globals.AllSimilarWords;
            
            bs = new BindingSource
            {
                DataSource = records
            };
            
            dgvWordList.DataSource = bs;
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
            if (records.Any(x => (string.IsNullOrEmpty(x.Words) && (x.NewRecord || x.Dirty))))
                if (MessageBox.Show("One or more edited records is blank. Do you want to go fill them in?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return;

            foreach (SimilarWordsRecord record in records)
            {
                record.SaveRecord();
            }
            Close();
        }

        #region Grid events

        private void dgvCohort_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SimilarWordsRecord newRecord = (SimilarWordsRecord)dgv.Rows[e.RowIndex].DataBoundItem;

            if (newRecord == null)
                return;

            if (e.RowIndex+1 == records.Count())
                newRecord.NewRecord = true;
            else if (dgv.IsCurrentRowDirty)
                newRecord.Dirty = true;

        }

        private void dgvCohort_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SimilarWordsRecord words = (SimilarWordsRecord)e.Row.DataBoundItem;
                DBAction.DeleteRecord(words);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvCohort_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
