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
    public partial class DraftManager : Form
    {
        List<SurveyDraftRecord> Records;
        SurveyDraftRecord CurrentRecord;
        BindingSource bs;
        BindingSource bsEF;

        public DraftManager()
        {
            InitializeComponent();

            Records = DBAction.ListSurveyDrafts();

            bs = new BindingSource()
            {
                DataSource = Records
            };

            bsEF = new BindingSource()
            {
                DataSource = bs,
                DataMember = "ExtraFields"
            };

            bs.ListChanged += Bs_ListChanged;
            bs.PositionChanged += Bs_PositionChanged;

            bsEF.ListChanged += BsEF_ListChanged;

            chFieldNum.DataPropertyName = "FieldNumber";
            chLabel.DataPropertyName = "Label";
            dgvExtraFields.AutoGenerateColumns = false;
            dgvExtraFields.DataSource = bsEF;

            navRecords.BindingSource = bs;

            this.MouseWheel += DraftManager_OnMouseWheel;
            cboSurvey.MouseWheel += ComboBox_MouseWheel;
            cboInvestigator.MouseWheel += ComboBox_MouseWheel;
            txtComments.MouseWheel += TextBox_MouseWheel;
            txtTitle.MouseWheel += TextBox_MouseWheel;

            FillBoxes();

            BindProperties();


            CurrentRecord = (SurveyDraftRecord)bs.Current;
        }

        

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (SurveyDraftRecord)bs.Current;
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.NewIndex < 0)
                return;
            ((SurveyDraftRecord)bs[e.NewIndex]).Dirty = true;
        }

        private void BsEF_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.NewIndex < 0)
                return;

            if (e.NewIndex > bsEF.Count)
                return;

            ((SurveyDraftExtraFieldRecord)bsEF[e.NewIndex]).Dirty = true;
        }

        protected void DraftManager_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (SaveRecord() == 1)
                return;
            
            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;

            if (SaveRecord() == 1)
                return;

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        private void TextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            TextBox control = (TextBox)sender;

            ((HandledMouseEventArgs)e).Handled = true;

            if (SaveRecord() == 1)
                return;

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        #region Menu Items
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            Close();
            FormManager.Remove(this);
        }

        private void toolStripClearFilter_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.DataSource = Records;
            bs.Position = 0;
        }

        private void toolStripGoTo_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            // open a the survey draft seach to this draft
            DraftSearch getFrm = (DraftSearch)FormManager.GetForm("DraftSearch", 1);
            if (getFrm != null)
            {
                getFrm.GoToDraft(CurrentRecord.SurvID, CurrentRecord.ID);                
            }
            else
            {
                DraftSearch frm = new DraftSearch();
                frm.Tag = 1;
                FormManager.Add(frm);
                frm.GoToDraft(CurrentRecord.SurvID, CurrentRecord.ID);
            }
            ((MainMenu)FormManager.GetForm("MainMenu")).SelectTab("DraftSearch1");
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            DeleteDraft();
            
        }

        private void toolStripSurveyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            ComboBox box = (ComboBox)sender;

            var results = Records.Where(x => x.SurvID == (int)box.SelectedValue);

            if (results.Count()==0)
            {
                MessageBox.Show("No drafts found!");
                return;
            }

            bs.DataSource = results;
            bs.Position = 0;
            CurrentRecord = (SurveyDraftRecord)bs.Current;
        }
        #endregion

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return;
            }

            bs.MoveFirst();
        }
        #endregion

        #region Methods 
        private void DeleteDraft()
        {
            if (MessageBox.Show("Are you sure you want to delete this draft?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAction.DeleteRecord(CurrentRecord);
                bs.Remove(CurrentRecord);
                CurrentRecord = (SurveyDraftRecord)bs.Current;
            }
        }

        private int SaveRecord()
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return 1;
            }
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

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "ID");
            cboSurvey.DataBindings.Add("SelectedValue", bs, "SurvID");
            dtpDate.DataBindings.Add("Value", bs, "DraftDate", true);
            txtTitle.DataBindings.Add("Text", bs, "DraftTitle");
            txtComments.DataBindings.Add("Text", bs, "DraftComments");
            cboInvestigator.DataBindings.Add("SelectedValue", bs, "Investigator");
        }

        private void FillBoxes()
        {
            toolStripSurveyFilter.ComboBox.DataSource = new List<Survey> (Globals.AllSurveys);
            toolStripSurveyFilter.ComboBox.ValueMember = "SID";
            toolStripSurveyFilter.ComboBox.DisplayMember = "SurveyCode";
            toolStripSurveyFilter.ComboBox.SelectedItem = null;
            toolStripSurveyFilter.ComboBox.SelectedIndexChanged += toolStripSurveyFilter_SelectedIndexChanged;

            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.ValueMember = "SID";
            cboSurvey.DisplayMember = "SurveyCode";

            cboInvestigator.DataSource = new List<Person>(Globals.AllPeople);
            cboInvestigator.ValueMember = "ID";
            cboInvestigator.DisplayMember = "Name";


        }


        #endregion

        private void dgvExtraFields_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SurveyDraftExtraFieldRecord record = (SurveyDraftExtraFieldRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvExtraFields_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SurveyDraftExtraFieldRecord record = (SurveyDraftExtraFieldRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (record == null)
                return;
            if (record.NewRecord)
            {
                record.DraftID = CurrentRecord.ID;
                CurrentRecord.Dirty = true;
            }
            else
                record.SaveRecord();
        }

        private void dgvExtraFields_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                SurveyDraftExtraFieldRecord record = (SurveyDraftExtraFieldRecord)e.Row.DataBoundItem;

                    
                DBAction.DeleteRecord(record);
                bsEF.Remove(record);

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvExtraFields_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
