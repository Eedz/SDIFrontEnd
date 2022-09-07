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
    public partial class VarNameChangeReportForm : Form
    {
        public VarNameChangeReportForm()
        {
            InitializeComponent();
        }

        #region Events
        private void rbSurvey_Click(object sender, EventArgs e)
        {
            cboSurveyOrWave.DataSource = null;
            cboSurveyOrWave.DisplayMember = "SurveyCode";
            cboSurveyOrWave.ValueMember = "SID";
            cboSurveyOrWave.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurveyOrWave.SelectedItem = null;
            chkIncludeWordings.Enabled = true;


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
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {

            // get change records for survey/wave
            List<VarNameChangeRecord> changes;
            if (rbSurvey.Checked)
            {
                Survey s = (Survey)cboSurveyOrWave.SelectedItem;
                changes = new List<VarNameChangeRecord>(DBAction.GetVarNameChangeBySurvey(s.SurveyCode));
            }
            else if (rbWave.Checked)
            {
                StudyWaveRecord w = (StudyWaveRecord)cboSurveyOrWave.SelectedItem;
                changes = new List<VarNameChangeRecord>(DBAction.GetVarNameChanges(w, false));

            }
            else
                return;

            DataTable data = CreateReportTable();

            FillReportTable(data, changes);

            DataTableReport rpt = new DataTableReport(data);
            rpt.CreateReport();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.Remove(this);
        }
        #endregion

        #region Methods
        private void FillReportTable(DataTable data, List<VarNameChangeRecord> changes)
        {
            List<SurveyQuestion> referenceQs = new List<SurveyQuestion>();
            Survey s = new Survey();
            if (chkIncludeWordings.Checked)
            {
                s = (Survey)cboSurveyOrWave.SelectedItem;
                referenceQs = new List<SurveyQuestion>(DBAction.GetSurveyQuestions(s));
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

            foreach (VarNameChangeRecord change in changes)
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
                        newrow["Wording (" + s.SurveyCode + ")"] = matchingQ.GetQuestionText();
                }

                newrow["Change Date"] = change.ChangeDate;
                newrow["Rationale"] = change.Rationale;
                newrow["Surveys"] = change.GetSurveysAffected();
                data.Rows.Add(newrow);
            }
        }

        private DataTable CreateReportTable()
        {
            DataTable data = new DataTable();
            //data.Columns.Add(new DataColumn("ID", Type.GetType("System.String")));

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
                Survey s = (Survey)cboSurveyOrWave.SelectedItem;
                data.Columns.Add(new DataColumn("Wording (" + s.SurveyCode + ")", Type.GetType("System.String")));
            }

            data.Columns.Add(new DataColumn("Change Date", Type.GetType("System.String")));
            data.Columns.Add(new DataColumn("Rationale", Type.GetType("System.String")));
            data.Columns.Add(new DataColumn("Surveys", Type.GetType("System.String")));
            return data;
        }
        #endregion




    }
}
