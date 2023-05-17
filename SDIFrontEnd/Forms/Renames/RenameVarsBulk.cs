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

        BindingSource bsNotifications;
        List<VarNameChangeRecord> Changes;
        List<VarNameChange> Failures;

        public RenameVarsBulk()
        {
            InitializeComponent();

            FillBoxes();
            optFile.Checked = true;
        }

        #region Events
        

        private void cmdRename_Click(object sender, EventArgs e)
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

            if (!chkDoNotDoc.Checked)
            {
                VarChangeTracking frm = new VarChangeTracking(Changes, true);
                frm.ShowDialog();
            }
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
            bool useFile = optFile.Checked;

            txtPath.Enabled = useFile;
            cmdBrowse.Enabled = useFile;
            cmdImport.Enabled = useFile;
            lblFileInstructions.Visible = useFile;

            panelDetails.Visible = !useFile;


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
            if (string.IsNullOrEmpty(txtPath.Text))
                return;

            // import from file
            
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
            // clear datagrid

            dgvRenames.Rows.Clear();
            cboChangedBy.SelectedItem = null;
            txtAuthorization.Text = string.Empty;
            txtRationale.Text = string.Empty;
            txtSource.Text = string.Empty;
            chkPreFW.Checked = false;
            chkHidden.Checked = false;
            chkDoNotDoc.Checked = false;

            bsNotifications = new BindingSource()
            {
                DataSource = GetDefaultNotifications()
            };

            dgvNotifications.DataSource = bsNotifications;

            optFile.Checked = true;
            optVarName.Checked = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Scan the document for a table. Each unqie issue number found in the table corresponds to 1 Praccing Issue and its related responses.
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

                int rowCount = 0;
                foreach (TableRow row in renamesTable.Elements<TableRow>())
                {
                    // skip first row (heading)
                    rowCount++;
                    if (rowCount == 1)
                        continue;

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

        private void FillBoxes()
        {
            cboChangedBy.DisplayMember = "Name";
            cboChangedBy.ValueMember = "ID";
            cboChangedBy.DataSource = new List<Person>(Globals.AllPeople);

            chName.DisplayMember = "Name";
            chName.ValueMember = "ID";
            chName.DataSource = new List<Person>(Globals.AllPeople);
            chName.DataPropertyName = "PersonID";

            chType.DataSource = new List<string>() { "Auto-email", "Personal email", "Mentioned in meeting", "Personal conversation" };
            chType.DataPropertyName = "NotifyType";

            bsNotifications = new BindingSource()
            {
                DataSource = GetDefaultNotifications()
            };

            dgvNotifications.DataSource = bsNotifications;
        }

        private List<VarNameChangeNotificationRecord> GetDefaultNotifications()
        {
            List<VarNameChangeNotificationRecord> defaults = new List<VarNameChangeNotificationRecord>();

            foreach (Person p in Globals.AllPeople.Where(x => x.VarNameChangeNotify && x.Active))
            {
                defaults.Add(new VarNameChangeNotificationRecord() { PersonID = p.ID, Name = p.Name, NotifyType = "Auto-email" });
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
            string[] surveys = list.Split(new char[] { ',' });

            for (int i = 0; i < surveys.Length; i ++)
                surveys[i] = surveys[i].Trim();

            return surveys;
        }

        private List<VarNameChangeSurveyRecord> GetAffectedSurveyRecords(string surveyList)
        {
            List<VarNameChangeSurveyRecord> records = new List<VarNameChangeSurveyRecord>();
            string[] surveys = GetSurveys(surveyList);
            for (int i = 0; i < surveys.Length; i++)
            {
                VarNameChangeSurveyRecord surveysAff = new VarNameChangeSurveyRecord();
                surveysAff.SurveyCode = surveys[i];
                records.Add(surveysAff);
            }
            return records;
        }

        private List<Survey> GetAffectedSurveys(string surveyList)
        {
            List<Survey> records = new List<Survey>();
            string[] surveys = GetSurveys(surveyList);
            for (int i = 0; i < surveys.Length; i++)
            {
                Survey surveysAff = Globals.AllSurveys.First(x=>x.SurveyCode.Equals(surveys[i]));
                if (surveysAff == null) continue;
                records.Add(surveysAff);
            }
            return records;
        }

        private List<VarNameChangeNotificationRecord> GetNotifications()
        {
            List<VarNameChangeNotificationRecord> records = new List<VarNameChangeNotificationRecord>();

            foreach (DataGridViewRow row in dgvNotifications.Rows)
            {
                if (row.IsNewRow)
                    continue;

                VarNameChangeNotificationRecord record = new VarNameChangeNotificationRecord();
                record.PersonID = (int)row.Cells["chName"].Value;
                record.Name = (string)row.Cells["chName"].FormattedValue;
                record.NotifyType = (string)row.Cells["chType"].Value;
                records.Add(record);
            }

            return records;
        }

        private void PerformRenames()
        {

            // create list of renamers
            List<VarRenamer> renames = new List<VarRenamer>();

            // create a list to hold failures
            Failures = new List<VarNameChange>();
            // create a rename object for each row in the datagrid view
            Changes = new List<VarNameChangeRecord>();
            foreach (DataGridViewRow row in dgvRenames.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string oldvarname = (string)row.Cells[0].Value;
                string newvarname = (string)row.Cells[1].Value;

                RefVariableName oldName = new RefVariableName(Utilities.ChangeCC(oldvarname));
                RefVariableName newName = new RefVariableName(Utilities.ChangeCC(newvarname));

                VarRenamer rename = new VarRenamer(oldName, newName, GetAffectedSurveys((string)row.Cells["chSurveysAffected"].Value));

                rename.PerformRefRename();

                if (rename.FailedRenames.Count > 0)
                {
                    VarNameChange failure = new VarNameChange();
                    failure.OldName = oldvarname;
                    failure.NewName = newvarname;
                    foreach (string s in rename.FailedRenames)
                        failure.SurveysAffected.Add(new Survey(s));

                    Failures.Add(failure);
                }

                // document rename, fill in the rest of the information
                foreach (VarNameChangeRecord change in rename.Changes)
                {
                    change.ChangedBy = (Person)cboChangedBy.SelectedItem;
                    change.ChangeDate = DateTime.Now;
                    change.Authorization = txtAuthorization.Text;
                    change.Rationale = txtRationale.Text;
                    change.Source = txtSource.Text;
                    change.PreFWChange = chkPreFW.Checked;
                    change.HiddenChange = chkHidden.Checked;
                    change.Notifications = GetNotifications();
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
                
            // all lockeds surveys
            var lockedList = Globals.AllSurveys.Where(x => x.Locked).Select(x=>x.SurveyCode).ToList();

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
            StringBuilder varlabel= new StringBuilder();
            if (Scope == 1)
            {
                VariableName old = DBAction.GetVariable(varnameOld);
                if (old!=null)
                    varlabel.AppendLine(varnameOld + ": " + old.VarLabel);

                VariableName newName = DBAction.GetVariable(varnameNew);
                if (newName!=null)
                    varlabel.AppendLine(varnameNew + ": " + newName.VarLabel);
            }
            else if (Scope == 2)
            {
                List<VariableName> oldRefVars = DBAction.GetVarNamesByRef(varnameOld);
                if (oldRefVars.Count>0)
                    varlabel.AppendLine(varnameOld + ": " + oldRefVars[0].VarLabel);

                List<VariableName> newRefVars = DBAction.GetVarNamesByRef(varnameNew);
                if (newRefVars.Count > 0)
                    varlabel.AppendLine(varnameNew + ": " + newRefVars[0].VarLabel);
            }
            else
                return;

            row.Cells[2].Value = varlabel.ToString();
        }

        private void UpdateDetails()
        {
            foreach(DataGridViewRow row in dgvRenames.Rows)
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

        #endregion
    }
}
