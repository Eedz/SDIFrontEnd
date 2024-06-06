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
using HtmlRtfConverter;

namespace SDIFrontEnd
{
    // TODO use TextMeasuring to resize text boxes
    public partial class HarmonyResults : Form
    {
        DataTable Results;
        BindingSource bs;
        public HarmonyResults(DataTable data)
        {
            InitializeComponent();

            Results = data;

            bs = new BindingSource();
            bs.DataSource = Results;

            txtRefVarName.DataBindings.Add("Text", bs, "refVarName");
     
            txtSurveys.DataBindings.Add("Text", bs, "Surveys");
            dataRepeater1.DataSource = bs;
            txtRefVarName.AutoSize = true;
            rtbQuestion.AutoSize = true;
            txtSurveys.AutoSize = true;
        }

        private void txtSurveys_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Size size = TextRenderer.MeasureText(txt.Text, txt.Font, txt.Size, TextFormatFlags.Default);
            txt.Width = size.Width;
            txt.Height = size.Height;
        }

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (DataTable)((BindingSource)dataRepeater.DataSource).DataSource;

            var text = (RichTextBox)e.DataRepeaterItem.Controls.Find("rtbQuestion", false)[0];
            string plain = datasource.Rows[e.DataRepeaterItem.ItemIndex]["Question"].ToString();
            text.Rtf = Converter.HTMLToRtf(plain); 
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
        }
    }
}
