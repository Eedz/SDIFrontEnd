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
    // TODO see if rows need to be expandable, if so, use DataGrid control instead of DataGridView control
    public partial class SurveyEntryGreen : Form
    {

        public SurveyEntry frmParent;
        private string SurveyGlob;
        BindingList<SurveyQuestion> Questions;
        BindingSource bs;
        public bool Pin { get; set; }

        public SurveyEntryGreen(string refVarName, string survey)
        {
            InitializeComponent();

            SurveyGlob = survey;

            Questions = new BindingList<SurveyQuestion>();
            bs = new BindingSource()
            {
                DataSource = Questions
            };
            navQuestions.BindingSource = bs;

            gridQuestions2.AutoGenerateColumns = true;

            BindProperties();

            ColorForm();

            UpdateRefVarName(refVarName);
        }

        private void BindProperties()
        {
            gridQuestions2.DataSource = bs;
        }


        private void ColorForm()
        {
           // Color temp = Color.FromArgb(0xC7B889);
            //Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            //this.BackColor = result;
        }

        public void UpdateRefVarName(string refVarName)
        {
            Questions = new BindingList<SurveyQuestion>(DBAction.GetRefVarNameQuestionsGlob(refVarName, SurveyGlob));

            bs.DataSource = Questions;
            gridQuestions2.Refresh();
        }

        private void SurveyEntryGreen_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Hide most of the columns except basic question info and wording numbers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridQuestions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gridQuestions2.ColumnCount; i++)
            {
                switch (gridQuestions2.Columns[i].Name)
                {
                    case "VarName":
                    case "SurveyCode":
                    case "Qnum":
                    case "PrePNum":
                    case "PreINum":
                    case "PreANum":
                    case "LitQNum":
                    case "PstINum":
                    case "PstPNum":
                    case "RespName":
                    case "NRName":
                        break;
                    default:
                        gridQuestions2.Columns[i].Visible = false;
                        break;

                }

            }
            gridQuestions2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }

       

        
    }
}
