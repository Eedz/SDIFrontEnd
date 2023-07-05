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
    public partial class SurveyList : Form
    {
        List<Survey> Records;
        List<SurveyCohort> CohortList;
        List<SurveyMode> ModeList;

        BindingSource bs;

        Survey editedSurvey;
        int surveyRow = -1;
        bool rowCommit = true;

        public SurveyList(List<SurveyRecord> list)
        {
            InitializeComponent();

            Records = list.Select(x => x.Item).ToList();
            CohortList = new List<SurveyCohort>(Globals.AllCohorts);
            ModeList = new List<SurveyMode>(Globals.AllModes);

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
            chType.DisplayMember = "Cohort";
            chType.ValueMember = "ID";
            chType.DataSource = CohortList;

            chMode.DisplayMember = "ModeAbbrev";
            chMode.ValueMember = "ID";
            chMode.DataSource = ModeList;

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

            Survey tmp = null;

            // Store a reference to the Survey object for the row being painted.
            if (e.RowIndex == surveyRow)
            {
                tmp = editedSurvey;
            }
            else
            {
                tmp = Records[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the Survey object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSurveyCode":
                    e.Value = tmp.SurveyCode;
                    break;
                case "chTitle":
                    e.Value = tmp.Title;
                    break;
                case "chType":
                    e.Value = tmp.Cohort;
                    break;
                case "chMode":
                    e.Value = tmp.Mode;
                    break;
                case "chUserState":
                    e.Value = tmp.UserStateList;
                    break;
                case "chProducts":
                    e.Value = tmp.ProductList;
                    break;
                case "chLanguages":
                    e.Value = tmp.LanguagesList;
                    break;
                case "chFileName":
                    e.Value = tmp.WebName;
                    break;
                case "chReRun":
                    e.Value = tmp.ReRun;
                    break;
                case "chHide":
                    e.Value = tmp.HideSurvey;
                    break;
                case "chLocked":
                    e.Value = tmp.Locked;
                    break;
            }
        }

        private void dgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Survey tmp = null;
            // Store a reference to the Survey object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a new row (not THE new row), create a new Survey object and reference the row's data.
                if (editedSurvey == null)
                    editedSurvey = new Survey()
                    {
                        SID = Records[e.RowIndex].SID,
                        WaveID = Records[e.RowIndex].WaveID,
                        SurveyCode = Records[e.RowIndex].SurveyCode,
                        Title = Records[e.RowIndex].Title,
                        Cohort = Records[e.RowIndex].Cohort,
                        Mode = Records[e.RowIndex].Mode,
                        WebName = Records[e.RowIndex].WebName,
                        ReRun = Records[e.RowIndex].ReRun,
                        HideSurvey = Records[e.RowIndex].HideSurvey,
                        Locked = Records[e.RowIndex].Locked
                    };

                tmp = this.editedSurvey;
                this.surveyRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedSurvey == null ? new ITCLib.Survey() : this.editedSurvey;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSurveyCode":
                    tmp.SurveyCode = (string)e.Value;
                    break;
                case "chTitle":
                    tmp.Title = (string)e.Value;
                    break;
                case "chType":
                    tmp.Cohort = CohortList.FirstOrDefault(x => x.ID == (int)e.Value);
                    break;
                case "chMode":
                    tmp.Mode = ModeList.FirstOrDefault(x=>x.ID == (int)e.Value);
                    break;
                case "chUserState":
                case "chProducts":
                case "chLanguages":
                    break;
                case "chFileName":
                    tmp.WebName = (string)e.Value;
                    break;
                case "chReRun":
                    tmp.ReRun = (bool)e.Value;
                    break;
                case "chHide":
                    tmp.HideSurvey = (bool)e.Value;
                    break;
                case "chLocked":
                    break;
            }
        }

        private void dgv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited
            // Survey object if there is one.
            if (editedSurvey != null && e.RowIndex < Records.Count)
            {
                if (editedSurvey.Locked)
                {
                    MessageBox.Show("Unable to modify locked surveys.");
                    editedSurvey = null;
                    surveyRow = -1;
                    return;
                }

                DBAction.UpdateSurvey(editedSurvey);

                Records[e.RowIndex].SurveyCode = editedSurvey.SurveyCode;
                Records[e.RowIndex].Title = editedSurvey.Title;
                Records[e.RowIndex].Cohort = editedSurvey.Cohort;
                Records[e.RowIndex].Mode = editedSurvey.Mode;
                Records[e.RowIndex].WebName = editedSurvey.WebName;
                Records[e.RowIndex].ReRun = editedSurvey.ReRun;
                Records[e.RowIndex].HideSurvey = editedSurvey.HideSurvey;

                editedSurvey = null;
                surveyRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedSurvey = null;
                surveyRow = -1;
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

            if (surveyRow == dgv.Rows.Count - 2 && surveyRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding Survey object with a new, empty one.
                editedSurvey = new Survey();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding Survey object.
                editedSurvey = null;
                surveyRow = -1;
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion
    }
}
