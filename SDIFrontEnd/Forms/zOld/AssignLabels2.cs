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

using System.Configuration;
using System.Data.SqlClient;

namespace SDIFrontEnd
{
    /// <summary>
    /// This version of the form uses a table for a cache.
    /// </summary>
    public partial class AssignLabels2 : Form
    {

        public string key;

        private Cache memoryCache;

        List<VariableName> VarNames;

        // Declare a Customer object to store data for a row being edited.
        private VariableName varNameEdit;

        // Declare a variable to store the index of a row being edited.
        // A value of -1 indicates that there is no row currently in edit.
        private int rowInEdit = -1;

        // Declare a variable to indicate the commit scope.
        // Set this value to false to use cell-level commit scope.
        //private bool rowScopeCommit = true;

        public AssignLabels2()
        {
            InitializeComponent();


            this.dgvVars.CellValueNeeded += DgvVars_CellValueNeeded;

            // Create a DataRetriever and use it to create a Cache object
            // and to initialize the DataGridView columns and rows.
            try
            {
                DataRetriever retriever = new DataRetriever(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString, "qryVariableInfo");
                memoryCache = new Cache(retriever, 8);
                foreach (DataColumn column in retriever.Columns)
                {
                    dgvVars.Columns.Add(column.ColumnName, column.ColumnName);
                }
                this.dgvVars.RowCount = retriever.RowCount;
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection could not be established. Verify that the connection string is valid.");

            }



            this.dgvVars.CellValuePushed += DgvVars_CellValuePushed;

            this.dgvVars.RowValidated += DgvVars_RowValidated;

            this.dgvVars.CellValidated += DgvVars_CellValidated;

            //this.dgvVars.CancelRowEdit += DgvVars_CancelRowEdit;


            VarNames = Globals.AllVarNames;

            cboGoToVar.DataSource = new List<RefVariableName>(Globals.AllRefVarNames);
            cboGoToVar.DisplayMember = "RefVarName";
            cboGoToVar.ValueMember = "RefVarName";

            dgvVars.AutoGenerateColumns = false;


            chRefVarname.DataPropertyName = "refVarName";
            //chSurveys.DataPropertyName = "SurveyList";

            chVarLabel.DataPropertyName = "VarLabel";

            chTopic.DataSource = new List<TopicLabel>(Globals.AllTopicLabels);
            chTopic.DisplayMember = "LabelText";
            chTopic.ValueMember = "ID";
            chTopic.DataPropertyName = "Topic";

            chContent.DataSource = new List<ContentLabel>(Globals.AllContentLabels);
            chContent.DisplayMember = "LabelText";
            chContent.ValueMember = "ID";
            chContent.DataPropertyName = "Content";

            chProduct.DataSource = new List<ProductLabel>(Globals.AllProductLabels);
            chProduct.DisplayMember = "LabelText";
            chProduct.ValueMember = "ID";
            chProduct.DataPropertyName = "Product";

            chDomain.DataSource = new List<DomainLabel>(Globals.AllDomainLabels);
            chDomain.DisplayMember = "LabelText";
            chDomain.ValueMember = "ID";
            chDomain.DataPropertyName = "Domain";



            dgvVars.DataSource = VarNames;

        }

        // Create a DataRetriever and use it to create a Cache object
        // and to initialize the DataGridView columns and rows.
        void SetupWithTable()
        {
            try
            {
                DataRetriever retriever = new DataRetriever(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString, "qryVariableInfo");
                memoryCache = new Cache(retriever, 8);

                for (int i = 0; i < retriever.Columns.Count; i++)
                {
                    string columnName = retriever.Columns[i].ColumnName;
                    switch (columnName)
                    {
                        case "refVarName":
                        case "VarName":
                        case "VarLabel":
                            dgvVars.Columns.Add(columnName, columnName);
                            break;
                        case "ContentNum":
                            DataGridViewComboBoxColumn contentColumn = new DataGridViewComboBoxColumn();
                            contentColumn.DataSource = new List<ContentLabel>(Globals.AllContentLabels);
                            contentColumn.DisplayMember = "LabelText";
                            contentColumn.ValueMember = "ID";
                            contentColumn.HeaderText = "Content";
                            dgvVars.Columns.Add(contentColumn);
                            break;
                        case "TopicNum":
                            DataGridViewComboBoxColumn topicColumn = new DataGridViewComboBoxColumn();
                            topicColumn.DataSource = new List<TopicLabel>(Globals.AllTopicLabels);
                            topicColumn.DisplayMember = "LabelText";
                            topicColumn.ValueMember = "ID";
                            topicColumn.HeaderText = "Topic";
                            dgvVars.Columns.Add(topicColumn);
                            break;
                        case "DomainNum":
                            DataGridViewComboBoxColumn domainColumn = new DataGridViewComboBoxColumn();
                            domainColumn.DataSource = new List<DomainLabel>(Globals.AllDomainLabels);
                            domainColumn.DisplayMember = "LabelText";
                            domainColumn.ValueMember = "ID";
                            domainColumn.HeaderText = "Domain";
                            dgvVars.Columns.Add(domainColumn);
                            break;
                        case "ProductNum":
                            DataGridViewComboBoxColumn productColumn = new DataGridViewComboBoxColumn();
                            productColumn.DataSource = new List<ProductLabel>(Globals.AllProductLabels);
                            productColumn.DisplayMember = "LabelText";
                            productColumn.ValueMember = "ID";
                            productColumn.HeaderText = "Product";
                            dgvVars.Columns.Add(productColumn);
                            break;
                        default:
                            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                            textColumn.HeaderText = columnName;
                            textColumn.Visible = false;
                            dgvVars.Columns.Add(textColumn);
                            break;
                    }

                }

                this.dgvVars.RowCount = retriever.RowCount;
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection could not be established. Verify that the connection string is valid.");

            }
        }

