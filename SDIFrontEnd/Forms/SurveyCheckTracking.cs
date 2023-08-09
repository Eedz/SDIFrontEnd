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
    public partial class SurveyCheckTracking : Form
    {
        protected BindingSource bs;
        protected bool NewRecord = false;
        protected bool Dirty = false;
        protected bool Moving = false;

        public Form frmParent;
        public string key;

        List<SurveyCheckRec> SurveyCheckRecords;
        List<SurveyCheckRec> Filtered;
        SurveyCheckRec CurrentRecord;

        public SurveyCheckTracking()
        {
            InitializeComponent();

            // get the records
            SurveyCheckRecords = DBAction.GetSurveyCheckRecords();
            // setup binding source
            bs = new BindingSource()
            {
                DataSource = SurveyCheckRecords
            };

            navRecords.BindingSource = bs;

            // setup the form
            SetupForm();
            BindProperties();
            ColorForm(0xDCE6F2);

            // register events
            this.MouseWheel += ITCForm_OnMouseWheel;
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += Bs_ListChanged;
            bs.DataError += Bs_DataError;

            // set initial state
            if (SurveyCheckRecords.Count == 0)
                AddRecord();
            else
                LockForm(true);

            CurrentRecord = (SurveyCheckRec)bs.Current;

            SetRecordStatus("");
            Moving = false;

            
        }

        public SurveyCheckTracking(int ID)
        {
            InitializeComponent();

            // get the records
            SurveyCheckRecords = DBAction.GetSurveyCheckRecords();
            // setup binding source
            bs = new BindingSource()
            {
                DataSource = SurveyCheckRecords
            };

            navRecords.BindingSource = bs;

            // setup the form
            SetupForm();
            BindProperties();
            ColorForm(0xDCE6F2);

            // register events
            this.MouseWheel += ITCForm_OnMouseWheel;
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += Bs_ListChanged;
            bs.DataError += Bs_DataError;

            // set initial state
            if (SurveyCheckRecords.Count == 0)
                AddRecord();
            else
                LockForm(true);

            var obj = bs.List.OfType<SurveyCheckRec>().ToList().Find(f => f.ID == ID);
            var pos = bs.IndexOf(obj);
            bs.Position = pos;

            CurrentRecord = (SurveyCheckRec)bs.Current;

            SetRecordStatus("");
            Moving = false;


        }

        private void Bs_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            
        }


        /// <summary>
        /// Set the dirty flag if the current item has changed but not due to a move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (Moving)
            {
                Dirty = false ;
                SetRecordStatus("");
                tglLock.Checked = true;
            }
            else
            {
                Dirty = true;
                SetRecordStatus("Unsaved");
            }
        }

        /// <summary>
        /// For the current record, display the reference surveys, reset the moving flag and clear the record status.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (SurveyCheckRec)bs.Current;

            if (CurrentRecord != null)
                dgvRefSurveys.DataSource = CurrentRecord.ReferenceSurveys;

            SetRecordStatus("");
            Moving = false;
        }

        /// <summary>
        /// Populates data grid and combo boxes.
        /// </summary>
        private void SetupForm()
        {
            // reference survey list
            dgvRefSurveys.AutoGenerateColumns = false;

            DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
            column1.DataPropertyName = "CheckID";
            column1.Name = "CheckID";
            column1.Visible = false;
            dgvRefSurveys.Columns.Add(column1);

            DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn();
            column2.DataPropertyName = "SID";
            column2.DataSource = DBAction.GetAllSurveysInfo();
            column2.DisplayMember = "SurveyCode";
            column2.ValueMember = "SID";
            column2.Name = "Survey";

            dgvRefSurveys.Columns.Add(column2);

            CalendarColumn column3 = new CalendarColumn();
            column3.DataPropertyName = "SurveyDate";
            column3.Name = "Date";

            dgvRefSurveys.Columns.Add(column3);

            // survey filter list
            dgvSurveys.DataSource = SurveyCheckRecords.Select(x => x.SurveyCode).ToList(); // DBAction.GetSurveyCheckSurveys();

            // combo boxes
            cboCheckType.DisplayMember = "CheckName";
            cboCheckType.ValueMember = "ID";
            cboCheckType.DataSource = new List<SurveyCheckType>(DBAction.GetSurveyCheckTypes());

            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);

            cboCheckInit.DisplayMember = "Name";
            cboCheckInit.ValueMember = "ID";
            cboCheckInit.DataSource = new List<Person>(Globals.AllPeople);
        }

        /// <summary>
        /// Bind properties to controls.
        /// </summary>
        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "ID");
            cboCheckType.DataBindings.Add("SelectedItem", bs, "CheckType",false , DataSourceUpdateMode.OnPropertyChanged);
            cboCheckInit.DataBindings.Add("SelectedItem", bs, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            cboSurvey.DataBindings.Add("SelectedItem", bs, "SurveyCode", false, DataSourceUpdateMode.OnPropertyChanged);
            txtComments.DataBindings.Add("Text", bs, "Comments", false, DataSourceUpdateMode.OnPropertyChanged);

            Binding b = new Binding("Value", bs, "CheckDate", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpCheckDate.DataBindings.Add(b);
            b.Format += new ConvertEventHandler(dtp_Format);
            b.Parse += new ConvertEventHandler(dtp_Parse);
        }

        private void ITCForm_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save record.");
                return;
            }

            Moving = true;

            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }

        
        private void dgvSurveys_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Cannot change filter.");
                return;
            }

            string code = (string)dgvSurveys[e.ColumnIndex, e.RowIndex].Value;
            Filtered = SurveyCheckRecords.Where(x => x.SurveyCode.SurveyCode.Equals(code)).ToList();
            bs.DataSource = Filtered;
        }

        private void cmdAll_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Cannot clear filter.");
                return;
            }
            bs.DataSource = SurveyCheckRecords;

        }

        private void dgvSurveys_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0;i<dgvSurveys.Columns.Count;i ++) 
            {
                if (!dgvSurveys.Columns[i].Name.Equals("SurveyCode"))
                    dgvSurveys.Columns[i].Visible = false;
            }
        }

        private void dtp_Format(object sender, ConvertEventArgs e)
        {

            // e.Value is the object value, we format it to be what we want to show up in the control 
            Binding b = sender as Binding;

            if (b != null)
            {
                DateTimePicker dtp = (b.Control as DateTimePicker);
                if (dtp != null)
                {
                    if (e.Value == null)
                    {
                        dtp.ShowCheckBox = true;
                        dtp.Checked = false;
                        // have to set e.Value to SOMETHING, since it’s coming in as NULL 
                        // if i set to DateTime.Today, and that’s DIFFERENT than the control’s current  
                        // value, then it triggers a CHANGE to the value, which CHECKS the box (not ok) 
                        // the trick – set e.Value to whatever value the control currently has.   
                        // This does NOT cause a CHANGE, and the checkbox stays OFF. 
                        e.Value = dtp.Value;
                    }
                    else
                    {
                        dtp.ShowCheckBox = true;
                        dtp.Checked = true;
                        // leave e.Value unchanged – it’s not null, so the DTP is fine with it. 
                    }
                }
            }
        }

        private void dtp_Parse(object sender, ConvertEventArgs e)

        {

            // e.value is the formatted value coming from the control.   

            // we change it to be the value we want to stuff in the object. 



            Binding b = sender as Binding;

            if (b != null)

            {

                DateTimePicker dtp = (b.Control as DateTimePicker);

                if (dtp != null)

                {

                    if (dtp.Checked == false)

                    {

                        dtp.ShowCheckBox = true;

                        dtp.Checked = false;
                 
                        e.Value = new Nullable<DateTime>();

                    }

                    else

                    {

                        DateTime val = Convert.ToDateTime(e.Value);

                        e.Value = new Nullable<DateTime>(val);

                    }

                }

            }

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            
            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save record. Ensure all required fields are completed.");
                return;
            }
            
            AddRecord();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void tglLock_CheckedChanged(object sender, EventArgs e)
        {
            LockForm(tglLock.Checked);
        }

        private void AddRecord()
        {
            // navigate to new record
            bs.AddNew();
            NewRecord = true;
            tglLock.Checked = false;

            cboCheckType.SelectedIndex = 0;
            cboSurvey.SelectedItem = null;
            cboCheckInit.SelectedIndex = 0;

            SetRecordStatus("New Record");
        }

        /// <summary>
        /// Deletes the current item from the binding source's internal list. If this is not a new record then delete it from the database as well.
        /// </summary>
        private void DeleteRecord()
        {
            if (!NewRecord)
            {
                // delete record from database
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    DBAction.DeleteRecord(CurrentRecord);
                else
                    return;
            }
            // delete item from list
            bs.RemoveCurrent();
        }


        private void LockForm(bool lockState)
        {
            lockState = !lockState;
            foreach (Control c in panelMain.Controls)
            {
                if (c is TextBox || c is ComboBox || c is CheckBox || c is DateTimePicker)
                    c.Enabled = lockState;
            }

            dgvRefSurveys.Enabled = lockState;
            tglLock.Enabled = true;
            
        }

        private int SaveRecord()
        {
            if (CurrentRecord == null)
            {
                NewRecord = false;
                Dirty = false;
                SetRecordStatus("");
                return 0;
            }

            if (CurrentRecord.SurveyCode == null) {
                MessageBox.Show("Unable to save. Survey must be specified");
                return 1;
            }
            
            if (NewRecord)
            {
                if (DBAction.InsertSurveyCheckRecord(CurrentRecord) == 1)
                    return 1;

                foreach (SurveyCheckRefSurvey s in CurrentRecord.ReferenceSurveys)
                {
                    if (s.ID == 0)
                    {
                        s.CheckID = CurrentRecord.ID;
                        if (DBAction.InsertSurveyCheckRef(s) == 1)
                            return 1;
                    }
                }

                NewRecord = false;
                Dirty = false;
                
            }
            else if (Dirty)
            {

                if (DBAction.UpdateSurveyCheckRecord(CurrentRecord) == 1)
                    return 1;

                foreach (SurveyCheckRefSurvey s in CurrentRecord.ReferenceSurveys)
                {
                    if (s.ID == 0)
                    {
                        s.CheckID = CurrentRecord.ID;
                        if (DBAction.InsertSurveyCheckRef(s) == 1)
                            return 1;
                    }
                }
                Dirty = false;

            }

            // refresh survey filter list in case a new survey was added
            dgvSurveys.DataSource = SurveyCheckRecords.Select(x => x.SurveyCode).ToList(); //DBAction.GetSurveyCheckSurveys();
                
            SetRecordStatus("");
            return 0;
        }

        protected void ColorForm(int hex)
        {
            Color temp = Color.FromArgb(hex);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;
        }

        protected void MoveRecord(int count)
        {
            Moving = true;
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

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            
            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }

            MoveRecord(1);

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            
            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }
            Moving = true;
            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }
            Moving = true;
            bs.MoveFirst();
        }
        #endregion

        protected void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SurveyCheckTracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void dgvRefSurveys_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void dgvRefSurveys_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!NewRecord)
            {
                Dirty = true;
                SetRecordStatus("Unsaved");
            }
        }

        private void SetRecordStatus(string status)
        {
            lblRecordStatus.Text = status;
        }

        private void dgvRefSurveys_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dgvRefSurveys_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // prompt user that they are deleting records
            if (MessageBox.Show("Are you sure you want to delete this Reference Survey record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // delete records
                SurveyCheckRefSurvey rec = (SurveyCheckRefSurvey) dgvRefSurveys.Rows[e.Row.Index].DataBoundItem;
                DBAction.DeleteRecord(rec);
            }
            
        }

        private void SurveyCheckTracking_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveRecord() == 1)
            {
                e.Cancel = true;
            }
            else
            {
                
            }
        }

        
    }
}
