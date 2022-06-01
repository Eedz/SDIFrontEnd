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
    public partial class SurveyList : Form
    {

        List<SurveyRecord> Surveys;
        List<SurveyCohortRecord> CohortList;
        List<SurveyMode> ModeList;
        bool rowEdited;
        BindingSource bs;


        public SurveyList(List<SurveyRecord> list)
        {
            InitializeComponent();
            Surveys = list;
            CohortList = DBAction.GetCohortInfo();
            ModeList = DBAction.GetModeInfo();

            bs = new BindingSource();
            bs.DataSource = Surveys;

            SetupGrid();

        }

        private void SetupGrid()
        {
            chSurveyCode.DataPropertyName = "SurveyCode";
            chTitle.DataPropertyName = "Title";

            chType.DisplayMember = "Cohort";
            chType.ValueMember = "ID";
            chType.DataPropertyName = "Cohort";
            chType.DataSource = DBAction.GetCohortInfo();


            chMode.DisplayMember = "ModeAbbrev";
            chMode.ValueMember = "ID";
            chMode.DataPropertyName = "Mode";
            chMode.DataSource = DBAction.GetModeInfo();

            chUserState.DataPropertyName = "UserStateList";
            chProducts.DataPropertyName = "ProductList";
            chLanguages.DataPropertyName = "LanguagesList";

            chFileName.DataPropertyName = "WebName";
            chReRun.DataPropertyName = "ReRun";
            chHide.DataPropertyName = "HideSurvey";
            chLocked.DataPropertyName = "Locked";

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

            // Abort validation if cell is not in the Language column.
            if (headerText.Equals("Type"))
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = CohortList.FirstOrDefault(x => x.Cohort.Equals(e.FormattedValue.ToString()));
            else if (headerText.Equals("Mode"))
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ModeList.FirstOrDefault(x => x.ModeAbbrev.Equals(e.FormattedValue.ToString()));
        }

        private void dgvSurveys_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Survey editedSurvey = (Survey)dgv.Rows[e.RowIndex].DataBoundItem;

            if (rowEdited && editedSurvey.Locked)
            {
                MessageBox.Show("Cannot modify locked surveys.");
             }
            else if (rowEdited)
            {
                // update survey
                if (DBAction.UpdateSurvey(editedSurvey) == 1)
                {
                    MessageBox.Show("Error updating survey.");
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
