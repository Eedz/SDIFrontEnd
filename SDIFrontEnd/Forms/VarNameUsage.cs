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
using System.Text.RegularExpressions;

namespace SDIFrontEnd
{
    /// <summary>
    /// Displays refVarNames matching the provided pattern and whether they are in used or not.
    /// </summary>
    public partial class VarNameUsage : Form
    {
        public enum VarPattern { PrefixOnly, Hundred, Ten, One, Undefined }

        VarPattern Pattern;
        List<RefVariableName> usedList;
        List<RefVariableName> unusedList;

        public VarNameUsage()
        {
            InitializeComponent();
        }

        public VarNameUsage(string pattern) : this()
        {
            SearchVars(pattern);
        }

        #region Events

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.Remove(this);
        }

        private void txtCriteria_Validating(object sender, CancelEventArgs e)
        {
            txtCriteria.Text = txtCriteria.Text.ToUpper();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCriteria.Text))
                SearchVars(txtCriteria.Text);
        }

        private void VarNameUsage_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Remove(this);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Perform the search for both used and unused VarNames.
        /// </summary>
        /// <param name="criteria"></param>
        public void SearchVars(string criteria)
        {
            GetPattern(criteria);

            if (Pattern == VarPattern.Undefined)
            {
                MessageBox.Show("Invalid pattern. Use a standard VarName pattern like these: AD, AD1, or AD10");
                return;
            }

            ShowUsedVarNames(criteria);
            ShowUnusedVarNames(criteria);            
        }

        /// <summary>
        /// Determine the type of pattern provided in the form.
        /// </summary>
        /// <param name="criteria"></param>
        private void GetPattern(string criteria)
        {
            // get pattern
            Pattern = VarPattern.Undefined;

            if (criteria.Length == 2 && Regex.IsMatch(criteria, "[A-Z]{2}"))
            {
                Pattern = VarPattern.PrefixOnly;

            }
            else if (criteria.Length == 3 && Regex.IsMatch(criteria, "[A-Z]{2}[0-9]"))
            {
                Pattern = VarPattern.Hundred;

            }
            else if (criteria.Length == 4 && Regex.IsMatch(criteria, "[A-Z]{2}[0-9]{2}"))
                Pattern = VarPattern.Ten;
            //else if (Regex.IsMatch(criteria, "[A-Z]{2}[0-9]{3}"))
            //    pattern = VarPattern.One;
        }

        /// <summary>
        /// Get and display the list of matching in-use VarNames.
        /// </summary>
        private void ShowUsedVarNames(string criteria)
        {
            dgvUsed.Rows.Clear();
            usedList = Globals.AllRefVarNames
                .Where(x => x.RefVarName.StartsWith(criteria) && x.StandardForm)
                .Distinct()
                .ToList();
            PopulateGrid(usedList, dgvUsed);
        }

        /// <summary>
        /// Get and display the list of matching unused VarNames.
        /// </summary>
        /// <param name="criteria"></param>
        private void ShowUnusedVarNames(string criteria)
        {
            dgvUnused.Rows.Clear();
            GetUnused(criteria);
            PopulateGrid(unusedList, dgvUnused);
        }

        /// <summary>
        /// Build the list of unused VarNames.
        /// </summary>
        /// <param name="criteria"></param>
        private void GetUnused(string criteria)
        {
            unusedList = new List<RefVariableName>();
            string prefix = criteria.Substring(0, 2);
            string nums = criteria.Substring(2).PadRight(3, '0');

            string numsMax = nums.Replace("0", "9");
            int varBase = Int32.Parse(nums);
            int varMax = Int32.Parse(numsMax);

            for (int i = varBase; i <= varMax; i++)
            {
                RefVariableName v = new RefVariableName(prefix + i.ToString().PadLeft(3, '0'));
                v.Prefix = prefix;
                //v.Number = i.ToString().PadLeft(3,'0');
                v.Number = i.ToString();
                if (!usedList.Contains(v, new RefVarNameBaseComparer()))
                    unusedList.Add(v);
            }
        }

        /// <summary>
        /// Populate the specified grid with VarName ranges from the list.
        /// </summary>
        /// <param name="vars"></param>
        /// <param name="dgv"></param>
        private void PopulateGrid(List<RefVariableName> vars, DataGridView dgv)
        {
            List<string> ranges = new List<string>();

            if (vars.Count == 0)
                return;

            string prefix = vars[0].Prefix;
            int currentNum = Int32.Parse(vars[0].Number);
            string currentRange = vars[0].RefVarName;
            int prevNum = currentNum;

            for (int i = 1; i < vars.Count; i++)
            {
                int num = Int32.Parse(vars[i].Number);
                if (num == prevNum)
                    continue;
                else if (num - prevNum > 1)
                {
                    if (!currentRange.Equals(vars[i-1]))
                        currentRange += "-" + vars[i-1];
                    ranges.Add(currentRange);
                    currentRange = vars[i].RefVarName;
                }
                prevNum = Int32.Parse(vars[i].Number);
            }

            if (!currentRange.Equals(vars[vars.Count-1]))
                currentRange += "-" + vars[vars.Count - 1];
            ranges.Add(currentRange);

            foreach (string range in ranges)
            {
                string[] split = range.Split(new char[] { '-' });
                int count = 1;
                
                int num1 = Int32.Parse(split[0].Substring(2, 3));
                int num2 = Int32.Parse(split[1].Substring(2, 3));
                count = num2 - num1 + 1;
                    
                if  (count>1)
                    dgv.Rows.Add(new object[] { range, count });
                else 
                    dgv.Rows.Add(new object[] { range.Substring(0,range.IndexOf("-")), count });
            }
        }
        #endregion

        
    }


}
