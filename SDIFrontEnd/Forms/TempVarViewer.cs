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
            string survey = ((Survey)cboSurveyFilter.SelectedItem).SurveyCode;
            ListTempVars(survey);
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
            FormManager.RemovePopup(this);
        }
        #endregion

        #region Methods

        private void ListAllTempVars()
        {
            List<VariableNameSurveys> list = new List<VariableNameSurveys>();
            foreach (string s in Globals.AllTempPrefixes)
                list.AddRange(DBAction.GetVarNamesPrefix(s));

            dgvTempVars.DataSource = list;
        }

        private void ListTempVars(string survey)
        {
            List<VariableNameSurveys> list = new List<VariableNameSurveys>();
            string prefix = "";
            foreach (RegionRecord r in Globals.AllRegions)
                foreach (StudyRecord st in r.Studies)
                    foreach (StudyWaveRecord w in st.Waves)
                        foreach (SurveyRecord surv in w.Surveys)
                            if (surv.SurveyCode.Equals(survey))
                                prefix = r.TempVarPrefix;


            if (!string.IsNullOrEmpty(prefix))
                list.AddRange(DBAction.GetVarNamesPrefix(prefix));

            dgvTempVars.DataSource = list;
        }

        #endregion
    }
}
