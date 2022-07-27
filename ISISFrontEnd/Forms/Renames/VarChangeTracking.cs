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
    public partial class VarChangeTracking : Form
    {
        // TODO history
        // TODO indicate deleted var
        // TODO toggle hidden/prefws
        // TODO undo change

        BindingList<VarNameChangeRecord> Records;
        VarNameChangeRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsNotify;
        BindingSource bsSurveys;

        bool SaveAll = false; // indicates if all records should be saved when closing

        public VarChangeTracking()
        {
            InitializeComponent();

            FillBoxes();

            bs = new BindingSource();
            Records = new BindingList<VarNameChangeRecord>();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += Bs_ListChanged;
            bsNotify = new BindingSource();
            bsNotify.DataSource = bs;
            bsNotify.DataMember = "Notifications";

            bsSurveys = new BindingSource();
            bsSurveys.DataSource = bs;
            bsSurveys.DataMember = "SurveysAffected";

            this.MouseWheel += VarChangeTracking_MouseWheel;

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
            CurrentRecord = (VarNameChangeRecord)bs.Current;
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
            LoadRecords(DBAction.GetVarNameChangeBySurvey(selected.SurveyCode));
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
            FormManager.Remove(this);
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

        private void dgvSurveys_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VarNameChangeSurveyRecord record = (VarNameChangeSurveyRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvSurveys_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VarNameChangeSurveyRecord record = (VarNameChangeSurveyRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (record == null)
                return;
            if (record.NewRecord)
            {
                record.ChangeID = CurrentRecord.ID;
            }

            record.SurvID = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
            record.SurveyCode = (string)dgv.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
            record.SaveRecord();
        }

        private void dgvSurveys_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VarNameChangeSurveyRecord record = (VarNameChangeSurveyRecord)e.Row.DataBoundItem;
                DBAction.DeleteVarNameChangeSurvey(record.ID);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvSurveys_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Notifications Grid

        private void dgvNotifications_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VarNameChangeNotificationRecord record = (VarNameChangeNotificationRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvNotifications_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VarNameChangeNotificationRecord record = (VarNameChangeNotificationRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (record == null)
                return;
            if (record.NewRecord)
            {
                record.ChangeID = CurrentRecord.ID;
            }

            record.PersonID = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
            record.Name = (string)dgv.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
            record.SaveRecord();
        }

        private void dgvNotifications_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VarNameChangeNotificationRecord record = (VarNameChangeNotificationRecord)e.Row.DataBoundItem;
                DBAction.DeleteVarNameChangeNotification(record.ID);

            }
            else
            {
                e.Cancel = true;
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

            dgvNotifications.DataSource = bsNotify;
            dgvSurveys.DataSource = bsSurveys;

            panelMain.Visible = true;
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
                DBAction.DeleteVarNameChange(CurrentRecord.ID);
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
