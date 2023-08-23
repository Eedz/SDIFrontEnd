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

            dgvTempVars.AutoGenerateColumns = false;

            chSurveyList.DataPropertyName = "SurveyList";
            chVarName.DataPropertyName = "VarName";
            chVarLabel.DataPropertyName = "VarLabel";
            chContent.DataPropertyName = "Content";
            chTopic.DataPropertyName = "Topic";
            chDomain.DataPropertyName = "Domain";
            chProduct.DataPropertyName = "Product";

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
