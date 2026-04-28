
using ITCLib;
using ITCReportLib;
using OpenXMLHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FM = FormManager;
namespace SDIFrontEnd
{
    public partial class ResponseSetReport : Form
    {
        BindingList<ResponseSet> _allSets = new BindingList<ResponseSet>();
        List<Survey> _surveyList;
        BindingList<VariableName> _variableNames = new BindingList<VariableName>();

        BindingList<Survey> _selectedSurveys = new BindingList<Survey>();
        BindingList<ResponseSet> _selectedSets = new BindingList<ResponseSet>();
        BindingList<VariableName> _selectedVariableNames = new BindingList<VariableName>();




        public ResponseSetReport(List<Survey> surveyList)
        {
            InitializeComponent();
            _surveyList = surveyList;
        }

        private void ResponseSetReport_Load(object sender, EventArgs e)
        {
            cboSurveys.DisplayMember = "SurveyCode";
            cboSurveys.DataSource = _surveyList;
            cboSets.DisplayMember = "RespSetName";
            cboSets.DataSource = _allSets;
            cboVars.DisplayMember = "VarName";
            cboVars.DataSource = _variableNames;

            lstSelectedSets.DisplayMember = "RespSetName";
            lstSelectedSets.DataSource = _selectedSets;
            lstSelectedVars.DataSource = _selectedVariableNames;
            lstSelectedSurveys.DataSource = _selectedSurveys;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataTable = Utilities.DataGridViewToDataTable(dgvResponseSets);

            DataTableReport rpt = new DataTableReport(dataTable, "Response Set Report");

            rpt.CreateReport();
            rpt.OutputReport();
        }

        private void cmdAddSurvey_Click(object sender, EventArgs e)
        {
            if (cboSurveys.SelectedItem == null) return;

            if (!_selectedSurveys.Contains((Survey)cboSurveys.SelectedItem))
            {
                _selectedSurveys.Add((Survey)cboSurveys.SelectedItem);
                UpdateVars();
                UpdateSets();
                UpdateAllRows();
                UpdateColumns();
            }

            cboSurveys.SelectedIndex++;
            
        }

        private void cmdRemoveSurvey_Click(object sender, EventArgs e)
        {
            if (cboSurveys.SelectedItem == null) return;
            var survey = (Survey)lstSelectedSurveys.SelectedItem;
            if (_selectedSurveys.Any(x=>x.SID == survey.SID))
            {
                _selectedSurveys.Remove(survey);
                UpdateAllRows();
                UpdateColumns();
            }
            
        }

        private void cmdAddVar_Click(object sender, EventArgs e)
        {
            if (cboVars.SelectedItem == null) return;
            var varname = (VariableName)cboVars.SelectedItem;
            if (!_selectedVariableNames.Contains(varname))
            {
                _selectedVariableNames.Add(varname);
                UpdateAllRows();
                UpdateColumns();
            }

            cboVars.SelectedIndex++;
        }

        private void cmdRemoveVar_Click(object sender, EventArgs e)
        {
            if (lstSelectedVars.SelectedItem == null) return;

            var varname = (VariableName)lstSelectedVars.SelectedItem;
            if (_selectedVariableNames.Contains(varname))
            {
                _selectedVariableNames.Remove(varname);
                UpdateAllRows();
                UpdateColumns();
            }            
        }

        private void cmdAddSet_Click(object sender, EventArgs e)
        {
            if (cboSets.SelectedItem == null) return;

            if (!_selectedSets.Contains((ResponseSet)cboSets.SelectedItem))
            {
                _selectedSets.Add((ResponseSet)cboSets.SelectedItem);
                UpdateColumns();
            }
            cboSets.SelectedIndex++;
        }

        private void cmdRemoveSet_Click(object sender, EventArgs e)
        {
            if (cboSets.SelectedItem == null) return;

            var set = (ResponseSet)lstSelectedSets.SelectedItem;
            if (_selectedSets.Contains(set))
            {
                _selectedSets.Remove(set);
                RemoveColumn(set.RespSetName);
                UpdateColumns();
            }
        }

