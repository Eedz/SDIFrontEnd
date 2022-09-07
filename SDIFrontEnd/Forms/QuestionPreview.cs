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
    public partial class QuestionPreview : Form
    {
        BindingSource bs;
        SurveyQuestion CurrentQuestion;
        SurveyQuestion FormattedQuestion;

        List<string> StandardFields;
        public QuestionPreview(SurveyQuestion sq)
        {
            InitializeComponent();

            CurrentQuestion = sq;
            FormattedQuestion = sq.Copy();

            bs = new BindingSource
            {
                DataSource = CurrentQuestion
            };

            StandardFields = new List<string>();
            StandardFields.Add("PreP");
            StandardFields.Add("PreI");
            StandardFields.Add("PreA");
            StandardFields.Add("LitQ");
            StandardFields.Add("PstI");
            StandardFields.Add("PstP");
            StandardFields.Add("RespOptions");
            StandardFields.Add("NRCodes");

            lstStandardFields.DataSource = StandardFields;
            for (int i = 0; i < lstStandardFields.Items.Count; i++)
            {
                lstStandardFields.SetSelected(i, true);
            }
            txtBaseQuestion.Rtf = Utilities.FormatText(CurrentQuestion.GetQuestionText(StandardFields, false, "<br>"), true);
            LoadQuestion();
        }

        private void LoadQuestion()
        {

            StandardFields.Clear();

            foreach (string s in lstStandardFields.SelectedItems) 
            {
                StandardFields.Add(s);
            }
            

            txtFormattedQuestion.Clear();
            txtFormattedQuestion.Rtf = Utilities.FormatText(CurrentQuestion.GetQuestionText(StandardFields, false, "<br>"), true);
        }

        private void lstStandardFields_SelectedIndexChanged(object sender, EventArgs e)
        {
           // occurs too often
        }

        private void lstStandardFields_Click(object sender, EventArgs e)
        {
            LoadQuestion();
        }
    }
}
