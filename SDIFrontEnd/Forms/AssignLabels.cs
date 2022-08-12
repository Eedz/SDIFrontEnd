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
    public partial class AssignLabels : Form
    {
        private ObjectCache<VariableNameSurveys> memoryCache;

        private List<VariableNameSurveys> FullList;

        private QuestionViewer frmQuestionViewer;

        // Declare a variable to store the index of a row being edited.
        // A value of -1 indicates that there is no row currently in edit.
        private int rowInEdit = -1;

        public AssignLabels()
        {
            InitializeComponent();

            this.dgvVars.CellValueNeeded += DgvVars_CellValueNeeded;

            FullList = DBAction.GetVarNameUsage();

            cboGoToVar.DataSource = Globals.AllRefVarNames;
            cboGoToVar.DisplayMember = "RefVarName";
            cboGoToVar.ValueMember = "RefVarName";

            toolStripLabelType.ComboBox.DataSource = new List<string> { "Domain", "Topic", "Content", "Product" };
            toolStripLabelType.ComboBox.SelectedItem = null;
            
        }

        public AssignLabels (string refVarName) : this()
        {
            GoToVar(refVarName);
        }

        #region DataGridView Events
        /// <summary>
        /// Set the cell's value from the memoryCache based on the name of the column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvVars_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            VariableNameSurveys item = memoryCache.RetrieveRow(e.RowIndex);

            if (item == null) return;

            switch (this.dgvVars.Columns[e.ColumnIndex].Name)
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

        /// <summary>
        /// Set the underlying object's property to the edited value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvVars_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            VariableName item = memoryCache.RetrieveRow(e.RowIndex);

            // Set the appropriate property to the cell value entered.
            switch (this.dgvVars.Columns[e.ColumnIndex].Name)
            {
                case "VarLabel":
                    String newValue = e.Value as String;
                    item.VarLabel = newValue;
                    break;
                case "Content":
                    ContentLabel newContent = Globals.AllContentLabels.Where(x => x.ID == (int)e.Value).FirstOrDefault();
                    item.Content = newContent;
                    break;
                case "Topic":
                    TopicLabel newTopic = Globals.AllTopicLabels.Where(x => x.ID == (int)e.Value).FirstOrDefault();
                    item.Topic = newTopic;
                    break;
                case "Domain":
                    DomainLabel newDomain = Globals.AllDomainLabels.Where(x => x.ID == (int)e.Value).FirstOrDefault();
                    item.Domain = newDomain;
                    break;
                case "Product":
                    ProductLabel newProduct = Globals.AllProductLabels.Where(x => x.ID == (int)e.Value).FirstOrDefault();
                    item.Product = newProduct;
                    break;
            }

            rowInEdit = e.RowIndex;
        }

        private void DgvVars_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            VariableName item = memoryCache.RetrieveRow(e.RowIndex);

            if (item == null)
                return;

            if (e.RowIndex != rowInEdit)
                return;

            DBAction.UpdateLabels(item);

            rowInEdit = -1;

        }

        private void DgvVars_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            // If the user has canceled the edit of an existing row,
            // release the corresponding Customer object.
           // this.varNameEdit = null;
            this.rowInEdit = -1;
        }

        private void dgvVars_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

        #region Events

        private void AssignLabels_Load(object sender, EventArgs e)
        {
            AddGridColumns();
            SetupWithObjects(FullList);

            this.dgvVars.CellValuePushed += DgvVars_CellValuePushed;
            this.dgvVars.RowValidated += DgvVars_RowValidated;
            this.dgvVars.CancelRowEdit += DgvVars_CancelRowEdit;

            toolStripLabelType.ComboBox.SelectedIndexChanged += toolStripLabelType_SelectedIndexChanged;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripLabelLibrary_Click(object sender, EventArgs e)
        {
            frmLabelLibrary frm = new frmLabelLibrary();
            frm.ShowDialog();
        }

        private void toolStripUnusedVars_Click(object sender, EventArgs e)
        {
            string pattern = dgvVars.CurrentRow.Cells[0].Value.ToString().Substring(0, 3);

            VarNameUsage frm = new VarNameUsage(pattern);
            frm.Tag = 1;
            FormManager.AddPopup(frm);
        }

        private void toolStripFilterVars_Click(object sender, EventArgs e)
        {
            AssignLabelsFilter frm = new AssignLabelsFilter();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                if (frm.SelectedVars.Count>0)
                    FilterVars(frm.SelectedVars);
                else
                    FilterRefVars(frm.SelectedRefVars);
            }
            
        }

        private void toolStripLabelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripLabelType.ComboBox.SelectedItem == null)
                return;

            string labelType = (string)toolStripLabelType.ComboBox.SelectedItem;

            DisplayInconsistentLabels(labelType);
        }

        private void toolStripDisplayBtn_Click(object sender, EventArgs e)
        {
            DisplayQuestion();
        }

        private void toolStripExportBtn_Click(object sender, EventArgs e)
        {
            ExportQuestion();
        }

        private void cboGoToVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoToVar.SelectedItem == null)
                return;

            GoToVar(((RefVariableName)cboGoToVar.SelectedItem).RefVarName);
        }

        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void cmdClearFilter_Click(object sender, EventArgs e)
        {
            chkFilterContent.Checked = false;

            ClearFilter();
        }

        private void AssignLabels_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Remove(this);
        }
        #endregion

        #region Methods

        // Create an ObjectDataRetriever and use it to create an ObjectCache object
        // and to initialize the DataGridView rows.
        private void SetupWithObjects(List<VariableNameSurveys> source)
        {
            try
            {
                int rowCount = 16;
                if (source.Count < 16)
                    rowCount = source.Count;

                dgvVars.RowCount = 0;

                ObjectDataRetriever<VariableNameSurveys> retriever = new ObjectDataRetriever<VariableNameSurveys>(source);
                memoryCache = new ObjectCache<VariableNameSurveys>(retriever, rowCount);

                this.dgvVars.RowCount = retriever.RowCount;
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
            DataGridViewTextBoxColumn chRefVarName = new DataGridViewTextBoxColumn();
            chRefVarName.Name = "RefVarName";
            chRefVarName.HeaderText = "refVar";
            chRefVarName.Width = 80;
            chRefVarName.ReadOnly = true;
            dgvVars.Columns.Add(chRefVarName);

            DataGridViewTextBoxColumn chSurveys = new DataGridViewTextBoxColumn();
            chSurveys.Name = "Surveys";
            chSurveys.HeaderText = "Surveys";
            chSurveys.Width = 250;
            chSurveys.ReadOnly = true;
            dgvVars.Columns.Add(chSurveys);

            DataGridViewTextBoxColumn chVarName = new DataGridViewTextBoxColumn();
            chVarName.Name = "VarName";
            chVarName.HeaderText = "VarName";
            chVarName.Width = 80;
            chVarName.ReadOnly = true;
            dgvVars.Columns.Add(chVarName);

            DataGridViewTextBoxColumn chVarLabel = new DataGridViewTextBoxColumn();
            chVarLabel.Name = "VarLabel";
            chVarLabel.HeaderText = "VarLabel";
            chVarLabel.Width = 250;
            dgvVars.Columns.Add(chVarLabel);

            DataGridViewComboBoxColumn chTopic = new DataGridViewComboBoxColumn();
            chTopic.Name = "Topic";
            chTopic.DataSource = new List<TopicLabel>(Globals.AllTopicLabels);
            chTopic.DisplayMember = "LabelText";
            chTopic.ValueMember = "ID";
            chTopic.Width = 200;
            dgvVars.Columns.Add(chTopic);

            DataGridViewComboBoxColumn chContent = new DataGridViewComboBoxColumn();
            chContent.Name = "Content";
            chContent.DataSource = new List<ContentLabel>(Globals.AllContentLabels);
            chContent.DisplayMember = "LabelText";
            chContent.ValueMember = "ID";
            chContent.Width = 200;
            dgvVars.Columns.Add(chContent);

            DataGridViewComboBoxColumn chProduct = new DataGridViewComboBoxColumn();
            chProduct.Name = "Product";
            chProduct.DataSource = new List<ProductLabel>(Globals.AllProductLabels);
            chProduct.DisplayMember = "LabelText";
            chProduct.ValueMember = "ID";
            chProduct.Width = 100;
            dgvVars.Columns.Add(chProduct);

            DataGridViewComboBoxColumn chDomain = new DataGridViewComboBoxColumn();
            chDomain.Name = "Domain";
            chDomain.DataSource = new List<DomainLabel>(Globals.AllDomainLabels);
            chDomain.DisplayMember = "LabelText";
            chDomain.ValueMember = "ID";
            chDomain.Width = 125;
            dgvVars.Columns.Add(chDomain);
        }

        /// <summary>
        /// Go to the row containing the refVarName.
        /// </summary>
        /// <param name="refVarName"></param>
        private void GoToVar(string refVarName)
        {
            if (dgvVars.Rows.Count == 0)
                return;

            int index = -1;
            for(int i =0; i < Globals.AllVarNames.Count; i++)
            {
                if (Globals.AllVarNames[i].RefVarName.Equals(refVarName))
                {
                    index = i;
                    break;
                }
            }
            dgvVars.FirstDisplayedScrollingRowIndex = index;
        }

        private void FilterVars(List<VariableName> vars)
        {
            List<VariableNameSurveys> filteredList = FullList.Where(x => vars.Contains(x)).ToList();
            if (filteredList.Count > 0)
            {
                SetupWithObjects(filteredList);
                txtCurrentFilter.Text = "VarName is one of (" + string.Join(", ", vars) + ")";
            }
        }

        private void FilterRefVars(List<RefVariableName> vars)
        {
            List<VariableNameSurveys> filteredList = FullList.Where(x => vars.Contains(x)).ToList();
            if (filteredList.Count > 0)
            {
                SetupWithObjects(filteredList);
                txtCurrentFilter.Text = "RefVarName is one of (" + string.Join(", ", vars) + ")";
            }
        }

        private void UpdateFilter()
        {
            VariableNameSurveys item = memoryCache.RetrieveRow(dgvVars.CurrentRow.Index);
            List<VariableNameSurveys> filteredList = FullList; ;
            StringBuilder filter = new StringBuilder();

            if (chkFilterPrefix.Checked)
            {
                filter.AppendLine("Prefix = " + item.RefVarName.Substring(0, 2));
                filteredList = filteredList.Where(x => x.Prefix.Equals(item.Prefix)).ToList();
            }
            if (chkFilterRefVar.Checked)
            {
                filter.AppendLine("RefVarName = " + item.RefVarName);
                filteredList = filteredList.Where(x => x.RefVarName.Equals(item.RefVarName)).ToList();
            }
            if (chkFilterVarLabel.Checked)
            {
                filter.AppendLine("VarLabel = " + item.VarLabel);
                filteredList = filteredList.Where(x => x.VarLabel.Equals(item.VarLabel)).ToList();
            }
            if (chkFilterDomain.Checked)
            { 
                filter.AppendLine("Domain = " + item.Domain.LabelText);
                filteredList = filteredList.Where(x => x.Domain.ID.Equals(item.Domain.ID)).ToList();
            }
            if (chkFilterTopic.Checked)
            {
                filter.AppendLine("Topic = " + item.Topic.LabelText);
                filteredList = filteredList.Where(x => x.Topic.ID.Equals(item.Topic.ID)).ToList();
            }
            if (chkFilterContent.Checked)
            {
                filter.AppendLine("Content = " + item.Content.LabelText);
                filteredList = filteredList.Where(x => x.Content.ID.Equals(item.Content.ID)).ToList();
            }
            if (chkFilterProduct.Checked)
            {
                filter.AppendLine("Product = " + item.Product.LabelText);
                filteredList = filteredList.Where(x => x.Product.ID.Equals(item.Product.ID)).ToList();
            }

            if (filteredList.Count > 0)
            {
                SetupWithObjects(filteredList);
                txtCurrentFilter.Text = filter.ToString();
            }
        }

        private void ClearFilter()
        {
            UncheckFilters();
            txtCurrentFilter.Text = string.Empty;
            SetupWithObjects(FullList);
        }

        private void UncheckFilters()
        {
            chkFilterContent.CheckedChanged -= Filter_CheckedChanged;
            chkFilterContent.Checked = false;
            chkFilterContent.CheckedChanged += Filter_CheckedChanged;

            chkFilterTopic.CheckedChanged -= Filter_CheckedChanged;
            chkFilterTopic.Checked = false;
            chkFilterTopic.CheckedChanged += Filter_CheckedChanged;

            chkFilterDomain.CheckedChanged -= Filter_CheckedChanged;
            chkFilterDomain.Checked = false;
            chkFilterDomain.CheckedChanged += Filter_CheckedChanged;

            chkFilterProduct.CheckedChanged -= Filter_CheckedChanged;
            chkFilterProduct.Checked = false;
            chkFilterProduct.CheckedChanged += Filter_CheckedChanged;

            chkFilterPrefix.CheckedChanged -= Filter_CheckedChanged;
            chkFilterPrefix.Checked = false;
            chkFilterPrefix.CheckedChanged += Filter_CheckedChanged;

            chkFilterRefVar.CheckedChanged -= Filter_CheckedChanged;
            chkFilterRefVar.Checked = false;
            chkFilterRefVar.CheckedChanged += Filter_CheckedChanged;

            chkFilterVarLabel.CheckedChanged -= Filter_CheckedChanged;
            chkFilterVarLabel.Checked = false;
            chkFilterVarLabel.CheckedChanged += Filter_CheckedChanged;
        }

        private void DisplayQuestion()
        {
            VariableNameSurveys item = memoryCache.RetrieveRow(dgvVars.CurrentRow.Index);

            List<SurveyQuestion> questions = DBAction.GetVarNameQuestions(item.VarName);

            if (frmQuestionViewer == null || frmQuestionViewer.IsDisposed)
            {
                frmQuestionViewer = new QuestionViewer(questions);
                frmQuestionViewer.Owner = this;
                frmQuestionViewer.Show();
            }
            else
            {
                frmQuestionViewer.Focus();
            }

        }

        private void ExportQuestion()
        {
            VariableNameSurveys item = memoryCache.RetrieveRow(dgvVars.CurrentRow.Index);

            if (item == null)
            {
                MessageBox.Show("No VarNames to export!");
                return;
            }

            List<SurveyQuestion> questions = DBAction.GetVarNameQuestions(item.VarName);

            bool q, t, c, f;

            q = toolStripQ.Checked;
            t = toolStripT.Checked;
            c = toolStripC.Checked;
            f = toolStripF.Checked;

            

            QuestionReport report = new QuestionReport();
            report.SelectedSurvey = null;
            report.Questions = questions;
            report.IncludeQuestion = q;
            report.IncludeComments = c;
            report.IncludeTranslation = t;
            report.IncludeFilters = f;

            report.CreateReport();
        }

        private void DisplayInconsistentLabels(string type)
        {

            List<VariableNameSurveys> filteredList = new List<VariableNameSurveys>();

            // for the given label type, make groups of refVarNames and the labels
            // for every group whose refVarname appears multiple times in the groupings, add to the filtered list

            switch (type)
            {
                case "Domain":
                    
                    var groupedDomains = FullList.GroupBy(x => new { x.RefVarName, x.Domain.ID })
                        .Select(group => new { VariableName = group.Key, Items = group.ToList() }).ToList();

                    foreach (var group in groupedDomains)
                    {
                        string groupVarName = group.VariableName.RefVarName;
                        if (groupedDomains.Where(x=>x.VariableName.RefVarName.Equals(groupVarName)).Count()>1)
                            filteredList.AddRange(group.Items);
                    }
                    break;
                case "Topic":
                    var groupedTopics = FullList.GroupBy(x => new { x.RefVarName, x.Topic.ID })
                        .Select(group => new { VariableName = group.Key, Items = group.ToList() }).ToList();

                    foreach (var group in groupedTopics)
                    {
                        string groupVarName = group.VariableName.RefVarName;
                        if (groupedTopics.Where(x => x.VariableName.RefVarName.Equals(groupVarName)).Count() > 1)
                            filteredList.AddRange(group.Items);
                    }
                    break;
                case "Content":
                    var groupedContent = FullList.GroupBy(x => new { x.RefVarName, x.Content.ID })
                        .Select(group => new { VariableName = group.Key, Items = group.ToList() }).ToList();

                    foreach (var group in groupedContent)
                    {
                        string groupVarName = group.VariableName.RefVarName;
                        if (groupedContent.Where(x => x.VariableName.RefVarName.Equals(groupVarName)).Count() > 1)
                            filteredList.AddRange(group.Items);
                    }
                    break;
                case "Product":
                    var groupedProducts = FullList.GroupBy(x => new { x.RefVarName, x.Product.ID })
                        .Select(group => new { VariableName = group.Key, Items = group.ToList() }).ToList();

                    foreach (var group in groupedProducts)
                    {
                        string groupVarName = group.VariableName.RefVarName;
                        if (groupedProducts.Where(x => x.VariableName.RefVarName.Equals(groupVarName)).Count() > 1)
                            filteredList.AddRange(group.Items);
                    }
                    break;
                default:
                    return;
            }
            if (filteredList.Count() > 0)
            {
                SetupWithObjects(filteredList);
            }
        }
        #endregion

        
    }
}
