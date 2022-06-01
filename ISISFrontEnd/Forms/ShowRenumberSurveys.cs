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
    // TODO replace already open editor
    public partial class ShowRenumberSurveys : Form
    {
        List<Survey> Surveys { get; set; }

        public ShowRenumberSurveys(List<Survey> surveys)
        {
            InitializeComponent();

            Surveys = surveys;
            dataRepeater1.DataSource = Surveys;

            txtSurvey.DataBindings.Add("Text", Surveys, "SurveyCode");
        }

        private void cmdOpenEditor_Click(object sender, EventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)(((Button)sender).Parent).Parent;
            var datasource = (List<Survey>)dataRepeater.DataSource;
            Survey item = datasource[dataRepeater.CurrentItemIndex];

            if (FormManager.FormOpen("SurveyEditor", 1))
            {
                // TODO add filter method to form
                FormManager.GetForm("SurveyEditor", 1).Focus();
                return;
            }

            SurveyEditor frm = new SurveyEditor(item.SurveyCode);
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
