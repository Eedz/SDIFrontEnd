using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FM = FormManager;
using ITCLib;

namespace SDIFrontEnd
{
    
    // TODO add translation changes (need to start tracking them)
    // TODO add some info about what the current record(s) look like (i.e. only a deletion record means it was created and deleted on the same day)
    // TODO have wording changes appear as separate entries

    public partial class QuestionHistory : Form
    {
        List<ChangedSurveyQuestion> history = new List<ChangedSurveyQuestion>();
        BindingSource bs, bsPrev, bsNext;
        CommentList commentsForm;
        int currentQID;

        public QuestionHistory()
        {
            InitializeComponent();

            this.MouseWheel += QuestionHistory_MouseWheel;
           
            bs = new BindingSource();
            bsPrev = new BindingSource();
            bsNext = new BindingSource();

            bs.PositionChanged += Bs_PositionChanged;

            GetAuditSurveys();
            GetAuditVarNames();
        }

        private void QuestionHistory_Load(object sender, EventArgs e)
        {

            cboSurvey.SelectedItem = "4CV3";         
            bs.Position = 1;

        }

        private void QuestionHistory_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            MoveRecord();
        }

        

        private void cboSurvey_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)cboSurvey.SelectedValue))
            {
                GetAuditVarNames();
            }
            else
            {
                return;
            }

            VariableName v = (VariableName)cboVarName.SelectedItem;

            if (v!= null && !string.IsNullOrEmpty((string)cboSurvey.SelectedValue))
            {
                RefreshCurrentQuestion((string)cboSurvey.SelectedValue, v.VarName);
                cboDeletedVarName.SelectedItem = null;
            }
            
        }

        private void cboVarName_SelectedValueChanged(object sender, EventArgs e)
        {
            VariableName v = (VariableName)cboVarName.SelectedItem;

            if (v !=null && (string)cboSurvey.SelectedValue != null)
            {
                RefreshCurrentQuestion((string)cboSurvey.SelectedValue, v.VarName, false);
                cboDeletedVarName.SelectedItem = null;
            }
        }

        private void cboDeletedVarName_SelectedValueChanged(object sender, EventArgs e)
        {
            VariableName v = (VariableName)cboDeletedVarName.SelectedItem;
            if (v != null && (!string.IsNullOrEmpty((string)cboSurvey.SelectedValue)))
            {
                RefreshCurrentQuestion((string)cboSurvey.SelectedValue, v.VarName, true);
                cboVarName.SelectedItem = null;
            }
        }

        private void cmdComments_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<CommentList>().Count() == 1)
            {
                commentsForm.Focus();
                return;
            }

            int qid = 0;

            List<QuestionComment> comments = new List<QuestionComment>();
            string survey = (string)cboSurvey.SelectedValue;
            string varname = "";

            if (!string.IsNullOrEmpty((string)cboVarName.SelectedValue))
                varname = (string)cboVarName.SelectedValue;
            else if (!string.IsNullOrEmpty((string)cboDeletedVarName.SelectedValue))
                varname = (string)cboDeletedVarName.SelectedValue;


            //if (!string.IsNullOrEmpty(survey) && !string.IsNullOrEmpty(varname))
            //{
            //    qid = DBAction.GetQuestionID(survey, varname);

            //    if (qid == 0)
            //    {
            //        // must be a deleted question
            //        comments = DBAction.GetDeletedComments(survey, varname);
            //    }
            //    else
            //    {
            //        comments = DBAction.GetQuesCommentsByQID(qid);
                    
            //    }
                
            //}

            if (comments.Count > 0)
            {
                commentsForm = new CommentList(survey, varname, comments );
                commentsForm.Visible = true;
            }
            else
            {
                MessageBox.Show("No comments for this question.");
            }
        }

        private void GetAuditSurveys()
        {
            cboSurvey.ValueMember = "Survey";
            cboSurvey.DisplayMember = "Survey";
            cboSurvey.DataSource = DBAction.GetAuditSurveys();
        }

        /// <summary>
        /// Retrieves the VarNames for the selected Survey. Deleted VarNames are first so that we end up with an in-use VarName as the default.
        /// </summary>
        private void GetAuditVarNames()
        {
            cboVarName.ValueMember = "VarName";
            cboVarName.DisplayMember = "RefVarName";

            
            // get deleted vars
            cboDeletedVarName.DataSource = DBAction.GetDeletedVarNames((string)cboSurvey.SelectedValue);
            // get in-use vars
            cboVarName.DataSource = DBAction.GetAuditVarNames((string)cboSurvey.SelectedValue);
        }

        private void RefreshCurrentQuestion(string survey, string varname, bool deleted = false)
        {
            int qid = 0;
            List<QuestionComment> comments;
            if (deleted)
            {
                qid = Convert.ToInt32(DBAction.GetDeletedQID(survey, varname));
                //comments = DBAction.GetDeletedComments(survey, varname);
            }
            else
            {
                qid = DBAction.GetQuestionID(survey, varname);
               // comments = DBAction.GetQuesCommentsByQID(qid);
            }
            
            if (qid == 0)
            {
                MessageBox.Show("Question not found in audit trail.");
                return;
            }

            currentQID = qid;

            GetHistory(qid);

            RefreshForm();

            if (commentsForm != null)
            {
                //commentsForm.ChangeQuestion(survey, varname, comments);
            }
        }

        private void RefreshCurrentQuestion(string survey, string varname)
        {
            int qid = 0;
            
            qid = DBAction.GetQuestionID(survey, varname);
            
            if (qid == 0)
            {
                // must be a deleted question
                qid = Convert.ToInt32(DBAction.GetDeletedQID(survey, varname));                
            }

            if (qid == 0)
            {
                MessageBox.Show("Question not found in audit trail.");
                return;
            }

            currentQID = qid;

            GetHistory(qid);

            RefreshForm();
        }

        private void MarkWordings()
        {
            // left
            if (!string.IsNullOrEmpty(txtPrePNumberPrev.Text))
                MarkWording("PreP", Int32.Parse(txtPrePNumberPrev.Text), lblPrePPrev);

            if (!string.IsNullOrEmpty(txtPreINumberPrev.Text))
                MarkWording("PreI", Int32.Parse(txtPreINumberPrev.Text), lblPreIPrev);

            if (!string.IsNullOrEmpty(txtPreANumberPrev.Text))
                MarkWording("PreA", Int32.Parse(txtPreANumberPrev.Text), lblPreAPrev);

            if (!string.IsNullOrEmpty(txtLitQNumberPrev.Text))
                MarkWording("LitQ", Int32.Parse(txtLitQNumberPrev.Text), lblLitQPrev);

            if (!string.IsNullOrEmpty(txtPstINumberPrev.Text))
                MarkWording("PstI", Int32.Parse(txtPstINumberPrev.Text), lblPstIPrev);

            if (!string.IsNullOrEmpty(txtPstPNumberPrev.Text))
                MarkWording("PstP", Int32.Parse(txtPstPNumberPrev.Text), lblPstPPrev);

            if (!string.IsNullOrEmpty(txtRespNamePrev.Text))
                MarkWording("RespOptions", txtRespNamePrev.Text, lblRespsPrev);

            if (!string.IsNullOrEmpty(txtNRNamePrev.Text))
                MarkWording("NRCodes", txtNRNamePrev.Text, lblNonRespsPrev);

            // middle
            if (!string.IsNullOrEmpty(txtPrePNumber.Text))
                MarkWording("PreP", Int32.Parse(txtPrePNumber.Text), lblPreP);

            if (!string.IsNullOrEmpty(txtPreINumber.Text))
                MarkWording("PreI", Int32.Parse(txtPreINumber.Text), lblPreI);

            if (!string.IsNullOrEmpty(txtPreANumber.Text))
                MarkWording("PreA", Int32.Parse(txtPreANumber.Text), lblPreA);

            if (!string.IsNullOrEmpty(txtLitQNumber.Text))
                MarkWording("LitQ", Int32.Parse(txtLitQNumber.Text), lblLitQ);

            if (!string.IsNullOrEmpty(txtPstINumber.Text))
                MarkWording("PstI", Int32.Parse(txtPstINumber.Text), lblPstI);

            if (!string.IsNullOrEmpty(txtPstPNumber.Text))
                MarkWording("PstP", Int32.Parse(txtPstPNumber.Text), lblPstP);

            if (!string.IsNullOrEmpty(txtRespName.Text))
                MarkWording("RespOptions", txtRespName.Text, lblResps);

            if (!string.IsNullOrEmpty(txtNRName.Text))
                MarkWording("NRCodes", txtNRName.Text, lblNonResps);

            // right
            if (!string.IsNullOrEmpty(txtPrePNumberNext.Text))
                MarkWording("PreP", Int32.Parse(txtPrePNumberNext.Text), lblPrePNext);

            if (!string.IsNullOrEmpty(txtPreINumberNext.Text))
                MarkWording("PreI", Int32.Parse(txtPreINumberNext.Text), lblPreINext);

            if (!string.IsNullOrEmpty(txtPreANumberNext.Text))
                MarkWording("PreA", Int32.Parse(txtPreANumberNext.Text), lblPreANext);

            if (!string.IsNullOrEmpty(txtLitQNumberNext.Text))
                MarkWording("LitQ", Int32.Parse(txtLitQNumberNext.Text), lblLitQNext);

            if (!string.IsNullOrEmpty(txtPstINumberNext.Text))
                MarkWording("PstI", Int32.Parse(txtPstINumberNext.Text), lblPstINext);

            if (!string.IsNullOrEmpty(txtPstPNumberNext.Text))
                MarkWording("PstP", Int32.Parse(txtPstPNumberNext.Text), lblPstPNext);

            if (!string.IsNullOrEmpty(txtRespNameNext.Text))
                MarkWording("RespOptions", txtRespNameNext.Text, lblRespsNext);

            if (!string.IsNullOrEmpty(txtNRNameNext.Text))
                MarkWording("NRCodes", txtNRNameNext.Text, lblNonRespsNext);
        }

        private void MarkWording(string field, int wordingNumber, Label lbl)
        {
            if (wordingNumber !=0 && DBAction.WordingHasHistory(field, wordingNumber))
                lbl.BackColor = Color.Orange;
            else
                lbl.BackColor = SystemColors.Control;
        }

        private void MarkWording(string field, string respName, Label lbl)
        {
            if (!respName.Equals("0") && DBAction.ResponseHasHistory(field, respName))
                lbl.BackColor = Color.Orange;
            else
                lbl.BackColor = SystemColors.Control;
        }

        private void MoveRecord()
        {
            if (bs.Position == 0)
            {
                bsPrev.Position = 0;
                // hide previous question
                panelPrev.Visible = false;
            }
            else
            {
                bsPrev.Position = bs.Position - 1;
                panelPrev.Visible = true;
            }

            if (bs.Position == bs.Count - 1)
            {
                bsNext.Position = bs.Count - 1;
                panelNext.Visible = false;
            }
            else
            {
                bsNext.Position = bs.Position + 1;
                panelNext.Visible = true;
            }

            ChangedSurveyQuestion previous = (ChangedSurveyQuestion)bsPrev.Current;
            ChangedSurveyQuestion current = (ChangedSurveyQuestion)bs.Current;
            ChangedSurveyQuestion next = (ChangedSurveyQuestion)bsNext.Current;

            rtbQuestionTextPrev.Rtf = "";
            rtbQuestionTextPrev.Rtf = previous.GetQuestionTextRich();
            rtbQuestionText.Rtf = "";
            rtbQuestionText.Rtf = current.GetQuestionTextRich();
            rtbQuestionTextNext.Rtf = "";
            rtbQuestionTextNext.Rtf = next.GetQuestionTextRich();

            ColorControl(txtVarName);
            ColorControl(txtUserName);

            ColorControl(txtAltQnum);
            ColorControl(txtAltQnum2);
            ColorControl(txtAltQnum3);

            ColorControl(txtPrePNumber);
            ColorControl(txtPreINumber);
            ColorControl(txtPreANumber);
            ColorControl(txtLitQNumber);
            ColorControl(txtPstINumber);
            ColorControl(txtPstPNumber);
            ColorControl(txtRespName);
            ColorControl(txtNRName);

            ColorControl(chkCorrected);
            ColorControl(chkScriptOnly);

            ColorControl(txtVarType);
            ColorControl(txtNumCol);
            ColorControl(txtNumDec);
            ColorControl(txtNumFmt);

            MarkWordings();
        }


        private void RefreshForm()
        {
            bsPrev.Position = 0;
            bsNext.Position = 0;
            bs.Position = 0;

            bsPrev.DataSource = history;
            bsNext.DataSource = history;
            bs.DataSource = history ;
            

            navQuestions.BindingSource = bs;
            navQuestions.Refresh();

            foreach (Control c in this.Controls)
            {
                if (c is TextBox || c is DateTimePicker || c is RichTextBox || c is CheckBox)
                {
                    c.DataBindings.Clear();
                }
            }

            foreach (Control c in this.panelPrev.Controls)
            {
                if (c is TextBox || c is DateTimePicker || c is RichTextBox || c is CheckBox)
                {
                    c.DataBindings.Clear();
                }
            }

            foreach (Control c in this.panelNext.Controls)
            {
                if (c is TextBox || c is DateTimePicker || c is RichTextBox || c is CheckBox)
                {
                    c.DataBindings.Clear();
                }
            }

            BindControl(this.Controls["txtUpdateDate"], "UpdateDate");
            BindControl(this.Controls["txtChangeType"], "ChangeType");
            BindControl(this.Controls["txtUserName"], "UserName");

            BindControl(this.Controls["txtAltQnum"], "AltQnum");
            BindControl(this.Controls["txtAltQnum2"], "AltQnum2");
            BindControl(this.Controls["txtAltQnum3"], "AltQnum3");

            BindControl(this.Controls["txtVarName"], "VarName");
            BindControl(this.Controls["txtPrePNumber"], "PrePNum");
            BindControl(this.Controls["txtPreINumber"], "PreINum");
            BindControl(this.Controls["txtPreANumber"], "PreANum");
            BindControl(this.Controls["txtLitQNumber"], "LitQNum");
            BindControl(this.Controls["txtPstINumber"], "PstINum");
            BindControl(this.Controls["txtPstPNumber"], "PstPNum");
            BindControl(this.Controls["txtRespName"], "RespName");
            BindControl(this.Controls["txtNRName"], "NRName");

            BindControl(this.Controls["chkTableFormat"], "TableFormat");
            BindControl(this.Controls["chkCorrected"], "CorrectedFlag");
            BindControl(this.Controls["txtVarType"], "VarType");
            BindControl(this.Controls["chkScriptOnly"], "ScriptOnly");
            BindControl(this.Controls["txtNumCol"], "NumCol");
            BindControl(this.Controls["txtNumDec"], "NumDec");
            BindControl(this.Controls["txtNumFmt"], "NumFmt");

            bs.Position = 0;
            MoveRecord();
        }

        private void BindControl(Control c, string member)
        {
            if (c is TextBox) {

                panelPrev.Controls[c.Name + "Prev"].DataBindings.Add(new Binding("Text", bsPrev, member));
                this.Controls[c.Name].DataBindings.Add(new Binding("Text", bs, member));
                panelNext.Controls[c.Name + "Next"].DataBindings.Add(new Binding("Text", bsNext, member));
            }
            else if (c is CheckBox)
            {
                panelPrev.Controls[c.Name + "Prev"].DataBindings.Add(new Binding("Checked", bsPrev, member));
                this.Controls[c.Name].DataBindings.Add(new Binding("Checked", bs, member));
                panelNext.Controls[c.Name + "Next"].DataBindings.Add(new Binding("Checked", bsNext, member));
            }
            else if (c is DateTimePicker)
            {
                panelPrev.Controls[c.Name + "Prev"].DataBindings.Add(new Binding("Value", bsPrev, member));
                this.Controls[c.Name].DataBindings.Add(new Binding("Value", bs, member));
                panelNext.Controls[c.Name + "Next"].DataBindings.Add(new Binding("Value", bsNext, member));
            }
        }

        private void ColorControl(TextBox c)
        {
            TextBox prev = (TextBox)panelPrev.Controls[c.Name + "Prev"];
            TextBox next = (TextBox)panelNext.Controls[c.Name + "Next"];

            if (c is TextBox)
            {
                if (!prev.Text.Equals(c.Text))
                    c.BackColor = Color.Yellow;
                else
                    c.BackColor = Color.White;

                if (!next.Text.Equals(c.Text))
                    next.BackColor = Color.Yellow;
                else
                    next.BackColor = Color.White;
            }
            
        }

        private void ColorControl(CheckBox c)
        {
            CheckBox prev =(CheckBox) panelPrev.Controls[c.Name + "Prev"];
            CheckBox next =(CheckBox) panelNext.Controls[c.Name + "Next"];

            if (!prev.Checked.Equals(c.Checked))
                c.BackColor = Color.Yellow;
            else
                c.BackColor = Color.White;

            if (!next.Checked.Equals(c.Checked))
                next.BackColor = Color.Yellow;
            else
                next.BackColor = Color.White;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode )
            {
                case Keys.Right:
                    bs.Position++;
                    break;
                case Keys.Left:
                    bs.Position--;
                    break;
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            bs.Position++;
        }

        private void cmdPrev_Click(object sender, EventArgs e)
        {
            bs.Position--;
        }

        #region Open Wording Methods and Click Events

        private void OpenWordingHistory(string fieldname, int id)
        {
            WordingHistory frm = new WordingHistory(fieldname, id);

            if (!frm.IsDisposed)
                frm.Visible = true;
        }

        private void OpenWordingHistory(string fieldname, string id)
        {
            ResponseSetHistory frm = new ResponseSetHistory(fieldname, id);

            if (!frm.IsDisposed)
                frm.Visible = true;
        }

        private void txtPrePNumber_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreP", Convert.ToInt32(txtPrePNumber.Text));
        }

        private void txtPreINumber_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreI", Convert.ToInt32(txtPreINumber.Text));
        }

        private void txtPreANumber_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreA", Convert.ToInt32(txtPreANumber.Text));
        }

        private void txtLitQNumber_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("LitQ", Convert.ToInt32(txtLitQNumber.Text));
        }

        private void txtRespName_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("RespOptions", txtRespName.Text);
        }

        private void txtNRName_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("NRCodes", txtNRName.Text);
        }

        private void txtPstINumber_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PstI", Convert.ToInt32(txtPstINumber.Text));
        }

        private void txtPstPNumber_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PstP", Convert.ToInt32(txtPstPNumber.Text));
        }

        private void txtPrePNumberPrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreP", Convert.ToInt32(txtPrePNumberPrev.Text));
        }

        private void txtPreINumberPrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreI", Convert.ToInt32(txtPreINumberPrev.Text));
        }

        private void txtPreANumberPrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreA", Convert.ToInt32(txtPreANumberPrev.Text));
        }

        private void txtLitQNumberPrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("LitQ", Convert.ToInt32(txtLitQNumberPrev.Text));
        }

        private void txtRespNamePrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("RespOptions", txtRespNamePrev.Text);
        }

        private void txtNRNamePrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("NRCodes", txtNRNamePrev.Text);
        }

        private void txtPstINumberPrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PstI", Convert.ToInt32(txtPstINumberPrev.Text));
        }

        private void txtPstPNumberPrev_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PstP", Convert.ToInt32(txtPstPNumberPrev.Text));
        }

        private void txtPrePNumberNext_DoubleClick(object sender, EventArgs e)
        {
            TextBox field = (TextBox)sender;

            string s = field.DataBindings[0].BindingMemberInfo.BindingMember;
            OpenWordingHistory("PreP", Convert.ToInt32(txtPrePNumberNext.Text));
        }

        private void txtPreINumberNext_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreI", Convert.ToInt32(txtPreINumberNext.Text));
        }

        private void txtPreANumberNext_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PreA", Convert.ToInt32(txtPreANumberNext.Text));
        }

        private void txtLitQNumberNext_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("LitQ", Convert.ToInt32(txtLitQNumberNext.Text));
        }

        private void txtRespNameNext_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("RespOptions", txtRespNameNext.Text);
        }

        private void txtNRNameNext_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("NRCodes", txtNRNameNext.Text);
        }

        private void txtPstINumberNext_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PstI", Convert.ToInt32(txtPstINumberNext.Text));
        }

        private void cmdFeed_Click(object sender, EventArgs e)
        {
            AuditFeed feed = new AuditFeed();
            feed.Visible = true;
        }

        private void txtPstPNumberNext_DoubleClick(object sender, EventArgs e)
        {
            OpenWordingHistory("PstP", Convert.ToInt32(txtPstPNumberNext.Text));
        }
