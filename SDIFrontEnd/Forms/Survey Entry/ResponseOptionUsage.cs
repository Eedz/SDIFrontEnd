using ITCLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HtmlRtfConverter;

namespace SDIFrontEnd
{
    public partial class ResponseOptionUsage : Form
    {
        List<ResponseSetRecord> Records;
        public ResponseSetRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsCurrent;

        List<ResponseUsage> Usages;
        ObjectCache<ResponseUsage> memoryCache;

        private bool Locked { get; set; }

        public ResponseOptionUsage(ResponseSet respset)
        {
            InitializeComponent();

            var wordings = GetResponseSets(respset.FieldType); 
            Usages = new List<ResponseUsage>();

            Records = new List<ResponseSetRecord>();
            foreach (ResponseSet w in wordings)
            {
                Records.Add(new ResponseSetRecord(w));
            }

            bs = new BindingSource
            {
                DataSource = Records
            };

            bsCurrent = new BindingSource
            {
                DataSource = bs,
                DataMember = "Item"
            };

            bs.CurrentChanged += Bs_CurrentChanged;
            bsCurrent.ListChanged += Bs_ListChanged;
            bs.AllowNew = true;
            bs.AddingNew += Bs_AddingNew;

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

            CurrentRecord.Dirty = true;
        }

        private void Bs_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new ResponseSetRecord(new ResponseSet(CurrentRecord.Item.Type));
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
            AddWording(CurrentRecord.Item);
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

