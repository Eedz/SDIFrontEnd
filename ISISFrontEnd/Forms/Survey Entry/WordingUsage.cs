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
    // TODO unlock surveys for editing
    public partial class WordingUsage : Form
    {
        public Wording CurrentWording;

        BindingSource bs;
        List<Wording> Wordings;
        List<ITCLib.WordingUsage> Usages;
        ObjectCache<ITCLib.WordingUsage> memoryCache;

        private bool Locked { get; set; }
        private bool NewRecord { get; set; }

        private bool _dirty;
        private bool Dirty
        {
            get
            {
                return _dirty;
            }
            set
            {
                _dirty = value;
                if (_dirty)
                    lblTitle.Text = "Wording Usage*";
                else
                    lblTitle.Text = "Wording Usage";
            }
        }

        public WordingUsage()
        {
            InitializeComponent();

            Wordings = DBAction.GetWordings();
            Usages = new List<ITCLib.WordingUsage>();

            bs = new BindingSource
            {
                DataSource = Wordings
            };
            bs.CurrentChanged += Bs_CurrentChanged;
            bs.ListChanged += Bs_ListChanged;

            BindProperties();

            navWordings.BindingSource = bs;
            this.MouseWheel += WordingUsage_MouseWheel;
            txtWordingR.MouseWheel += WordingUsage_MouseWheel;

            AddGridColumns();
        }

        public WordingUsage(Wording wording)
        {
            InitializeComponent();

            GetWordings(wording.FieldName);
            Usages = new List<ITCLib.WordingUsage>();

            bs = new BindingSource
            {
                DataSource = Wordings
            };
            bs.CurrentChanged += Bs_CurrentChanged;
            bs.ListChanged += Bs_ListChanged;

            BindProperties();

            navWordings.BindingSource = bs;
            this.MouseWheel += WordingUsage_MouseWheel;
            txtWordingR.MouseWheel += WordingUsage_MouseWheel;

            AddGridColumns();
            GoToWording(wording);
        }

        #region Events

        private void WordingUsage_Load(object sender, EventArgs e)
        {
            UpdateCurrentWording();
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            UpdateCurrentWording();
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;
            Dirty = true;
        }

        /// <summary>
        /// When moving to the next/previous item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WordingUsage_MouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();
            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            SaveRecord();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdSearchClip_Click(object sender, EventArgs e)
        {
            string searchTerm = Clipboard.GetText();

            FilterWordings(searchTerm);
        }

        private void cmdTextSearch_Click(object sender, EventArgs e)
        { 
            InputBox input = new InputBox("Search Criteria");
            input.ShowDialog();
            if (input.DialogResult == DialogResult.Cancel)
                return;

            FilterWordings(input.userInput);
        }

        private void cmdCopyToNew_Click(object sender, EventArgs e)
        {
            AddWording(CurrentWording);
            UpdateCurrentWording();
        }

        
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddWording();
            UpdateCurrentWording();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteWording();
        }
        private void WordingUsage_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRecord();
        }

        private void txtWordingR_Validated(object sender, EventArgs e)
        {
            //txtWordingR.Rtf = Utilities.FormatRTF(txtWordingR.Rtf);
            //Wording current = (Wording)bs.Current;
            //string plain = txtWordingR.Text;
            //current.WordingText = plain;
            //Dirty = true;
        }

        

        private void chkEdit_Click(object sender, EventArgs e)
        {
            if (!chkEdit.Checked)
            {
                
                SaveRecord();
                chkEdit.Text = "Edit";
                cmdBold.Enabled = false;
                cmdItalic.Enabled = false;
                txtWordingR.BackColor = SystemColors.Control;
            }
            else
            {
                if (CurrentWording.WordID == 0 && !NewRecord) // 0 wording, reserved
                {
                    MessageBox.Show("Wording #0 is reserved and cannot be edited.");
                    return;
                }
                else if (Locked)
                {
                    if (MessageBox.Show("This wording is used in a locked survey and cannot be modified. Would you like to unlock the surveys that use this wording?", "Unlock?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string[] surveys = Usages.Where(x => x.Locked).Select(x => x.SurveyCode).ToArray();
                        for (int i = 0; i < surveys.Length; i++)
                            DBAction.UnlockSurvey(surveys[i], 60);
                    }
                    else
                        return;
                }
                else if (Usages.Count > 1) // existing survey used in more than 1 survey
                    MessageBox.Show("You are about to edit a wording used in multiple survey questions.");

                // otherwise, existing wording used in 0 or 1 surveys OR a new wording
                // unlock wording field for editing

                chkEdit.Text = "Save";
                txtWordingR.BackColor = Color.White;
                txtWordingR.ReadOnly = false;
                cmdBold.Enabled = true;
                cmdItalic.Enabled = true;
            }
            
        }

        private void cmdBold_Click(object sender, EventArgs e)
        {
            if (txtWordingR.SelectionFont.Bold)
            {
                txtWordingR.SelectionFont = new Font(txtWordingR.Font, FontStyle.Regular);
            }
            else
            {
                txtWordingR.SelectionFont = new Font(txtWordingR.Font, FontStyle.Bold);
            }
        }

        private void cmdItalic_Click(object sender, EventArgs e)
        {
            if (txtWordingR.SelectionFont.Italic)
            {
                txtWordingR.SelectionFont = new Font(txtWordingR.Font, FontStyle.Regular);
            }
            else
            {
                txtWordingR.SelectionFont = new Font(txtWordingR.Font, FontStyle.Italic);
            }
        }

        #region Navigator button events
        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            MoveRecord(1);
            UpdateCurrentWording();
            
        }

        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            MoveRecord(-1);
            UpdateCurrentWording();
            
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveLast();
            UpdateCurrentWording();
            
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveFirst();
            UpdateCurrentWording();
            
        }

        #endregion

        #endregion

        #region Methods

        private void UpdatePlainText()
        {
            // change RTF tags to HTML tags
            txtWordingR.Rtf = Utilities.FormatRTF(txtWordingR.Rtf);
            // now get plain text which includes the HTML tags we've inserted
            string plain = txtWordingR.Text;

            CurrentWording.WordingText = plain;
            Dirty = true;
            bs.ResetCurrentItem();
        }

        private void GetWordings(string fieldname)
        {
            switch (fieldname)
            {
                case "PreP":
                    Wordings = Globals.AllPreP;
                    break;
                case "PreI":
                    Wordings = Globals.AllPreI;
                    break;
                case "PreA":
                    Wordings = Globals.AllPreA;
                    break;
                case "LitQ":
                    Wordings = Globals.AllLitQ;
                    break;
                case "PstI":
                    Wordings = Globals.AllPstI;
                    break;
                case "PstP":
                    Wordings = Globals.AllPstP;
                    break;
            }
        }

        /// <summary>
        /// Navigate to a particular wording.
        /// </summary>
        /// <param name="wording"></param>
        private void GoToWording(Wording wording)
        {
            int index = -1;
            foreach (Wording w in Wordings)
            {
                index++;
                if (w.WordID == wording.WordID)
                    break;
            }
            if (index >= 0)
                bs.Position = index;
        }

        private void OpenEditor(Wording wording)
        {
            RichTextEditor frmEditor = new RichTextEditor(wording.WordingTextR);
            frmEditor.ShowDialog();
            if (frmEditor.DialogResult == DialogResult.OK)
            {
                txtWordingR.Rtf = Utilities.FormatRTF(frmEditor.EditedText);

                wording.WordingText = Utilities.RemoveHighlightTags(txtWordingR.Text);

                Dirty = true;
            }
        }

        private void AddWording()
        {
            string field = txtFieldName.Text;
            NewRecord = true;
            lblNewID.Left = txtWordID.Left;
            lblNewID.Top = txtWordID.Top;
            lblNewID.Visible = true;
            bs.DataSource = Wordings;
            CurrentWording = (Wording)bs.AddNew();
            CurrentWording.FieldName = field;
            OpenEditor(CurrentWording);
        }

        private void AddWording(Wording template)
        {
            
            NewRecord = true;
            lblNewID.Left = txtWordID.Left;
            lblNewID.Top = txtWordID.Top;
            lblNewID.Visible = true;
            bs.DataSource = Wordings;
            CurrentWording = (Wording)bs.AddNew();
            CurrentWording.FieldName = template.FieldName;
            CurrentWording.WordingText = template.WordingText;
            OpenEditor(CurrentWording);
        }

        public int FilterWordings(string criteria)
        {
            var results = Wordings.Where(x => x.WordingText.Contains(criteria)).ToList();

            if (results.Count() > 0)
            {
                bs.DataSource = results;
                navWordings.BindingSource = null;
                navWordings.BindingSource = bs;
            }
            else
            {
                MessageBox.Show("No results found.");
            }

            return bs.Count;
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

        private int SaveRecord()
        {
            UpdatePlainText();
            Wording current = (Wording)bs.Current;
            if (CurrentWording.WordID == 0) // new wording created by this form
            {
                // insert into table
                DBAction.InsertWording(CurrentWording);
                Dirty = false;
                NewRecord = false;
            }
            else if (Dirty) // existing wording edited
            {
                DBAction.UpdateWording(CurrentWording);
                Dirty = false;
            }
            bs.ResetBindings(false);
            lblNewID.Visible = false;

            return 0;
        }

        private void BindProperties()
        {
            txtFieldName.DataBindings.Add("Text", bs, "FieldName");
            txtWordID.DataBindings.Add("Text", bs, "WordID");
            txtWordingR.DataBindings.Add("RTF", bs, "WordingTextR");
        }

        private void LoadUsageList(string field, int wordID)
        {
            if (wordID == 0)
            {
                Usages.Clear();
                dgvWordingUsage.Visible = false;
                lblUses.Visible = false;
            }
            else
            {
                if (Usages.Count > 0 && Usages[0].WordID.Equals(wordID))
                    return;

                Usages = DBAction.GetWordingUsage(field, wordID);

                SetupCache();

                dgvWordingUsage.Visible = true;
                lblUses.Visible = true;
            }
        }

        // Create an ObjectDataRetriever and use it to create an ObjectCache object and to initialize the DataGridView rows.
        private void SetupCache()
        { 
            try
            {
                dgvWordingUsage.RowCount = 0;

                ObjectDataRetriever<ITCLib.WordingUsage> retriever = new ObjectDataRetriever<ITCLib.WordingUsage>(Usages);
                memoryCache = new ObjectCache<ITCLib.WordingUsage>(retriever, 16);

                this.dgvWordingUsage.RowCount = retriever.RowCount;
            }
            catch 
            {
                MessageBox.Show("Connection could not be established. Verify that the connection string is valid.");
                Close();
            }
        }

        /// <summary>
        /// Add columns to grid for each property.
        /// </summary>
        private void AddGridColumns()
        {
            dgvWordingUsage.AutoGenerateColumns = false;
           
            DataGridViewTextBoxColumn chVarName = new DataGridViewTextBoxColumn();
            chVarName.Name = "VarName";
            chVarName.HeaderText = "VarName";
            chVarName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chVarName.Width = 75;
            dgvWordingUsage.Columns.Add(chVarName);

            DataGridViewTextBoxColumn chSurvey = new DataGridViewTextBoxColumn();
            chSurvey.Name = "Survey";
            chSurvey.HeaderText = "Survey";
            chSurvey.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chSurvey.Width = 100;
            dgvWordingUsage.Columns.Add(chSurvey);

            DataGridViewTextBoxColumn chWordID = new DataGridViewTextBoxColumn();
            chWordID.Name = "Wnum";
            chWordID.HeaderText = "W#";
            chWordID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chWordID.Width = 75;
            dgvWordingUsage.Columns.Add(chWordID);

            DataGridViewTextBoxColumn chVarLabel = new DataGridViewTextBoxColumn();
            chVarLabel.Name = "VarLabel";
            chVarLabel.HeaderText = "VarLabel";
            chVarLabel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chVarLabel.Width = 400;
            dgvWordingUsage.Columns.Add(chVarLabel);

            DataGridViewCheckBoxColumn chLocked = new DataGridViewCheckBoxColumn();
            chLocked.Name = "Locked";
            chLocked.HeaderText = "Locked";
            chLocked.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chLocked.Width = 50;
            dgvWordingUsage.Columns.Add(chLocked);
        }

        private void DeleteWording()
        {
            if (Usages.Count > 0 || (CurrentWording.WordID == 0 && !NewRecord))
            {
                MessageBox.Show("This wording is used by " + Usages.Count + " survey question(s) and cannot be deleted.");
            }
            else
            {
                if (MessageBox.Show("This will delete " + CurrentWording.FieldName + "#" + CurrentWording.WordID + ".\r\nDo you want to proceed?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DBAction.DeleteWording(CurrentWording.FieldName, CurrentWording.WordID) == 1)
                    {
                        MessageBox.Show("Error deleting wording.");
                    }
                    else
                    {
                        bs.RemoveCurrent();
                    }
                }
            }
        }

        /// <summary>
        /// Refresh the form with the current wording. Locking controls as needed.
        /// </summary>
        private void UpdateCurrentWording()
        {
            CurrentWording = (Wording)bs.Current;

            LoadUsageList(CurrentWording.FieldName, CurrentWording.WordID);
            Locked = Usages.Any(x => x.Locked) || (CurrentWording.WordID == 0 && !NewRecord);

            lblNewID.Visible = NewRecord;
            if (CurrentWording.WordID == 0 && !NewRecord) // 0 wording, reserved
            {
                chkEdit.Enabled = false;
            }
            else
            {
                chkEdit.Enabled = true;
            }

            chkEdit.Checked = false;
            txtWordingR.ReadOnly = true;
            txtWordingR.BackColor = SystemColors.Control;
            cmdBold.Enabled = false;
            cmdItalic.Enabled = false;
        }
        #endregion

        #region DataGridView Events
        /// <summary>
        /// Set the cell's value from the memoryCache based on the name of the column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWordingUsage_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            ITCLib.WordingUsage item = memoryCache.RetrieveRow(e.RowIndex);

            if (item == null) return;

            switch (this.dgvWordingUsage.Columns[e.ColumnIndex].Name)
            {
                case "VarName":
                    e.Value = item.VarName;
                    break;
                case "Survey":
                    e.Value = item.SurveyCode;
                    break;
                case "Wnum":
                    e.Value = item.WordID;
                    break;
                case "VarLabel":
                    e.Value = item.VarLabel;
                    break;
                case "Locked":
                    e.Value = item.Locked;
                    break;
            }
        }



        #endregion

        
    }
}
