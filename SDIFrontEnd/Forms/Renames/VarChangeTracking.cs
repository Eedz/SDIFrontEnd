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
        BindingList<VarNameChangeRecord> Records;
        VarNameChangeRecord CurrentRecord;

        BindingSource bs;

        bool SaveAll = false; // indicates if all records should be saved when closing

        VarNameChangeSurveyRecord editedSurvey;
        int surveyRow = -1;

        VarNameChangeNotificationRecord editedNotify;
        int notifyRow = -1;

        bool rowCommit = true;

        public VarChangeTracking()
        {
            InitializeComponent();

            FillBoxes();

            bs = new BindingSource();
            Records = new BindingList<VarNameChangeRecord>();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += Bs_ListChanged;

            this.MouseWheel += VarChangeTracking_MouseWheel;

            dgvSurveys.CellValueNeeded += dgvSurveys_CellValueNeeded;
            dgvSurveys.NewRowNeeded += dgvSurveys_NewRowNeeded;
            dgvSurveys.CellValuePushed += dgvSurveys_CellValuePushed;
            dgvSurveys.RowValidated += dgvSurveys_RowValidated;
            dgvSurveys.RowDirtyStateNeeded += dgvSurveys_RowDirtyStateNeeded;
            dgvSurveys.CancelRowEdit += dgvSurveys_CancelRowEdit;
            dgvSurveys.UserDeletingRow += dgvSurveys_UserDeletingRow;
            dgvSurveys.DataError += dgvSurveys_DataError;

            dgvNotifications.CellValueNeeded += dgvNotifications_CellValueNeeded;
            dgvNotifications.NewRowNeeded += dgvNotifications_NewRowNeeded;
            dgvNotifications.CellValuePushed += dgvNotifications_CellValuePushed;
            dgvNotifications.RowValidated += dgvNotifications_RowValidated;
            dgvNotifications.RowDirtyStateNeeded += dgvNotifications_RowDirtyStateNeeded;
            dgvNotifications.CancelRowEdit += dgvNotifications_CancelRowEdit;
            dgvNotifications.UserDeletingRow += dgvNotifications_UserDeletingRow;
            dgvNotifications.DataError += dgvNotifications_DataError;

            BindProperties();
        }

        public VarChangeTracking (List<VarNameChangeRecord> records, bool saveAll) : this()
        {
            lblSurvey.Visible = false;
            cboSurvey.Visible = false;
            chkToggleHistory.Visible = false;
            dataRepeater1.Visible = false;
            SaveAll = saveAll;
            LoadRecords(records);
        }

        #region Events
        private void VarChangeTracking_Load(object sender, EventArgs e)
        {
            CurrentRecord = (VarNameChangeRecord)bs.Current;
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentRecord();
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;

            int index = e.NewIndex; // index of the changed item

            ((VarNameChangeRecord)bs[index]).Dirty = true;
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
            if (SaveRecord() == 1)
                return;

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
            this.editedSurvey = new VarNameChangeSurveyRecord();
            this.surveyRow = dgv.Rows.Count - 1;
        }

        private void dgvSurveys_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.SurveysAffected.Count == 0) return;

            VarNameChangeSurveyRecord tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == surveyRow)
            {
                tmp = editedSurvey;
            }
            else
            {
                tmp = CurrentRecord.SurveysAffected[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chSurvey":
                    e.Value = tmp.SurvID;
                    break;
            }
        }

        private void dgvSurveys_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VarNameChangeSurveyRecord tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.SurveysAffected.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedSurvey == null)
                    editedSurvey = new VarNameChangeSurveyRecord()
                    {
                        ID = CurrentRecord.SurveysAffected[e.RowIndex].ID,
                        SurveyCode = CurrentRecord.SurveysAffected[e.RowIndex].SurveyCode,
                        SurvID = CurrentRecord.SurveysAffected[e.RowIndex].SurvID,
                        ChangeID = CurrentRecord.SurveysAffected[e.RowIndex].ChangeID
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
                    VarNameChangeSurveyRecord newValue = new VarNameChangeSurveyRecord();

                    tmp.ID = newValue.ID;
                    tmp.ChangeID = CurrentRecord.ID;
                    tmp.SurvID = (int)e.Value;
                    break;

            }
        }

        private void dgvSurveys_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedSurvey != null && e.RowIndex >= CurrentRecord.SurveysAffected.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.SurveysAffected.Add(editedSurvey);
                DBAction.InsertVarNameChangeSurvey(editedSurvey);

                editedSurvey = null;
                surveyRow = -1;
            }
            else if (editedSurvey != null && e.RowIndex < CurrentRecord.SurveysAffected.Count)
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

            if (surveyRow == dgv.Rows.Count - 2 && surveyRow == CurrentRecord.SurveysAffected.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedSurvey = new VarNameChangeSurveyRecord();
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
            if (e.Row.Index < this.CurrentRecord.SurveysAffected.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    VarNameChangeSurveyRecord record = CurrentRecord.SurveysAffected[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.SurveysAffected.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
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
            this.editedNotify = new VarNameChangeNotificationRecord();
            this.notifyRow = dgv.Rows.Count - 1;
        }

        private void dgvNotifications_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Notifications.Count == 0) return;

            VarNameChangeNotificationRecord tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == notifyRow)
            {
                tmp = editedNotify;
            }
            else
            {
                tmp = CurrentRecord.Notifications[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chNotifyName":
                    e.Value = tmp.PersonID;
                    break;
                case "chNotifyType":
                    e.Value = tmp.NotifyType;
                    break;
            }
        }

        private void dgvNotifications_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VarNameChangeNotificationRecord tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Notifications.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedNotify == null)
                    editedNotify = new VarNameChangeNotificationRecord()
                    {
                        ID = CurrentRecord.Notifications[e.RowIndex].ID,
                        ChangeID = CurrentRecord.Notifications[e.RowIndex].ChangeID,
                        PersonID = CurrentRecord.Notifications[e.RowIndex].PersonID,
                        NotifyType = CurrentRecord.Notifications[e.RowIndex].NotifyType
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
                    tmp.ChangeID = CurrentRecord.ID;
                    tmp.PersonID = (int)e.Value;
                    break;

                case "chNotifyType":
                    tmp.ChangeID = CurrentRecord.ID;
                    tmp.NotifyType = (string)e.Value;
                    break;
            }
        }

        private void dgvNotifications_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedNotify != null && e.RowIndex >= CurrentRecord.Notifications.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Notifications.Add(editedNotify);
                DBAction.InsertVarNameChangeNotification(editedNotify);

                editedNotify = null;
                notifyRow = -1;
            }
            else if (editedNotify != null && e.RowIndex < CurrentRecord.Notifications.Count)
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

            if (notifyRow == dgv.Rows.Count - 2 && notifyRow == CurrentRecord.Notifications.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedNotify = new VarNameChangeNotificationRecord();
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
            if (e.Row.Index < this.CurrentRecord.Notifications.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    VarNameChangeNotificationRecord record = CurrentRecord.Notifications[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Notifications.RemoveAt(e.Row.Index);
                    DBAction.DeleteRecord(record);
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
            if (SaveRecord() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveFirst();
        }

        #endregion
        #endregion

        #region Methods


        private void LoadRecords(List<VarNameChangeRecord> records)
        {
            Records = new BindingList<VarNameChangeRecord>( records);
            bs.DataSource = Records;
            bindingNavigator1.BindingSource = bs;

            panelMain.Visible = true;
        }

        private void RefreshCurrentRecord()
        {
            CurrentRecord = (VarNameChangeRecord)bs.Current;

            dgvSurveys.SetVirtualGridRows(CurrentRecord.SurveysAffected.Count()+1);
            dgvNotifications.SetVirtualGridRows(CurrentRecord.Notifications.Count()+1);
        }

        private void FillBoxes()
        {
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.SelectedItem = null;
            cboSurvey.SelectedIndexChanged += cboSurvey_SelectedIndexChanged;

            cboChangedBy.DataSource = new List<Person>(Globals.AllPeople);
            cboChangedBy.DisplayMember = "Name";
            cboChangedBy.ValueMember = "ID";

            dgvSurveys.AutoGenerateColumns = false;
            chSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            chSurvey.DisplayMember = "SurveyCode";
            chSurvey.ValueMember = "SID";

            dgvNotifications.AutoGenerateColumns = false;
            chNotifyName.DataSource = new List<Person>(Globals.AllPeople);
            chNotifyName.DisplayMember = "Name";
            chNotifyName.ValueMember = "ID";

            chNotifyType.DataSource = new List<string>() { "Auto-email", "Personal email", "Mentioned in meeting", "Personal conversation" };
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "ID");
            txtOldName.DataBindings.Add("Text", bs, "OldName");
            txtNewName.DataBindings.Add("Text", bs, "NewName");
            dtpChangeDate.DataBindings.Add("Value", bs, "ChangeDate", true);
            cboChangedBy.DataBindings.Add("SelectedItem", bs, "ChangedBy");
            txtAuthorization.DataBindings.Add("Text", bs, "Authorization");
            txtRationale.DataBindings.Add("Text", bs, "Rationale");
            txtSource.DataBindings.Add("Text", bs, "Source");
            chkPreFWS.DataBindings.Add("Checked", bs, "PreFWChange");
            chkHiddenChange.DataBindings.Add("Checked", bs, "HiddenChange");

            chSurvey.DataPropertyName = "SurvID";
            chNotifyName.DataPropertyName = "PersonID";
            chNotifyType.DataPropertyName = "NotifyType";
        }

        private int SaveRecord()
        {
            if (CurrentRecord == null)
                return 0;

            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return 1;
            }

            lblNewID.Visible = false;
            return 0;
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
                DBAction.DeleteRecord(CurrentRecord);
                bs.RemoveCurrent();
            }
        }

        private void EmailRecord()
        {
            if (SaveRecord() == 1)
                return;

            Microsoft.Office.Interop.Outlook.Application app = new
                          Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem item = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            item.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

            List<string> recipients = new List<string>();

            foreach (VarNameChangeNotificationRecord notify in CurrentRecord.Notifications)
            {
                Person person = Globals.AllPeople.Where(x => x.ID == notify.PersonID).FirstOrDefault();
                if (person != null && !string.IsNullOrEmpty(person.Email))
                    recipients.Add(person.Email);
            }

            item.To = string.Join(";", recipients);
            item.Recipients.ResolveAll();
            item.Subject = CurrentRecord.OldName + " Renamed: " + CurrentRecord.NewName;
            item.Body = "Country: " + CurrentRecord.GetSurveysAffected() + "\r\n" + "VarName: " + CurrentRecord.OldName + " has been renamed to " + CurrentRecord.NewName + "\r\n" +
                "Date: " + CurrentRecord.ChangeDate.ToString("d") + "\r\n" + "Effective as of next release.\r\nRationale: " + CurrentRecord.Rationale;
            item.Display();
        }

        private void LoadHistory()
        {

        }
        #endregion
    }
}
