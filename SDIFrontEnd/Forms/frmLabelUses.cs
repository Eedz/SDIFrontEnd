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
    public partial class frmLabelUses : Form
    {
        List<SurveyQuestion> QuestionList;
        public frmLabelUses(List<SurveyQuestion> list)
        {
            InitializeComponent();

            QuestionList = list;

            foreach(SurveyQuestion sq in QuestionList)
            {
                int rowID = dataGridView1.Rows.Add();

                DataGridViewRow row = dataGridView1.Rows[rowID];

                row.Cells["chSurvey"].Value = sq.SurveyCode;
                row.Cells["chrefVarName"].Value = sq.VarName.RefVarName;
                row.Cells["chVarName"].Value = sq.VarName.VarName;
                row.Cells["chVarLabel"].Value = sq.VarName.VarLabel;
                row.Cells["chDomain"].Value = sq.VarName.Domain.LabelText;
                row.Cells["chTopic"].Value = sq.VarName.Topic.LabelText;
                row.Cells["chContent"].Value = sq.VarName.Content.LabelText;
                row.Cells["chProduct"].Value = sq.VarName.Product.LabelText;
                   

            }
     
        }

        
    }
}
