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
    public partial class SurveyManager : Form
    {
        List<SurveyRecord> Records;
        List<StudyWave> WaveList;
        List<int> LockedSurveys;
        SurveyRecord CurrentRecord;

        List<Language> LanguageList;
        List<UserState> UserStateList;
        List<ScreenedProduct> ScreenedProductList;

        BindingSource bs;
        BindingSource bsCurrent;

        bool rowCommit = true;
        int langRow = -1;
        SurveyLanguage editedLanguage;

        int stateRow = -1;
        SurveyUserState editedState;

        int productRow = -1;
        SurveyScreenedProduct editedProduct;

        public SurveyManager()
        {
            InitializeComponent();

            SetupMouseWheel();

            FillLists();

            SetupBindingSources();

            FillBoxes();

            SetupGrids();

            BindProperties();
            
            UpdateCurrentRecord();

        }

        #region Form Setup

        private void SetupMouseWheel()
        {
            this.MouseWheel += SurveyManager_MouseWheel;
            cboWaveID.MouseWheel += ComboBox_MouseWheel;
            cboSurveyType.MouseWheel += ComboBox_MouseWheel;
            cboMode.MouseWheel += ComboBox_MouseWheel;
        }

        /// <summary>
        /// Get all items needed from the database.
        /// </summary>
        private void FillLists()
        {
            Records = new List<SurveyRecord>();
            foreach (Survey survey in Globals.AllSurveys)
            {
                Records.Add(new SurveyRecord(survey));
            }

            WaveList = new List<StudyWave>(Globals.AllWaves);
            LockedSurveys = DBAction.GetLockedSurveys();
            UserStateList = new List<UserState>(Globals.AllUserStates);
            ScreenedProductList = DBAction.GetScreenProducts();
            LanguageList = new List<Language>(Globals.AllLanguages);
        }

        /// <summary>
        /// Instantiate binding sources and set their data sources.
        /// </summary>
        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource();
            bsCurrent.DataSource = bs;
            bsCurrent.DataMember = "Item";
            bsCurrent.ListChanged += BsCurrent_ListChanged;

            bindingNavigator1.BindingSource = bs;
        }

        /// <summary>
        /// Bind controls to their respective properties.
        /// </summary>
        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bsCurrent, "SID");
            txtSurveyCode.DataBindings.Add("Text", bsCurrent, "SurveyCode");
            txtSurveyTitle.DataBindings.Add("Text", bsCurrent, "Title");

            cboMode.DataBindings.Add("SelectedItem", bsCurrent, "Mode");

            cboSurveyType.DataBindings.Add("SelectedItem", bsCurrent, "Cohort");

            txtFileName.DataBindings.Add("Text", bsCurrent, "WebName");

            Binding b = new Binding("Value", bsCurrent, "CreationDate", true, DataSourceUpdateMode.OnPropertyChanged);
            b.Format += new ConvertEventHandler(dtp_Format);
            b.Parse += new ConvertEventHandler(dtp_Parse);

            dtpCreationDate.DataBindings.Add(b);
            
  
            chkNCT.DataBindings.Add("Checked", bsCurrent, "NCT");
            
            chkHideSurvey.DataBindings.Add("Checked", bsCurrent, "HideSurvey");
            chkLocked.DataBindings.Add("Checked", bsCurrent, "Locked");
            chkITCSurvey.DataBindings.Add("Checked", bsCurrent, "ITCSurvey");
          
            // study info
            cboWaveID.DataBindings.Add("SelectedValue", bsCurrent, "WaveID");
            
        }

        /// <summary>
        /// Add event handlers to grids.
        /// </summary>
        private void SetupGrids()
        {
            dgvLanguages.AutoGenerateColumns = false;

            chLangID.DataSource = LanguageList;
            chLangID.DisplayMember = "LanguageName";
            chLangID.ValueMember = "ID";

            dgvLanguages.CellValueNeeded += dgvLanguages_CellValueNeeded;
            dgvLanguages.NewRowNeeded += dgvLanguages_NewRowNeeded;
            dgvLanguages.CellValuePushed += dgvLanguages_CellValuePushed;
            dgvLanguages.RowValidated += dgvLanguages_RowValidated;
            dgvLanguages.RowDirtyStateNeeded += dgvLanguages_RowDirtyStateNeeded;
            dgvLanguages.CancelRowEdit += dgvLanguages_CancelRowEdit;
            dgvLanguages.UserDeletingRow += dgvLanguages_UserDeletingRow;
            dgvLanguages.DataError += dgvLanguages_DataError;

            dgvUserStates.AutoGenerateColumns = false;

            chUserStateID.DataSource = UserStateList;
            chUserStateID.DisplayMember = "UserStateName";
            chUserStateID.ValueMember = "ID";

            dgvUserStates.CellValueNeeded += dgvStates_CellValueNeeded;
            dgvUserStates.NewRowNeeded += dgvStates_NewRowNeeded;
            dgvUserStates.CellValuePushed += dgvStates_CellValuePushed;
            dgvUserStates.RowValidated += dgvStates_RowValidated;
            dgvUserStates.RowDirtyStateNeeded += dgvStates_RowDirtyStateNeeded;
            dgvUserStates.CancelRowEdit += dgvStates_CancelRowEdit;
            dgvUserStates.UserDeletingRow += dgvStates_UserDeletingRow;
            dgvUserStates.DataError += dgvStates_DataError;
           
            dgvScreenedProducts.AutoGenerateColumns = false;

            chProductID.DataSource = ScreenedProductList;
            chProductID.DisplayMember = "ProductName";
            chProductID.ValueMember = "ID";

            dgvScreenedProducts.CellValueNeeded += dgvProducts_CellValueNeeded;
            dgvScreenedProducts.NewRowNeeded += dgvProducts_NewRowNeeded;
            dgvScreenedProducts.CellValuePushed += dgvProducts_CellValuePushed;
            dgvScreenedProducts.RowValidated += dgvProducts_RowValidated;
            dgvScreenedProducts.RowDirtyStateNeeded += dgvProducts_RowDirtyStateNeeded;
            dgvScreenedProducts.CancelRowEdit += dgvProducts_CancelRowEdit;
            dgvScreenedProducts.UserDeletingRow += dgvProducts_UserDeletingRow;
            dgvScreenedProducts.DataError += dgvProducts_DataError;

        }

        /// <summary>
        /// Add items to combo boxes.
        /// </summary>
        private void FillBoxes()
        {
            toolStripGoTo.ComboBox.ValueMember = "SID";
            toolStripGoTo.ComboBox.DisplayMember = "SurveyCode";
            toolStripGoTo.ComboBox.DataSource = new List<Survey>(Globals.AllSurveys);
            toolStripGoTo.ComboBox.SelectedItem = null;
            toolStripGoTo.ComboBox.SelectedIndexChanged += toolStripGoTo_SelectedIndexChanged;

            cboWaveID.DisplayMember = "WaveCode";
            cboWaveID.ValueMember = "ID";
            cboWaveID.DataSource = new List<StudyWave>(WaveList);

            cboMode.DisplayMember = "ModeAbbrev";
            cboMode.ValueMember = "ID";
            cboMode.DataSource = new List<SurveyMode>(Globals.AllModes);

            cboSurveyType.DisplayMember = "Cohort";
            cboSurveyType.ValueMember = "ID";
            cboSurveyType.DataSource = new List<SurveyCohort>(Globals.AllCohorts);
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Update the Current Record and lock the form if necessary.
        /// </summary>
        private void UpdateCurrentRecord()
        {
            CurrentRecord = (SurveyRecord)bs.Current;
            
            dgvLanguages.SetVirtualGridRows(CurrentRecord.Item.LanguageList.Count + 1);
            dgvScreenedProducts.SetVirtualGridRows(CurrentRecord.Item.ScreenedProducts.Count + 1);
            dgvUserStates.SetVirtualGridRows(CurrentRecord.Item.UserStates.Count + 1);

            ToggleLocks(CurrentRecord.Item.Locked);
        }

        private void SaveRecord()
        {
            bsCurrent.EndEdit();
            txtID.Focus();

            bool newRec = CurrentRecord.NewRecord;
            int updated = CurrentRecord.SaveRecord();

            if (updated == 0)
            {
                //lblStatus.Text = "";
                CurrentRecord.Dirty = false;

                if (newRec)
                    Globals.AllSurveys.Add(CurrentRecord.Item);
            }
            else
            {
                MessageBox.Show("Unable to save record.");
            }
        }

        /// <summary>
        /// Set the lock property of the current record if it is part of the locked surveys list.
        /// </summary>
        private void LockSurvey()
        {
            if (!CurrentRecord.Item.Locked && LockedSurveys.Contains(CurrentRecord.Item.SID))
            {
                if (DBAction.LockSurvey(CurrentRecord.Item) == 0)
                    CurrentRecord.Item.Locked = true;
            }
        }

        /// <summary>
        /// Set the readonly/enabled property of each control.
        /// </summary>
        /// <param name="lockFlag">True if controls are to be readonly/disabled.</param>
        private void ToggleLocks(bool lockFlag)
        {
            txtID.ReadOnly = true;
            txtSurveyCode.Enabled = !lockFlag;
            cboWaveID.Enabled = !lockFlag;
            txtSurveyTitle.Enabled = !lockFlag;
            cboSurveyType.Enabled = !lockFlag;
            cboMode.Enabled = !lockFlag;
            dtpCreationDate.Enabled = !lockFlag;
            txtFileName.Enabled = !lockFlag;
            chkHideSurvey.Enabled = !lockFlag;
            chkITCSurvey.Enabled = !lockFlag;
            chkNCT.Enabled = !lockFlag;

            dgvLanguages.Enabled = !lockFlag;
            dgvUserStates.Enabled = !lockFlag;
            dgvScreenedProducts.Enabled = !lockFlag;

            chkLocked.Visible = lockFlag;          
        }

        /// <summary>
        /// Move through the binding source for a set number of items.
        /// </summary>
        /// <param name="count">Positive integers move forward, negative move backwards.</param>
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

        /// <summary>
        /// Open the NewSurveyEntry form in dialog mode. If the result is acceptable, add the new survey item to the bindingsource.
        /// </summary>
        private void AddSurvey()
        {
            NewSurveyEntry frm = new NewSurveyEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                bs.Add(frm.NewSurvey);
                GoToSurvey(frm.NewSurvey.Item.SID);
            }   
        }

        private void AddWave()
        {
            NewWaveEntry frm = new NewWaveEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                WaveList.Add(frm.NewWave.Item);
                cboWaveID.DataSource = null;
                cboWaveID.DataSource = WaveList;
                cboWaveID.SelectedValue = frm.NewWave.Item.ID;
            }
        }

        /// <summary>
        /// Navigate the bindingsource to the specified survey ID.
        /// </summary>
        /// <param name="survid"></param>
        private void GoToSurvey(int survid)
        {
            for (int i = 0; i < Records.Count(); i++)
            {
                if (Records[i].Item.SID == survid)
                {
                    bs.Position = i;
                    return;
                }
            }
        }

        // TODO use form manager, new instance?
        private void ViewWaves()
        {
            WaveManager frm = new WaveManager(CurrentRecord.Item.WaveID);
            frm.Show();
        }

        private void OpenListView()
        {
            SurveyList frm = new SurveyList(new List<SurveyRecord>(Records));
            frm.ShowDialog();
        }
        
        private void DeleteRecord()
        {
            if (LockedSurveys.Contains(CurrentRecord.Item.SID))
            {
                MessageBox.Show("Cannot delete locked surveys.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this survey? (All questions, comments and translations will also be deleted for this survey)?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAction.DeleteRecord(CurrentRecord);
                bs.RemoveCurrent();
                UpdateCurrentRecord();
            }
        }

        /// <summary>
        /// If a survey is locked already, that means it is part of the AutoLock table, unlock it for 1 hour
        /// </summary>
        private void UnlockSurvey()
        {
            if (chkLocked.Checked)
            {
                LockSurvey();
                ToggleLocks(true);
            }
            else
            {
                if (CurrentRecord.Item.Locked)
                {
                    DBAction.UnlockSurvey(CurrentRecord.Item.SurveyCode, 60 * 60000);
                }
                ToggleLocks(false);
            }
        }
        #endregion

        #region Events

        private void SurveyManager_Load(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void SurveyManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void chkLocked_Click(object sender, EventArgs e)
        {
            UnlockSurvey();
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void SurveyManager_MouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void BsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            // item: bs[e.NewIndex]
            // property name: e.PropertyDescriptor.Name
            if (e.PropertyDescriptor != null)
            {
                // get the paper record that was modified
                Survey modifiedSurvey = (Survey)bsCurrent[e.NewIndex];
                SurveyRecord modifiedRecord = Records.Where(x => x.Item == modifiedSurvey).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    case "LanguageList":
                    case "ScreenedProducts":
                    case "UserStates":
                    case "Locked":
                        break;
                    default:
                        modifiedRecord.Dirty = true;
                        break;
                }
                //if (CurrentRecord.Dirty)
                //lblStatus.Text = "*";
            }
        }

        private void cmdAddWave_Click(object sender, EventArgs e)
        {
            AddWave();
        }

        private void dtp_Format(object sender, ConvertEventArgs e)
        {
            // e.Value is the object value, we format it to be what we want to show up in the control 
            Binding b = sender as Binding;

            if (b == null)
                return;

            DateTimePicker dtp = (b.Control as DateTimePicker);
            if (dtp == null)
                return;

            if (e.Value == null)
            {
                // have to set e.Value to SOMETHING, since it’s coming in as NULL 
                // if i set to DateTime.Today, and that’s DIFFERENT than the control’s current  
                // value, then it triggers a CHANGE to the value, which CHECKS the box (not ok) 
                // the trick – set e.Value to whatever value the control currently has.   
                // This does NOT cause a CHANGE, and the checkbox stays OFF. 
                e.Value = dtp.Value;

                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = " ";
                dtp.ShowCheckBox = true;
                dtp.Checked = false;
            }
            else
            {
                dtp.Format = DateTimePickerFormat.Short;
                dtp.ShowCheckBox = true;
                dtp.Checked = true;
                // leave e.Value unchanged – it’s not null, so the DTP is fine with it. 
            }
        }

        private void dtp_Parse(object sender, ConvertEventArgs e)
        {
            // e.value is the formatted value coming from the control.   
            // we change it to be the value we want to stuff in the object. 
            Binding b = sender as Binding;

            if (b == null)
                return;

            DateTimePicker dtp = (b.Control as DateTimePicker);

            if (dtp == null)
                return;

            if (dtp.Checked == false)
            {
                dtp.ShowCheckBox = true;
                dtp.Checked = false;
                e.Value = new Nullable<DateTime>();
            }
            else
            {
                DateTime val = Convert.ToDateTime(e.Value);
                dtp.Format = DateTimePickerFormat.Short;
                e.Value = new Nullable<DateTime>(val);
            }
        }
        #endregion

        #region Menu bars
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            Close();
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListView();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSurvey();
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            SaveRecord();
            GoToSurvey(((Survey)toolStripGoTo.SelectedItem).SID);
        }

        private void toolbuttonWaves_Click(object sender, EventArgs e)
        {
            ViewWaves();
        }
        #endregion

        #region Language datagridview
        private void dgvLanguages_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedLanguage = new SurveyLanguage();
            this.langRow = dgv.Rows.Count - 1;
        }

        private void dgvLanguages_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.LanguageList.Count == 0) return;

            SurveyLanguage tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == langRow)
            {
                tmp = editedLanguage;
            }
            else
            {
                tmp = CurrentRecord.Item.LanguageList[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLangID":
                    e.Value = tmp.SurvLanguage;
                    break;
            }
        }

        private void dgvLanguages_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SurveyLanguage tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.LanguageList.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedLanguage == null)
                    editedLanguage = new SurveyLanguage()
                    {
                        ID = CurrentRecord.Item.LanguageList[e.RowIndex].ID,
                        SurvLanguage = CurrentRecord.Item.LanguageList[e.RowIndex].SurvLanguage,
                        SurvID = CurrentRecord.Item.LanguageList[e.RowIndex].SurvID,
                    };

                tmp = this.editedLanguage;
                this.langRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedLanguage;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLangID":
                    SurveyLanguage newValue = new SurveyLanguage();

                    tmp.ID = newValue.ID;
                    tmp.SurvID = CurrentRecord.Item.SID;
                    tmp.SurvLanguage = LanguageList.FirstOrDefault(x => x.ID == (int)e.Value);
                    break;

            }
        }

        private void dgvLanguages_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedLanguage != null && e.RowIndex >= CurrentRecord.Item.LanguageList.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.LanguageList.Add(editedLanguage);
                CurrentRecord.AddLanguages.Add(editedLanguage);

                editedLanguage = null;
                langRow = -1;
            }
            else if (editedLanguage != null && e.RowIndex < CurrentRecord.Item.LanguageList.Count)
            {
                // ignore edits
                editedLanguage = null;
                langRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedLanguage = null;
                langRow = -1;
            }
        }

        private void dgvLanguages_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvLanguages_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (langRow == dgv.Rows.Count - 2 && langRow == CurrentRecord.Item.LanguageList.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedLanguage = new SurveyLanguage();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedLanguage = null;
                langRow = -1;
            }
        }

        private void dgvLanguages_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.LanguageList.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SurveyLanguage record = CurrentRecord.Item.LanguageList[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.LanguageList.RemoveAt(e.Row.Index);
                    CurrentRecord.DeleteLanguages.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.langRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.langRow = -1;
                this.editedLanguage = null;
            }
        }

        private void dgvLanguages_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

        #region User States datagridview
        private void dgvStates_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedState = new SurveyUserState();
            this.stateRow = dgv.Rows.Count - 1;
        }

        private void dgvStates_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.UserStates.Count == 0) return;

            SurveyUserState tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == stateRow)
            {
                tmp = editedState;
            }
            else
            {
                tmp = CurrentRecord.Item.UserStates[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chUserStateID":
                    e.Value = tmp.State;
                    break;
            }
        }

        private void dgvStates_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SurveyUserState tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.UserStates.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedState == null)
                    editedState = new SurveyUserState()
                    {
                        ID = CurrentRecord.Item.UserStates[e.RowIndex].ID,
                        State = CurrentRecord.Item.UserStates[e.RowIndex].State,
                        SurvID = CurrentRecord.Item.UserStates[e.RowIndex].SurvID,
                    };

                tmp = this.editedState;
                this.stateRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedState;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chUserStateID":
                    SurveyUserState newValue = new SurveyUserState();
                    tmp.ID = newValue.ID;
                    tmp.SurvID = CurrentRecord.Item.SID;
                    tmp.State = UserStateList.FirstOrDefault(x => x.ID == (int)e.Value);
                    break;

            }
        }

        private void dgvStates_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedState != null && e.RowIndex >= CurrentRecord.Item.UserStates.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.UserStates.Add(editedState);
                CurrentRecord.AddStates.Add(editedState);

                editedState = null;
                stateRow = -1;
            }
            else if (editedState != null && e.RowIndex < CurrentRecord.Item.UserStates.Count)
            {
                // ignore edits
                editedState = null;
                stateRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedState = null;
                stateRow = -1;
            }
        }

        private void dgvStates_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvStates_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (stateRow == dgv.Rows.Count - 2 && stateRow == CurrentRecord.Item.UserStates.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedState = new SurveyUserState();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedState = null;
                stateRow = -1;
            }
        }

        private void dgvStates_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.UserStates.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SurveyUserState record = CurrentRecord.Item.UserStates[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.UserStates.RemoveAt(e.Row.Index);
                    CurrentRecord.DeleteStates.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.stateRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.stateRow = -1;
                this.editedState = null;
            }
        }

        private void dgvStates_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Screened Products datagridview

        private void dgvProducts_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedProduct = new SurveyScreenedProduct();
            this.productRow = dgv.Rows.Count - 1;
        }

        private void dgvProducts_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.ScreenedProducts.Count == 0) return;

            SurveyScreenedProduct tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == productRow)
            {
                tmp = editedProduct;
            }
            else
            {
                tmp = CurrentRecord.Item.ScreenedProducts[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chProductID":
                    e.Value = tmp.Product;
                    break;
            }
        }

        private void dgvProducts_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SurveyScreenedProduct tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.ScreenedProducts.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedProduct == null)
                    editedProduct = new SurveyScreenedProduct()
                    {
                        ID = CurrentRecord.Item.ScreenedProducts[e.RowIndex].ID,
                        Product = CurrentRecord.Item.ScreenedProducts[e.RowIndex].Product,
                        SurvID = CurrentRecord.Item.ScreenedProducts[e.RowIndex].SurvID,
                    };

                tmp = this.editedProduct;
                this.productRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedProduct;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chProductID":
                    SurveyScreenedProduct newValue = new SurveyScreenedProduct();
                    tmp.ID = newValue.ID;
                    tmp.SurvID = CurrentRecord.Item.SID;
                    tmp.Product = ScreenedProductList.FirstOrDefault(x => x.ID == (int)e.Value);
                    break;

            }
        }

        private void dgvProducts_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedProduct != null && e.RowIndex >= CurrentRecord.Item.ScreenedProducts.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.ScreenedProducts.Add(editedProduct);
                CurrentRecord.AddProducts.Add(editedProduct);

                editedProduct = null;
                productRow = -1;
            }
            else if (editedProduct != null && e.RowIndex < CurrentRecord.Item.ScreenedProducts.Count)
            {
                // ignore edits
                editedProduct = null;
                productRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedProduct = null;
                productRow = -1;
            }
        }

        private void dgvProducts_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvProducts_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (productRow == dgv.Rows.Count - 2 && productRow == CurrentRecord.Item.ScreenedProducts.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedProduct = new SurveyScreenedProduct();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedProduct = null;
                productRow = -1;
            }
        }

        private void dgvProducts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.ScreenedProducts.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SurveyScreenedProduct record = CurrentRecord.Item.ScreenedProducts[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.ScreenedProducts.RemoveAt(e.Row.Index);
                    CurrentRecord.DeleteProducts.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.productRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.productRow = -1;
                this.editedProduct = null;
            }
        }

        private void dgvProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Navigation Bar events
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            LockSurvey();

            MoveRecord(1);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            LockSurvey();

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            LockSurvey();

            bs.MoveLast();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            LockSurvey();

            bs.MoveFirst();
        }
        #endregion

    }
}
