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
    public partial class StudyList : Form
    {
        List<Study> Records;

        BindingSource bs;

        Study editedStudy;
        int studyRow = -1;
        bool rowCommit = true;

        public StudyList(List<StudyRecord> list)
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
            chAgeGroup.Items.Add("");
            chAgeGroup.Items.Add("Adult");
            chAgeGroup.Items.Add("Mixed");
            chAgeGroup.Items.Add("Youth");

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

            Study tmp = null;

            // Store a reference to the Study object for the row being painted.
            if (e.RowIndex == studyRow)
            {
                tmp = editedStudy;
            }
            else
            {
                tmp = Records[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the Study object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chStudyName":
                    e.Value = tmp.StudyName;
                    break;
                case "chCountry":
                    e.Value = tmp.CountryName;
                    break;
                case "chAgeGroup":
                    e.Value = tmp.AgeGroup;
                    break;
                case "chCountryCode":
                    e.Value = tmp.CountryCode;
                    break;
                case "chISOCode":
                    e.Value = tmp.ISO_Code;
                    break;
                case "chLanguages":
                    e.Value = tmp.Languages;
                    break;
                case "chCohort":
                    e.Value = tmp.Cohort;
                    break;
            }
        }

        private void dgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Study tmp = null;
            // Store a reference to the Study object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row (not THE new row), create a new Study object and reference the row's data.
                if (editedStudy == null)
                    editedStudy = new Study()
                    {
                        ID = Records[e.RowIndex].ID,
                        RegionID = Records[e.RowIndex].RegionID,
                        StudyName = Records[e.RowIndex].StudyName,
                        CountryName = Records[e.RowIndex].CountryName,
                        AgeGroup = Records[e.RowIndex].AgeGroup,
                        CountryCode = Records[e.RowIndex].CountryCode,
                        ISO_Code = Records[e.RowIndex].ISO_Code,
                        Languages = Records[e.RowIndex].Languages,
                        Cohort = Records[e.RowIndex].Cohort
                    };

                tmp = this.editedStudy;
                this.studyRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedStudy == null ? new ITCLib.Study() : this.editedStudy;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chStudyName":
                    tmp.StudyName = (string)e.Value;
                    break;
                case "chCountry":
                    tmp.CountryName = (string)e.Value;
                    break;
                case "chAgeGroup":
                    tmp.AgeGroup = (string)e.Value;
                    break;
                case "chCountryCode":
                    tmp.CountryCode = (int)e.Value;
                    break;
                case "chISOCode":
                    tmp.ISO_Code = (string)e.Value;
                    break;
                case "chLanguages":
                    tmp.Languages = (string)e.Value;
                    break;
                case "chCohort":
                    tmp.Cohort = (int)e.Value;
                    break;
            }
        }

        private void dgv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited
            // Study object if there is one.
            if (editedStudy != null && e.RowIndex < Records.Count)
            {
                DBAction.UpdateStudy(editedStudy);

                Records[e.RowIndex].StudyName = editedStudy.StudyName;
                Records[e.RowIndex].CountryName = editedStudy.CountryName;
                Records[e.RowIndex].AgeGroup = editedStudy.AgeGroup;
                Records[e.RowIndex].CountryCode = editedStudy.CountryCode;
                Records[e.RowIndex].ISO_Code = editedStudy.ISO_Code;
                Records[e.RowIndex].Languages = editedStudy.Languages;
                Records[e.RowIndex].Cohort = editedStudy.Cohort;

                editedStudy = null;
                studyRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedStudy = null;
                studyRow = -1;
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

            if (studyRow == dgv.Rows.Count - 2 && studyRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding Study object with a new, empty one.
                editedStudy = new Study();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding Study object.
                editedStudy = null;
                studyRow = -1;
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

    }
}
