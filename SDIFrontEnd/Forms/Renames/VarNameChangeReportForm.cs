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
using ITCReportLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class VarNameChangeReportForm : Form
    {
        private enum ReportScope { Survey, Wave }

        ReportScope Scope { get; set; }

        public VarNameChangeReportForm()
        {
            InitializeComponent();
        }

        #region Methods

        private void GetReportDetails(out List<VarNameChange> changes, out string title)
        {
            title = string.Empty;
            changes = new List<VarNameChange>();
            if (Scope == ReportScope.Survey)
            {
                foreach (Survey survey in lstSelected.Items)
                {
                    changes.AddRange(DBAction.GetVarNameChanges(survey));
                }
                title = "VarName Change Report - " + string.Join(", ", lstSelected.Items.Cast<Survey>().Select(x => x.SurveyCode));
            }
            else if (Scope == ReportScope.Wave)
            {
                foreach (StudyWave wave in lstSelected.Items)
                {
                    changes.AddRange(DBAction.GetVarNameChanges(wave));
                }
                title = "VarName Change Report - " + string.Join(", ", lstSelected.Items.Cast<StudyWave>().Select(x => x.WaveCode));
            }

            changes = changes.OrderBy(x => x.ChangeDate).ToList();
        }

        private DataTable CreateReportSource(List<VarNameChange> changes)
        {
            DataTable data = CreateReportTable();
            FillReportTable(data, changes);

            return data;
        }

        private void FillReportTable(DataTable data, List<VarNameChange> changes)
        {
            // get wordings if needed
            List<SurveyQuestion> referenceQs = new List<SurveyQuestion>();
            Survey s = new Survey();
            if (chkIncludeWordings.Checked)
            {
                s = (Survey)lstSelected.Items[0];
                referenceQs.AddRange(DBAction.GetSurveyQuestions(s));
            }

            DateTime? lowerBound;
            if (dtpLower.Checked)
                lowerBound = dtpLower.Value;
            else
                lowerBound = null;

            DateTime? upperBound;
            if (dtpUpper.Checked)
                upperBound = dtpUpper.Value;
            else
                upperBound = null;

            foreach (VarNameChange change in changes)
            {
                // skip headings
                if (chkExcludeHeadings.Checked && (change.OldName.StartsWith("Z") || change.NewName.StartsWith("Z")))
                    continue;
                // skip hidden changes
                if (chkExcludeHidden.Checked && change.HiddenChange)
                    continue;
                // skip pre-fw changes
                if (chkExcludePreFW.Checked && change.PreFWChange)
                    continue;
                // skip changes out of date range
                if (lowerBound != null && change.ChangeDate < lowerBound)
                    continue;
                if (upperBound != null && change.ChangeDate > upperBound)
                    continue;

                DataRow newrow = data.NewRow();

                newrow["Old Name"] = change.OldName;
                newrow["New Name"] = change.NewName;

                if (chkIncludeVarLabel.Checked)
                {
                    VariableName matchingVar = Globals.AllVarNames.FirstOrDefault(x => x.VarName.Equals(change.NewName));
                    if (matchingVar != null)
                        newrow["VarLabel"] = matchingVar.VarLabel;
                }

                if (chkIncludeWordings.Checked)
                {
                    SurveyQuestion matchingQ = referenceQs.FirstOrDefault(x => x.VarName.VarName.Equals(change.NewName) && x.SurveyCode.Equals(s.SurveyCode));
                    if (matchingQ != null)
                        newrow["Wording (" + s.SurveyCode + ")"] = matchingQ.GetQuestionTextHTML();
                }

                newrow["Change Date"] = change.ChangeDate.ToString("dd-MMM-yyyy");
                newrow["Rationale"] = change.Rationale;

                if (chkIncludeAllSurveys.Checked)
                    newrow["Surveys"] = change.GetSurveys();
                else
                {
                    newrow["Surveys"] = GetAffectedSurveysList(change);
                }
                data.Rows.Add(newrow);
            }
        }

        private string GetAffectedSurveysList(VarNameChange change)
        {
            if (Scope == ReportScope.Survey)
            {
                List<Survey> surveys = lstSelected.Items.Cast<Survey>().ToList();
                return string.Join(", ", change.SurveysAffected.Where(x => surveys.Any(y => y.SurveyCode.Equals(x.SurveyCode))).Select(x => x.SurveyCode));
            }
            else if (Scope == ReportScope.Wave)
            {
                List<StudyWave> waves = lstSelected.Items.Cast<StudyWave>().ToList();
                List<Survey> surveys = waves.SelectMany(x => x.Surveys).ToList();
                return string.Join(", ", change.SurveysAffected.Where(x => surveys.Any(y => y.SurveyCode.Equals(x.SurveyCode))).Select(x => x.SurveyCode));
            }
            else
            {
                return string.Empty;
            }
        }

        private DataTable CreateReportTable()
        {
            DataTable data = new DataTable();

            if (rbBoth.Checked)
            {
                data.Columns.Add(new DataColumn("Old Name", Type.GetType("System.String")));
                data.Columns.Add(new DataColumn("Old RefName", Type.GetType("System.String")));
                data.Columns.Add(new DataColumn("New Name", Type.GetType("System.String")));
                data.Columns.Add(new DataColumn("New RefName", Type.GetType("System.String")));
            }
            else if (rbVarName.Checked)
            {
                data.Columns.Add(new DataColumn("Old Name", Type.GetType("System.String")));
                data.Columns.Add(new DataColumn("New Name", Type.GetType("System.String")));
            }
            else if (rbRefVarName.Checked)
            {
                data.Columns.Add(new DataColumn("Old RefName", Type.GetType("System.String")));
                data.Columns.Add(new DataColumn("New RefName", Type.GetType("System.String")));
            }

            if (chkIncludeVarLabel.Checked)
                data.Columns.Add(new DataColumn("VarLabel", Type.GetType("System.String")));
            if (chkIncludeWordings.Checked)
            {
                Survey s = (Survey)lstSelected.Items[0];
                data.Columns.Add(new DataColumn("Wording (" + s.SurveyCode + ")", Type.GetType("System.String")));
            }

            data.Columns.Add(new DataColumn("Change Date", Type.GetType("System.String")));
            data.Columns.Add(new DataColumn("Rationale", Type.GetType("System.String")));
            data.Columns.Add(new DataColumn("Surveys", Type.GetType("System.String")));
            return data;
        }
        #endregion

        #region Events

        private void VarNameChangeReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void rbSurvey_Click(object sender, EventArgs e)
        {
            cboSurveyOrWave.DataSource = null;
            cboSurveyOrWave.DisplayMember = "SurveyCode";
            cboSurveyOrWave.ValueMember = "SID";
            cboSurveyOrWave.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurveyOrWave.SelectedItem = null;
            lstSelected.Items.Clear();
            Scope = ReportScope.Survey;
        }

        private void rbWave_Click(object sender, EventArgs e)
        {
            cboSurveyOrWave.DataSource = null;
            cboSurveyOrWave.DisplayMember = "WaveCode";
            cboSurveyOrWave.ValueMember = "ID";
            cboSurveyOrWave.DataSource = new List<StudyWave>(Globals.AllWaves);
            cboSurveyOrWave.SelectedItem = null;
            chkIncludeWordings.Enabled = false;
            chkIncludeWordings.Checked = false;
            lstSelected.Items.Clear();
            Scope = ReportScope.Wave;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (cboSurveyOrWave.SelectedItem == null)
                return;

            if (!lstSelected.Items.Contains(cboSurveyOrWave.SelectedItem))
                lstSelected.Items.Add(cboSurveyOrWave.SelectedItem);

            chkIncludeWordings.Enabled = lstSelected.Items.Count == 1 && Scope == ReportScope.Survey;
            chkIncludeWordings.Checked = false;
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            lstSelected.Items.Remove(lstSelected.SelectedItem);

            chkIncludeWordings.Enabled = lstSelected.Items.Count == 1 && Scope == ReportScope.Survey;
            chkIncludeWordings.Checked = false;
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (lstSelected.Items.Count == 0) return;

            GetReportDetails(out List<VarNameChange> changes, out string title);

            DataTable data = CreateReportSource(changes);

            DataTableReport rpt = new DataTableReport(data, title);
            rpt.CreateReport();
            rpt.OutputReport();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    

        
    }
}
