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
    public partial class VarNameWordingUsage : Form
    {
        

        public VarNameWordingUsage(List<QuestionUsage> records)
        {
            InitializeComponent();

            BindingSource bs = new BindingSource()
            {
                DataSource = records
            };

            txtSurveys.DataBindings.Add("Text", bs, "SurveyList");
            bindingNavigator1.BindingSource = bs;
        }

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = ((BindingSource)dataRepeater.DataSource);
        
            QuestionUsage item = (QuestionUsage)datasource[e.DataRepeaterItem.ItemIndex];

            var vText = (TextBox)e.DataRepeaterItem.Controls.Find("txtRefVarName", false)[0];
            vText.Text = item.VarName.RefVarName;

            var qText = (RichTextBox)e.DataRepeaterItem.Controls.Find("rtbQuestionText", false)[0];
            qText.Rtf = item.GetQuestionTextRich();

        }
    }
}
