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
    public partial class SimilarWordsList : Form
    {
        private List<SimilarWordsRecord> Records;

        SimilarWords editedWords;
        int wordsRow = -1;
        bool rowCommit = true;

        public SimilarWordsList()
        {
            InitializeComponent();
            Records = new List<SimilarWordsRecord>();
            foreach (SimilarWords words in Globals.AllSimilarWords)
            {
                Records.Add(new SimilarWordsRecord(words));
            }

            dgvWordList.RowCount = Records.Count + 1;
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            dgvWordList.FirstDisplayedScrollingRowIndex = dgvWordList.Rows.Count - 1;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Grid events

        private void dgvWordList_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedWords = new SimilarWords();
            this.wordsRow = this.dgvWordList.Rows.Count - 1;
        }

        private void dgvWordList_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If there are not records, no values are needed.
            if (Records.Count == 0) return;

            SimilarWords tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == wordsRow)
            {
                tmp = editedWords;
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
                case "chWords":
                    e.Value = string.Join(", ", tmp.Words);
                    break;
            }
        }

        private void dgvWordList_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SimilarWords tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedWords == null)
                    editedWords = new SimilarWords()
                    {
                        ID = Records[e.RowIndex].Item.ID,
                        Words = Records[e.RowIndex].Item.Words,
                    };

                tmp = this.editedWords;
                this.wordsRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedWords;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chID":
                    break;
                case "chWords":
                    tmp.Words = ((string)e.Value).Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    break;
            }
        }

        private void dgvWordList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedWords != null && e.RowIndex >= Records.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                SimilarWordsRecord newRecord = new SimilarWordsRecord(editedWords);
                newRecord.NewRecord = true;
                newRecord.SaveRecord();
                Records.Add(newRecord);
                Globals.AllSimilarWords.Add(editedWords);
                dgv.Refresh();

                editedWords = null;
                wordsRow = -1;
            }
            else if (editedWords != null && e.RowIndex < Records.Count)
            {
                // update object in the data store
                Records[e.RowIndex].Item = editedWords;
                Records[e.RowIndex].Dirty = true;
                Records[e.RowIndex].SaveRecord();

                editedWords = null;
                wordsRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedWords = null;
                wordsRow = -1;
            }
        }

        private void dgvWordList_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvWordList_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (wordsRow == dgv.Rows.Count - 2 && wordsRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedWords = new SimilarWords();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedWords = null;
                wordsRow = -1;
            }
        }

        private void dgvWordList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.Records.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete these words?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SimilarWords record = Records[e.Row.Index].Item;
                    // If the user has deleted an existing row, remove thecorresponding object from the data store.
                    DBAction.DeleteRecord(record);
                    Globals.AllSimilarWords.Remove(record);
                    this.Records.RemoveAt(e.Row.Index);

                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.wordsRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.wordsRow = -1;
                this.editedWords = null;
            }
        }

        private void dgvWordList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion




    }
}
