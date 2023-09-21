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
    public partial class DraftManager : Form
    {
        List<DraftRecord> Records;
        DraftRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsCurrent;

        SurveyDraftExtraField editedEF;
        int efRow = -1;
        bool rowCommit = true;

        public DraftManager(List<SurveyDraft> drafts)
        {
            InitializeComponent();

            SetupMouseWheel();

            FillLists(drafts);

            SetupBindingSources();

            FillBoxes();

            BindProperties();

            SetupGrid();
        }

        #region Form Setup
        private void SetupMouseWheel()
        {
            this.MouseWheel += DraftManager_OnMouseWheel;
            cboSurvey.MouseWheel += ComboBox_MouseWheel;
            cboInvestigator.MouseWheel += ComboBox_MouseWheel;
        }

        private void FillLists(List<SurveyDraft> drafts)
        {
            Records = new List<DraftRecord>();
            foreach (SurveyDraft d in drafts)
            {
                Records.Add(new DraftRecord(d));
            }
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource()
            {
                DataSource = Records
            };

            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource();
            bsCurrent.DataSource = bs;
            bsCurrent.DataMember = "Item";
            bsCurrent.ListChanged += BsCurrent_ListChanged;

            navRecords.BindingSource = bs;
        }

        private void SetupGrid()
        {
            dgvExtraFields.AutoGenerateColumns = false;

            dgvExtraFields.CellValueNeeded += dgvExtraFields_CellValueNeeded;
            dgvExtraFields.CellValuePushed += dgvExtraFields_CellValuePushed;
            dgvExtraFields.RowValidated += dgvExtraFields_RowValidated;
            dgvExtraFields.RowDirtyStateNeeded += dgvExtraFields_RowDirtyStateNeeded;
            dgvExtraFields.CancelRowEdit += dgvExtraFields_CancelRowEdit;
            dgvExtraFields.DataError += dgvExtraFields_DataError;
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bsCurrent, "ID");
            cboSurvey.DataBindings.Add("SelectedValue", bsCurrent, "SurvID");
            dtpDate.DataBindings.Add("Value", bsCurrent, "DraftDate", true);
            txtTitle.DataBindings.Add("Text", bsCurrent, "DraftTitle");
            txtComments.DataBindings.Add("Text", bsCurrent, "DraftComments");
            cboInvestigator.DataBindings.Add("SelectedValue", bsCurrent, "Investigator");
        }

        private void FillBoxes()
        {
            toolStripSurveyFilter.ComboBox.ValueMember = "SID";
            toolStripSurveyFilter.ComboBox.DisplayMember = "SurveyCode";
            toolStripSurveyFilter.ComboBox.DataSource = new List<Survey>(Globals.AllSurveys);
            toolStripSurveyFilter.ComboBox.SelectedItem = null;
            toolStripSurveyFilter.ComboBox.SelectedIndexChanged += toolStripSurveyFilter_SelectedIndexChanged;

            cboSurvey.ValueMember = "SID";
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);

            cboInvestigator.ValueMember = "ID";
            cboInvestigator.DisplayMember = "Name";
            cboInvestigator.DataSource = new List<Person>(Globals.AllPeople);
        }
        #endregion

        #region Methods 

        private void UpdateCurrentRecord()
        {
            CurrentRecord = (DraftRecord)bs.Current;
            // explicitly set RowCount since we are not allowing user to add rows
            dgvExtraFields.RowCount = CurrentRecord.Item.ExtraFields.Count;
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
            }
            else
            {
                MessageBox.Show("Unable to save record.");
            }
        }

        private void DeleteDraft()
        {
            if (MessageBox.Show("Are you sure you want to delete this draft?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAction.DeleteRecord(CurrentRecord.Item);
                bs.Remove(CurrentRecord);
                CurrentRecord = (DraftRecord)bs.Current;
            }
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
        #endregion

        #region Events
        private void DraftManager_Load(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void DraftManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        protected void DraftManager_OnMouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();

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
                SurveyDraft modifiedSurvey = (SurveyDraft)bsCurrent[e.NewIndex];
                DraftRecord modifiedRecord = Records.Where(x => x.Item == modifiedSurvey).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    case "ExtraFields":
                        break;
                    default:
                        modifiedRecord.Dirty = true;
                        break;
                }
                //if (CurrentRecord.Dirty)
                //lblStatus.Text = "*";
            }
        }

        
        #endregion

        #region Menu Items
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            Close();
        }

        private void toolStripClearFilter_Click(object sender, EventArgs e)
        {
            SaveRecord();       

            bs.DataSource = Records;
            bs.Position = 0;
        }

        private void toolStripGoTo_Click(object sender, EventArgs e)
        {
            SaveRecord();

            // open a the survey draft seach to this draft
            DraftSearch getFrm = (DraftSearch)FM.FormManager.GetForm("DraftSearch", 1);
            if (getFrm != null)
            {
                getFrm.GoToDraft(CurrentRecord.Item.SurvID, CurrentRecord.Item.ID);                
            }
            else
            {
                DraftSearch frm = new DraftSearch();
                frm.Tag = 1;
                FM.FormManager.Add(frm);
                frm.GoToDraft(CurrentRecord.Item.SurvID, CurrentRecord.Item.ID);
            }
            ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("DraftSearch1");
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            DeleteDraft();
            
        }

        private void toolStripSurveyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveRecord();

            ComboBox box = (ComboBox)sender;

            var results = Records.Where(x => x.Item.SurvID == (int)box.SelectedValue);

            if (results.Count()==0)
            {
                MessageBox.Show("No drafts found!");
                return;
            }

            bs.DataSource = results;
            bs.Position = 0;
            CurrentRecord = (DraftRecord)bs.Current;
        }
        #endregion

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            bs.MoveFirst();
        }
        #endregion

        #region DataGridView Events
        private void dgvExtraFields_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.ExtraFields.Count == 0) return;

            SurveyDraftExtraField tmp;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == efRow)
            {
                tmp = editedEF;
            }
            else
            {
                tmp = CurrentRecord.Item.ExtraFields[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chFieldNum":
                    e.Value = tmp.FieldNumber;
                    break;
                case "chLabel":
                    e.Value = tmp.Label;
                    break;
            }
        }

        private void dgvExtraFields_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            SurveyDraftExtraField tmp;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.ExtraFields.Count)
            {
                // If the user is editing a row, create a new object.
                if (editedEF == null)
                    editedEF = new SurveyDraftExtraField()
                    {
                        ID = CurrentRecord.Item.ExtraFields[e.RowIndex].ID,
                        DraftID = CurrentRecord.Item.ID,
                        FieldNumber = CurrentRecord.Item.ExtraFields[e.RowIndex].FieldNumber,
                        Label = CurrentRecord.Item.ExtraFields[e.RowIndex].Label
                    };

                tmp = this.editedEF;
                this.efRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedEF;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chFieldNum":
                    tmp.FieldNumber = (int)e.Value;
                    break;
                case "chLabel":
                    tmp.Label = (string)e.Value;
                    break;
            }
        }

        private void dgvExtraFields_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedEF != null && e.RowIndex >= CurrentRecord.Item.ExtraFields.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // ignore adds
                editedEF = null;
                efRow = -1;
            }
            else if (editedEF != null && e.RowIndex < CurrentRecord.Item.ExtraFields.Count)
            {
                CurrentRecord.Item.ExtraFields[e.RowIndex] = editedEF;
                CurrentRecord.EditedExtraFields.Add(editedEF);
                editedEF = null;
                efRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedEF = null;
                efRow = -1;
            }
        }

        private void dgvExtraFields_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvExtraFields_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (efRow == dgv.Rows.Count - 2 && efRow == CurrentRecord.Item.ExtraFields.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedEF = new SurveyDraftExtraField();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedEF = null;
                efRow = -1;
            }
        }

        private void dgvExtraFields_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

    }
}
