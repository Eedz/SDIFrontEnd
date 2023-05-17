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
using FM = FormManager;

namespace SDIFrontEnd
{
    // TODO replace already open editor
    public partial class ShowRenumberSurveys : Form
    {
        List<KeyValuePair<int, string>> Surveys { get; set; }

        public ShowRenumberSurveys(List<KeyValuePair<int, string>> surveys)
        {
            InitializeComponent();

            Surveys = surveys;
            dataRepeater1.DataSource = Surveys;

            txtSurvey.DataBindings.Add("Text", Surveys, "Value");
        }

        private void cmdOpenEditor_Click(object sender, EventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)(((Button)sender).Parent).Parent;
            var datasource = (List<KeyValuePair<int, string>>)dataRepeater.DataSource;
            KeyValuePair<int, string> item = datasource[dataRepeater.CurrentItemIndex];

            SurveyEditor getFrm = (SurveyEditor)FM.FormManager.GetForm("SurveyEditor", 6);
            if (getFrm != null)
            {
                if (!getFrm.CurrentSurvey.SurveyCode.Equals(item.Value))
                { 
                    getFrm.ChangeSurvey(item.Value);
                }
            }
            else
            {
                SurveyEditor frm = new SurveyEditor(item.Key);
                frm.Tag = 6;
                FM.FormManager.Add(frm);
            }
            ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("SurveyEditor6");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
