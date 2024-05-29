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
    public partial class PrefixList : Form
    {      
        List<VariablePrefixRecord> Records;
        VariablePrefixRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsCurrent;

        List<VariableNameSurveys> Usages;
        ObjectCache<VariableNameSurveys> memoryCache;

        VarNameWordingUsage questionUsage;

        int rangeRow = -1;
        VariableRange editedRange;
        bool rowCommit = true;

        public PrefixList(List<VariablePrefix> prefixes)
        {
            InitializeComponent();

            this.MouseWheel += PrefixList_MouseWheel;
            cboGoTo.MouseWheel += ComboBox_MouseWheel;

            Records = new List<VariablePrefixRecord>();
            foreach (VariablePrefix prefix in prefixes)
            {
                Records.Add(new VariablePrefixRecord(prefix));
            }

            Usages = new List<VariableNameSurveys>();

            SetupBindingSources();

            SetupGrids();

            FillControls();
            
            BindProperties();
        }

        #region Events
        private void PrefixList_Load(object sender, EventArgs e)
        {
            AddGridColumns();

            UpdateCurrentRecord();
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void BsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            
        }

        private void PrefixList_MouseWheel(object sender, MouseEventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
                bs.MovePrevious();
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            Close();
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            CurrentRecord = (VariablePrefixRecord)bs.AddNew();
            CurrentRecord.NewRecord = true;
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this prefix?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (DBAction.DeleteRecord(CurrentRecord.Item) == 1)
                    MessageBox.Show("Error deleting prefix.");

                bs.RemoveCurrent();
            }
        }

        private void toolStripDatasheet_Click(object sender, EventArgs e)
        {
            OpenDatasheetView();
        }

        private void lstParallelPrefixes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && MessageBox.Show("Are you sure you want to remove this parallel prefix?", "Confirm Delete.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteParallelPrefix();
            }
        }

        private void cmdAddParallelPrefix_Click(object sender, EventArgs e)
        {
            Picker<VariablePrefix> picker = new Picker<VariablePrefix>(Records.Select(x => x.Item).ToList(), "Prefix", "ID", "Choose Prefix");

            picker.ShowDialog();

            if (picker.DialogResult == DialogResult.Cancel)
                return;

            ParallelPrefix parallel = new ParallelPrefix()
            {
                PrefixID = CurrentRecord.Item.ID,
                RelatedPrefixID = picker.Data.ID,
                RelatedPrefix = picker.Data.Prefix
            };

            CurrentRecord.AddedParallels.Add(parallel);
            CurrentRecord.Item.ParallelPrefixes.Add(parallel);

            lstParallelPrefixes.DataSource = null;
            lstParallelPrefixes.DataSource = CurrentRecord.Item.ParallelPrefixes;
        }

        private void chkShowWordings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowWordings.Checked)
            {
                if (dgvVariableInfo.CurrentRow == null)
                    return;

                
                string varname = (string)dgvVariableInfo.CurrentRow.Cells["VarName"].Value;
                ShowWordings(varname);
            }else
            {
                if (questionUsage!=null)
                    questionUsage.Close();
            }
        }

        private void cboGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoTo.SelectedItem == null)
                return;

            GoToPrefix((VariablePrefix)cboGoTo.SelectedItem);
        }

        private void chkFilterByRange_Click(object sender, EventArgs e)
        {
            dgvVariableInfo.Rows.Clear();
            if (chkFilterByRange.Checked)
            {
                VariableRange range = CurrentRecord.Item.Ranges[dgvVarNameRanges.CurrentRow.Index]; 
                if (range != null)
                {
                    List<VariableNameSurveys> filteredUsages = Usages.Where(x => x.NumberInt() >= range.LowerInt() && x.NumberInt() <= range.UpperInt()).ToList();
                    SetupWithObjects(filteredUsages);
                }
            }
            else
            {
                SetupWithObjects(Usages);
            }
        }

        #region DataGridView Events
        
        // ranges
        private void dgv_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Create a new object when the user edits the row for new records.
            this.editedRange = new VariableRange();
            this.rangeRow = dgv.Rows.Count - 1;
        }

        private void dgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // if this is the row for new records, no values needed
            if (e.RowIndex == dgv.RowCount - 1) return;
            // if there are no records, no values needed
            if (CurrentRecord.Item.Ranges.Count == 0) return;

            VariableRange tmp = null;

            // Store a reference to the Survey object for the row being painted.
            if (e.RowIndex == rangeRow)
            {
                tmp = editedRange;
            }
            else
            {
                tmp = CurrentRecord.Item.Ranges[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the Survey object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLower":
                    e.Value = tmp.Lower;
                    break;
                case "chUpper": 
                    e.Value = tmp.Upper; break;
                case "chDescription":
                    e.Value = tmp.Description; break;

            }
        }

        private void dgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            VariableRange tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.Ranges.Count)
            {
                // If the user is editing a new row (not THE new row), create a new object and reference the row's data.
                if (editedRange == null)
                    editedRange = new VariableRange()
                    {
                        ID = CurrentRecord.Item.Ranges[e.RowIndex].ID,
                        PrefixID = CurrentRecord.Item.Ranges[e.RowIndex].PrefixID,
                        Lower = CurrentRecord.Item.Ranges[e.RowIndex].Lower,
                        Upper = CurrentRecord.Item.Ranges[e.RowIndex].Upper,
                        Description = CurrentRecord.Item.Ranges[e.RowIndex].Description
                     
                    };

                tmp = this.editedRange;
                this.rangeRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedRange == null ? new ITCLib.VariableRange() : this.editedRange;
                tmp.PrefixID = CurrentRecord.Item.ID;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chLower":
                    tmp.Lower = (string)e.Value;
                    break;
                case "chUpper":
                    tmp.Upper = (string)e.Value;
                    break;
                case "chDescription":
                    tmp.Description = (string)e.Value;
                    break;
            }
        }

        private void dgv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Save row changes if any were made and release the edited object if there is one.
            if (editedRange != null && e.RowIndex >= CurrentRecord.Item.Ranges.Count &&
                e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.Ranges.Add(editedRange);
                CurrentRecord.AddedRanges.Add(editedRange);
                editedRange = null;
                rangeRow = -1;
            }
            if (editedRange != null && e.RowIndex < CurrentRecord.Item.Ranges.Count)
            {
                CurrentRecord.EditedRanges.Add(editedRange);
                CurrentRecord.Item.Ranges[e.RowIndex] = editedRange;
                editedRange = null;
                rangeRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedRange = null;
                rangeRow = -1;
            }
        }

        private void dgv_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgv_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (rangeRow == dgv.Rows.Count - 2 && rangeRow == CurrentRecord.Item.Ranges.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding Survey object with a new, empty one.
                editedRange = new VariableRange();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding Survey object.
                editedRange = null;
                rangeRow = -1;
            }
        }

        private void dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VariableRange record = CurrentRecord.Item.Ranges[e.Row.Index];
                // If the user has deleted an existing row, remove the
                // corresponding object from the data store.
                this.CurrentRecord.Item.Ranges.RemoveAt(e.Row.Index);
                CurrentRecord.DeletedRanges.Add(record);
            }
            else
            {
                e.Cancel = true;
            }

            if (e.Row.Index == this.rangeRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.rangeRow = -1;
                this.editedRange = null;
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvVarNameRanges_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvVariableInfo.Rows.Clear();
            if (chkFilterByRange.Checked)
            {
                VariableRange range = CurrentRecord.Item.Ranges[e.RowIndex];
                if (range != null)
                {
                    List<VariableNameSurveys> filteredUsages = Usages.Where(x => x.NumberInt() >= range.LowerInt() && x.NumberInt() <= range.UpperInt()).ToList();
                    SetupWithObjects(filteredUsages);
                }
            }
            else
            {
                SetupWithObjects(Usages);
            }
        }

        // variable list
        private void dgvVariableInfo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (chkShowWordings.Checked)
            {
                if (dgvVariableInfo.CurrentRow == null)
                    return;


                string refvarname = (string)dgv.Rows[e.RowIndex].Cells["VarName"].Value;
                ShowWordings(refvarname);
            }
            else
            {
                if (questionUsage != null)
                    questionUsage.Close();
            }
        }

        /// <summary>
        /// Set the cell's value from the memoryCache based on the name of the column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVariableInfo_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            VariableNameSurveys item = memoryCache.RetrieveRow(e.RowIndex);

            if (item == null) return;

            switch (this.dgvVariableInfo.Columns[e.ColumnIndex].Name)
            {
                case "VarName":
                    e.Value = item.VarName;
                    break;
                case "Surveys":
                    e.Value = item.SurveyList;
                    break;
                case "RefVarName":
                    e.Value = item.RefVarName;
                    break;
                case "VarLabel":
                    e.Value = item.VarLabel;
                    break;
                case "Content":
                    e.Value = item.Content;
                    break;
                case "Topic":
                    e.Value = item.Topic;
                    break;
                case "Domain":
                    e.Value = item.Domain;
                    break;
                case "Product":
                    e.Value = item.Product;
                    break;
            }
        }

        private void dgvVariableInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                string cellValue = dgv.Rows[e.RowIndex].Cells["RefVarName"].Value.ToString();
                string pattern = cellValue.Substring(0, 3);

                if (FM.FormManager.FormOpen("VarNameUsage"))
                {
                    VarNameUsage getFrm = (VarNameUsage)FM.FormManager.GetForm("VarNameUsage", 1);
                    getFrm.SearchVars(pattern);
                    getFrm.BringToFront();
                    return;
                }
                VarNameUsage frm = new VarNameUsage(pattern);
                frm.Tag = 1;
                FM.FormManager.AddPopup(frm);
            }
            catch
            {
            }

        }

        private void dgvVariableInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        private void PrefixList_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveFirst();
        }
        #endregion

        #endregion

        #region Methods
        
        async private Task UpdateQuestionRange()
        {
            Usages = await DBAction.GetVarNamesPrefixAsync(CurrentRecord.Item.Prefix);
            if (Usages.Count > 0)
                SetupWithObjects(Usages);
            else
                dgvVariableInfo.RowCount = 0;

            return;
        }

        async private void UpdateCurrentRecord()
        {
            CurrentRecord = (VariablePrefixRecord)bs.Current;

            lstParallelPrefixes.DataSource = CurrentRecord.Item.ParallelPrefixes;

            if (CurrentRecord.NewRecord)
                return;

            await UpdateQuestionRange();

            dgvVarNameRanges.SetVirtualGridRows(CurrentRecord.Item.Ranges.Count + 1);
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource();
            bsCurrent.DataSource = bs;
            bsCurrent.DataMember = "Item";
            bsCurrent.ListChanged += BsCurrent_ListChanged;

            navPrefixes.BindingSource = bs;
        }

        private void FillControls()
        {
            lstParallelPrefixes.DisplayMember = "Prefix";
            lstParallelPrefixes.ValueMember = "ID";

            cboGoTo.DataSource = Records.Select(x=>x.Item).ToList();
            cboGoTo.DisplayMember = "Prefix";
            cboGoTo.ValueMember = "ID";
            cboGoTo.SelectedItem = null;
        }

        private void SetupGrids()
        {
            dgvVarNameRanges.AutoGenerateColumns = false;
            dgvVarNameRanges.CellValueNeeded += dgv_CellValueNeeded;
            dgvVarNameRanges.NewRowNeeded += dgv_NewRowNeeded;
            dgvVarNameRanges.CellValuePushed += dgv_CellValuePushed;
            dgvVarNameRanges.RowValidated += dgv_RowValidated;
            dgvVarNameRanges.RowDirtyStateNeeded += dgv_RowDirtyStateNeeded;
            dgvVarNameRanges.CancelRowEdit += dgv_CancelRowEdit;
            dgvVarNameRanges.UserDeletingRow += dgv_UserDeletingRow;
            dgvVarNameRanges.DataError += dgv_DataError;
        }

        void SetupWithObjects(List<VariableNameSurveys> usages)
        {
            // Create an ObjectDataRetriever and use it to create an ObjectCache object
            // and to initialize the DataGridView rows.
            try
            {
                ObjectDataRetriever<VariableNameSurveys> retriever = new ObjectDataRetriever<VariableNameSurveys>(usages);
                memoryCache = new ObjectCache<VariableNameSurveys>(retriever, 16);
                dgvVariableInfo.Rows.Clear();
                this.dgvVariableInfo.RowCount = retriever.RowCount;
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
            DataGridViewTextBoxColumn chSurveys = new DataGridViewTextBoxColumn();
            chSurveys.Name = "Surveys";
            chSurveys.HeaderText = "Surveys";
            chSurveys.Width = 400;
            chSurveys.DisplayIndex = 6;
            dgvVariableInfo.Columns.Add(chSurveys);

            DataGridViewTextBoxColumn chRefVarName = new DataGridViewTextBoxColumn();
            chRefVarName.Name = "RefVarName";
            chRefVarName.HeaderText = "RefVarName";
            chRefVarName.Width = 70;
            chRefVarName.DisplayIndex = 0;
            dgvVariableInfo.Columns.Add(chRefVarName);

            DataGridViewTextBoxColumn chVarName = new DataGridViewTextBoxColumn();
            chVarName.Name = "VarName";
            chVarName.HeaderText = "VarName";
            chVarName.Visible = false;
            dgvVariableInfo.Columns.Add(chVarName);

            DataGridViewTextBoxColumn chVarLabel = new DataGridViewTextBoxColumn();
            chVarLabel.Name = "VarLabel";
            chVarLabel.HeaderText = "VarLabel";
            chVarLabel.Width = 300;
            chVarLabel.DisplayIndex = 1;
            dgvVariableInfo.Columns.Add(chVarLabel);

            DataGridViewComboBoxColumn chTopic = new DataGridViewComboBoxColumn();
            chTopic.Name = "Topic";
            chTopic.DataSource = new List<TopicLabel>(Globals.AllTopicLabels);
            chTopic.DisplayMember = "LabelText";
            chTopic.ValueMember = "ID";
            chTopic.Width = 150;
            chTopic.DisplayIndex = 2;
            dgvVariableInfo.Columns.Add(chTopic);

            DataGridViewComboBoxColumn chContent = new DataGridViewComboBoxColumn();
            chContent.Name = "Content";
            chContent.DataSource = new List<ContentLabel>(Globals.AllContentLabels);
            chContent.DisplayMember = "LabelText";
            chContent.ValueMember = "ID";
            chContent.Width = 150;
            chContent.DisplayIndex = 3;
            dgvVariableInfo.Columns.Add(chContent);

            DataGridViewComboBoxColumn chProduct = new DataGridViewComboBoxColumn();
            chProduct.Name = "Product";
            chProduct.DataSource = new List<ProductLabel>(Globals.AllProductLabels);
            chProduct.DisplayMember = "LabelText";
            chProduct.ValueMember = "ID";
            chProduct.Width = 150;
            chProduct.DisplayIndex = 4;
            dgvVariableInfo.Columns.Add(chProduct);

            DataGridViewComboBoxColumn chDomain = new DataGridViewComboBoxColumn();
            chDomain.Name = "Domain";
            chDomain.DataSource = new List<DomainLabel>(Globals.AllDomainLabels);
            chDomain.DisplayMember = "LabelText";
            chDomain.ValueMember = "ID";
            chDomain.Width = 150;
            chDomain.DisplayIndex = 5;
            dgvVariableInfo.Columns.Add(chDomain);
        }

        private void BindProperties()
        {
            txtPrefix.DataBindings.Add(new Binding("Text", bsCurrent, "Prefix"));
            txtPrefixName.DataBindings.Add(new Binding("Text", bsCurrent, "PrefixName"));
            txtProductType.DataBindings.Add(new Binding("Text", bsCurrent, "ProductType"));
            txtRelatedPrefixes.DataBindings.Add(new Binding("Text", bsCurrent, "RelatedPrefixes"));
            txtDescription.DataBindings.Add(new Binding("Text", bsCurrent, "Description"));
            txtComments.DataBindings.Add(new Binding("Text", bsCurrent, "Comments"));
            chkInactive.DataBindings.Add(new Binding("Checked", bsCurrent, "Inactive"));
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

            bool newrec = CurrentRecord.NewRecord;
            int rowsAffected = CurrentRecord.SaveRecord();

            if (rowsAffected == 1)
            {
                MessageBox.Show("Error saving record.");
                return 1;
            }

            if (newrec)
            {
                Globals.AllPrefixes.Add(CurrentRecord.Item);
            }

            return 0;
        }

        private void ShowWordings(string varname)
        {
            VariableName variable = new VariableName(varname);
            List<QuestionUsage> usages = DBAction.GetVarNameQuestions(variable);

            if (questionUsage!=null )
                questionUsage.Close();


            questionUsage = new VarNameWordingUsage(usages);
            questionUsage.Owner = this;
            questionUsage.Show();
        }

        private void DeleteParallelPrefix()
        {
            ParallelPrefix item = (ParallelPrefix)lstParallelPrefixes.SelectedItem;

            CurrentRecord.Item.ParallelPrefixes.Remove(item);

            lstParallelPrefixes.DataSource = null;
            lstParallelPrefixes.DataSource = CurrentRecord.Item.ParallelPrefixes;

            CurrentRecord.DeletedParallels.Add(item);
        }

        private void GoToPrefix(VariablePrefix prefix)
        {
            int index = -1;
            for (int i = 0; i < Records.Count; i++)
            {
                if (Records[i].Item.ID == prefix.ID)
                {
                    index = i;
                    break;
                }
            }
            if (index > -1) bs.Position = index;
        }

        private void OpenDatasheetView()
        {
            PrefixListSheet getFrm = (PrefixListSheet)FM.FormManager.GetForm("PrefixListSheet", 1);
            if (getFrm == null)

            {
                PrefixListSheet frm = new PrefixListSheet(Globals.AllPrefixes);
                frm.Tag = 1;
                FM.FormManager.Add(frm);
            }
            ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("PrefixListSheet1");
        }

        #endregion






    }
}
