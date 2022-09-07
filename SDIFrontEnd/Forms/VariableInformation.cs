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
    public partial class VariableInformation : Form
    {
        List<VariableName> Variables;
        BindingSource bs;
        public VariableInformation()
        {
            InitializeComponent();

            Variables = Globals.AllVarNames;
            //Variables = DBAction.GetVarNames(); TODO create

            bs = new BindingSource();
            bs.DataSource = Variables;

            navVars.BindingSource = bs;

            BindProperties();
        }

        private void BindProperties()
        {
            txtVarName.DataBindings.Add("Text", bs, "VarName");
            txtRefVarName.DataBindings.Add("Text", bs, "RefVarName");
        }

        private void lstUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load question text, labels
        }

        private void cboGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