        private void ResponseSetReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        void UpdateColumns()
        {
            dgvResponseSets.Columns.Clear();

            foreach (var set in _selectedSets)
                if (!dgvResponseSets.Columns.Contains(set.RespSetName))
                {
                    var column = new DataGridViewTextBoxColumn() { Name = set.RespSetName, HeaderText = set.RespSetName, Width = 150 };
                    dgvResponseSets.Columns.Add(column);
                    UpdateColumnRows(set);
                }

            // for any questions that do not use any of the sets, add a column for those sets
            if (_selectedVariableNames.Count == 0) return;
            List<SearchCriterium> criteria = new List<SearchCriterium>
            {
                new SearchCriterium() 
                { 
                    Field = "Survey", Compare = Comparity.Equals, Fields = new List<string>() { "VarName" }, Criteria = _selectedVariableNames.Select(r => r.VarName).ToList() 
                }
            };
            var questions = DBAction.GetSurveyQuestions(criteria, false);

            var questionsWithoutSets = questions.Where(x => !_selectedSets.Any(s => s.RespSetName == x.RespOptionsS.RespSetName));
            var setsToAdd = questionsWithoutSets.Select(x => x.RespOptionsS).Distinct().ToList();
            foreach (var set in setsToAdd)
            {
                if (!dgvResponseSets.Columns.Contains(set.RespSetName))
                {
                    var column = new DataGridViewTextBoxColumn() { Name = set.RespSetName, HeaderText = set.RespSetName, Width = 150 };
                    dgvResponseSets.Columns.Add(column);
                    UpdateColumnRows(set);
                }
            }
        }

        void UpdateColumnRows(ResponseSet setName)
        {
            while (dgvResponseSets.Rows.Count < 2)
                dgvResponseSets.Rows.Add();
                
            

            var varNamesCell = dgvResponseSets.Rows[0].Cells[dgvResponseSets.Columns[setName.RespSetName].Index];
            var responsesCell = dgvResponseSets.Rows[1].Cells[dgvResponseSets.Columns[setName.RespSetName].Index];

            varNamesCell.Value = GetVarNamesBySet(setName.RespSetName);
            responsesCell.Value = setName.RespList.Replace("<br>", "\r\n").Replace("&nbsp;", " ")
                                    .Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
            
            dgvResponseSets.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        void UpdateAllRows()
        {
            foreach (ResponseSet setName in _selectedSets)
            {
                var varNamesCell = dgvResponseSets.Rows[0].Cells[dgvResponseSets.Columns[setName.RespSetName].Index];
                var responsesCell = dgvResponseSets.Rows[1].Cells[dgvResponseSets.Columns[setName.RespSetName].Index];

                varNamesCell.Value = GetVarNamesBySet(setName.RespSetName);
                responsesCell.Value = setName.RespList.Replace("<br>", "\r\n").Replace("&nbsp;", " ")
                                        .Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&"); 
            }
            dgvResponseSets.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        void RemoveColumn(string setname)
        {
            dgvResponseSets.Columns.Remove(setname);
        }

        string GetVarNamesBySet(string setName)
        {
            List<SearchCriterium> criteria = new List<SearchCriterium>
            {
                new SearchCriterium() { Field = "RespName", Compare = Comparity.Equals, Fields = new List<string>(){ "RespName" }, Criteria =new List<string> {setName } },
                
            };
            if (_selectedSurveys.Count > 0)
                criteria.Add(new SearchCriterium() { Field = "Survey", Compare = Comparity.Equals, Fields = new List<string>() { "Survey" }, Criteria = _selectedSurveys.Select(r => r.SurveyCode).ToList() });


            var questions = DBAction.GetSurveyQuestions(criteria, false);
            if (_selectedVariableNames.Count > 0)
                questions = questions.Where(x => _selectedVariableNames.Any(y => y.VarName == x.VarName.VarName)).ToList();

            return string.Join("\r\n", questions.Select(x=>$"{x.VarName.VarName} ({x.SurveyCode})"));
        }

        void UpdateVars()
        {
            _variableNames.Clear();
            _variableNames = new BindingList<VariableName>(DBAction.GetVarNamesFromSurveyList(_selectedSurveys.Select(s => s.SurveyCode).ToList()));
            cboVars.DataSource = _variableNames;
        }

        void UpdateSets()
        {
            _allSets.Clear();
            _allSets = new BindingList<ResponseSet>( DBAction.GetResponseSetsBySurveys(_selectedSurveys.Select(s => s.SurveyCode).ToList()));
            cboSets.DataSource = _allSets;
        }
    }
}