#endregion

        private void GetHistory(int qid)
        {
            history.Clear();
            ChangedSurveyQuestion previous = new ChangedSurveyQuestion();
            // get audit entries for certain primary key 
            var entries = DBAction.GetQuestionHistory(qid);
            
            // for each individual Day in the audit entries
            //var days = from entry in entries
            //           group entry by entry.UpdateDate.Date into newGroup
            //           orderby newGroup.Key
            //           select newGroup;

            var days = from entry in entries
                       group entry by entry.UpdateDate into newGroup
                       orderby newGroup.Key
                       select newGroup;

            // create a new question
            foreach (var day in days)
            {
                ChangedSurveyQuestion sq = new ChangedSurveyQuestion()
                {
                    VarName = previous.VarName,
                    PrePNum = previous.PrePNum,
                    PreINum = previous.PreINum,
                    PreANum = previous.PreANum,
                    LitQNum = previous.LitQNum,
                    PstINum = previous.PstINum,
                    PstPNum = previous.PstPNum,
                    UpdateDate = previous.UpdateDate
                };

                if (!string.IsNullOrEmpty(previous.RespName))
                    sq.RespName = string.Copy(previous.RespName);
                if (!string.IsNullOrEmpty(previous.NRName))
                    sq.NRName = string.Copy(previous.NRName);
                if (!string.IsNullOrEmpty(previous.VarType))
                    sq.VarType = string.Copy(previous.VarType);


                // go through the entries for the day always overwriting with the newest value
                foreach (AuditEntry entry in day)
                {
                    sq.UpdateDate = entry.UpdateDate;
                    sq.ChangeType = entry.Type;
                    sq.UserName = entry.UserName;
                    switch (entry.FieldName)
                    {
                        case "VarName":
                            sq.VarName = entry.NewValue;
                            break;
                        case "PreP#":
                            sq.PrePNum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PreI#":
                            sq.PreINum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PreA#":
                            sq.PreANum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "LitQ#":
                            sq.LitQNum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PstI#":
                            sq.PstINum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PstP#":
                            sq.PstPNum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "RespName":
                            sq.RespName = entry.NewValue;
                            break;
                        case "NRName":
                            sq.NRName = entry.NewValue;
                            break;
                        case "AltQnum":
                            sq.AltQnum = entry.NewValue;
                            break;
                        case "AltQnum2":
                            sq.AltQnum2 = entry.NewValue;
                            break;
                        case "AltQnum3":
                            sq.AltQnum3 = entry.NewValue;
                            break;
                        case "TableFormat":
                            if (entry.NewValue == null || entry.NewValue.Equals("0"))
                                sq.TableFormat = false;
                            else
                                sq.TableFormat = true;
                            break;
                        case "CorrectedFlag":
                            if (entry.NewValue == null ||  entry.NewValue.Equals("0"))
                                sq.CorrectedFlag = false;
                            else
                                sq.CorrectedFlag = true;
                            break;
                        case "ScriptOnly":
                            if (entry.NewValue == null || entry.NewValue.Equals("0"))
                                sq.ScriptOnly = false;
                            else
                                sq.ScriptOnly = true;
                            break;
                        case "VarType":
                            sq.VarType = entry.NewValue;
                            break;
                        case "NumCol":
                            sq.NumCol = Convert.ToInt32(entry.NewValue);
                            break;
                        case "NumDec":
                            sq.NumDec= Convert.ToInt32(entry.NewValue);
                            break;
                        case "NumFmt":
                            sq.NumFmt = entry.NewValue;
                            break;
                        
                    }

                }
                previous = sq;
                history.Add(sq);

            }

            // TODO get wording on the date in this object
            foreach (ChangedSurveyQuestion sq in history)
            {
                if (sq.PrePNum > 0)
                {
                    sq.PreP = GetWording("PreP", sq.PrePNum, sq.UpdateDate);
                }



                if (sq.PreINum > 0)
                {
                    sq.PreI = GetWording("PreI", sq.PreINum, sq.UpdateDate);
                    
                    //sq.PreI = DBAction.GetWordingText("PreI", sq.PreINum);
                    //if (string.IsNullOrEmpty(sq.PreI))
                    //    sq.PreI = DBAction.GetDeletedWording("PreI", sq.PreINum);
                }


                if (sq.PreANum > 0)
                {
                    sq.PreA = GetWording("PreA", sq.PreANum, sq.UpdateDate);
                    
                    //sq.PreI = DBAction.GetWordingText("PreA", sq.PreANum);
                    //if (string.IsNullOrEmpty(sq.PreA))
                    //    sq.PreA = DBAction.GetDeletedWording("PreA", sq.PreANum);
                }

                if (sq.LitQNum > 0)
                {
                    sq.LitQ = GetWording("LitQ", sq.LitQNum, sq.UpdateDate);
                    //break;
                    //sq.LitQ = DBAction.GetWordingText("LitQ", sq.LitQNum);
                    //if (string.IsNullOrEmpty(sq.LitQ))
                    //    sq.LitQ = DBAction.GetDeletedWording("LitQ", sq.LitQNum);
                }

                if (sq.PstINum > 0)
                {
                    sq.PstI = GetWording("PstI", sq.PstINum, sq.UpdateDate);
                    //sq.PstI = DBAction.GetWordingText("PstI", sq.PstINum);
                    //if (string.IsNullOrEmpty(sq.PstI))
                    //    sq.PstI = DBAction.GetDeletedWording("PstI", sq.PstINum);
                }

                if (sq.PstPNum > 0)
                {

                    sq.PstP = GetWording("PstP", sq.PstPNum, sq.UpdateDate);
                    //break;
                    //sq.PstP = DBAction.GetWordingText("PstP", sq.PstPNum);
                    //if (string.IsNullOrEmpty(sq.PstP))
                    //    sq.PstP = DBAction.GetDeletedWording("PstP", sq.PstPNum);
                }

                if (sq.RespName != null && !sq.RespName.Equals("0"))
                {
                    

                    sq.RespOptions = DBAction.GetResponseText(sq.RespName);
                    if (string.IsNullOrEmpty(sq.RespOptions))
                        sq.RespOptions = DBAction.GetDeletedWording("RespOptions", sq.RespName);
                }

                if (sq.NRName!=null && !sq.NRName.Equals("0"))
                {
                    sq.NRCodes = DBAction.GetNonResponseText(sq.NRName);
                    if (string.IsNullOrEmpty(sq.NRCodes))
                        sq.NRCodes = DBAction.GetDeletedWording("NRCodes", sq.NRName);
                }
            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuestionHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private string GetWording(string wordingType, int wordingID, DateTime since)
        {
            // get wording history for this wording
            List<AuditEntry> wHistory = DBAction.GetWordingHistory(wordingType, wordingID);
            string wordingToUse = "";



            // if this wording has no history, or all entries are previous to the date of this sq, use the latest
            var updates = wHistory.Where(x => x.UpdateDate <= since);
            if (wHistory.Count ==0 || updates.Count<AuditEntry>() == wHistory.Count)
            {
                wordingToUse = DBAction.GetWordingText(wordingType, wordingID);
                if (string.IsNullOrEmpty(wordingToUse))
                    wordingToUse = DBAction.GetDeletedWording(wordingType, wordingID.ToString());
            }
            else  // other wise use the one just before this date
            {
                foreach (AuditEntry entry in updates)
                {
                    if (entry.UpdateDate <= since && entry.FieldName.Equals("Wording"))
                        wordingToUse = entry.NewValue;
                }
            }
            return wordingToUse;
        }

        private void GetHistoryDetailed(int qid)
        {
            history.Clear();
            ChangedSurveyQuestion previous = new ChangedSurveyQuestion();
            // get audit entries for certain primary key 
            var entries = DBAction.GetQuestionHistory(qid);

            // for each individual Day in the audit entries
            var days = from entry in entries
                       group entry by entry.UpdateDate.Date into newGroup
                       orderby newGroup.Key
                       select newGroup;

            // create a new question
            foreach (var day in days)
            {
                ChangedSurveyQuestion sq = new ChangedSurveyQuestion()
                {
                    VarName = previous.VarName,
                    PrePNum = previous.PrePNum,
                    PreINum = previous.PreINum,
                    PreANum = previous.PreANum,
                    LitQNum = previous.LitQNum,
                    PstINum = previous.PstINum,
                    PstPNum = previous.PstPNum,
                    UpdateDate = previous.UpdateDate
                };

                if (!string.IsNullOrEmpty(previous.RespName))
                    sq.RespName = string.Copy(previous.RespName);
                if (!string.IsNullOrEmpty(previous.NRName))
                    sq.NRName = string.Copy(previous.NRName);
                if (!string.IsNullOrEmpty(previous.VarType))
                    sq.VarType = string.Copy(previous.VarType);


                // go through the entries for the day always overwriting with the newest value
                foreach (AuditEntry entry in day)
                {
                    sq.UpdateDate = entry.UpdateDate.Date;
                    sq.ChangeType = entry.Type;
                    sq.UserName = entry.UserName;
                    switch (entry.FieldName)
                    {
                        case "VarName":
                            sq.VarName = entry.NewValue;
                            break;
                        case "PreP#":
                            sq.PrePNum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PreI#":
                            sq.PreINum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PreA#":
                            sq.PreANum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "LitQ#":
                            sq.LitQNum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PstI#":
                            sq.PstINum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "PstP#":
                            sq.PstPNum = Convert.ToInt32(entry.NewValue);
                            break;
                        case "RespName":
                            sq.RespName = entry.NewValue;
                            break;
                        case "NRName":
                            sq.NRName = entry.NewValue;
                            break;
                        case "AltQnum":
                            sq.AltQnum = entry.NewValue;
                            break;
                        case "AltQnum2":
                            sq.AltQnum2 = entry.NewValue;
                            break;
                        case "AltQnum3":
                            sq.AltQnum3 = entry.NewValue;
                            break;
                        case "TableFormat":
                            if (entry.NewValue == null || entry.NewValue.Equals("0"))
                                sq.TableFormat = false;
                            else
                                sq.TableFormat = true;
                            break;
                        case "CorrectedFlag":
                            if (entry.NewValue == null || entry.NewValue.Equals("0"))
                                sq.CorrectedFlag = false;
                            else
                                sq.CorrectedFlag = true;
                            break;
                        case "ScriptOnly":
                            if (entry.NewValue == null || entry.NewValue.Equals("0"))
                                sq.ScriptOnly = false;
                            else
                                sq.ScriptOnly = true;
                            break;
                        case "VarType":
                            sq.VarType = entry.NewValue;
                            break;
                        case "NumCol":
                            sq.NumCol = Convert.ToInt32(entry.NewValue);
                            break;
                        case "NumDec":
                            sq.NumDec = Convert.ToInt32(entry.NewValue);
                            break;
                        case "NumFmt":
                            sq.NumFmt = entry.NewValue;
                            break;

                    }

                }
                previous = sq;
                history.Add(sq);

            }

            // TODO get wording on the date in this object
            foreach (ChangedSurveyQuestion sq in history)
            {
                if (sq.PrePNum > 0)
                {
                    sq.PreP = DBAction.GetWordingText("PreP", sq.PrePNum);
                    if (string.IsNullOrEmpty(sq.PreP))
                        sq.PreP = DBAction.GetDeletedWording("PreP", sq.PrePNum.ToString());
                }

                if (sq.PreINum > 0)
                {
                    sq.PreI = DBAction.GetWordingText("PreI", sq.PreINum);
                    if (string.IsNullOrEmpty(sq.PreI))
                        sq.PreI = DBAction.GetDeletedWording("PreI", sq.PreINum.ToString());
                }


                if (sq.PreANum > 0)
                {
                    sq.PreI = DBAction.GetWordingText("PreA", sq.PreANum);
                    if (string.IsNullOrEmpty(sq.PreA))
                        sq.PreA = DBAction.GetDeletedWording("PreA", sq.PreANum.ToString());
                }

                if (sq.LitQNum > 0)
                {
                    sq.LitQ = DBAction.GetWordingText("LitQ", sq.LitQNum);
                    if (string.IsNullOrEmpty(sq.LitQ))
                        sq.LitQ = DBAction.GetDeletedWording("LitQ", sq.LitQNum.ToString());
                }

                if (sq.PstINum > 0)
                {
                    sq.PstI = DBAction.GetWordingText("PstI", sq.PstINum);
                    if (string.IsNullOrEmpty(sq.PstI))
                        sq.PstI = DBAction.GetDeletedWording("PstI", sq.PstINum.ToString());
                }

                if (sq.PstPNum > 0)
                {
                    sq.PstP = DBAction.GetWordingText("PstP", sq.PstPNum);
                    if (string.IsNullOrEmpty(sq.PstP))
                        sq.PstP = DBAction.GetDeletedWording("PstP", sq.PstPNum.ToString());
                }

                if (sq.RespName != null && !sq.RespName.Equals("0"))
                {
                    sq.RespOptions = DBAction.GetResponseText(sq.RespName);
                    if (string.IsNullOrEmpty(sq.RespOptions))
                        sq.RespOptions = DBAction.GetDeletedWording("RespOptions", sq.RespName);
                }

                if (sq.NRName != null && !sq.NRName.Equals("0"))
                {
                    sq.NRCodes = DBAction.GetNonResponseText(sq.NRName);
                    if (string.IsNullOrEmpty(sq.NRCodes))
                        sq.NRCodes = DBAction.GetDeletedWording("NRCodes", sq.NRName);
                }
            }

        }
    }
}
