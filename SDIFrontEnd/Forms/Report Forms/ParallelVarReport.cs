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
    // TODO include range info
    // TODO range option
    public partial class ParallelVarReport : Form
    {
        public ParallelVarReport()
        {
            InitializeComponent();

            cboPrefixes.DisplayMember = "Prefix";
            cboPrefixes.ValueMember = "Prefix";
            cboPrefixes.DataSource = DBAction.GetVariablePrefixes();
            cboPrefixes.SelectedItem = null;

            for (int i = 0; i <= 900; i += 100)
            {
                dgvColumns.Rows.Add(new object[] { false, i.ToString("000"), string.Empty });
            }
        }

        #region Events
        private void ParallelVarReport_Load(object sender, EventArgs e)
        {

        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            VariablePrefix prefixInfo = (VariablePrefix)cboPrefixes.SelectedItem;

            if (prefixInfo == null)
                return;

            string prefix = prefixInfo.Prefix;
            // get range information if requested

            // get crosstab table
            DataTable crosstab = GetData(prefix); 
            // output report
            DataTableReport report = new DataTableReport(crosstab);
            report.CreateReport();
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.RemovePopup(this);
        }
        #endregion

        #region Methods
        private DataTable GetData(string prefix, int lower = 0, int upper = 100)
        {
            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("RefVarName", Type.GetType("System.String")));
            data.Columns.Add(new DataColumn("X", Type.GetType("System.String")));

            List<int> hundreds = new List<int>();
            foreach (DataGridViewRow row in dgvColumns.Rows)
            {
                if ((bool)row.Cells["chInclude"].Value)
                {
                    hundreds.Add(Int32.Parse((string)row.Cells["chHundred"].Value));
                    DataColumn c = new DataColumn((string)row.Cells["chHundred"].Value, Type.GetType("System.String"));
                    c.Caption = GetColumnName(row);
                    data.Columns.Add(c);
                }
            }

            List<string> vars = new List<string>();

            for (int i = lower; i < upper; i++)
            {
                
                // create the basic list of vars (0-100)
                vars.Add(prefix + "*" + i.ToString("00"));

                // add in actual variations from global list
                foreach (int h in hundreds)
                {
                    var actual = Globals.AllRefVarNames.Where(x => x.Prefix.Equals(prefix) && x.NumberInt() == (h + i));

                    foreach (RefVariableName v in actual)
                        if (!vars.Contains(prefix + "*" + v.Number.Substring(1, 2) + v.Suffix)) vars.Add(prefix + "*" + v.Number.Substring(1, 2) + v.Suffix);
                }
                
            }

            foreach (string v in vars)
            {
                DataRow row = data.NewRow();
                row["RefVarName"] = v;
                int count = 0;
                foreach (int h in hundreds)
                {
                    int numbers = h + Int32.Parse( v.Substring(3, 2));
                    string suffix = "";
                    if (char.IsLetter(v[v.Length-1]))
                        suffix = v.Substring(v.Length - 1);
                    string pattern = prefix + numbers + suffix;
                    var matches = Globals.AllVarNames.Where(x => x.RefVarName.Equals(pattern));

                    foreach (VariableName vn in matches)
                        row[h.ToString()] += vn.VarLabel + "\r\n";

                    if (matches.Count() > 0)
                        count++;
                }
                if (count == 0) row["X"] = "*";
                data.Rows.Add(row);
            }

            return data;
        }

        private string GetColumnName(DataGridViewRow row)
        {
            StringBuilder column = new StringBuilder();

            column.Append((string)row.Cells["chHundred"].Value);

            string desc = (string)row.Cells["chHundred"].Value;
            if (!string.IsNullOrEmpty(desc))
                column.Append(" - " + desc);

            return column.ToString();
        }

        #endregion

        
    }
}
