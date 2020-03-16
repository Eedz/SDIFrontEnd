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

namespace ISISFrontEnd
{
    public partial class AssignLabels : Form
    {
        public MainMenu frmParent;
        public string key;

        List<VariableName> VarNames;
        List<SurveyQuestion> Questions;

        public AssignLabels()
        {
            InitializeComponent();

            //VarNames = DBAction.GetAllVarNames();
            Questions = DBAction.GetAllSurveyQuestions();

            dgvVars.DataSource = Questions;

        }

        private void dgvVars_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        

    }

    public class VarNameUsage 
    {
        public string VarName { get; set; }
        public string refVarName { get; set; }
        public string Survey { get; set; }
        public string VarLabel { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Product { get; set; }
        public string Domain { get; set; }
    }
}
