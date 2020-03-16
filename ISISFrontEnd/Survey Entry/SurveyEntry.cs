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
    // TODO on this form (Survey Entry)
    // instead of having a CurrentSurvey object, have a bindinglist of questions, then the DBAction methods can always return a regular list, and forms can use it to create a bindinglist
    // brown form filters
    // green form filters
    // translations
    // corrected wordings

    // other menu items

    public partial class SurveyEntry : Form
    {
        public MainMenu frmParent;              // reference to main menu
        public string key;                      // unique ID for this instance
        public int index; // there will be a maximum of 3 survey entry forms
        public Survey CurrentSurvey;            // currently displayed survey
        public SurveyQuestion CurrentQuestion;  // currently displayed question
        BindingSource bs;
        BindingSource bsComments;

        private bool _dirty;
        private bool Dirty
        {
            get
            {
                return _dirty;
            }
            set
            {
                _dirty = value;
                if (_dirty)
                {
                    lblTitle.Text = "Survey Entry*";
                }
                else
                {
                    lblTitle.Text = "Survey Entry";
                }
            }
        }

        private bool NewRecord { get; set; }

        private bool Renumber { get; set; }
        private bool TranslationSync { get; set; }

        // references to popup forms
        WordingUsage frmWordings;
        ResponseOptionUsage frmRespOptions;
        NonResponseOptionUsage frmNonRespOptions;
        SurveyEntryBrown frmBrown;
        SurveyEntryGreen frmGreen;
        // translation
        // deleted questions
        // corrected questions
        CommentEntry frmComments;
        // comments


        public SurveyEntry()
        {
            InitializeComponent();
        }

        public SurveyEntry(string surveyCode)
        {

            CurrentSurvey = DBAction.GetSurveyInfo(surveyCode);
            DBAction.FillQuestions(CurrentSurvey);

            if (CurrentSurvey.Questions == null)
            {
                MessageBox.Show("Error getting " + surveyCode + "'s questions. Ensure there is at least one question in this survey.");
                Close();
            }


            InitializeComponent();

            this.MouseWheel += SurveyEntry_OnMouseWheel;
            //txtPrePR.MouseWheel += SurveyEntry_OnMouseWheel;

            bs = new BindingSource
            {
                DataSource = CurrentSurvey.Questions

            };
            bs.PositionChanged += Bs_PositionChanged;
            bs.CurrentItemChanged += Bs_CurrentItemChanged;

            bs.ListChanged += SurveyEntry_ListChanged;

            navQuestions.BindingSource = bs;


            // bind the comment bindingsource to the current item in the question bindingsource, but set the datamember to the comment list
            bsComments = new BindingSource
            {
                DataSource = bs.Current,
                DataMember = "Comments"
            };
            navComments.BindingSource = bsComments;


            BindProperties();

            LockForm();

            ColorForm();


        }


        private void Bs_CurrentItemChanged(object sender, EventArgs e)
        {



        }

        #region Events
        private void SurveyEntry_Load(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;
            //bs.Position = frmParent.currentUser.positions[index]; // TODO add position property to user
            LoadComments();
            LoadQuestion();
        }

        protected void SurveyEntry_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }

        }

        private void SurveyEntry_ListChanged(object sender, ListChangedEventArgs e)
        {

            if (e.PropertyDescriptor == null) return;

            SurveyQuestion currentQ = (SurveyQuestion)bs.Current;
            switch (e.PropertyDescriptor.Name)
            {
                case "PrePNum":
                    currentQ.PreP = DBAction.GetWordingText("PreP", currentQ.PrePNum);
                    break;
                case "PreINum":
                    currentQ.PreI = DBAction.GetWordingText("PreI", currentQ.PreINum);
                    break;
                case "PreANum":
                    currentQ.PreA = DBAction.GetWordingText("PreA", currentQ.PreANum);
                    break;
                case "LitQNum":
                    currentQ.LitQ = DBAction.GetWordingText("LitQ", currentQ.LitQNum);
                    break;
                case "PstINum":
                    currentQ.PstI = DBAction.GetWordingText("PstI", currentQ.PstINum);
                    break;
                case "PstPNum":
                    currentQ.PstP = DBAction.GetWordingText("PstP", currentQ.PstPNum);
                    break;
                case "RespName":
                    currentQ.RespOptions = DBAction.GetResponseText(currentQ.RespName);
                    break;
                case "NRName":
                    currentQ.NRCodes = DBAction.GetNonResponseText(currentQ.NRName);
                    break;
            }
            bs.ResetBindings(false);
            Dirty = true;
        }

        /// <summary>
        /// Updates subforms to match the current record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;

            if (frmBrown != null)
                frmBrown.UpdateForm(CurrentQuestion.VarName.RefVarName);

            if (frmGreen != null)
                frmGreen.UpdateRefVarName(CurrentQuestion.VarName.RefVarName);

            LoadComments();
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

        
            txtPrePNum.BackColor = result;
        
            txtPreINum.BackColor = result;
      
            txtPreANum.BackColor = result;
      
            txtLitQNum.BackColor = result;
         
            txtPstINum.BackColor = result;
    
            txtPstPNum.BackColor = result;
            txtRespName.BackColor = result;
      
          
            txtNRName.BackColor = result;


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

            cmdUnlockSurvey.DataBindings.Add("Visible", CurrentSurvey, "Locked");

            // wordings
            txtPrePNum.DataBindings.Add(new Binding("Text", bs, "PrePNum"));
         
            txtPreINum.DataBindings.Add(new Binding("Text", bs, "PreINum"));
      
            txtPreANum.DataBindings.Add(new Binding("Text", bs, "PreANum"));
      
            txtLitQNum.DataBindings.Add(new Binding("Text", bs, "LitQNum"));
        
            txtPstINum.DataBindings.Add(new Binding("Text", bs, "PstINum"));
        
            txtPstPNum.DataBindings.Add(new Binding("Text", bs, "PstPNum"));
      
            txtRespName.DataBindings.Add(new Binding("Text", bs, "RespName"));

            txtNRName.DataBindings.Add(new Binding("Text", bs, "NRName"));
    

            chkCorrected.DataBindings.Add(new Binding("Visible", bs, "CorrectedFlag"));

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
            txtVarLabel.DataBindings.Add("Text", bs, "VarName.VarLabel");
            cboDomainLabel.DataBindings.Add("SelectedValue", bs, "VarName.Domain.ID");
            cboTopicLabel.DataBindings.Add("SelectedValue", bs, "VarName.Topic.ID");
            cboContentLabel.DataBindings.Add("SelectedValue", bs, "VarName.Content.ID");
            cboProductLabel.DataBindings.Add("SelectedValue", bs, "VarName.Product.ID");

            // field info
            chkTableFormat.DataBindings.Add("Checked", bs, "TableFormat");
            chkScriptOnly.DataBindings.Add("Checked", bs, "ScriptOnly");
            txtFmt.DataBindings.Add("Text", bs, "NumFmt");
            txtQuesType.DataBindings.Add("Text", bs, "VarType");
            numDec.DataBindings.Add("Value", bs, "NumDec");
            numCols.DataBindings.Add("Value", bs, "NumCol");

            // comments
            txtNoteType.DataBindings.Add("Text", bsComments, "NoteType");
            txtDate.DataBindings.Add("Text", bsComments, "NoteDate");
            txtInit.DataBindings.Add("Text", bsComments, "Name");
            txtNote.DataBindings.Add("Text", bsComments, "Notes");
            txtSource.DataBindings.Add("Text", bsComments, "Source");
            txtSourceName.DataBindings.Add("Text", bsComments, "SourceName");
        }

        /// <summary>
        /// Binds the wording number boxes' ReadOnly attribute to the Current Survey's locked attribute
        /// </summary>
        private void LockForm()
        {
            if (txtPrePNum.DataBindings["ReadOnly"] != null)
                txtPrePNum.DataBindings.Remove(txtPrePNum.DataBindings["ReadOnly"]);

            txtPrePNum.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPreINum.DataBindings["ReadOnly"] != null)
                txtPreINum.DataBindings.Remove(txtPreINum.DataBindings["ReadOnly"]);
            txtPreINum.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPreANum.DataBindings["ReadOnly"] != null)
                txtPreANum.DataBindings.Remove(txtPreANum.DataBindings["ReadOnly"]);
            txtPreANum.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtLitQNum.DataBindings["ReadOnly"] != null)
                txtLitQNum.DataBindings.Remove(txtLitQNum.DataBindings["ReadOnly"]);
            txtLitQNum.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPstINum.DataBindings["ReadOnly"] != null)
                txtPstINum.DataBindings.Remove(txtPstINum.DataBindings["ReadOnly"]);
            txtPstINum.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPstPNum.DataBindings["ReadOnly"] != null)
                txtPstPNum.DataBindings.Remove(txtPstPNum.DataBindings["ReadOnly"]);
            txtPstPNum.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtRespName.DataBindings["ReadOnly"] != null)
                txtRespName.DataBindings.Remove(txtRespName.DataBindings["ReadOnly"]);
            txtRespName.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtNRName.DataBindings["ReadOnly"] != null)
                txtNRName.DataBindings.Remove(txtNRName.DataBindings["ReadOnly"]);
            txtNRName.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");
        }


        #endregion

        #region Wording Buttons
        private void cmdOpenPreP_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PreP", CurrentQuestion.PrePNum);
        }

        private void cmdOpenPreI_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PreI", CurrentQuestion.PreINum);
        }

        private void cmdOpenPreA_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PreA", CurrentQuestion.PreANum);
        }

        private void cmdOpenLitQ_Click(object sender, EventArgs e)
        {
            OpenWordingForm("LitQ", CurrentQuestion.LitQNum);
        }

        private void cmdOpenPstI_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PstI", CurrentQuestion.PstINum);
        }

        private void cmdOpenPstP_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PstP", CurrentQuestion.PstPNum);
        }

        private void cmdOpenResp_Click(object sender, EventArgs e)
        {
            SurveyQuestion currentQ = (SurveyQuestion)bs.Current;
            if (frmRespOptions != null)
                frmRespOptions.Close();

            frmRespOptions = new ResponseOptionUsage("RespOptions", currentQ.RespName);

            frmRespOptions.Show();
        }

        private void cmdOpenNonResp_Click(object sender, EventArgs e)
        {
            SurveyQuestion currentQ = (SurveyQuestion)bs.Current;
            if (frmNonRespOptions != null)
                frmNonRespOptions.Close();

            frmNonRespOptions = new NonResponseOptionUsage("NRCodes", currentQ.NRName);

            frmNonRespOptions.Show();
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

            cmdUnlockSurvey.DataBindings.Clear();
            cmdUnlockSurvey.DataBindings.Add("Visible", CurrentSurvey, "Locked");

            LockForm();
        }

        public void LoadQuestion()
        {
            txtQuestionTextR.Rtf = CurrentQuestion.GetQuestionTextRich();
        }

        public void LoadComments()
        {
            

            if (CurrentQuestion.Comments.Count == 0)
            {
                lblCommentsPanel.Text = "No comments for this question.";
                panelComments.Visible = false;
                return;
            }
            else if (CurrentQuestion.Comments.Count == 1)
            {
                lblCommentsPanel.Text = "1 comment for this question.";
                panelComments.Visible = true;
            }
            else
            {
                lblCommentsPanel.Text = CurrentQuestion.Comments.Count + " comments for this question.";
                panelComments.Visible = true;
            }

            bsComments.DataSource = bs.Current;
        }

        /// <summary>
        /// Opens the wording form popup to a specific wording.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="number"></param>
        public void OpenWordingForm(string field, int number)
        {
            if (frmWordings != null)
                frmWordings.Close();

            frmWordings = new WordingUsage(field, number);

            frmWordings.Show();
        }

        private int SaveRecord()
        {
            
            if (NewRecord)
            {

                if (DBAction.InsertQuestion(CurrentSurvey.SurveyCode, CurrentQuestion) == 1)
                    return 1;
                
                NewRecord = false;
                Dirty = false;
            }
            else if (Dirty)
            {
                
                if (DBAction.UpdateQuestionWordings(CurrentQuestion) == 1)
                    return 1;

                //if (DBAction.UpdateLabels (CurrentQuestion) == 1) 
                //  return 1;

                Dirty = false;
            }
            
            return 0;
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
        /// Returns a VarName entered by the user. Continually prompts user for input until either an empty string is provided (user cancelled), or a valid VarName is entered.
        /// </summary>
        /// <returns></returns>
        private string GetNewVarName()
        {
            bool varOK = false;
            //bool tempVarOK = false;
            string newVarName = "";

            while (!varOK) // && !tempVarOK)
            {
                InputBox newName = new InputBox("New VarName:", "Enter VarName");
                newName.ShowDialog();

                newVarName = newName.userInput;

                if (CurrentSurvey.Questions.Where(x => x.VarName.Equals(newVarName)).Count() == 0)
                    varOK = true;

                // TODO check for temp name availability 
                // tempVarOK = true;
            }
            return newVarName;
        }

        // adds a question to the underlying survey's list of questions
        private void AddQuestion(string varname)
        {
            
            SurveyQuestion newQ = new SurveyQuestion();
            VariableName newVar;
            string newQnum = CurrentQuestion.Qnum;
            // get varname
            newQ.VarName.FullVarName = varname;
            // determine qnum
            if (CurrentQuestion.Qnum.Contains("!"))
                newQnum += "00";
            else
                newQnum += "z";

            if (newQnum.Length > 10) {
                MessageBox.Show("The Qnum for this new question is too long. Please limit the Qnum to 10 digits (including suffix). You may need to renumber the survey first.");
                return;
            }

            newQ.Qnum = newQnum;
            
            newVar = DBAction.GetVariable(newQ.VarName.FullVarName);
            if (newVar == null)
            {
                // if VarName does not exist, check refVarNames
                if (DBAction.RefVarNameExists(Utilities.ChangeCC(varname)))
                {
                    // display all the sets of the labels for this refVarName
                    VariableLabelSelector selector = new VariableLabelSelector(Utilities.ChangeCC(varname));
                    selector.frmParent = this;
                    selector.ShowDialog();
                }
            }
            else
            {
                // if VarName already exists, use those labels
                newQ.VarName.VarLabel = newVar.VarLabel;
                newQ.VarName.Domain = new DomainLabel(newVar.Domain);
                newQ.VarName.Topic = new TopicLabel(newVar.Topic);
                newQ.VarName.Content = new ContentLabel(newVar.Content);
                newQ.VarName.Product = new ProductLabel(newVar.Product);
            }

            // add to the list of questions, but after the current question
            CurrentSurvey.AddQuestion(newQ, bs.Position+1);
            
            // go to the new question
            GoToQnum(newQ.Qnum);

            SaveRecord();

            Renumber = true;

            // TODO check for wave comments
            
        }

        /// <summary>
        /// Sets the current questions labels.
        /// </summary>
        /// <param name="varlabel"></param>
        /// <param name="domain"></param>
        /// <param name="topic"></param>
        /// <param name="content"></param>
        /// <param name="product"></param>
        public void SetLabels(string varlabel, DomainLabel domain, TopicLabel topic, ContentLabel content, ProductLabel product)
        {
            CurrentQuestion.VarName.VarLabel = varlabel;
            CurrentQuestion.VarName.Domain = domain;
            CurrentQuestion.VarName.Topic = topic;
            CurrentQuestion.VarName.Content = content;
            CurrentQuestion.VarName.Product = product;
        }

        // TODO finish
        
        private void DeleteQuestion()
        {
            if (MessageBox.Show(CurrentQuestion.VarName + " will be deleted from " + CurrentSurvey.SurveyCode + ". \r\n Do you want to proceed?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int nextID = bs.Position;

                // backup comments
                DBAction.BackupComments(CurrentQuestion.ID);
                // delete question from database
                DBAction.DeleteQuestion(CurrentQuestion.VarName.FullVarName, CurrentQuestion.SurveyCode);
                // remove question from the list
                CurrentSurvey.Questions.Remove(CurrentQuestion);
                // remove current item from bindingsource
                bs.RemoveCurrent();

                // refresh comments
                
                // delete varname if no more uses 
                Renumber = true;

            }
            else
            {
                return;
            }

            if (MessageBox.Show("Do you want to document this deletion? (Click 'No' if you already have)", "Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {

            }
        }

        // TODO test
        private void SearchWordings()
        {
            string searchTerm = Clipboard.GetText();
            if (frmWordings == null)
                frmWordings = new WordingUsage();

            if (frmWordings.FilterWordings(Clipboard.GetText()) > 0)
            {
                frmWordings.Visible = true;
                return;
            }

            if (frmRespOptions == null)
                frmRespOptions = new ResponseOptionUsage();

            if (frmRespOptions.FilterWordings(Clipboard.GetText()) > 0)
            {
                return;
            }

            if (frmNonRespOptions == null)
                frmNonRespOptions = new NonResponseOptionUsage();

            if (frmNonRespOptions.FilterWordings(Clipboard.GetText()) > 0)
            {
                return;
            }
            
            
            
        }

        /// <summary>
        /// Copies the wording numbers and labels from the previous record to the current record. 
        /// LitQ, VarLabel and Content Labels are NOT copied with this method.
        /// </summary>
        private void CopyPreviousRecord()
        {
            try
            {
                SurveyQuestion previousQ = (SurveyQuestion)bs[bs.Position - 1];
                CurrentQuestion.PrePNum = previousQ.PrePNum;
                CurrentQuestion.PreINum = previousQ.PreINum;
                CurrentQuestion.PreANum = previousQ.PreANum;
                //CurrentQuestion.LitQNum = previousQ.LitQNum;
                CurrentQuestion.PstINum = previousQ.PstINum;
                CurrentQuestion.PstPNum = previousQ.PstPNum;
                CurrentQuestion.RespName = previousQ.RespName;
                CurrentQuestion.NRName = previousQ.NRName;

                // copy labels only if they are blank
                if (CurrentQuestion.VarName.Domain.ID == 0) CurrentQuestion.VarName.Domain.ID = previousQ.VarName.Domain.ID;
                if (CurrentQuestion.VarName.Topic.ID == 0) CurrentQuestion.VarName.Topic.ID = previousQ.VarName.Topic.ID;
                //if (CurrentQuestion.VarName.Content.ID == 0) CurrentQuestion.VarName.Content.ID = previousQ.VarName.Content.ID;
                if (CurrentQuestion.VarName.Product.ID == 0) CurrentQuestion.VarName.Product.ID = previousQ.VarName.Product.ID;

                bs.ResetCurrentItem();
            }
            catch
            {
                MessageBox.Show("You are at the first record!");
            }

            
        }

        #endregion

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            MoveRecord(1);
            
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this question.");
                return;
            }

            bs.MoveFirst();
        }
        #endregion


        private void cmdUnlockSurvey_Click(object sender, EventArgs e)
        {
            // TODO unlock form etc.
        }

        #region Menu - Functions
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRecord = true;
            string var = GetNewVarName();
            if (!string.IsNullOrEmpty(var))
                AddQuestion(var);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteQuestion();
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SurveyEntryFilter frmFilter = new SurveyEntryFilter();
            frmFilter.frmParent = this;
            frmFilter.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bs.ResetBindings(false);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // search wordings with clipboard
            SearchWordings();
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyPrevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyPreviousRecord();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Menu - Popups
        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frmBrown != null)
            {
                frmBrown.Close();
            }

            frmBrown = new SurveyEntryBrown(CurrentQuestion.VarName.RefVarName, frmParent.currentUser.SurveyEntryBrown[index - 1]);
            frmBrown.frmParent = this;
            frmBrown.Left = this.Left + 600;
            frmBrown.Top = this.Top + 100;
            frmBrown.TopLevel = true;
            frmBrown.TopMost = true;
            frmBrown.BringToFront();
            frmBrown.Show();
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frmGreen != null)
            {
                frmGreen.Close();
            }

            frmGreen = new SurveyEntryGreen(CurrentQuestion.VarName.RefVarName, frmParent.currentUser.SurveyEntryGreen[index - 1]);
            frmGreen.frmParent = this;
            frmGreen.Left = this.Left + 600;
            frmGreen.Top = this.Top + 600;
            frmGreen.TopLevel = true;
            frmGreen.TopMost = true;
            frmGreen.BringToFront();
            frmGreen.Show();
        }

        private void correctedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void varCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComments = new CommentEntry();
            frmComments.TopLevel = true;
            frmComments.TopMost = true;
            frmComments.BringToFront();
            frmComments.Show();
        }

        private void translationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Menu - Forms
        #endregion

        #region Menu - Toggle Fields
        private void altQnumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblAltQnum.Visible = !lblAltQnum.Visible;
            txtAltQnum.Visible = !txtAltQnum.Visible;

        }

        private void altQnum2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblAltQnum2.Visible = !lblAltQnum2.Visible;
            txtAltQnum2.Visible = !txtAltQnum2.Visible;
        }

        private void altQnum3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblAltQnum3.Visible = !lblAltQnum3.Visible;
            txtAltQnum3.Visible = !txtAltQnum3.Visible;
        }

        private void wordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPrePNum.Visible = !txtPrePNum.Visible;
            txtPreINum.Visible = !txtPreINum.Visible;
            txtPreANum.Visible = !txtPreANum.Visible;
            txtLitQNum.Visible = !txtLitQNum.Visible;
            txtPstINum.Visible = !txtPstINum.Visible;
            txtPstPNum.Visible = !txtPstPNum.Visible;
            txtRespName.Visible = !txtRespName.Visible;
            txtNRName.Visible = !txtNRName.Visible;
        }

        private void fieldInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkScriptOnly.Visible = !chkScriptOnly.Visible;
            lblFmt.Visible = !lblFmt.Visible;
            txtFmt.Visible = !txtFmt.Visible;
            lblType.Visible = !lblType.Visible;
            txtQuesType.Visible = !txtQuesType.Visible;
            lblDec.Visible = !lblDec.Visible;
            numDec.Visible = !numDec.Visible;
            lblCol.Visible = !lblCol.Visible;
            numCols.Visible = !numCols.Visible;
        }

        private void labelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblVarLabel.Visible = !lblVarLabel.Visible;
            txtVarLabel.Visible = !txtVarLabel.Visible;
            lblDomainLabel.Visible = !lblDomainLabel.Visible;
            cboDomainLabel.Visible = !cboDomainLabel.Visible;
            lblTopicLabel.Visible = !lblTopicLabel.Visible;
            cboTopicLabel.Visible = !cboTopicLabel.Visible;
            lblContentLabel.Visible = !lblContentLabel.Visible;
            cboContentLabel.Visible = !cboContentLabel.Visible;
            lblProductLabel.Visible = !lblProductLabel.Visible;
            cboProductLabel.Visible = !cboProductLabel.Visible;
        }
        #endregion

        #region Menu - Output
        #endregion

        #region Menu Items
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void questionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            

        }

        private void createEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        


        
        #endregion

        private void txtCorrected_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CurrentQuestion.CorrectedFlag = !CurrentQuestion.CorrectedFlag;
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionPreview preview = new QuestionPreview((SurveyQuestion)bs.Current);

            preview.Show();
        }

        /// <summary>
        /// Close any popup forms that were opened by this form. Then close this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (frmBrown!=null) frmBrown.Close();
            if (frmGreen != null) frmGreen.Close();
            if (frmWordings!=null) frmWordings.Close();
            if (frmRespOptions!=null) frmRespOptions.Close();
            if (frmNonRespOptions!=null) frmNonRespOptions.Close();
            
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
            frmParent.LabelSurveyEntryButtons();
            frmParent.CloseTab(key);
        }

        
    }
}