        private void DgvVars_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            
                // If the user has canceled the edit of an existing row,
                // release the corresponding Customer object.
                this.varNameEdit = null;
                this.rowInEdit = -1;
            
        }

        

        private void DgvVars_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (this.varNameEdit != null && e.RowIndex < this.VarNames.Count)
            {
                // Save the modified Customer object in the data store.
                this.VarNames[e.RowIndex] = this.varNameEdit;
                this.varNameEdit = null;
                this.rowInEdit = -1;
            }
            else if (this.dgvVars.ContainsFocus)
            {
                this.varNameEdit = null;
                this.rowInEdit = -1;
            }
        }

        private void DgvVars_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
           // varnameTmp = this.varNameEdit;
        }

        // not used since we are using bound mode
        private void DgvVars_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            VariableName varnameTmp = null;

            // Store a reference to the Customer object for the row being edited.
            if (e.RowIndex < this.VarNames.Count)
            {
                // If the user is editing a new row, create a new Customer object.
                //this.varNameEdit = new VariableName(((VariableName)this.VarNames[e.RowIndex]).RefVarName);

                varnameTmp = this.varNameEdit;
                this.rowInEdit = e.RowIndex;
            }
            else
            {
                varnameTmp = this.varNameEdit;
            }

            // Set the appropriate Customer property to the cell value entered.

            switch (this.dgvVars.Columns[e.ColumnIndex].Name)
            {
                case "chVarLabel":
                    String newValue = e.Value as String;
                    varnameTmp.VarLabel = newValue;
                    break;
                case "chContent":
                    ContentLabel newContent = e.Value as ContentLabel;
                    varnameTmp.Content = newContent;
                    break;
                case "chTopic":
                    TopicLabel newTopic = e.Value as TopicLabel;
                    varnameTmp.Topic = newTopic;
                    break;
                case "chDomain":
                    DomainLabel newDomain = e.Value as DomainLabel;
                    varnameTmp.Domain = newDomain;
                    break;
                case "chProduct":
                    ProductLabel newProduct = e.Value as ProductLabel;
                    varnameTmp.Product = newProduct;
                    break;


            }
        }

        // not used since we are using bound mode
        private void DgvVars_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

            //e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);

            //DataGridView dgv = (DataGridView)sender;
            //// If this is the row for new records, no values are needed.
            //if (e.RowIndex == dgv.RowCount - 1) return;

            //VariableName varTmp = null;

            //// Store a reference to the Customer object for the row being painted.
            //if (e.RowIndex == rowInEdit)
            //{
            //    varTmp = varNameEdit;
            //}
            //else
            //{
            //    varTmp = VarNames[e.RowIndex];
            //}

            // Set the cell value to paint using the Customer object retrieved.
            //switch (dgv.Columns[e.ColumnIndex].Name)
            //{
            //    case "Company Name":
            //        e.Value = customerTmp.CompanyName;
            //        break;

            //    case "Contact Name":
            //        e.Value = customerTmp.ContactName;
            //        break;
            //}
        }

        public AssignLabels2 (string refVarName) : this()
        {
            GoToVar(refVarName);
        }

        #region Events

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
            frm.Tag = "VarNameUsage";
            FormManager.AddPopup(frm);
        }

        private void toolStripFilterVars_Click(object sender, EventArgs e)
        {
            
        }

        private void cboGoToVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoToVar.SelectedItem == null)
                return;

            GoToVar(((RefVariableName)cboGoToVar.SelectedItem).RefVarName);
        }

        private void AssignLabels_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Remove(this);
        }
        #endregion

        #region Methods
        private void GoToVar(string refVarName)
        {
            int rowIndex = -1;
            dgvVars.ClearSelection();
            foreach (DataGridViewRow row in dgvVars.Rows)
            {
                // VariableName v = (VariableName)row.DataBoundItem;
                if (((VariableName)row.DataBoundItem).RefVarName.Equals(refVarName))
                {
                    rowIndex = row.Index;
                    row.Selected = true;
                    dgvVars.CurrentCell = dgvVars.Rows[row.Index].Cells[0];

                    dgvVars.Focus();

                    break;
                }
            }
        }

        #endregion

        private void dgvVars_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dgvVars_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        
    }

    
}
