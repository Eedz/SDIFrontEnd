﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ITCLib;
using HtmlRtfConverter;

namespace SDIFrontEnd
{   
    public partial class WordingEntryForm : Form
    {
        List<WordingRecord> Records;
        public WordingRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsCurrent;

        List<ITCLib.WordingUsage> Usages;
        ObjectCache<ITCLib.WordingUsage> memoryCache;

        bool Locked;

        private bool isResizing;
        private Point lastMousePosition;

        public WordingEntryForm(Wording wording) 
        {
            InitializeComponent();

            var wordings = GetWordings(wording.Type);
            Usages = new List<ITCLib.WordingUsage>();

            Records = new List<WordingRecord>();
            foreach (Wording w in wordings)
            {
                Records.Add(new WordingRecord(w));
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

            CurrentRecord.Dirty = true;
        }

        private void Bs_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new WordingRecord(new Wording(CurrentRecord.Item.Type));
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
        private void WordingUsage_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRecord();
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
                if (CurrentRecord.Item.WordID == 0 && !CurrentRecord.NewRecord) // 0 wording, reserved
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
            string html = Converter.ConvertRTFtoHTML(txtWordingR.Rtf);
            // now remove the extraneous tags
            html = HTMLUtilities.RemoveHtmlTag(html, "div");
            html = HTMLUtilities.RemoveEmptyParagraphsWithBr(html);
            html = HTMLUtilities.RemoveStyleAttribute(html, "p");
            html = html.Replace("<p>", "<br>");
            html = html.Replace("</p>", "");
            html = html.Replace("<span>", "");
            html = html.Replace("</span>", "");
            html = html.TrimAndRemoveAll("<br>");
            
            CurrentRecord.Item.WordingText = html;

            bs.ResetCurrentItem();
        }

        private List<Wording> GetWordings(string fieldname)
        {
            switch (fieldname)
            {
                case "PreP":
                    return Globals.AllPreP;
                case "PreI":
                    return Globals.AllPreI;
                case "PreA":
                    return Globals.AllPreA;
                case "LitQ":
                    return Globals.AllLitQ;
                case "PstI":
                    return Globals.AllPstI;
                case "PstP":
                    return Globals.AllPstP;
                default:
                    return null;
            }
        }

