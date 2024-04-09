using ITCLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SDIFrontEnd
{
    // TODO open locked surveys form with list of surveys   
    public partial class ResponseOptionUsage : Form
    {
        List<ResponseSet> ResponseSets;
        public ResponseSet CurrentSet;
        BindingSource bs;

        List<ResponseUsage> Usages;
        ObjectCache<ResponseUsage> memoryCache;

        private bool Locked { get; set; }
        private bool NewRecord { get; set; }
        private bool Dirty { get; set; }

        public ResponseOptionUsage(string fieldname)
        {
            InitializeComponent();

            GetResponseSets(fieldname); 
            Usages = new List<ResponseUsage>();

            bs = new BindingSource
            {
                DataSource = ResponseSets
            };
            bs.CurrentChanged += Bs_CurrentChanged;
            bs.ListChanged += Bs_ListChanged;

            BindProperties();

            navWordings.BindingSource = bs;

            AddGridColumns();
        }

        public ResponseOptionUsage(ResponseSet respset)
        {
            InitializeComponent();

            GetResponseSets(respset.FieldType); 
            Usages = new List<ResponseUsage>();

            bs = new BindingSource
            {
                DataSource = ResponseSets
            };
            bs.CurrentChanged += Bs_CurrentChanged;
            bs.ListChanged += Bs_ListChanged;

            BindProperties();

            navWordings.BindingSource = bs;

            AddGridColumns();
            GoToWording(respset);
        }     
        #region Events

        private void ResponseOptionUsage_Load(object sender, EventArgs e)
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
            if (SaveRecord() == 1)
                return;

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

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
            AddWording(CurrentSet);
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

        private void ResponseOptionUsage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveRecord() == 1)
            {
                if (MessageBox.Show("Unable to save this response set. Do you want to close anyway and lose any changes to this set?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
                
        }

        private void txtWordingR_Validated(object sender, EventArgs e)
        {
            txtWordingR.Rtf = Utilities.FormatRTF(txtWordingR.Rtf);
            ResponseSet current = (ResponseSet)bs.Current;
            string plain = txtWordingR.Text;
            plain = Utilities.RemoveHighlightTags(plain);
            plain = Utilities.TrimString(plain, "<br>");
            plain = plain.Replace("<br>", "\r\n");
            current.RespList = plain;
            Dirty = true;
            bs.ResetCurrentItem();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (CurrentSet.RespSetName.Equals("0") && !NewRecord) // 0 wording, reserved
            {
                MessageBox.Show("Response Set #0 is reserved and cannot be edited.");
                return;

            }
            else if (Locked)
            {
                if (MessageBox.Show("This response set is used in a locked survey and cannot be modified. Would you like to unlock the surveys that use this response set?", "Unlock?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string[] surveys = Usages.Where(x => x.Locked).Select(x => x.SurveyCode).ToArray();
                      
                    for (int i = 0; i < surveys.Length; i++)
                    {
                        DBAction.UnlockSurvey(surveys[i], 60);
                    }

                }
                else
                {
                    return;
                }
            }
            else if (Usages.Count > 1) // existing survey used in more than 1 survey
            {
                MessageBox.Show("You are about to edit a response set used in multiple survey questions.");
            }
            else // existing wording used in 0 or 1 surveys OR a new wording
            {
            }

            // open editor
            OpenEditor(CurrentSet);
        }

        #endregion

        #region Navigator button events
        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveRecord() == 1)
                return;

            MoveRecord(1);
            UpdateCurrentWording();
        }

        /// <summary>
        /// When moving to the previous item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveRecord() == 1)
                return;

            MoveRecord(-1);
            UpdateCurrentWording();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveRecord() == 1)
                return;

            bs.MoveLast();
            UpdateCurrentWording();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            if (SaveRecord() == 1)
                return;

            bs.MoveFirst();
            UpdateCurrentWording();
        }

        #endregion

        #region Methods

        private void GetResponseSets(string fieldname)
        {
            switch (fieldname)
            {
                case "RespOptions":
                    ResponseSets = Globals.AllRespOptions;
                    break;
                case "NRCodes":
                    ResponseSets = Globals.AllNRCodes;
                    break;
            }
        }

        /// <summary>
        /// Navigate to a particular wording.
        /// </summary>
        /// <param name="wording"></param>
        private void GoToWording(ResponseSet response)
        {
            int index = -1;
            foreach (ResponseSet r in ResponseSets)
            {
                index++;
                if (r.RespSetName.ToLower().Equals(response.RespSetName.ToLower()))
                    break;
            }
            if (index >= 0)
                bs.Position = index;
        }

        private void OpenEditor(ResponseSet set)
        {
            RichTextEditor frmEditor = new RichTextEditor(set.RespListR);
            frmEditor.ShowDialog();
            if (frmEditor.DialogResult == DialogResult.OK)
            {
                txtWordingR.Rtf = Utilities.FormatRTF(frmEditor.EditedText);
                string plain = txtWordingR.Text;
                plain = Utilities.RemoveHighlightTags(plain);
                plain = Utilities.TrimString(plain, "<br>"); 

                set.RespList = plain;

                Dirty = true;
                bs.ResetCurrentItem();
            }

        }

        private void AddWording()
        {
            ResponseType field = CurrentSet.Type;
            NewRecord = true;
           
            bs.DataSource = ResponseSets;
            CurrentSet = (ResponseSet)bs.AddNew();
            CurrentSet.Type = field;
            CurrentSet.RespSetName = "(New)";
            OpenEditor(CurrentSet);
        }

        private void AddWording(ResponseSet template)
        {
            NewRecord = true;
           
            bs.DataSource = ResponseSets;
            CurrentSet = (ResponseSet)bs.AddNew();
            CurrentSet.Type = template.Type;
            CurrentSet.RespList = template.RespList;
            CurrentSet.RespSetName = "(New)";
            OpenEditor(CurrentSet);
        }

        public int FilterWordings(string criteria)
        {
            List<ResponseSet> results = ResponseSets.Where(x => x.RespList.ToLower().Contains(criteria.ToLower())).ToList();

            if (results.Count == 0)
            {
                MessageBox.Show("No results found.");
                return 0;
            }

            bs.DataSource = results;

            navWordings.BindingSource = null;
            navWordings.BindingSource = bs;
            bs.MoveFirst();
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
            if (CurrentSet.RespSetName.Equals("(New)"))
            {
                MessageBox.Show("This appears to be a new response set. Please assign a name before saving.");
                return 1;
            }
            
            if (NewRecord && this.ResponseSets.Count(x => x.RespSetName.Equals(CurrentSet.RespSetName))>1)
            {
                MessageBox.Show("There is already a response set named '" + CurrentSet.RespSetName + "'. Please choose another name.");
                return 1;
            }

            if (NewRecord && !CurrentSet.RespSetName.Equals("(New)")) // new set created by this form
            {
                // insert into table
                DBAction.InsertResponseSet(CurrentSet);
                Dirty = false;
                NewRecord = false;
            }
            else if (Dirty) // existing set edited
            {
                DBAction.UpdateResponseSet(CurrentSet);
                Dirty = false;
            }
            bs.ResetBindings(false);
      
            return 0;
        }

        private void BindProperties()
        {
            txtFieldName.DataBindings.Add("Text", bs, "FieldType");
            txtWordID.DataBindings.Add("Text", bs, "RespSetName");
            txtWordingR.DataBindings.Add("RTF", bs, "RespListR");
        }

        private void LoadUsageList(string field, string respName)
        {
            if (respName == "0")
            {
                Usages.Clear();
                dgvWordingUsage.Visible = false;
                lblUses.Visible = false;
            }
            else
            {
                if (Usages.Count > 0 && Usages[0].RespName.Equals(respName))
                    return;

                Usages = DBAction.GetResponseUsage(field, respName);

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

                ObjectDataRetriever<ResponseUsage> retriever = new ObjectDataRetriever<ResponseUsage>(Usages);
                memoryCache = new ObjectCache<ResponseUsage>(retriever, 16);

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

            DataGridViewTextBoxColumn chSetName = new DataGridViewTextBoxColumn();
            chSetName.Name = "SetName";
            chSetName.HeaderText = "Set Name";
            chSetName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chSetName.Width = 75;
            dgvWordingUsage.Columns.Add(chSetName);

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
            if (Usages.Count > 0 || (CurrentSet.RespSetName == "0" && !NewRecord))
            {
                MessageBox.Show("This response set is used by " + Usages.Count + " survey question(s) and cannot be deleted.");
            }
            else
            {
                if (MessageBox.Show("This will delete " + CurrentSet.FieldType + " " + CurrentSet.RespSetName + ".\r\nDo you want to proceed?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DBAction.DeleteRecord(CurrentSet) == 1)
                    {
                        MessageBox.Show("Error deleting response set.");
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
            CurrentSet = (ResponseSet)bs.Current;

            LoadUsageList(CurrentSet.FieldType, CurrentSet.RespSetName);
            Locked = Usages.Any(x => x.Locked) || (CurrentSet.RespSetName.Equals("0") && !NewRecord);

            if (CurrentSet.RespSetName == "0" && !NewRecord) // 0 wording, reserved
            {
                cmdEdit.Enabled = false;
                txtWordID.ReadOnly = true;
            }
            else
            {
                cmdEdit.Enabled = true;
                txtWordID.ReadOnly = false;
            }
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
            ResponseUsage item = memoryCache.RetrieveRow(e.RowIndex);

            if (item == null) return;

            switch (this.dgvWordingUsage.Columns[e.ColumnIndex].Name)
            {
                case "VarName":
                    e.Value = item.VarName;
                    break;
                case "Survey":
                    e.Value = item.SurveyCode;
                    break;
                case "SetName":
                    e.Value = item.RespName;
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
