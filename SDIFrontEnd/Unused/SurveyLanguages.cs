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
    public partial class SurveyLanguages : Form
    {
        List<SurveyLanguage> Records;       // language records to display
        List<Language> AvailableLanguages;  // list of all languages

        int DefaultSurvID; // ID of the target survey

        // data grid view helpers
        SurveyLanguage editedRecord;
        int editedRow = -1;
        bool rowCommit = true;

        public SurveyLanguages(Survey survey)
        {
            InitializeComponent();

            DefaultSurvID = survey.SID;
            Records = survey.LanguageList;

            AvailableLanguages = DBAction.ListLanguages();

            SetupGrid();

            lblTitle.Text = survey.SurveyCode + " Languages";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Focus();
            Close();
        }

        private void newLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Languages frm = new Languages();
            frm.ShowDialog();

            AvailableLanguages = DBAction.ListLanguages();
            chLangID.DataSource = AvailableLanguages;
        }

        private void SetupGrid()
        {
            chLangID.DisplayMember = "LanguageName";
            chLangID.ValueMember = "ID";
            chLangID.DataSource = AvailableLanguages;

            dgv.AutoGenerateColumns = false;

            dgv.NewRowNeeded += Dgv_NewRowNeeded;
            dgv.CellValueNeeded += Dgv_CellValueNeeded;
            dgv.CellValuePushed += Dgv_CellValuePushed;
            dgv.RowValidated += Dgv_RowValidated;
            dgv.RowDirtyStateNeeded += Dgv_RowDirtyStateNeeded;
            dgv.CancelRowEdit += Dgv_CancelRowEdit;
            dgv.UserDeletingRow += Dgv_UserDeletingRow;
            dgv.DataError += Dgv_DataError;

            dgv.RowCount = Records.Count + 1;
        }

        private void Dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void Dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < Records.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this language?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SurveyLanguage record = Records[e.Row.Index];
                    // If the user has deleted an existing row, remove the corresponding object from the data store.
                    Records.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.editedRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                editedRow = -1;
                editedRecord = null;
            }
        }

        private void Dgv_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (editedRow == dgv.Rows.Count - 2 && editedRow == Records.Count)
            {
                // If the user has canceled the edit of a newly created row, replace the corresponding object with a new, empty one.
                editedRecord = new SurveyLanguage();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedRecord = null;
                editedRow = -1;
            }
        }

        private void Dgv_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void Dgv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedRecord != null && e.RowIndex >= Records.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                Records.Add(editedRecord);
                editedRecord.SurvID = DefaultSurvID;
                DBAction.InsertSurveyLanguage(editedRecord);

                editedRecord = null;
                editedRow = -1;
            }
            else if (editedRecord != null && e.RowIndex < Records.Count)
            {
                // Save the modified object in the data store.
                Records[e.RowIndex] = editedRecord;
                DBAction.UpdateSurveyLanguage(editedRecord);
                editedRecord = null;
                editedRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedRecord = null;
                editedRow = -1;
            }
        }

        private void Dgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SurveyLanguage tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < Records.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedRecord == null)
                    editedRecord = new SurveyLanguage()
                    {
                        ID = Records[e.RowIndex].ID,
                        SurvID = Records[e.RowIndex].SurvID,
                        SurvLanguage = Records[e.RowIndex].SurvLanguage
                    };

                tmp = editedRecord;
                editedRow = e.RowIndex;
            }
            else
            {
                tmp = editedRecord;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLangID":
                    Language newValue = AvailableLanguages.FirstOrDefault(x => x.ID == (int)e.Value);
                    tmp.SurvLanguage.ID = newValue.ID;
                    tmp.SurvLanguage.LanguageName = newValue.LanguageName;
                    break;
            }
        }

        private void Dgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If there are no records to show, no values are needed.
            if (Records.Count == 0) return;

            SurveyLanguage tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == editedRow)
            {
                tmp = editedRecord;
            }
            else
            {
                tmp = Records[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLangID":
                    e.Value = tmp.SurvLanguage.ID;
                    break;
            }
        }

        private void Dgv_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            editedRecord = new SurveyLanguage();
            editedRow = dgv.Rows.Count - 1;
        }
    }
}