        private List<Wording> GetWordings(WordingType fieldname)
        {
            switch (fieldname)
            {
                case WordingType.PreP:
                    return Globals.AllPreP;
                case WordingType.PreI:
                   return Globals.AllPreI;
                case WordingType.PreA:
                    return Globals.AllPreA;
                case WordingType.LitQ:
                    return Globals.AllLitQ;
                case WordingType.PstI:
                    return Globals.AllPstI;
                case WordingType.PstP:
                    return Globals.AllPstP;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Navigate to a particular wording.
        /// </summary>
        /// <param name="wording"></param>
        private void GoToWording(Wording wording)
        {
            int index = -1;
            foreach (WordingRecord w in Records)
            {
                index++;
                if (w.Item.WordID == wording.WordID)
                    break;
            }
            if (index >= 0)
                bs.Position = index;
        }

        private void AddWording()
        {
            WordingType field = CurrentRecord.Item.Type;
            
            lblNewID.Left = txtWordID.Left;
            lblNewID.Top = txtWordID.Top;
            lblNewID.Visible = true;
            
            CurrentRecord = (WordingRecord)bs.AddNew();
            CurrentRecord.NewRecord = true;
            CurrentRecord.Item.Type = field;

            chkEdit.Text = "Save";
        }

        private void AddWording(Wording template)
        {
            lblNewID.Left = txtWordID.Left;
            lblNewID.Top = txtWordID.Top;
            lblNewID.Visible = true;
            CurrentRecord = (WordingRecord)bs.AddNew();
            CurrentRecord.NewRecord = true;
            CurrentRecord.Item.Type = template.Type;
            CurrentRecord.Item.WordingText = template.WordingText;

            chkEdit.Text = "Save";
        }

        public int FilterWordings(string criteria)
        {
            var results = Records.Where(x => x.Item.WordingText.ToLower().Contains(criteria.ToLower())).ToList();

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
            bsCurrent.EndEdit();

            if (CurrentRecord.Item.WordID!=0 && CurrentRecord.Item.IsBlank)
            {
                return 0;
            }

            bool newRec = CurrentRecord.NewRecord;
            int result = CurrentRecord.SaveRecord();

            if (newRec)
            {
                Globals.AddWording(CurrentRecord.Item);
                Globals.RefreshWordings?.Invoke(this, new EventArgs());
            }

            bs.ResetBindings(false);
            lblNewID.Visible = false;

            return 0;
        }

        private void BindProperties()
        {
            txtFieldName.DataBindings.Add("Text", bsCurrent, "Type");
            txtWordID.DataBindings.Add("Text", bsCurrent, "WordID");
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
            if (Usages.Count > 0 || (CurrentRecord.Item.WordID == 0 && !CurrentRecord.NewRecord))
            {
                MessageBox.Show("This wording is used by " + Usages.Count + " survey question(s) and cannot be deleted.");
            }
            else
            {
                if (MessageBox.Show("This will delete " + CurrentRecord.Item.FieldType + "#" + CurrentRecord.Item.WordID + ".\r\nDo you want to proceed?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DBAction.DeleteWording(CurrentRecord.Item.FieldType, CurrentRecord.Item.WordID) == 1)
                    {
                        MessageBox.Show("Error deleting wording.");
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
            CurrentRecord = (WordingRecord)bs.Current;
            txtWordingR.Rtf = null;
            txtWordingR.Rtf = Converter.HTMLToRtf(CurrentRecord.Item.WordingText);

            LoadUsageList(CurrentRecord.Item.FieldType, CurrentRecord.Item.WordID);
            Locked = Usages.Any(x => x.Locked) || (CurrentRecord.Item.WordID == 0 && !CurrentRecord.NewRecord);

            lblNewID.Visible = CurrentRecord.NewRecord;
            if (CurrentRecord.Item.WordID == 0 && !CurrentRecord.NewRecord) // 0 wording, reserved
            {
                chkEdit.Enabled = false;
                txtWordingR.ReadOnly = true;
            }
            else if (CurrentRecord.NewRecord)
            {
                chkEdit.Enabled = true;
                chkEdit.Checked = true;
                txtWordingR.ReadOnly = false;
                txtWordingR.BackColor = SystemColors.Window;
                cmdBold.Enabled = true;
                cmdItalic.Enabled = true;
            }
            else
            {
                chkEdit.Enabled = true;
                chkEdit.Checked = false;
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

        private void cmdExpand_Click(object sender, EventArgs e)
        {
            this.Height += 100;
            txtWordingR.Height += 100;
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the mouse is near the bottom edge
            if (e.Button == MouseButtons.Left && e.Y >= txtWordingR.Height - 10)
            {
                isResizing = true;
                lastMousePosition = e.Location;
                txtWordingR.Cursor = Cursors.SizeNS;
            }
        }

        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                int oldHeight = txtWordingR.Height;
                int newHeight = txtWordingR.Height + (e.Y - lastMousePosition.Y);
                if (newHeight > 20) // Set a minimum height
                {
                    txtWordingR.Height = newHeight;
                    lastMousePosition = e.Location;
                    this.Height += newHeight - oldHeight;
                }
            }
            else
            {
                // Change cursor if near the bottom edge
                if (e.Y >= txtWordingR.Height - 10)
                {
                    txtWordingR.Cursor = Cursors.SizeNS;
                }
                else
                {
                    txtWordingR.Cursor = Cursors.Default;
                }
            }
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = false;
                txtWordingR.Cursor = Cursors.Default;
            }
        }
    }
}
