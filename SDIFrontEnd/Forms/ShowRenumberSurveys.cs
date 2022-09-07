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

            SurveyEditor getFrm = (SurveyEditor)FormManager.GetForm("SurveyEditor", 6);
            if (getFrm != null)
            {
                if (!getFrm.CurrentSurvey.SurveyCode.Equals(item.SurveyCode))
                { 
                    getFrm.ChangeSurvey(item.SurveyCode);
                }
            }
            else
            {
                SurveyEditor frm = new SurveyEditor(item.SID);
                frm.Tag = 6;
                FormManager.Add(frm);
            }
            ((MainMenu)FormManager.GetForm("MainMenu")).SelectTab("SurveyEditor6");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
