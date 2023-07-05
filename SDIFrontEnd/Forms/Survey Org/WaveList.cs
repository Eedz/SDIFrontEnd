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
    public partial class WaveList : Form
    {
        List<StudyWave> Records;

        BindingSource bs;

        StudyWave editedStudyWave;
        int waveRow = -1;
        bool rowCommit = true;

        public WaveList(List<StudyWaveRecord> list)
        {
            InitializeComponent();
            Records = list.Select(x=>x.Item).ToList();

            SetupBindingSources();

            SetupGrid();
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = Records;
        }

        private void SetupGrid()
        {
            dgv.AutoGenerateColumns = false;

            dgv.CellValueNeeded += dgv_CellValueNeeded;
            dgv.CellValuePushed += dgv_CellValuePushed;
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

        #region DataGrid Events
        private void dgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // if there are no records, no values needed
            if (Records.Count == 0) return;

            StudyWave tmp = null;

            // Store a reference to the StudyWave object for the row being painted.
            if (e.RowIndex == waveRow)
            {
                tmp = editedStudyWave;
            }
            else
            {
                tmp = Records[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the StudyWave object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chWaveCode":
                    e.Value = tmp.WaveCode;
                    break;
                case "chStudyName":
                    e.Value = tmp.ISO_Code;
                    break;
                case "chWaveNumber":
                    e.Value = tmp.Wave;
                    break;
                case "chEnglishRouting":
                    e.Value = tmp.EnglishRouting;
                    break;
                case "chCountries":
                    e.Value = tmp.Countries;
                    break;
            }
        }

        private void dgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            StudyWave tmp = null;
            // Store a reference to the StudyWave object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row (not THE new row), create a new StudyWave object and reference the row's data.
                if (editedStudyWave == null)
                    editedStudyWave = new StudyWave()
                    {
                        ID = Records[e.RowIndex].ID,
                        StudyID = Records[e.RowIndex].StudyID,
                        Wave = Records[e.RowIndex].Wave,
                        ISO_Code = Records[e.RowIndex].ISO_Code,
                        EnglishRouting = Records[e.RowIndex].EnglishRouting,
                        Countries = Records[e.RowIndex].Countries,
                    };

                tmp = this.editedStudyWave;
                this.waveRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedStudyWave == null ? new ITCLib.StudyWave() : this.editedStudyWave;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chWaveCode":
                    break;
                case "chStudyName":
                    tmp.ISO_Code = (string)e.Value;
                    break;
                case "chWaveNumber":
                    tmp.Wave = (double) e.Value;
                    break;
                case "chEnglishRouting":
                    tmp.EnglishRouting = (bool)e.Value;
                    break;
                case "chCountries":
                    tmp.Countries = (string)e.Value;
                    break;
            }
        }

        private void dgv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited
            // StudyWave object if there is one.
            if (editedStudyWave != null && e.RowIndex < Records.Count)
            {
                DBAction.UpdateWave(editedStudyWave);

                Records[e.RowIndex].ISO_Code = editedStudyWave.ISO_Code;
                Records[e.RowIndex].Wave = editedStudyWave.Wave;
                Records[e.RowIndex].EnglishRouting = editedStudyWave.EnglishRouting;
                Records[e.RowIndex].Countries = editedStudyWave.Countries;

                editedStudyWave = null;
                waveRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedStudyWave = null;
                waveRow = -1;
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

            if (waveRow == dgv.Rows.Count - 2 && waveRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding StudyWave object with a new, empty one.
                editedStudyWave = new StudyWave();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding StudyWave object.
                editedStudyWave = null;
                waveRow = -1;
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion
    }
}
