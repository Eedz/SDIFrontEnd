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
    public partial class AssignLabelsFilter : Form
    {
        public List<VariableName> SelectedVars;
        public List<RefVariableName> SelectedRefVars;

        public AssignLabelsFilter()
        {
            InitializeComponent();

            SelectedVars = new List<VariableName>();
            SelectedRefVars = new List<RefVariableName>();
        }

        private void optVarName_CheckedChanged(object sender, EventArgs e)
        {
            if (optVarName.Checked)
            {
                cboVarList.DataSource = Globals.AllVarNames;
            }
            else
            {
                cboVarList.DataSource = Globals.AllRefVarNames;
            }

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            lstSelectedVars.Items.Add(cboVarList.SelectedItem);
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            lstSelectedVars.Items.Remove(lstSelectedVars.SelectedItem);
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            if (optVarName.Checked)
            {
                SelectedVars = lstSelectedVars.Items.Cast<VariableName>().ToList();
            }
            else
            {
                SelectedRefVars = lstSelectedVars.Items.Cast<RefVariableName>().ToList();
            }
            
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
