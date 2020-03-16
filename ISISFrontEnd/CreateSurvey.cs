using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using ITCLib;

namespace ISISFrontEnd
{
    enum QuestionType { Series, Standalone, Heading, InterviewerNote, Subheading }

    public partial class CreateSurvey : Form
    {
        public MainMenu frmParent;
        public string key;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionStringTest"].ConnectionString);

        Survey CurrentSurvey { get; set; }
        List<SurveyQuestion> DeletedQuestions { get; set; }
        List<SurveyQuestion> AddedQuestions { get; set; }

        bool ShowCorrected { get; set; }

        public CreateSurvey()
        {
            InitializeComponent();
        }

        private void CreateSurvey_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sql;
            DataTable surveyList = new DataTable();
            sql = new SqlDataAdapter("SELECT Survey FROM qrySurveys ORDER BY ISO_Code, Wave, Survey", conn);
            
            //using (conn) {
            conn.Open();
            sql.Fill(surveyList);
            conn.Close();

            cboSurvey.ValueMember = "Survey";
            cboSurvey.DisplayMember = "Survey";
            cboSurvey.DataSource = surveyList;
            

            cboSurvey.SelectedItem = null;

            cboSurvey.SelectedIndexChanged += SurveyChanged;
            //}

            DeletedQuestions = new List<SurveyQuestion>();
            AddedQuestions = new List<SurveyQuestion>();
        }

        private void SurveyChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboSurvey.GetItemText(cboSurvey.SelectedItem))) return;
           
            CurrentSurvey = DBAction.GetSurveyInfo(cboSurvey.GetItemText(cboSurvey.SelectedItem));

            lstReport.Items.Clear();
            lstReport.View = View.Details;

            foreach (SurveyQuestion sq in CurrentSurvey.Questions)
            {
                ListViewItem li = new ListViewItem(new string[] { "", sq.Qnum, sq.AltQnum, sq.VarName.FullVarName, sq.VarName.VarLabel, "", sq.RespName, sq.CorrectedFlag.ToString(), sq.TableFormat.ToString() });
                li.Tag = sq;
                lstReport.Items.Add(li);
            }

            Renumber();

        }

        /// <summary>
        /// Sets the New Q# column by analyzing the current Qnum and deciding what type of question it is (standalone vs. series vs. heading). The row is also colored based on the type.
        /// </summary>
        private void Renumber()
        {         
            int qLet=0;
            int hcount=0;
            int i;
           
            QuestionType qType;

            int currQnum;
            string newQnum;

            if (lstReport.Tag == null)
                currQnum = 0;
            else 
                currQnum = (int)lstReport.Tag;

            foreach (ListViewItem row in lstReport.Items)
            {
                qType = GetQuestionType(row);

                FormatListItem(row, qType); // add color and style to row

                // increment either the letter or the number, count headings
                switch (qType)
                {
                    case QuestionType.Series:
                        qLet++;
                        hcount = 0;
                        break;
                    case QuestionType.Standalone:
                        currQnum++;
                        qLet = 1;
                        hcount = 0;
                        break;
                    case QuestionType.Heading:
                        hcount++;
                        break;
                    case QuestionType.Subheading:
                        hcount++;
                        break;
                }

                newQnum = currQnum.ToString("000");

                if (qType != QuestionType.Standalone)
                {
                    newQnum += new string('z', (qLet - 1) / 26);
                    newQnum += Char.ConvertFromUtf32(96 + qLet - 26 * ((qLet - 1) / 26));

                }

                if (hcount > 0)
                    newQnum += "!" + hcount.ToString("000");

                row.SubItems[0].Text = newQnum;

                // add 'a' to series starters
                if (qType == QuestionType.Standalone)
                {
                    i = row.Index;

                    do
                    {
                        if (i < lstReport.Items.Count-1)
                            i ++;
                        else
                            break;

                    } while (GetQuestionType(lstReport.Items[i]) == QuestionType.Heading || GetQuestionType(lstReport.Items[i]) == QuestionType.InterviewerNote);

                    if (GetQuestionType(lstReport.Items[i]) == QuestionType.Series)
                        row.SubItems[0].Text += "a";
                }
            }         
        }

        /// <summary>
        /// Determines the type of questions for the given row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>QuestionType enum based on the Qnum and VarName.</returns>
        private QuestionType GetQuestionType(ListViewItem row)
        {
            string qnum  = row.SubItems[1].Text;
            string varname = row.SubItems[3].Text;

            int head = Int32.Parse(Utilities.GetSeriesQnum(qnum));
            string tail = Utilities.GetQnumSuffix(qnum);

            QuestionType qType;

            // get Question Type
            if (varname.StartsWith("Z"))
            {
                if (varname.EndsWith("s"))
                    qType = QuestionType.Subheading; // subheading
                else
                    qType = QuestionType.Heading; // heading
            }
            else if (varname.StartsWith("HG"))
            {
                qType = QuestionType.Standalone; // QuestionType.InterviewerNote; // interviewer note
            }
            else
            {
                if ((tail == "" || tail == "a") && (head != 0))
                    qType = QuestionType.Standalone; // standalone or first in series
                else
                    qType = QuestionType.Series; // series
            }
            return qType;
        }

        /// <summary>
        /// Adds color and formatting to the specified row, based on its QuestionType.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="questionType"></param>
        private void FormatListItem(ListViewItem row, QuestionType questionType)
        {
            // color row based on type
            row.UseItemStyleForSubItems = true;
            row.Tag = questionType;


            switch (questionType)
            {
                case QuestionType.Series:
                    row.ForeColor = Color.Black;
                    break;
                case QuestionType.Standalone:
                    row.ForeColor = Color.Blue;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;

                case QuestionType.Heading:
                    row.ForeColor = Color.Magenta;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;
                case QuestionType.InterviewerNote:
                    row.ForeColor = Color.Lime;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;
                case QuestionType.Subheading:
                    row.ForeColor = Color.LightBlue;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;

            }

            if (ShowCorrected)
                if (row.SubItems[8].ToString() == "True")
                    row.ForeColor = Color.Maroon;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SaveSurvey();
        }

        /// <summary>
        /// Updates the Qnum for each question in the current survey.
        /// TODO create new questions for each question in AddedQuestions
        /// TODO delete questions in DeletedQuestions
        /// </summary>
        private void SaveSurvey()
        {
            List<SurveyQuestion> saveErrors = new List<SurveyQuestion>();
            SurveyQuestion sq;
            foreach (ListViewItem li in lstReport.Items)
            {
                sq = (SurveyQuestion)li.Tag;
                sq.Qnum = li.SubItems[0].ToString();
                if (DBAction.UpdateQnum(sq) == 1)
                {
                    saveErrors.Add(sq);
                    
                }
            }

            if (saveErrors.Count > 0)
            {
                MessageBox.Show("error saving qnums for " + saveErrors.Count + " questions.");
                // show list?
            }
        }

        private void lstReport_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // toggle between standalone and series questions
            // remove/add suffix or just change type?
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void CreateSurvey_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        private void chkHighlightCorrected_CheckedChanged(object sender, EventArgs e)
        {
            ShowCorrected = chkHighlightCorrected.Checked;
        }
    }
}
