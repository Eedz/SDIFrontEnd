using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class TempVarViewer : Form
    {
        public TempVarViewer()
        {
            InitializeComponent();

            cboSurveyFilter.DisplayMember = "SurveyCode";
            cboSurveyFilter.ValueMember = "SID";
            cboSurveyFilter.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurveyFilter.SelectedItem = null;
            cboSurveyFilter.SelectedIndexChanged += cboSurveyFilter_SelectedIndexChanged; ;

            ListAllTempVars();
            
        }

        #region Events 
        private void cboSurveyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSurveyFilter.SelectedItem == null)
            {
                ListAllTempVars();
                return;
            }
            
            ListTempVars((Survey)cboSurveyFilter.SelectedItem);
        }

        private void cmdClearFilter_Click(object sender, EventArgs e)
        {
            cboSurveyFilter.SelectedItem = null;
            ListAllTempVars();
        }

        private void dgvTempVars_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                switch (grid.Columns[i].Name)
                {
                    case "ID":
                    case "CountryCode":
                    case "StandardForm":
                    case "Prefix":
                    case "Number":
                    case "Suffix":
                        grid.Columns[i].Visible = false;
                        break;
                }
            }
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.RemovePopup(this);
        }
        #endregion

        #region Methods

        async private void ListAllTempVars()
        {
            List<VariableNameSurveys> list = new List<VariableNameSurveys>();
            foreach (string s in Globals.AllTempPrefixes)
                list.AddRange(await DBAction.GetVarNamesPrefixAsync(s));

            dgvTempVars.DataSource = list;
        }

        async private void ListTempVars(Survey survey)
        {
            List<VariableNameSurveys> list = new List<VariableNameSurveys>();
            string prefix = Globals.GetTempVarPrefix(survey);
         
            if (!string.IsNullOrEmpty(prefix))
                list.AddRange(await DBAction.GetVarNamesPrefixAsync(prefix));

            dgvTempVars.DataSource = list;
        }

        #endregion
    }
}
