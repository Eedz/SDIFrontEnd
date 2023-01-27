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
    public partial class VarNameUsageReport : Form
    {
        public VarNameUsageReport()
        {
            InitializeComponent();

            cboPrefix.DisplayMember = "Prefix";
            cboPrefix.ValueMember = "ID";
            cboPrefix.DataSource = DBAction.GetVarPrefixes();
            cboPrefix.SelectedItem = null;
        }

        #region Events
        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (cboPrefix.SelectedItem == null)
                return;

            // create a list from lower to upper of all variables in the prefix
            VariablePrefixRecord prefix = (VariablePrefixRecord)cboPrefix.SelectedItem;
            int lower = Int32.Parse(txtLower.Text);
            int upper = Int32.Parse(txtUpper.Text);

            DataTable report = GetData(prefix, lower, upper);

            // then get all varnames in the same range
            // fill in question/surveys fields for used ones

            VarUsageReport rpt = new VarUsageReport(report, prefix.Prefix + " VarName Usage");
            rpt.CreateReport();
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports");
        }

        private void txtLower_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLower.Text))
                return;

            string txt = txtLower.Text;

            if (!Int32.TryParse(txt, out int number))
            {
                MessageBox.Show("Enter a value between 0-999");
                e.Cancel = true;
            }
        }

        private void txtUpper_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUpper.Text))
                return;

            string txt = txtUpper.Text;

            if (!Int32.TryParse(txt, out int number))
            {
                MessageBox.Show("Enter a value between 0-999");
                e.Cancel = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.RemovePopup(this);
        }
        #endregion

        private DataTable GetData(VariablePrefixRecord prefix, int lower = 0, int upper = 999)
        {
            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("RefVarName", Type.GetType("System.String")));
            data.Columns.Add(new DataColumn("Question", Type.GetType("System.String")));
            data.Columns.Add(new DataColumn("Surveys", Type.GetType("System.String")));





            // create the basic list of vars (0-999)
            for (int i = lower; i <= upper; i++)
            {
                string refVarName = prefix.Prefix + i.ToString("000");

                // if there is range information starting at this number, add a row to show it
                VariableRange range = prefix.Ranges.FirstOrDefault(x => x.LowerInt() == i);
                if (range!=null)
                {
                    DataRow newrow = data.NewRow();
                    newrow["Question"] = range.Lower + " - " + range.Upper + " " + range.Description;
                    data.Rows.Add(newrow);
                }

                // add in actual wordings for this varname
                var actual = DBAction.GetRefVarNameQuestions(refVarName);

                // if none are found, add just the varname to the table
                if (actual.Count == 0)
                {
                    DataRow newrow = data.NewRow();
                    newrow["RefVarName"] = prefix.Prefix + i.ToString("000");
                    data.Rows.Add(newrow);
                }
                else
                {
                    // group the matched varnames by the wordings to get each unique wording
                    var groups = actual.GroupBy(x => new { x.PrePNum, x.PreINum, x.PreANum, x.LitQNum, x.PstINum, x.PstPNum, x.RespNameLower, x.NRNameLower })
                        .Select(group => new { SurveyQuestion = group.Key, Items = group.ToList() });

                    foreach (var group in groups)
                    {
                        DataRow newrow = data.NewRow();
                        string surveyList = "";
                        foreach (var item in group.Items)
                        {
                            surveyList += item.SurveyCode + ", ";
                        }
                        newrow["RefVarName"] = group.Items[0].VarName.RefVarName;
                        newrow["Question"] = group.Items[0].GetQuestionText();
                        newrow["Surveys"] = surveyList;
                        data.Rows.Add(newrow);
                    }
                }
            }

            return data;
        }

        
    }
}
