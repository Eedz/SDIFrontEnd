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
    public partial class StudyList : Form
    {
        List<StudyRecord> Studies;

        bool rowEdited;
        BindingSource bs;

        public StudyList(List<StudyRecord> list)
        {
            InitializeComponent();
            Studies = list;

            bs = new BindingSource();
            bs.DataSource = Studies;

            SetupGrid();
        }

        private void SetupGrid()
        {
            chStudyName.DataPropertyName = "StudyName";
            chCountry.DataPropertyName = "CountryName";

            chAgeGroup.Items.Add("");
            chAgeGroup.Items.Add("Adult");
            chAgeGroup.Items.Add("Mixed");
            chAgeGroup.Items.Add("Youth");
            chAgeGroup.DataPropertyName = "AgeGroup";
            
            chCountryCode.DataPropertyName = "CountryCode";
            chISOCode.DataPropertyName = "ISOCode";
            chLanguages.DataPropertyName = "Languages";

            chCohort.DataPropertyName = "Cohort";

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
            StudyRecord editedStudy = (StudyRecord)dgv.Rows[e.RowIndex].DataBoundItem;

            if (rowEdited)
            {
                // update survey
                if (DBAction.UpdateStudy(editedStudy) == 1)
                {
                    MessageBox.Show("Error updating study.");
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
