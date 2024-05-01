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
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class VarChangeTracking : Form
    {
        List<VarNameChangeRecord> Records;
        VarNameChangeRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsCurrent;

        bool SaveAll = false; // indicates if all records should be saved when closing

        VarNameChangeSurvey editedSurvey;
        int surveyRow = -1;

        VarNameChangeNotification editedNotify;
        int notifyRow = -1;

        bool rowCommit = true;

        public VarChangeTracking()
        {
            InitializeComponent();

            this.MouseWheel += VarChangeTracking_MouseWheel;

            Records = new List<VarNameChangeRecord>();

            FillBoxes();

            SetupBindingSources();

            SetupGrids();                    

            BindProperties();
        }

        public VarChangeTracking (List<VarNameChange> records, bool saveAll) : this()
        {
            lblSurvey.Visible = false;
            cboSurvey.Visible = false;
            chkToggleHistory.Visible = false;
            dataRepeater1.Visible = false;
            SaveAll = saveAll;
            LoadRecords(records);
        }

        #region From Setup 

        private void FillBoxes()
        {
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.SelectedItem = null;
            cboSurvey.SelectedIndexChanged += cboSurvey_SelectedIndexChanged;

            cboChangedBy.DisplayMember = "Name";
            cboChangedBy.ValueMember = "ID";
            cboChangedBy.DataSource = new List<Person>(Globals.AllPeople);
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource()
            {
                DataSource = Records
            };
            
            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource()
            {
                DataSource = bs,
                DataMember = "Item"
            };
            
            bsCurrent.ListChanged += BsCurrent_ListChanged;
        }

        private void SetupGrids()
        {
            dgvSurveys.AutoGenerateColumns = false;

            chSurvey.DisplayMember = "SurveyCode";
            chSurvey.ValueMember = "SID";
            chSurvey.DataSource = new List<Survey>(Globals.AllSurveys);

            dgvSurveys.CellValueNeeded += dgvSurveys_CellValueNeeded;
            dgvSurveys.NewRowNeeded += dgvSurveys_NewRowNeeded;
            dgvSurveys.CellValuePushed += dgvSurveys_CellValuePushed;
            dgvSurveys.RowValidated += dgvSurveys_RowValidated;
            dgvSurveys.RowDirtyStateNeeded += dgvSurveys_RowDirtyStateNeeded;
            dgvSurveys.CancelRowEdit += dgvSurveys_CancelRowEdit;
            dgvSurveys.UserDeletingRow += dgvSurveys_UserDeletingRow;
            dgvSurveys.DataError += dgvSurveys_DataError;

            dgvNotifications.AutoGenerateColumns = false;

            chNotifyName.DisplayMember = "Name";
            chNotifyName.ValueMember = "ID";
            chNotifyName.DataSource = new List<Person>(Globals.AllPeople);

            chNotifyType.DataSource = new List<string>() { "Auto-email", "Personal email", "Mentioned in meeting", "Personal conversation" };

            dgvNotifications.CellValueNeeded += dgvNotifications_CellValueNeeded;
            dgvNotifications.NewRowNeeded += dgvNotifications_NewRowNeeded;
            dgvNotifications.CellValuePushed += dgvNotifications_CellValuePushed;
            dgvNotifications.RowValidated += dgvNotifications_RowValidated;
            dgvNotifications.RowDirtyStateNeeded += dgvNotifications_RowDirtyStateNeeded;
            dgvNotifications.CancelRowEdit += dgvNotifications_CancelRowEdit;
            dgvNotifications.UserDeletingRow += dgvNotifications_UserDeletingRow;
            dgvNotifications.DataError += dgvNotifications_DataError;
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bsCurrent, "ID");
            txtOldName.DataBindings.Add("Text", bsCurrent, "OldName");
            txtNewName.DataBindings.Add("Text", bsCurrent, "NewName");
            dtpChangeDate.DataBindings.Add("Value", bsCurrent, "ChangeDate", true);
            cboChangedBy.DataBindings.Add("SelectedItem", bsCurrent, "ChangedBy");
            txtAuthorization.DataBindings.Add("Text", bsCurrent, "Authorization");
            txtRationale.DataBindings.Add("Text", bsCurrent, "Rationale");
            txtSource.DataBindings.Add("Text", bsCurrent, "Source");
            chkPreFWS.DataBindings.Add("Checked", bsCurrent, "PreFWChange");
            chkHiddenChange.DataBindings.Add("Checked", bsCurrent, "HiddenChange");
        }


        #endregion

        #region Methods


        private void LoadRecords(List<VarNameChange> records)
        {
            Records = new List<VarNameChangeRecord>();
            foreach (VarNameChange change  in records)
            {
                if (change.ID == 0) 
                {
                    Records.Add(new VarNameChangeRecord(change)
                    {
                        NewRecord = true
                    });
                }
                else
                {
                    Records.Add(new VarNameChangeRecord(change));
                }                
            }
            
            bs.DataSource = Records;
            bindingNavigator1.BindingSource = bs;

            panelMain.Visible = true;
        }

        private void RefreshCurrentRecord()
        {
            CurrentRecord = (VarNameChangeRecord)bs.Current;

            dgvSurveys.SetVirtualGridRows(CurrentRecord.Item.SurveysAffected.Count() + 1);
            dgvNotifications.SetVirtualGridRows(CurrentRecord.Item.Notifications.Count() + 1);
        }

        private void SaveRecord()
        {
            if (CurrentRecord == null)
                return;

            bsCurrent.EndEdit();

            bool newRec = CurrentRecord.NewRecord;
            int updated = CurrentRecord.SaveRecord();

            if (updated == 0)
            {
                //lblStatus.Text = "";
                lblNewID.Visible = false;
                CurrentRecord.Dirty = false;
            }
            else
            {
                MessageBox.Show("Unable to save record.");
            }
        }

        private void MoveRecord(int count)
        {
            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }
        }

        private void AddNewRecord()
        {
            bs.AddNew();
            lblNewID.Left = txtID.Left;
            lblNewID.Top = txtID.Top;

            CurrentRecord.NewRecord = true;
        }

        private void DeleteRecord()
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAction.DeleteRecord(CurrentRecord.Item);
                bs.RemoveCurrent();
            }
        }

        private void EmailRecord()
        {
            SaveRecord();

            VarNameChange change = CurrentRecord.Item;

            Microsoft.Office.Interop.Outlook.Application app = new
                          Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem item = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            item.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

            List<string> recipients = new List<string>();

            foreach (VarNameChangeNotification notify in change.Notifications)
            {
                Person person = Globals.AllPeople.Where(x => x.ID == notify.Name.ID).FirstOrDefault();
                if (person != null && !string.IsNullOrEmpty(person.Email))
                    recipients.Add(person.Email);
            }

            item.To = string.Join(";", recipients);
            item.Recipients.ResolveAll();
            item.Subject = change.OldName + " Renamed: " + change.NewName;
            item.Body = "Country: " + change.GetSurveys() + "\r\n" + "VarName: " + change.OldName + " has been renamed to " + change.NewName + "\r\n" +
                "Date: " + change.ChangeDate.ToString("d") + "\r\n" + "Effective as of next release.\r\nRationale: " + change.Rationale;
            item.Display();
        }

        private void LoadHistory()
        {

        }
        #endregion

        #region Events
        private void VarChangeTracking_Load(object sender, EventArgs e)
        {
            CurrentRecord = (VarNameChangeRecord)bs.Current;
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentRecord();
        }

        private void BsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;

            // item: bs[e.NewIndex]
            // property name: e.PropertyDescriptor.Name
            if (e.PropertyDescriptor != null)
            {
                // get the paper record that was modified
                VarNameChange modifiedChange = (VarNameChange)bsCurrent[e.NewIndex];
                VarNameChangeRecord modifiedRecord = Records.Where(x => x.Item == modifiedChange).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    case "Notifications":
                    case "SurveysAffected":
                        break;
                    default:
                        modifiedRecord.Dirty = true;
                        break;
                }
                //if (CurrentRecord.Dirty)
                //lblStatus.Text = "*";
            }
        }

        private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null)
                return;
            Survey selected = (Survey)cboSurvey.SelectedItem;
            LoadRecords(DBAction.GetVarNameChanges(selected));
            RefreshCurrentRecord();
        }

        private void VarChangeTracking_MouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();

            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
                bs.MovePrevious();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveAll)
            {
                foreach (VarNameChangeRecord record in Records)
                    record.SaveRecord();
            }
            else
            {
                SaveRecord();
            }

            Close();
            FM.FormManager.Remove(this);
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void toolStripButtonEmail_Click(object sender, EventArgs e)
        {
            EmailRecord();
        }

        private void chkToggleHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToggleHistory.Checked)
                LoadHistory();
            else

                dataRepeater1.Visible = chkToggleHistory.Checked;
        }

        #region Surveys Affected Grid
        
        
        private void dgvSurveys_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedSurvey = new VarNameChangeSurvey();
            this.surveyRow = dgv.Rows.Count - 1;
        }

        private void dgvSurveys_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.SurveysAffected.Count == 0) return;

            VarNameChangeSurvey tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == surveyRow)
            {
                tmp = editedSurvey;
            }
            else
            {
                tmp = CurrentRecord.Item.SurveysAffected[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSurvey":
                    e.Value = tmp.SurveyCode;
                    break;
            }
        }

        private void dgvSurveys_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VarNameChangeSurvey tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.SurveysAffected.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedSurvey == null)
                    editedSurvey = new VarNameChangeSurvey()
                    {
                        ID = CurrentRecord.Item.SurveysAffected[e.RowIndex].ID,
                        SurveyCode = CurrentRecord.Item.SurveysAffected[e.RowIndex].SurveyCode,
                        ChangeID = CurrentRecord.Item.SurveysAffected[e.RowIndex].ChangeID
                    };

                tmp = this.editedSurvey;
                this.surveyRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedSurvey;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSurvey":
                    tmp.ChangeID = CurrentRecord.Item.ID;
                    tmp.SurveyCode = Globals.AllSurveys.FirstOrDefault(x=>x.SID==(int)e.Value);
                    break;
            }
        }

        private void dgvSurveys_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedSurvey != null && e.RowIndex >= CurrentRecord.Item.SurveysAffected.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.SurveysAffected.Add(editedSurvey);
                CurrentRecord.AddedSurveysAffected.Add(editedSurvey);

                editedSurvey = null;
                surveyRow = -1;
            }
            else if (editedSurvey != null && e.RowIndex < CurrentRecord.Item.SurveysAffected.Count)
            {
                // ignore edits
                editedSurvey = null;
                surveyRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedSurvey = null;
                surveyRow = -1;
            }
        }

        private void dgvSurveys_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvSurveys_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (surveyRow == dgv.Rows.Count - 2 && surveyRow == CurrentRecord.Item.SurveysAffected.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedSurvey = new VarNameChangeSurvey();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedSurvey = null;
                surveyRow = -1;
            }
        }

        private void dgvSurveys_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.SurveysAffected.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    VarNameChangeSurvey record = CurrentRecord.Item.SurveysAffected[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.SurveysAffected.RemoveAt(e.Row.Index);
                    CurrentRecord.DeletedSurveysAffected.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.surveyRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.surveyRow = -1;
                this.editedSurvey = null;
            }
        }

        private void dgvSurveys_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

        #region Notifications Grid

        private void dgvNotifications_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedNotify = new VarNameChangeNotification();
            this.notifyRow = dgv.Rows.Count - 1;
        }

        private void dgvNotifications_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.Notifications.Count == 0) return;

            VarNameChangeNotification tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == notifyRow)
            {
                tmp = editedNotify;
            }
            else
            {
                tmp = CurrentRecord.Item.Notifications[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chNotifyName":
                    e.Value = tmp.Name;
                    break;
                case "chNotifyType":
                    e.Value = tmp.NotifyType;
                    break;
            }
        }

        private void dgvNotifications_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VarNameChangeNotification tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.Notifications.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedNotify == null)
                    editedNotify = new VarNameChangeNotification()
                    {
                        ID = CurrentRecord.Item.Notifications[e.RowIndex].ID,
                        ChangeID = CurrentRecord.Item.Notifications[e.RowIndex].ChangeID,
                        Name = CurrentRecord.Item.Notifications[e.RowIndex].Name,
                        NotifyType = CurrentRecord.Item.Notifications[e.RowIndex].NotifyType
                    };

                tmp = this.editedNotify;
                this.notifyRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedNotify;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chNotifyName":
                    tmp.ChangeID = CurrentRecord.Item.ID;
                    tmp.Name = Globals.AllPeople.FirstOrDefault(x => x.ID == (int)e.Value);
                    break;

                case "chNotifyType":
                    tmp.ChangeID = CurrentRecord.Item.ID;
                    tmp.NotifyType = (string)e.Value;
                    break;
            }
        }

        private void dgvNotifications_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedNotify != null && e.RowIndex >= CurrentRecord.Item.Notifications.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.Notifications.Add(editedNotify);
                CurrentRecord.AddedNotifications.Add(editedNotify);

                editedNotify = null;
                notifyRow = -1;
            }
            else if (editedNotify != null && e.RowIndex < CurrentRecord.Item.Notifications.Count)
            {
                // ignore edits
                editedNotify = null;
                notifyRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedNotify = null;
                notifyRow = -1;
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

            if (notifyRow == dgv.Rows.Count - 2 && notifyRow == CurrentRecord.Item.Notifications.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedNotify = new VarNameChangeNotification();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedNotify = null;
                notifyRow = -1;
            }
        }

        private void dgvNotifications_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.Notifications.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    VarNameChangeNotification record = CurrentRecord.Item.Notifications[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.Notifications.RemoveAt(e.Row.Index);
                    CurrentRecord.DeletedNotifications.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.notifyRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.notifyRow = -1;
                this.editedNotify = null;
            }
        }

        private void dgvNotifications_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Binding Navigator Events
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            bs.MoveFirst();
        }

        #endregion
        #endregion

      
    }
}
