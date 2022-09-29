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

        List<StudyWaveRecord> Waves;

        bool rowEdited;
        BindingSource bs;


        public WaveList(List<StudyWaveRecord> list)
        {
            InitializeComponent();
            Waves = list;

            bs = new BindingSource();
            bs.DataSource = Waves;

            SetupGrid();

        }

        private void SetupGrid()
        {
            chWaveCode.DataPropertyName = "WaveCode";

            chStudyName.DataPropertyName = "ISO_Code";
        
            chWaveNumber.DataPropertyName = "Wave";
            chEnglishRouting.DataPropertyName = "EnglishRouting";
            chCountries.DataPropertyName = "Countries";

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
            StudyWaveRecord editedWave = (StudyWaveRecord)dgv.Rows[e.RowIndex].DataBoundItem;

            if (rowEdited)
            {
                // update wave
                if (DBAction.UpdateWave(editedWave) == 1)
                {
                    MessageBox.Show("Error updating wave.");
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
