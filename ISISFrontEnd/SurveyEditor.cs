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
    public partial class SurveyEditor : Form
    {

        public MainMenu frmParent;
        public string key;                      // unique ID for this instance
        public int index; // there will be a maximum of 3 survey entry forms
        public Survey CurrentSurvey { get; set; }            // currently displayed survey
        public SurveyQuestion CurrentQuestion { get; set; }  // currently displayed question
        BindingSource bs;

        // reference to dragged item in Question List
        private ListViewItem dragItem = null;

        // references to popup forms       
        SurveyEntryBrown frmBrown;

        // translation
        TranslationViewer frmTranslations;
        // deleted questions

        public SurveyEditor()
        {
            InitializeComponent();
        }

        public SurveyEditor(string surveyCode)
        {

            CurrentSurvey = DBAction.GetSurveyInfo(surveyCode);
            DBAction.FillQuestions(CurrentSurvey);

            if (CurrentSurvey.Questions == null)
            {
                MessageBox.Show("Error getting " + surveyCode + "'s questions. Ensure there is at least one question in this survey.");
                Close();
            }

            InitializeComponent();

            this.MouseWheel += SurveyEditor_OnMouseWheel;

            bs = new BindingSource
            {
                DataSource = CurrentSurvey.Questions

            };
            bs.PositionChanged += Bs_PositionChanged;

            navQuestions.BindingSource = bs;
            CurrentQuestion = (SurveyQuestion)bs.Current;

            FillList();

            BindProperties();

            ColorForm();


        }

        #region Events
        private void SurveyEditor_Load(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;
            //bs.Position = frmParent.currentUser.positions[index]; // TODO add position property to user

            LoadQuestion();
        }

        protected void SurveyEditor_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }

        }

        /// <summary>
        /// Updates subforms to match the current record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;

            if (frmBrown != null && !frmBrown.IsDisposed)
                frmBrown.UpdateForm(CurrentQuestion.VarName.RefVarName);

            if (frmTranslations != null && !frmTranslations.IsDisposed)
                frmTranslations.UpdateForm(CurrentQuestion.ID);

            for (int i = 0; i < lstQuestionList.Items.Count; i++)

            {
                lstQuestionList.Items[i].Selected = false;
                
            }

                for (int i = 0; i < lstQuestionList.Items.Count; i++)
            {
                if (lstQuestionList.Items[i].SubItems[2].Text.Equals(CurrentQuestion.VarName.FullVarName))
                {
                    lstQuestionList.Items[i].Selected = true;
                    lstQuestionList.Items[i].EnsureVisible();
                    
                  
                    break;
                }
            }
            LoadQuestion();
        }

        private void cboGoToVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GoToQuestion(cboGoToVar.GetItemText(cboGoToVar.SelectedItem));

            cboGoToVar.SelectedValue = "";
        }
        #endregion

        #region Form Setup
        private void ColorForm()
        {
            Color temp = Color.FromArgb(0xAAC499);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;
        }

        /// <summary>
        /// Bind the controls to the current survey's properties.
        /// </summary>
        private void BindProperties()
        {
            // top portion
            txtSurvey.DataBindings.Add(new Binding("Text", CurrentSurvey, "SurveyCode"));
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName.FullVarName"));
            txtQnum.DataBindings.Add(new Binding("Text", bs, "Qnum"));

            // go to box
            cboGoToVar.ValueMember = "refVarName";
            cboGoToVar.DataSource = DBAction.GetAllRefVars(CurrentSurvey.SurveyCode);
            cboGoToVar.DisplayMember = "refVarName";
            cboGoToVar.SelectedValue = "";


            // labels

            // fill 

            cboDomainLabel.DataSource = DBAction.ListDomainLabels();
            cboDomainLabel.ValueMember = "ID";
            cboDomainLabel.DisplayMember = "LabelText";

            cboTopicLabel.DataSource = DBAction.GetTopicLabels();
            cboTopicLabel.ValueMember = "ID";
            cboTopicLabel.DisplayMember = "LabelText";

            cboContentLabel.DataSource = DBAction.GetContentLabels();
            cboContentLabel.ValueMember = "ID";
            cboContentLabel.DisplayMember = "LabelText";

            cboProductLabel.DataSource = DBAction.GetProductLabels();
            cboProductLabel.ValueMember = "ID";
            cboProductLabel.DisplayMember = "LabelText";

            // bind
            txtVarLabel.DataBindings.Add(new Binding("Text", bs, "VarName.VarLabel"));
            cboDomainLabel.DataBindings.Add("SelectedValue", bs, "VarName.Domain.ID");
            cboTopicLabel.DataBindings.Add("SelectedValue", bs, "VarName.Topic.ID");
            cboContentLabel.DataBindings.Add("SelectedValue", bs, "VarName.Content.ID");
            cboProductLabel.DataBindings.Add("SelectedValue", bs, "VarName.Product.ID");

            // field info
            chkTableFormat.DataBindings.Add("Checked", bs, "TableFormat");
            chkScriptOnly.DataBindings.Add("Checked", bs, "ScriptOnly");
            txtVarType.DataBindings.Add("Text", bs, "VarType");
            numDec.DataBindings.Add("Value", bs, "NumDec");
            numCols.DataBindings.Add("Value", bs, "NumCol");


        }

        private void FillList()
        {
            if (CurrentSurvey == null) return;
            lstQuestionList.Items.Clear();
            lstQuestionList.View = View.Details;

            foreach (SurveyQuestion sq in CurrentSurvey.Questions)
            {
                string corr, tblfmt;
                if (sq.CorrectedFlag)
                    corr = "Yes";
                else
                    corr = "No";

                if (sq.TableFormat)
                    tblfmt = "Yes";
                else
                    tblfmt = "No";

                ListViewItem li = new ListViewItem(new string[] { sq.Qnum, sq.AltQnum, sq.VarName.FullVarName, sq.VarName.VarLabel, sq.RespName, corr, tblfmt });
                li.Tag = sq;
                lstQuestionList.Items.Add(li);
                FormatListItem(li, GetQuestionType(li));
            }
        }
        #endregion

        #region Methods
        public void ChangeSurvey(string newSurvey)
        {
            CurrentSurvey = null;
            CurrentSurvey = DBAction.GetSurveyInfo(newSurvey);
            DBAction.FillQuestions(CurrentSurvey);

            bs.DataSource = CurrentSurvey.Questions;
            txtSurvey.DataBindings.Clear();
            txtSurvey.DataBindings.Add("Text", CurrentSurvey, "SurveyCode");

            CurrentQuestion = (SurveyQuestion)bs.Current;

        }

        public void LoadQuestion()
        {
            rtbQuestionText.Rtf = "";
            rtbQuestionText.Rtf = CurrentQuestion.GetQuestionTextRich();
            // TODO incorporate color into LitQ @"{\colortbl;\red0\green0\blue255;}" 
        }

        private void MoveRecord(int count)
        {

            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }
        }

        private void GoToQuestion(string refVarName)
        {
            int index = 0;
            int currentIndex = bs.Position;
            bool found = false;
            foreach (SurveyQuestion sq in CurrentSurvey.Questions)
            {
                if (sq.VarName.RefVarName == refVarName)
                {
                    found = true;
                    break;
                }
                else
                {
                    index++;
                }
            }

            if (found) bs.Position = index;
        }

        private void GoToQnum(string qnum)
        {
            int index = 0;
            int currentIndex = bs.Position;
            bool found = false;
            foreach (SurveyQuestion sq in CurrentSurvey.Questions)
            {
                if (sq.Qnum == qnum)
                {
                    found = true;
                    break;
                }
                else
                {
                    index++;
                }
            }

            if (found) bs.Position = index;
        }

        /// <summary>
        /// Close any popup forms that were opened by this form. Then close this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseForm(object sender, EventArgs e)
        {
            // save the current filter in the user profile
            DBAction.SaveSession("frmSurveyEntry", CurrentSurvey.SurveyCode, bs.Position, frmParent.currentUser);

            if (frmBrown != null)
            {
                frmBrown.Close();
                frmBrown.Dispose();
            }
            Close();
        }

        /// <summary>
        /// Save the survey and position for the current user. Close the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBAction.SaveSession("frm" + this.Name + index, CurrentSurvey.SurveyCode, bs.Position, frmParent.currentUser);

            frmParent.CloseTab(key);
        }



        #endregion

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

        }

        /// <summary>
        /// Determines the type of questions for the given row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>QuestionType enum based on the Qnum and VarName.</returns>
        private QuestionType GetQuestionType(ListViewItem row)
        {
            string qnum = row.Text;
            string varname = row.SubItems[2].Text;

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

        
        private void ReNumberSurvey()
        {
            RenumberList();
            RenumberQuestions();
        }

        private void RenumberQuestions()
        {
            foreach (ListViewItem item in lstQuestionList.Items)
            {
                string varname = item.SubItems[2].Text;

                SurveyQuestion found = CurrentSurvey.Questions.Where(x => x.VarName.FullVarName.Equals(varname)).First();

                found.Qnum = item.SubItems[0].Text;
            }
        }

        /// <summary>
        /// Sets the New Q# column by analyzing the current Qnum and deciding what type of question it is (standalone vs. series vs. heading). The row is also colored based on the type.
        /// </summary>
        private void RenumberList() { 
            int qLet = 0;
            int hcount = 0;
            int i;

            QuestionType qType;

            int currQnum;
            string newQnum;

            if (lstQuestionList.Tag == null)
                currQnum = 0;
            else
                currQnum = (int)lstQuestionList.Tag;

            foreach (ListViewItem row in lstQuestionList.Items)
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
                        if (i < lstQuestionList.Items.Count - 1)
                            i++;
                        else
                            break;

                    } while (GetQuestionType(lstQuestionList.Items[i]) == QuestionType.Heading || GetQuestionType(lstQuestionList.Items[i]) == QuestionType.InterviewerNote);

                    if (GetQuestionType(lstQuestionList.Items[i]) == QuestionType.Series)
                        row.SubItems[0].Text += "a";
                }
            }
        }

        

        private void lstQuestionList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstQuestionList.SelectedIndices[0];
            string varname = lstQuestionList.Items[index].SubItems[2].Text;

            GoToQuestion(Utilities.ChangeCC(varname));
        }

        private void lstQuestionList_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void lstQuestionList_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void lstQuestionList_DragLeave(object sender, EventArgs e)
        {

        }

        private void lstQuestionList_MouseDown(object sender, MouseEventArgs e)
        {
            dragItem = lstQuestionList.GetItemAt(e.X, e.Y);
            // if the LV is still empty, no item will be found anyway,
            // so we don't have to consider this case
        }

        private void lstQuestionList_MouseUp(object sender, MouseEventArgs e)
        {
            // use 0 instead of e.X so that you don't have
            // to keep inside the columns while dragging
            ListViewItem itemOver = lstQuestionList.GetItemAt(0, e.Y);

            if (itemOver == null)
                return;

            Rectangle rc = itemOver.GetBounds(ItemBoundsPortion.Entire);

            // find out if we insert before or after the item the mouse is over
            bool insertBefore;
            if (e.Y < rc.Top + (rc.Height / 2))
                insertBefore = true;
            else
                insertBefore = false;

            if (dragItem != itemOver)
            // if we dropped the item on itself, nothing is to be done
            {
                if (insertBefore)
                {
                    lstQuestionList.Items.Remove(dragItem);
                    lstQuestionList.Items.Insert(itemOver.Index, dragItem);
                }
                else
                {
                    lstQuestionList.Items.Remove(dragItem);
                    lstQuestionList.Items.Insert(itemOver.Index + 1, dragItem);
                }
            }

            ReNumberSurvey();

        }

        private void lstQuestionList_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragItem == null)
                return;

            // Show the user that a drag operation is happening
            Cursor = Cursors.Hand;
        }

        private void lstQuestionList_DragOver(object sender, DragEventArgs e)
        {
            ListViewItem liRow = lstQuestionList.HitTest(e.X, e.Y).Item;

            if (liRow != null) liRow.EnsureVisible();
        }

        private void cmdOpenRelatedQs_Click(object sender, EventArgs e)
        {
            SurveyEntryBrown frm = new SurveyEntryBrown(CurrentQuestion.VarName.RefVarName, "*");
            frm.Visible = true;
        }

        private void chkHighlightDiffs_CheckedChanged(object sender, EventArgs e)
        {
            // highlight each field 
        }
    }
}
