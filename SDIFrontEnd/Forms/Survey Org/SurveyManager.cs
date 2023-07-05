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
    // TODO saving locked survey changes
    public partial class SurveyManager : Form
    {
        List<SurveyRecord> Records;
        List<StudyWave> WaveList;
        List<int> LockedSurveys;
        SurveyRecord CurrentRecord;

        List<Language> LanguageList;
        List<UserStateRecord> UserStateList;
        List<ScreenedProduct> ScreenedProductList;

        BindingSource bs;
        BindingSource bsCurrent;
        BindingSource bsLanguages;
        BindingSource bsUserStates;
        BindingSource bsScreenedProducts;

        bool newLanguageRow = false;
        bool newUserStateRow = false;
        bool newScreenedProductRow = false;

        bool editedLanguageRow = false;
        bool editedUserStateRow = false;
        bool editedScreenedProductRow = false;

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
            {
                MoveRecord(-1);
            }
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
                Survey modifiedRegion = (Survey)bsCurrent[e.NewIndex];
                SurveyRecord modifiedRecord = Records.Where(x => x.Item == modifiedRegion).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    case "LanguageList":
                    case "ScreenedProducts":
                    case "UserStates":
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
            UserStateList = new List<UserStateRecord>(Globals.AllUserStates);
            ScreenedProductList = DBAction.GetScreenProducts();
            LanguageList = DBAction.ListLanguages();
        }

        /// <summary>
        /// Instantiate binding sources and set their data sources.
        /// </summary>
        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bsCurrent = new BindingSource();
            bsLanguages = new BindingSource();
            bsUserStates = new BindingSource();
            bsScreenedProducts = new BindingSource();

            bs.DataSource = Records;

            bsCurrent.DataSource = bs;
            bsCurrent.DataMember = "Item";

            bsLanguages.DataSource = bsCurrent;
            bsLanguages.DataMember = "LanguageList";

            bsUserStates.DataSource = bsCurrent;
            bsUserStates.DataMember = "UserStates";

            bsScreenedProducts.DataSource = bsCurrent;
            bsScreenedProducts.DataMember = "ScreenedProducts";

            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += Bs_PositionChanged;
            bsCurrent.ListChanged += BsCurrent_ListChanged;
        }

        /// <summary>
        /// Bind controls to their respective properties.
        /// </summary>
        private void BindProperties()
        {
            txtID.DataBindings.Add(new Binding("Text", bsCurrent, "SID"));
            txtSurveyCode.DataBindings.Add("Text", bsCurrent, "SurveyCode");
            txtSurveyTitle.DataBindings.Add("Text", bsCurrent, "Title");

            cboMode.DataBindings.Add("SelectedItem", bsCurrent, "Mode");

            cboSurveyType.DataBindings.Add("SelectedItem", bsCurrent, "Cohort");

            txtFileName.DataBindings.Add("Text", bsCurrent, "WebName");

            Binding b = new Binding("Value", bsCurrent, "CreationDate", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpCreationDate.DataBindings.Add(b);
            b.Format += new ConvertEventHandler(dtp_Format);
            b.Parse += new ConvertEventHandler(dtp_Parse);
  
            chkNCT.DataBindings.Add("Checked", bsCurrent, "NCT");
            
            chkHideSurvey.DataBindings.Add("Checked", bsCurrent, "HideSurvey");
            chkLocked.DataBindings.Add("Checked", bsCurrent, "Locked");
            chkITCSurvey.DataBindings.Add("Checked", bsCurrent, "ITCSurvey");
          
            // study info
            cboWaveID.DataBindings.Add("SelectedValue", bsCurrent, "WaveID");
            
        }

        /// <summary>
        /// Bind grid columns to their respective properties and set the data grid view datasources.
        /// </summary>
        private void SetupGrids()
        {
            // languages grid
            chSurvIDLang.DataPropertyName = "SurvID";

            chLangID.DataSource = LanguageList;
            chLangID.DisplayMember = "LanguageName";
            chLangID.ValueMember = "ID";
            chLangID.DataPropertyName = "SurvLanguage";
            chLangID.ValueType = typeof(Language);

            dgvLanguages.AutoGenerateColumns = false;
            dgvLanguages.DataSource = bsLanguages;

            // user states grid
            chSurvIDState.DataPropertyName = "SurvID";

            chUserStateID.DataSource = UserStateList;
            chUserStateID.DisplayMember = "UserStateName";
            chUserStateID.ValueMember = "ID";
            chUserStateID.DataPropertyName = "State";

            dgvUserStates.AutoGenerateColumns = false;
            dgvUserStates.DataSource = bsUserStates;

            // screened products grid
            chSurvIDProduct.DataPropertyName = "SurvID";

            chProductID.DataSource = ScreenedProductList;
            chProductID.DisplayMember = "ProductName";
            chProductID.ValueMember = "ID";
            chProductID.DataPropertyName = "Product";

            dgvScreenedProducts.AutoGenerateColumns = false;
            dgvScreenedProducts.DataSource = bsScreenedProducts;
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


        #region Language datagridview

        private void dgvLanguages_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newLanguageRow = true;
        }

        private void dgvLanguages_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["chSurvIDLang"].Value = CurrentRecord.Item.SID;
        }

        private void dgvLanguages_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvLanguages.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the Language column.
            if (!headerText.Equals("Language")) return;


            dgvLanguages.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = LanguageList.FirstOrDefault(x => x.LanguageName.Equals(e.FormattedValue.ToString()));
        }

        private void dgvLanguages_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SurveyLanguage newLanguage;

            try
            {
                newLanguage = (SurveyLanguage)dgvLanguages.Rows[e.RowIndex].DataBoundItem;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

            if (!newLanguageRow && editedLanguageRow)
            {
                // update language
                if (DBAction.UpdateSurveyLanguage(newLanguage) == 1)
                    MessageBox.Show("Error updating language.");
                editedLanguageRow = false;
            }
            else if (newLanguageRow)
            {

                // insert language
                if (DBAction.InsertSurveyLanguage(newLanguage) == 1)
                    MessageBox.Show("Error adding new language.");
                newLanguageRow = false;
            }
        }


        private void dgvLanguages_RowLeave(object sender, DataGridViewCellEventArgs e)
        { 
            if (!dgvLanguages.IsCurrentRowDirty)
                return;

            SurveyLanguage newLanguage = (SurveyLanguage)dgvLanguages.Rows[e.RowIndex].DataBoundItem;
            if (newLanguage == null)
                return;

            editedLanguageRow = newLanguage.ID > 0;
        }

        private void dgvLanguages_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected language?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SurveyLanguage newLanguage = (SurveyLanguage)e.Row.DataBoundItem;

                DBAction.DeleteRecord(newLanguage);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvLanguages_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

        #region User States datagridview
        private void dgvUserStates_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newUserStateRow = true;
        }

        private void dgvUserStates_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["chSurvIDState"].Value = CurrentRecord.Item.SID;
        }

        private void dgvUserStates_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvUserStates.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the Language column.
            if (!headerText.Equals("User State")) return;

            var value = UserStateList.FirstOrDefault(x => x.UserStateName.Equals(e.FormattedValue.ToString()));

            if (value == null)
                return;

            dgvUserStates.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
        }

        private void dgvUserStates_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvUserStates.IsCurrentRowDirty)
                return;

            SurveyUserState newState = (SurveyUserState)dgvUserStates.Rows[e.RowIndex].DataBoundItem;
            if (newState == null)
                return;

            editedUserStateRow = newState.ID > 0;
        }

        private void dgvUserStates_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SurveyUserState newState;

            try
            {
                newState = (SurveyUserState)dgvUserStates.Rows[e.RowIndex].DataBoundItem;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

            if (!newUserStateRow && editedUserStateRow)
            {
                // update language
                if (DBAction.UpdateSurveyUserState(newState) == 1)
                    MessageBox.Show("Error updating user state.");
            }
            else if (newUserStateRow)
            {
                // insert language
                if (DBAction.InsertSurveyUserState(newState) == 1)
                    MessageBox.Show("Error adding new user state.");
            }
        }


        private void dgvUserStates_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected user state?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SurveyUserState state = (SurveyUserState)e.Row.DataBoundItem;
                DBAction.DeleteRecord(state);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvUserStates_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Screened Products datagridview

        private void dgvScreenedProducts_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newScreenedProductRow = true;
        }

        private void dgvScreenedProducts_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["chSurvIDProduct"].Value = CurrentRecord.Item.SID;
        }

        private void dgvScreenedProducts_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvScreenedProducts.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the Product column.
            if (!headerText.Equals("Product")) return;

            dgvScreenedProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ScreenedProductList.FirstOrDefault(x => x.ProductName.Equals(e.FormattedValue.ToString()));
        }

        private void dgvScreenedProducts_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SurveyScreenedProduct newProduct;
            try
            {
                newProduct = (SurveyScreenedProduct)dgvScreenedProducts.Rows[e.RowIndex].DataBoundItem;
            }catch(IndexOutOfRangeException)
            {
                return;
            }

            if (!newScreenedProductRow && editedScreenedProductRow)
            {
                // update screened product
                if (DBAction.UpdateSurveyScreenedProduct(newProduct) == 1)
                    MessageBox.Show("Error updating survey product.");
            }
            else if (newScreenedProductRow)
            {

                // insert screened product
                if (DBAction.InsertSurveyScreenedProduct(newProduct) == 1)
                    MessageBox.Show("Error adding new survey product.");
            }
        }

        private void dgvScreenedProducts_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvScreenedProducts.IsCurrentRowDirty)
                return;

            SurveyScreenedProduct newProduct = (SurveyScreenedProduct)dgvScreenedProducts.Rows[e.RowIndex].DataBoundItem;
            if (newProduct == null)
                return;

            editedScreenedProductRow = newProduct.ID > 0;
        }

        private void dgvScreenedProducts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected screend product?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SurveyScreenedProduct product = (SurveyScreenedProduct)e.Row.DataBoundItem;
                DBAction.DeleteRecord(product);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvScreenedProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }
        #endregion

        #region Navigation Bar events
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this survey.");
                //return;
            }

            LockSurvey();

            MoveRecord(1);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this survey.");
                //return;
            }

            LockSurvey();

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this survey.");
                //return;
            }

            LockSurvey();

            bs.MoveLast();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this survey.");
               // return;
            }

            LockSurvey();

            bs.MoveFirst();
        }
        #endregion

        /// <summary>
        /// Update the Current Record and lock the form if necessary.
        /// </summary>
        private void UpdateCurrentRecord()
        {
            CurrentRecord = (SurveyRecord)bs.Current;
            ToggleLocks(CurrentRecord.Item.Locked);
        }

        private void SaveRecord()
        {
            bsCurrent.EndEdit();

            bool newRec = CurrentRecord.NewRecord;
            int updated = CurrentRecord.SaveRecord();

            if (updated == 0)
            {
                //lblStatus.Text = "";
                CurrentRecord.Dirty = false;

                if (newRec)
                    Globals.AllSurveys.Add(CurrentRecord.Item);
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
                    DBAction.UnlockSurvey(CurrentRecord.Item, 60 * 60000);
                }
                ToggleLocks(false);
            }
        }
    }
}
