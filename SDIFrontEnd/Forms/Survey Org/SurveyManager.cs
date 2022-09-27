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
    // TODO saving locked survey changes
    public partial class SurveyManager : Form
    {
        BindingList<SurveyRecord> SurveyList;
        List<StudyWaveRecord> WaveList;
        List<int> LockedSurveys;
        SurveyRecord CurrentRecord;

        List<Language> LanguageList;
        List<UserStateRecord> UserStateList;
        List<ScreenedProduct> ScreenedProductList;

        BindingSource bs;
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

            this.MouseWheel += SurveyManager_MouseWheel;
            cboWaveID.MouseWheel += ComboBox_MouseWheel;
            cboSurveyType.MouseWheel += ComboBox_MouseWheel;
            cboMode.MouseWheel += ComboBox_MouseWheel;

            FillLists();

            SetupBindingSources();

            FillBoxes();

            SetupGrids();

            BindProperties();
            
            RefreshCurrentRecord();

        }

        #region Menu bars
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentRecord.SaveRecord();
            Close();
            FormManager.Remove(this);
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SurveyList frm = new SurveyList(new List<SurveyRecord>(SurveyList));
            frm.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSurvey();
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            GoToSurvey(((Survey)toolStripGoTo.SelectedItem).SID);
        }

        private void toolbuttonWaves_Click(object sender, EventArgs e)
        {
            WaveManager frm = new WaveManager(CurrentRecord.WaveID);
            frm.Show();
        }
        #endregion

        #region Events

        private void SurveyManager_Load(object sender, EventArgs e)
        {
            txtSurveyCode.Focus();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

            if (LockedSurveys.Contains(CurrentRecord.SID))
            {
                MessageBox.Show("Cannot delete locked surveys.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this survey? (All questions, comments and translations will also be deleted for this survey)?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAction.DeleteSurvey(CurrentRecord);
                bs.RemoveCurrent();
                RefreshCurrentRecord();
            }
           
        }



        private void chkLocked_Click(object sender, EventArgs e)
        {
            // we click on unlock, 
            // if a survey is locked already, that means it is part of the AutoLock table
            // unlock it for 1 hour

            if (chkLocked.Checked)
            {
                LockSurvey();

                ToggleLocks(true);

            }
            else
            {
                if (CurrentRecord.Locked)
                {
                    DBAction.UnlockSurvey(CurrentRecord, 60 * 60000);
                }

                ToggleLocks(false);
            }

            
            
            
            

        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void SurveyManager_MouseWheel(object sender, MouseEventArgs e)
        {
            if (CurrentRecord.SaveRecord()==1)
            {
                MessageBox.Show("Error saving record.");
               // return;
            }

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
            {
                MoveRecord(-1);
            }
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentRecord();

        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (e.PropertyDescriptor == null) return;

            CurrentRecord.Dirty = true;
        }

        private void cmdAddWave_Click(object sender, EventArgs e)
        {
            NewWaveEntry frm = new NewWaveEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                WaveList.Add(frm.NewWave);
                cboWaveID.DataSource = null;
                cboWaveID.DataSource = WaveList;
                cboWaveID.SelectedValue = frm.NewWave.ID;
            }
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

        /// <summary>
        /// Get all items needed from the database.
        /// </summary>
        private void FillLists()
        {
            SurveyList = new BindingList<SurveyRecord>(Globals.AllSurveys);
            WaveList = Globals.AllWaves;
            LockedSurveys = DBAction.GetLockedSurveys();
            UserStateList = Globals.AllUserStates;
            ScreenedProductList = DBAction.GetScreenProducts();
            LanguageList = DBAction.ListLanguages();
        }

        /// <summary>
        /// Instantiate binding sources and set their data sources.
        /// </summary>
        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bsLanguages = new BindingSource();
            bsUserStates = new BindingSource();
            bsScreenedProducts = new BindingSource();

            bs.DataSource = SurveyList;

            bsLanguages.DataSource = bs;
            bsLanguages.DataMember = "LanguageList";

            bsUserStates.DataSource = bs;
            bsUserStates.DataMember = "UserStates";

            bsScreenedProducts.DataSource = bs;
            bsScreenedProducts.DataMember = "ScreenedProducts";

            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += Bs_ListChanged;
        }

        /// <summary>
        /// Bind controls to their respective properties.
        /// </summary>
        private void BindProperties()
        {
            // survey info
            txtID.DataBindings.Add(new Binding("Text", bs, "SID"));
            txtSurveyCode.DataBindings.Add("Text", bs, "SurveyCode");
            txtSurveyTitle.DataBindings.Add("Text", bs, "Title");

            cboMode.DataBindings.Add("SelectedValue", bs, "Mode.ID");

            cboSurveyType.DataBindings.Add("SelectedValue", bs, "Cohort.ID");

            txtFileName.DataBindings.Add("Text", bs, "WebName");

            Binding b = new Binding("Value", bs, "CreationDate", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpCreationDate.DataBindings.Add(b);
            b.Format += new ConvertEventHandler(dtp_Format);
            b.Parse += new ConvertEventHandler(dtp_Parse);
  
            chkNCT.DataBindings.Add("Checked", bs, "NCT");
            
            chkHideSurvey.DataBindings.Add("Checked", bs, "HideSurvey");
            chkLocked.DataBindings.Add("Checked", bs, "Locked");
            chkITCSurvey.DataBindings.Add("Checked", bs, "ITCSurvey");
          
            // study info
            cboWaveID.DataBindings.Add("SelectedValue", bs, "WaveID");
            
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
            toolStripGoTo.ComboBox.DataSource = new List<Survey>(SurveyList);
            toolStripGoTo.ComboBox.ValueMember = "SID";
            toolStripGoTo.ComboBox.DisplayMember = "SurveyCode";

            cboWaveID.DisplayMember = "WaveCode";
            cboWaveID.ValueMember = "ID";
            cboWaveID.DataSource = new List<StudyWaveRecord>(WaveList);

            cboMode.DataSource = DBAction.GetModeInfo();
            cboMode.DisplayMember = "ModeAbbrev";
            cboMode.ValueMember = "ID";

            cboSurveyType.DataSource = DBAction.GetCohortInfo();
            cboSurveyType.DisplayMember = "Cohort";
            cboSurveyType.ValueMember = "ID";
        }
        #endregion


        #region Language datagridview

        private void dgvLanguages_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newLanguageRow = true;

        }

        private void dgvLanguages_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["chSurvIDLang"].Value = CurrentRecord.SID;
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
                DBAction.DeleteSurveyLanguage(newLanguage);

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
            e.Row.Cells["chSurvIDState"].Value = CurrentRecord.SID;
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
                DBAction.DeleteSurveyUserState(state);

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
            e.Row.Cells["chSurvIDProduct"].Value = CurrentRecord.SID;
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
                DBAction.DeleteSurveyScreenedProduct(product);

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
        private void RefreshCurrentRecord()
        {
            CurrentRecord = (SurveyRecord)bs.Current;
            ToggleLocks(CurrentRecord.Locked);
        }

        /// <summary>
        /// Set the lock property of the current record if it is part of the locked surveys list.
        /// </summary>
        private void LockSurvey()
        {
            if (!CurrentRecord.Locked && LockedSurveys.Contains(CurrentRecord.SID))
            {
                if (DBAction.LockSurvey(CurrentRecord) == 0)
                    CurrentRecord.Locked = true;
            }
        }

        /// <summary>
        /// Set the readonly/enabled property of each control.
        /// </summary>
        /// <param name="lockFlag">True if controls are to be readonly/disabled.</param>
        private void ToggleLocks(bool lockFlag)
        {
            txtID.ReadOnly = true;
            txtSurveyCode.ReadOnly = lockFlag;
            cboWaveID.Enabled = !lockFlag;
            txtSurveyTitle.ReadOnly = lockFlag;
            cboSurveyType.Enabled = !lockFlag;
            cboMode.Enabled = !lockFlag;
            dtpCreationDate.Enabled = !lockFlag;
            txtFileName.ReadOnly = lockFlag;
            chkHideSurvey.Enabled = !lockFlag;
            chkITCSurvey.Enabled = !lockFlag;
            chkNCT.Enabled = !lockFlag;

            dgvLanguages.ReadOnly = lockFlag;
            dgvUserStates.ReadOnly = lockFlag;
            dgvScreenedProducts.ReadOnly = lockFlag;

            if (lockFlag)
                chkLocked.Text = "Locked";
            else
                chkLocked.Text = "Unlocked";
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
                GoToSurvey(frm.NewSurvey.SID);
            }

            
        }

        /// <summary>
        /// Navigate the bindingsource to the specified survey ID.
        /// </summary>
        /// <param name="survid"></param>
        private void GoToSurvey(int survid)
        {
            for (int i = 0; i < SurveyList.Count(); i++)
            {
                if (SurveyList[i].SID == survid)
                {
                    bs.Position = i;
                    return;
                }
            }
        }

        
    }
}
