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
        List<VariablePrefixRecord> Prefixes;
        VariablePrefixRecord CurrentRecord;
        BindingSource bs;
        BindingSource bsRanges;
        BindingSource bsParallel;

        List<VariableNameSurveys> Usages;
        ObjectCache<VariableNameSurveys> memoryCache;

        VarNameWordingUsage questionUsage;

        public PrefixList()
        {
            InitializeComponent();

            this.MouseWheel += PrefixList_MouseWheel;
            cboGoTo.MouseWheel += ComboBox_MouseWheel;

            Prefixes = Globals.AllPrefixes;
            Usages = new List<VariableNameSurveys>();

            SetupBindingSources();

            navPrefixes.BindingSource = bs;

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

        private void PrefixList_MouseWheel(object sender, MouseEventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

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
                if (DBAction.DeleteRecord(CurrentRecord) == 1)
                    MessageBox.Show("Error deleting prefix.");

                bs.RemoveCurrent();
            }
        }

        private void toolStripDatasheet_Click(object sender, EventArgs e)
        {
            PrefixListSheet getFrm = (PrefixListSheet)FM.FormManager.GetForm("PrefixListSheet", 1);
            if (getFrm == null)

            {
                PrefixListSheet frm = new PrefixListSheet();
                frm.Tag = 1;
                FM.FormManager.Add(frm);
            }
            ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("PrefixListSheet1");
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

            VariablePrefix item = (VariablePrefix)cboGoTo.SelectedItem;
            int index = -1;
            for (int i = 0; i < Prefixes.Count; i++)
            {
                if (Prefixes[i].ID == item.ID)
                {
                    index = i;
                    break;
                }
            }
            if (index > -1) bs.Position = index;
        }

        private void chkFilterByRange_Click(object sender, EventArgs e)
        {
            dgvVariableInfo.Rows.Clear();
            if (chkFilterByRange.Checked)
            {
                VariableRange range = (VariableRange) dgvVarNameRanges.CurrentRow.DataBoundItem;
                List<VariableNameSurveys> filteredUsages = Usages.Where(x => x.NumberInt() >= range.LowerInt() && x.NumberInt() <= range.UpperInt()).ToList();
                SetupWithObjects(filteredUsages);
            }
            else
            {
                SetupWithObjects(Usages);
            }
        }

        private void Control_Validated(object sender, EventArgs e)
        {
            CurrentRecord.Dirty = true;
        }

        #region DataGridView Events
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

        private void dgvParallelPrefixes_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            ParallelPrefixRecord record = (ParallelPrefixRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvParallelPrefixes_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            ParallelPrefixRecord record = (ParallelPrefixRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (record == null)
                return;

            if (record.NewRecord)
            {
                record.RelatedID = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                record.PrefixID = CurrentRecord.ID;
                CurrentRecord.Dirty = true;
            }
            else 
                record.SaveRecord();
        }

        private void dgvParallelPrefixes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ParallelPrefixRecord record = (ParallelPrefixRecord)e.Row.DataBoundItem;
                DBAction.DeleteRecord(record);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvParallelPrefixes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvVarNameRanges_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvVariableInfo.Rows.Clear();
            if (chkFilterByRange.Checked)
            {
                VariableRange range = (VariableRange)dgvVarNameRanges.Rows[e.RowIndex].DataBoundItem;
                List<VariableNameSurveys> filteredUsages = Usages.Where(x => x.NumberInt() >= range.LowerInt() && x.NumberInt() <= range.UpperInt()).ToList();
                SetupWithObjects(filteredUsages);
            }
            else
            {
                SetupWithObjects(Usages);
            }
        }

        private void dgvVarNameRanges_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VariableRangeRecord record = (VariableRangeRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvVarNameRanges_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            VariableRangeRecord record = (VariableRangeRecord)dgv.Rows[e.RowIndex].DataBoundItem;

            if (record == null)
                return;

            if (record.NewRecord)
            {
                record.PrefixID = CurrentRecord.ID;
                CurrentRecord.Dirty = true;
            }
            else
                record.SaveRecord();
        }

        private void dgvVarNameRanges_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VariableRangeRecord record = (VariableRangeRecord)e.Row.DataBoundItem;
                DBAction.DeleteRecord(record);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvVarNameRanges_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

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
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
                return;

            bs.MoveFirst();
        }
        #endregion

        #endregion
        #region Methods

        private void UpdateCurrentRecord()
        {
            CurrentRecord = (VariablePrefixRecord)bs.Current;

            if (CurrentRecord.NewRecord)
                return;
            Usages = DBAction.GetVarNamesPrefix(CurrentRecord.Prefix);
            if (Usages.Count > 0)
                SetupWithObjects(Usages);
            else
                dgvVariableInfo.RowCount = 0;
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = Prefixes;
            bs.PositionChanged += Bs_PositionChanged;

            bsRanges = new BindingSource();
            bsRanges.DataSource = bs;
            bsRanges.DataMember = "Ranges";

            bsParallel = new BindingSource();
            bsParallel.DataSource = bs;
            bsParallel.DataMember = "ParallelPrefixes";
        }

        private void FillControls()
        {
            cboGoTo.DataSource = new List<VariablePrefixRecord>(Prefixes);
            cboGoTo.DisplayMember = "Prefix";
            cboGoTo.ValueMember = "ID";
            cboGoTo.SelectedItem = null;

            dgvVarNameRanges.AutoGenerateColumns = false;
            dgvVarNameRanges.DataSource = bsRanges;

            chLower.DataPropertyName = "Lower";
            chUpper.DataPropertyName = "Upper";
            chDescription.DataPropertyName = "Description";

            

            dgvParallelPrefixes.AutoGenerateColumns = false;
            dgvParallelPrefixes.DataSource = bsParallel;

            chParallelPrefix.DataSource = new List<VariablePrefixRecord>(Prefixes);
            chParallelPrefix.DisplayMember = "Prefix";
            chParallelPrefix.ValueMember = "ID";
            chParallelPrefix.DataPropertyName = "RelatedID";
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
            txtPrefix.DataBindings.Add(new Binding("Text", bs, "Prefix"));
            txtPrefixName.DataBindings.Add(new Binding("Text", bs, "PrefixName"));
            txtProductType.DataBindings.Add(new Binding("Text", bs, "ProductType"));
            txtRelatedPrefixes.DataBindings.Add(new Binding("Text", bs, "RelatedPrefixes"));
            txtDescription.DataBindings.Add(new Binding("Text", bs, "Description"));
            txtComments.DataBindings.Add(new Binding("Text", bs, "Comments"));
            chkInactive.DataBindings.Add(new Binding("Checked", bs, "Inactive"));
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
            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving record.");
                return 1;
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

        #endregion
        
    }
}