        private void chkEdit_Click(object sender, EventArgs e)
        {
            if (!chkEdit.Checked)
            {
                UpdatePlainText();
                SaveRecord();
                chkEdit.Text = "Edit";
                cmdBold.Enabled = false;
                cmdItalic.Enabled = false;
                cmdUnderline.Enabled = false;
                txtWordingR.BackColor = SystemColors.Control;
            }
            else
            {
                if (CurrentRecord.Item.RespSetName == "0" && !CurrentRecord.NewRecord) // 0 wording, reserved
                {
                    MessageBox.Show("Set '0' is reserved and cannot be edited.");
                    return;
                }
                else if (Locked)
                {
                    if (MessageBox.Show("This set is used in a locked survey and cannot be modified. Would you like to unlock the surveys that use this set?", "Unlock?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string[] surveys = Usages.Where(x => x.Locked).Select(x => x.SurveyCode).ToArray();
                        for (int i = 0; i < surveys.Length; i++)
                            DBAction.UnlockSurvey(surveys[i], 60);
                    }
                    else
                        return;
                }
                else if (Usages.Count > 1) // existing survey used in more than 1 survey
                    MessageBox.Show("You are about to edit a response set used in multiple survey questions.");

                // otherwise, existing wording used in 0 or 1 surveys OR a new wording
                // unlock wording field for editing

                chkEdit.Text = "Save";
                txtWordingR.BackColor = Color.White;
                txtWordingR.ReadOnly = false;
                cmdBold.Enabled = true;
                cmdItalic.Enabled = true;
                cmdUnderline.Enabled = true;
            }

        }

        private void cmdBold_Click(object sender, EventArgs e)
        {
            Font oldFont = txtWordingR.SelectionFont;
            Font newFont;

            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            txtWordingR.SelectionFont = newFont;
        }

        private void cmdItalic_Click(object sender, EventArgs e)
        {
            Font oldFont = txtWordingR.SelectionFont;
            Font newFont;

            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            txtWordingR.SelectionFont = newFont;
        }

        private void cmdUnderline_Click(object sender, EventArgs e)
        {
            Font oldFont = txtWordingR.SelectionFont;
            Font newFont;

            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            txtWordingR.SelectionFont = newFont;
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

        private void UpdatePlainText()
        {
            // change RTF tags to HTML tags
            string html = Converter.ConvertRTFtoHTML(txtWordingR.Rtf);
            // now remove the extraneous tags
            html = HTMLUtilities.RemoveHtmlTag(html, "div");
            html = HTMLUtilities.RemoveEmptyParagraphsWithBr(html);
            html = HTMLUtilities.RemoveStyleAttribute(html, "p");
            html = html.Replace("<p>", "<br>");
            html = html.Replace("</p>", "");
            html = html.TrimAndRemoveAll("<br>");

            CurrentRecord.Item.RespList = html;

            bs.ResetCurrentItem();
        }

        private List<ResponseSet> GetResponseSets(string fieldname)
        {
            switch (fieldname)
            {
                case "RespOptions":
                    return Globals.AllRespOptions;
                case "NRCodes":
                   return Globals.AllNRCodes;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Navigate to a particular wording.
        /// </summary>
        /// <param name="wording"></param>
        private void GoToWording(ResponseSet response)
        {
            int index = -1;
            foreach (ResponseSetRecord r in Records)
            {
                index++;
                if (r.Item.RespSetName.ToLower().Equals(response.RespSetName.ToLower()))
                    break;
            }
            if (index >= 0)
                bs.Position = index;
        }

        private void AddWording()
        {
            ResponseType field = CurrentRecord.Item.Type;
           
            CurrentRecord = (ResponseSetRecord)bs.AddNew();
            CurrentRecord.NewRecord = true;
            CurrentRecord.Item.Type = field;
            CurrentRecord.Item.RespSetName = "(New)";

            chkEdit.Text = "Save";
        }

        private void AddWording(ResponseSet template)
        {
            CurrentRecord = (ResponseSetRecord)bs.AddNew();
            CurrentRecord.NewRecord = true;
            CurrentRecord.Item.Type = template.Type;
            CurrentRecord.Item.RespList = template.RespList;
            CurrentRecord.Item.RespSetName = "(New)";

            chkEdit.Text = "Save";
        }

        public int FilterWordings(string criteria)
        {
            var results = Records.Where(x => x.Item.RespList.ToLower().Contains(criteria.ToLower())).ToList();

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
            bsCurrent.EndEdit();
            
            if (CurrentRecord.Item.RespSetName.Equals("(New)"))
            {
                MessageBox.Show("This appears to be a new response set. Please assign a name before saving.");
                return 1;
            }
            
            if (CurrentRecord.NewRecord && Records.Count(x => x.Item.RespSetName.Equals(CurrentRecord.Item.RespSetName))>1)
            {
                MessageBox.Show("There is already a response set named '" + CurrentRecord.Item.RespSetName + "'. Please choose another name.");
                return 1;
            }

            bool newRec = CurrentRecord.NewRecord;
            int result = CurrentRecord.SaveRecord();

            if (newRec)
            {
                Globals.AddResponseSet(CurrentRecord.Item);
                Globals.RefreshWordings?.Invoke(this, new EventArgs());
            }

            bs.ResetBindings(false);
      
            return 0;
        }

        private void BindProperties()
        {
            txtFieldName.DataBindings.Add("Text", bsCurrent, "Type");
            txtWordID.DataBindings.Add("Text", bsCurrent, "RespSetName");
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
            if (Usages.Count > 0 || (CurrentRecord.Item.RespSetName == "0" && !CurrentRecord.NewRecord))
            {
                MessageBox.Show("This response set is used by " + Usages.Count + " survey question(s) and cannot be deleted.");
            }
            else
            {
                if (MessageBox.Show("This will delete " + CurrentRecord.Item.FieldType + " " + CurrentRecord.Item.RespSetName + ".\r\nDo you want to proceed?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DBAction.DeleteRecord(CurrentRecord.Item) == 1)
                    {
                        MessageBox.Show("Error deleting response set.");
                    }
                    else
                    {
                        bs.RemoveCurrent();
                        Globals.RefreshWordings?.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        /// <summary>
        /// Refresh the form with the current wording. Locking controls as needed.
        /// </summary>
        private void UpdateCurrentWording()
        {
            CurrentRecord = (ResponseSetRecord)bs.Current;
            txtWordingR.Rtf = null;
            txtWordingR.Rtf = Converter.HTMLToRtf(CurrentRecord.Item.RespList);

            LoadUsageList(CurrentRecord.Item.FieldType, CurrentRecord.Item.RespSetName);
            Locked = Usages.Any(x => x.Locked) || (CurrentRecord.Item.RespSetName.Equals("0") && !CurrentRecord.NewRecord);

            if (CurrentRecord.Item.RespSetName == "0" && !CurrentRecord.NewRecord) // 0 wording, reserved
            {
                chkEdit.Enabled = false;
                txtWordID.ReadOnly = true;
            }
            else if (CurrentRecord.NewRecord)
            {
                chkEdit.Enabled = true;
                chkEdit.Checked = true;
                txtWordID.ReadOnly = false;
                txtWordingR.ReadOnly = false;
                txtWordingR.BackColor = SystemColors.Window;
                cmdBold.Enabled = true;
                cmdItalic.Enabled = true;
            }
            else
            {
                chkEdit.Enabled = true;
                chkEdit.Checked = false;
                txtWordID.ReadOnly = false;
                txtWordingR.ReadOnly = true;
                txtWordingR.BackColor = SystemColors.Control;
                cmdBold.Enabled = false;
                cmdItalic.Enabled = false;
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
