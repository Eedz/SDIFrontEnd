using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OpenXMLHelper;
using ITCLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class RenameVarsBulk : Form
    {
        public int Scope = 1;

        List<VarNameChangeNotification> Notifications;

        List<VarNameChange> Changes;
        List<VarNameChange> Failures;

        bool rowCommit = true;
        VarNameChangeNotification editedNotification;
        int notificationRow = -1;

        public RenameVarsBulk()
        {
            InitializeComponent();

            FillBoxes();

            SetupGrids();

            SetDefaults();
        }

        #region Form Setup

        /// <summary>
        /// Fill comboboxes on the form.
        /// </summary>
        private void FillBoxes()
        {
            cboChangedBy.DisplayMember = "Name";
            cboChangedBy.ValueMember = "ID";
            cboChangedBy.DataSource = new List<Person>(Globals.AllPeople);
        }

        /// <summary>
        /// Setup DataGridView events and fill combobox columns.
        /// </summary>
        private void SetupGrids()
        {
            Notifications = GetDefaultNotifications();

            dgvNotifications.AutoGenerateColumns = false;

            chName.DisplayMember = "Name";
            chName.ValueMember = "ID";
            chName.DataSource = new List<Person>(Globals.AllPeople);
            chName.DataPropertyName = "PersonID";

            chType.DataSource = new List<string>() { "Auto-email", "Personal email", "Mentioned in meeting", "Personal conversation" };

            dgvNotifications.CellValueNeeded += dgvNotifications_CellValueNeeded;
            dgvNotifications.NewRowNeeded += dgvNotifications_NewRowNeeded;
            dgvNotifications.CellValuePushed += dgvNotifications_CellValuePushed;
            dgvNotifications.RowValidated += dgvNotifications_RowValidated;
            dgvNotifications.RowDirtyStateNeeded += dgvNotifications_RowDirtyStateNeeded;
            dgvNotifications.CancelRowEdit += dgvNotifications_CancelRowEdit;
            dgvNotifications.UserDeletingRow += dgvNotifications_UserDeletingRow;
            dgvNotifications.DataError += dgvNotifications_DataError;

            dgvNotifications.SetVirtualGridRows(Notifications.Count + 1);
        }

        /// <summary>
        /// Set the default settings for the form.
        /// </summary>
        private void SetDefaults()
        {
            optManual.Checked = true;
            ShowForm();
        }
        #endregion

        #region Methods

        private void Rename()
        {
            if (!SurveyListOK())
            {
                MessageBox.Show("One or more surveys specified is not a valid survey code. Please check the surveys affected column and try again.");
                return;
            }

            PerformRenames();

            if (Failures.Count > 0)
            {
                DisplayFails(Failures);
            }

            if (Changes.Count == 0)
            {
                MessageBox.Show("No renames were made.");
                return;
            }

            if (!chkDoNotDoc.Checked && Changes.Count>0)
            {
                VarChangeTracking frm = new VarChangeTracking(Changes, true);
                frm.ShowDialog();
            }

            UpdateDetails();

        }
        
        /// <summary>
        /// Import old and new names from a document.
        /// </summary>
        private void Import()
        {
            if (string.IsNullOrEmpty(txtPath.Text))
                return;

            try
            {

                LoadRecords(txtPath.Text);
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to access the file. Make sure it is not open in the background and try again.");
                return;
            }

            UpdateDetails();
            panelDetails.Visible = true;
        }

        /// <summary>
        /// Scan the document for a table. Each row should contain and old VarName and new VarName. Add these values to the datagridview.
        /// </summary>
        /// <param name="filePath"></param>
        private void LoadRecords(string filePath)
        {
            dgvRenames.Rows.Clear();
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                Body body = doc.MainDocumentPart.Document.Body;
                Table renamesTable = doc.MainDocumentPart.Document.Body.Elements<Table>().FirstOrDefault();

                if (renamesTable == null)
                    throw new Exception("Missing table.");

                foreach (TableRow row in renamesTable.Elements<TableRow>().Skip(1))
                {
                    var cells = row.Elements<TableCell>();

                    string oldname = cells.ElementAt(0).GetCellText();
                    string newname = cells.ElementAt(1).GetCellText();

                    if (!string.IsNullOrEmpty(oldname) && !string.IsNullOrEmpty(newname))
                    {
                        dgvRenames.Rows.Add(new object[] { oldname, newname });
                    }
                }
            }
        }

        private List<VarNameChangeNotification> GetDefaultNotifications()
        {
            List<VarNameChangeNotification> defaults = new List<VarNameChangeNotification>();

            foreach (Person p in Globals.AllPeople.Where(x => x.VarNameChangeNotify && x.Active))
            {
                defaults.Add(new VarNameChangeNotification() { Name = p, NotifyType = "Auto-email" });
            }
            return defaults;
        }

        private bool SurveyListOK()
        {
            foreach (DataGridViewRow row in dgvRenames.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string[] surveys = GetSurveys((string)row.Cells["chSurveysAffected"].Value);

                foreach (string s in surveys)
                {
                    if (!Globals.AllSurveys.Any(x => x.SurveyCode.Equals(s)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string[] GetSurveys(string list)
        {
            string[] surveys = list.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < surveys.Length; i++)
                surveys[i] = surveys[i].Trim();

            return surveys;
        }

        private List<Survey> GetAffectedSurveys(string surveyList)
        {
            List<Survey> affected = new List<Survey>();
            string[] surveys = GetSurveys(surveyList);
            for (int i = 0; i < surveys.Length; i++)
            {
                Survey survey = Globals.AllSurveys.FirstOrDefault(x => x.SurveyCode.Equals(surveys[i]));
                if (survey != null)
                    affected.Add(survey);
            }
            return affected;
        }

        private void PerformRenames()
        {
            // create a list to hold failures
            Failures = new List<VarNameChange>();
            // create a rename object for each row in the datagrid view
            Changes = new List<VarNameChange>();

            foreach (DataGridViewRow row in dgvRenames.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string oldvarname = (string)row.Cells[0].Value;
                string newvarname = (string)row.Cells[1].Value;

                RefVariableName oldName = new RefVariableName(Utilities.ChangeCC(oldvarname));
                RefVariableName newName = new RefVariableName(Utilities.ChangeCC(newvarname));

                var surveys = GetAffectedSurveys((string)row.Cells["chSurveysAffected"].Value);

                VarRenamer rename = new VarRenamer(oldName, newName, surveys);

                rename.PerformRefRename();

                foreach (Wording prep in rename.WordingChanges)
                {
                    Globals.UpdateWordings(rename.WordingChanges);
                }

                if (rename.FailedRenames.Count > 0)
                {
                    VarNameChange failure = new VarNameChange();
                    failure.OldName = oldvarname;
                    failure.NewName = newvarname;
                    foreach (Survey s in rename.FailedRenames)
                        failure.SurveysAffected.Add(new VarNameChangeSurvey()
                        {
                            SurveyCode = s
                        });

                    Failures.Add(failure);
                }

                // document rename, fill in the rest of the information
                foreach (VarNameChange change in rename.Changes)
                {
                    change.ChangedBy = (Person)cboChangedBy.SelectedItem;
                    change.ChangeDate = DateTime.Now;
                    change.Authorization = txtAuthorization.Text;
                    change.Rationale = txtRationale.Text;
                    change.Source = txtSource.Text;
                    change.PreFWChange = chkPreFW.Checked;
                    change.HiddenChange = chkHidden.Checked;
                    change.Notifications = Notifications;
                    Changes.Add(change);
                }
            }
        }

        private void DisplayFails(List<VarNameChange> failures)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Some renames could not be performed.");

            foreach (VarNameChange c in failures)
                sb.AppendLine(c.OldName + " -> " + c.NewName + ": " + c.GetSurveys());

            MessageBox.Show(sb.ToString());
        }

        private void ListAffectedSurveys(DataGridViewRow row)
        {
            string varnameOld = (string)row.Cells[0].Value;
            string varnameNew = (string)row.Cells[1].Value;
            List<string> surveysOld;
            List<string> surveysNew;

            if (Scope == 1)
            {
                surveysOld = DBAction.GetVarNameSurveys(varnameOld);
                surveysNew = DBAction.GetVarNameSurveys(varnameNew);
            }
            else if (Scope == 2)
            {
                surveysOld = DBAction.GetRefVarNameSurveys(varnameOld);
                surveysNew = DBAction.GetRefVarNameSurveys(varnameNew);
            }
            else
                return;

            // all locked surveys
            var lockedList = Globals.AllSurveys.Where(x => x.Locked).Select(x => x.SurveyCode).ToList();

            var locked = surveysOld.Intersect(lockedList);

            var affected = surveysOld.Except(locked);
            affected = affected.Except(surveysNew);
            var both = surveysOld.Intersect(surveysNew);
            row.Cells[3].Value = string.Join(", ", affected);
            row.Cells[4].Value = string.Join(", ", both);
            row.Cells[5].Value = string.Join(", ", locked);

        }

        private void ListVarLabels(DataGridViewRow row)
        {
            string varnameOld = (string)row.Cells[0].Value;
            string varnameNew = (string)row.Cells[1].Value;
            StringBuilder varlabel = new StringBuilder();
            if (Scope == 1)
            {
                VariableName old = DBAction.GetVariable(varnameOld);
                if (old != null)
                    varlabel.AppendLine(varnameOld + ": " + old.VarLabel);

                VariableName newName = DBAction.GetVariable(varnameNew);
                if (newName != null)
                    varlabel.AppendLine(varnameNew + ": " + newName.VarLabel);
            }
            else if (Scope == 2)
            {
                List<VariableName> oldRefVars = DBAction.GetVarNamesByRef(varnameOld);
                if (oldRefVars.Count > 0)
                    varlabel.AppendLine(varnameOld + ": " + oldRefVars[0].VarLabel);

                List<VariableName> newRefVars = DBAction.GetVarNamesByRef(varnameNew);
                if (newRefVars.Count > 0)
                    varlabel.AppendLine(varnameNew + ": " + newRefVars[0].VarLabel);
            }
            else
                return;

            row.Cells[2].Value = varlabel.ToString();
        }

        /// <summary>
        /// Updates the list of affected surveys and the labels for each rename.
        /// </summary>
        private void UpdateDetails()
        {
            foreach (DataGridViewRow row in dgvRenames.Rows)
            {
                if (row.IsNewRow)
                    continue;

                ListAffectedSurveys(row);
                ListVarLabels(row);
            }
            AutoResizeColumnsAllowResizing(dgvRenames);
        }

        private void AutoResizeColumnsAllowResizing(DataGridView grid)
        {
            // Set your desired AutoSize Mode:
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn c in grid.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= grid.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = grid.Columns[i].Width;

                // Remove AutoSizing:
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                grid.Columns[i].Width = colw;
            }
            //grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void ShowForm()
        {
            bool useFile = optFile.Checked;

            txtPath.Enabled = useFile;
            cmdBrowse.Enabled = useFile;
            cmdImport.Enabled = useFile;
            lblFileInstructions.Visible = useFile;

            panelDetails.Visible = !useFile;
        }

        private void Clear()
        {
            // clear datagrid
            dgvRenames.Rows.Clear();
            // clear entered data
            cboChangedBy.SelectedItem = null;
            txtAuthorization.Text = string.Empty;
            txtRationale.Text = string.Empty;
            txtSource.Text = string.Empty;
            chkPreFW.Checked = false;
            chkHidden.Checked = false;
            chkDoNotDoc.Checked = false;
            // notifications to default
            Notifications = GetDefaultNotifications();

            dgvNotifications.SetVirtualGridRows(Notifications.Count + 1);

            optManual.Checked = true;
            optVarName.Checked = true;
        }
        #endregion 

        #region Events
        private void RenameVarsBulk_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void cmdRename_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void cmdUnlockRename_Click(object sender, EventArgs e)
        {
            UnlockSurvey frm = new UnlockSurvey();
            frm.ShowDialog();

            UpdateDetails();
        }

        private void Scope_Click(object sender, EventArgs e)
        {
            if (optVarName.Checked)
                Scope = 1;
            if (optRefVarName.Checked)
                Scope = 2;

            UpdateDetails();
        }

        private void Source_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.doc|*.docx";
            dialog.ShowDialog();

            txtPath.Text = dialog.FileName;
            cmdImport.Visible = true;
            cmdImport.Enabled = true;
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void dgvRenames_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string columnName = dgv.Columns[e.ColumnIndex].Name;

            if (columnName.Equals("chOldName") || columnName.Equals("chNewName"))
            {
                // fill affected surveys
                ListAffectedSurveys(dgv.Rows[e.RowIndex]);
                // get varlabels 
                ListVarLabels(dgv.Rows[e.RowIndex]);

                AutoResizeColumnsAllowResizing(dgv);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region DataGridView Events

        private void dgvNotifications_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedNotification = new VarNameChangeNotification();
            this.notificationRow = dgv.Rows.Count - 1;
        }

        private void dgvNotifications_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (Notifications.Count == 0) return;

            VarNameChangeNotification tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == notificationRow)
            {
                tmp = editedNotification;
            }
            else
            {
                tmp = Notifications[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chName":
                    e.Value = tmp.Name;
                    break;
                case "chType":
                    e.Value = tmp.NotifyType;
                    break;
            }
        }

        private void dgvNotifications_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VarNameChangeNotification tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < Notifications.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedNotification == null)
                    editedNotification = new VarNameChangeNotification()
                    {
                        Name = Notifications[e.RowIndex].Name,
                        NotifyType = Notifications[e.RowIndex].NotifyType,
                    };

                tmp = this.editedNotification;
                this.notificationRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedNotification;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chName":
                    tmp.Name = Globals.AllPeople.FirstOrDefault(x=>x.ID == (int)e.Value);
                    break;
                case "chType":
                    tmp.NotifyType = (string)e.Value;
                    break;
            }
        }

        private void dgvNotifications_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedNotification != null && e.RowIndex >= Notifications.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                Notifications.Add(editedNotification);

                editedNotification = null;
                notificationRow = -1;
            }
            else if (editedNotification != null && e.RowIndex < Notifications.Count)
            {
                Notifications[e.RowIndex] = editedNotification;
                editedNotification = null;
                notificationRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedNotification = null;
                notificationRow = -1;
            }
        }

        private void dgvNotifications_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvNotifications_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (notificationRow == dgv.Rows.Count - 2 && notificationRow == Notifications.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedNotification = new VarNameChangeNotification();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedNotification = null;
                notificationRow = -1;
            }
        }

        private void dgvNotifications_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.Notifications.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // If the user has deleted an existing row, remove the corresponding object from the data store.
                    Notifications.RemoveAt(e.Row.Index);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.notificationRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.notificationRow = -1;
                this.editedNotification = null;
            }
        }

        private void dgvNotifications_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

        #endregion

        
    }
}
