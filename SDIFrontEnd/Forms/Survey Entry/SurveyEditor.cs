using System;
using System.Collections;
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
    public partial class SurveyEditor : Form
    {  
        // TODO delete documentation
        
        // TODO corrected form (on hold)


        // TODO search wordings

        public SurveyRecord CurrentSurvey { get; set; }       // current survey record
        public QuestionRecord CurrentRecord { get; set; }     // currently displayed question record 
        
        BindingSource bs;
        
        // reference to dragged item in Question List
        private ListViewItem dragItem = null;

        // references to popup forms      
        WordingUsage frmWordings;
        RelatedQuestions frmRelated;
        TranslationViewer frmTranslations;
        DeletedSurveyQuestions frmDeleted;
        //ViewQuestionComments frmComments;
        CommentEntry frmComments;
        QuestionViewer frmQuestionViewer;
        public SurveyEditorSearch frmSearch;

        List<ModifiedQuestion> PendingChanges;
        List<QuestionRecord> PendingDeletes;
        List<QuestionRecord> PendingAdds;

        int searchStart = 0;

        public event EventHandler LabelAdded;


        public SurveyEditor(int survID)
        {
            InitializeComponent();

            CurrentSurvey = Globals.AllSurveys.Where(x => x.SID== survID).FirstOrDefault();

            if (CurrentSurvey == null)
            {
                MessageBox.Show("Error loading survey ID#" + survID + ". Ensure that this survey exists.");
                Close();
                return;
            }

            PendingChanges = new List<ModifiedQuestion>();
            PendingDeletes = new List<QuestionRecord>();
            PendingAdds = new List<QuestionRecord>();

            AddMouseWheelEvents();
            
            // binding source for the "question records"
            bs = new BindingSource
            {
                DataSource = CurrentSurvey.Questions
            };
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += SurveyEditor_ListChanged;
            
            navQuestions.BindingSource = bs;

            CurrentRecord = (QuestionRecord)bs.Current;

            FillBoxes();
            BindProperties();

            ChangeSurvey(CurrentSurvey.SurveyCode);

            LockForm();
            UpdateStatus();
            Globals.RefreshDomains += SurveyEditor_RefreshDomains;
            Globals.RefreshTopics += SurveyEditor_RefreshTopics;
            Globals.RefreshContents += SurveyEditor_RefreshContents;
            Globals.RefreshProducts += SurveyEditor_RefreshProducts;
        }

        public SurveyEditor(string surveyCode, string varname)
        {
            InitializeComponent();

            CurrentSurvey = Globals.AllSurveys.Where(x => x.SurveyCode.Equals(surveyCode)).FirstOrDefault();

            if (CurrentSurvey == null)
            {
                MessageBox.Show("Error loading " + surveyCode + ". Ensure that this survey exists.");
                Close();
                return;
            }

            PendingChanges = new List<ModifiedQuestion>();
            PendingDeletes = new List<QuestionRecord>();
            PendingAdds = new List<QuestionRecord>();

            AddMouseWheelEvents();

            // binding source for the "question records"
            bs = new BindingSource
            {
                DataSource = CurrentSurvey.Questions
            };
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += SurveyEditor_ListChanged;

            navQuestions.BindingSource = bs;

            CurrentRecord = (QuestionRecord)bs.Current;

            FillBoxes();
            BindProperties();

            ChangeSurvey(CurrentSurvey.SurveyCode);

            LockForm();
            UpdateStatus();

            GoToQuestion(varname);
        }

        #region Form Setup

        /// <summary>
        /// Load questions, translations, comments and filters into the survey matching surveyCode.
        /// </summary>
        /// <param name="surveyCode"></param>
        private void LoadData(string surveyCode)
        {
            CurrentSurvey = Globals.AllSurveys.Where(x => x.SurveyCode.Equals(surveyCode)).FirstOrDefault();

            CurrentSurvey.Questions = DBAction.GetCompleteSurvey(CurrentSurvey);
            
            foreach (SurveyQuestion q in CurrentSurvey.Questions)
            {
                q.Filters = string.Join("\r\n", q.GetFilterVars());
            }
        }

        /// <summary>
        /// Bind the controls to the current survey's properties.
        /// </summary>
        private void BindProperties()
        {
            // varname and qnum
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName.VarName"));
            txtQnum.DataBindings.Add(new Binding("Text", bs, "Qnum"));
            txtAltQnum.DataBindings.Add(new Binding("Text", bs, "AltQnum"));
            txtAltQnum2.DataBindings.Add(new Binding("Text", bs, "AltQnum2"));
            txtAltQnum3.DataBindings.Add(new Binding("Text", bs, "AltQnum3"));

            // wordings
            txtPreP.DataBindings.Add(new Binding("Text", bs, "PrePNum"));
            txtPreI.DataBindings.Add(new Binding("Text", bs, "PreINum"));
            txtPreA.DataBindings.Add(new Binding("Text", bs, "PreANum"));
            txtLitQ.DataBindings.Add(new Binding("Text", bs, "LitQNum"));
            txtPstI.DataBindings.Add(new Binding("Text", bs, "PstINum"));
            txtPstP.DataBindings.Add(new Binding("Text", bs, "PstPNum"));
            txtRO.DataBindings.Add(new Binding("Text", bs, "RespName"));
            txtNR.DataBindings.Add(new Binding("Text", bs, "NRName"));

            // labels
            txtVarLabel.DataBindings.Add(new Binding("Text", bs, "VarName.VarLabel"));
            cboDomainLabel.DataBindings.Add("SelectedValue", bs, "VarName.Domain.ID");
            cboTopicLabel.DataBindings.Add("SelectedValue", bs, "VarName.Topic.ID");
            cboContentLabel.DataBindings.Add("SelectedValue", bs, "VarName.Content.ID");
            cboProductLabel.DataBindings.Add("SelectedValue", bs, "VarName.Product.ID");
        }

        /// <summary>
        /// Fill comboboxes with their options
        /// </summary>
        private void FillBoxes()
        {
            // menus
            toolStripLanguage.ComboBox.DataSource = RefreshLanguages();
            toolStripLanguage.ComboBox.DisplayMember = "SurvLanguage";
            toolStripLanguage.ComboBox.ValueMember = "SurvLanguage";

            // top portion
            cboSurvey.DataSource = new List<SurveyRecord>(Globals.AllSurveys);
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.SelectedValue = CurrentSurvey.SID;
            cboSurvey.SelectedIndexChanged += cboSurvey_SelectedIndexChanged;

            cboDomainLabel.DataSource = new List<DomainLabel>(Globals.AllDomainLabels);
            cboDomainLabel.ValueMember = "ID";
            cboDomainLabel.DisplayMember = "LabelText";

            cboTopicLabel.DataSource = new List<TopicLabel>(Globals.AllTopicLabels);
            cboTopicLabel.ValueMember = "ID";
            cboTopicLabel.DisplayMember = "LabelText";

            cboContentLabel.DataSource = new List<ContentLabel>(Globals.AllContentLabels);
            cboContentLabel.ValueMember = "ID";
            cboContentLabel.DisplayMember = "LabelText";

            cboProductLabel.DataSource = new List<ProductLabel>(Globals.AllProductLabels);
            cboProductLabel.ValueMember = "ID";
            cboProductLabel.DisplayMember = "LabelText";
        }

        /// <summary>
        /// Binds the wording number boxes' ReadOnly attribute to the Current Survey's locked attribute
        /// </summary>
        private void LockForm()
        {

            if (txtPreP.DataBindings["ReadOnly"] != null)
                txtPreP.DataBindings.Remove(txtPreP.DataBindings["ReadOnly"]);

            txtPreP.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPreI.DataBindings["ReadOnly"] != null)
                txtPreI.DataBindings.Remove(txtPreI.DataBindings["ReadOnly"]);
            txtPreI.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPreA.DataBindings["ReadOnly"] != null)
                txtPreA.DataBindings.Remove(txtPreA.DataBindings["ReadOnly"]);
            txtPreA.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtLitQ.DataBindings["ReadOnly"] != null)
                txtLitQ.DataBindings.Remove(txtLitQ.DataBindings["ReadOnly"]);
            txtLitQ.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPstI.DataBindings["ReadOnly"] != null)
                txtPstI.DataBindings.Remove(txtPstI.DataBindings["ReadOnly"]);
            txtPstI.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtPstP.DataBindings["ReadOnly"] != null)
                txtPstP.DataBindings.Remove(txtPstP.DataBindings["ReadOnly"]);
            txtPstP.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtRO.DataBindings["ReadOnly"] != null)
                txtRO.DataBindings.Remove(txtRO.DataBindings["ReadOnly"]);
            txtRO.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            if (txtNR.DataBindings["ReadOnly"] != null)
                txtNR.DataBindings.Remove(txtNR.DataBindings["ReadOnly"]);
            txtNR.DataBindings.Add("ReadOnly", CurrentSurvey, "Locked");

            cmdUnlock.Enabled = CurrentSurvey.Locked;
        }

        /// <summary>
        /// Fill the list view control with questions
        /// </summary>
        private void FillList()
        {
            if (CurrentSurvey == null) return;

            lstQuestionList.Items.Clear();
            lstQuestionList.View = View.Details;

            foreach (QuestionRecord qr in CurrentSurvey.Questions)
            {
                string corr;
                if (qr.CorrectedFlag)
                    corr = "Yes";
                else
                    corr = "No";

                QuestionType type = Utilities.GetQuestionType(qr);
                ListViewItem li = new ListViewItem(
                    new string[] { qr.Qnum, qr.Qnum, qr.AltQnum, qr.VarName.VarName, qr.VarName.VarLabel, qr.RespName, corr, ((int)type).ToString() });
                li.Tag = qr;
                lstQuestionList.Items.Add(li);

                if (qr.Dirty)
                    li.BackColor = Color.Orange;
                if (qr.NewRecord)
                    li.BackColor = Color.LightGreen;

                FormUtilities.FormatListItem(li, type);
            }
        }

        private void AddMouseWheelEvents()
        {
            this.MouseWheel += SurveyEditor_OnMouseWheel;
            cboSurvey.MouseWheel += ComboBox_MouseWheel;
            cboGoToVar.MouseWheel += ComboBox_MouseWheel;
            cboDomainLabel.MouseWheel += ComboBox_MouseWheel;
            cboTopicLabel.MouseWheel += ComboBox_MouseWheel;
            cboContentLabel.MouseWheel += ComboBox_MouseWheel;
            cboProductLabel.MouseWheel += ComboBox_MouseWheel;
            rtbQuestionText.MouseWheel += SurveyEditor_OnMouseWheel;
        }
        #endregion

        #region Menu/Toolstrip Items
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            AddQuestions();
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            PerformDelete();
        }

        private void toolStripCopyPrev_Click(object sender, EventArgs e)
        {
            CopyPreviousRecord();
        }

        private void toolStripSearchQs_Click(object sender, EventArgs e)
        {
            OpenSearch();
        }

        

        private void toolStripTranslation_Click(object sender, EventArgs e)
        {
            ViewTranslation();
        }

        private void toolStripLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frmTranslations != null && !frmTranslations.IsDisposed)
                frmTranslations.UpdateForm(CurrentSurvey, CurrentRecord, (SurveyLanguage)toolStripLanguage.ComboBox.SelectedItem);
        }

        private void toolStripViewComments_Click(object sender, EventArgs e)
        {
            ViewComments();
        }

        private void toolStripDeleted_Click(object sender, EventArgs e)
        {
            ViewDeletedVars();
            
        }

        private void toolStripCorrected_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Corrected form not yet developed. Revisit the need for this feature.");
        }

        private void toolStripRelated_Click(object sender, EventArgs e)
        {
            ViewRelatedQuestions();
            

        }

        private void toolStripDisplay_Click(object sender, EventArgs e)
        {
            DisplayQuestion();
        }

        private void toolStripExport_Click(object sender, EventArgs e)
        {
            ExportQuestion();
        }

        private void assignLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssignLabels frm = (AssignLabels)FormManager.GetForm("AssignLabels");
            if(frm == null)
            {
                frm = new AssignLabels(CurrentRecord.VarName.RefVarName);
            }
            frm.Show();
        }

        private void harmonyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HarmonyReportForm frm = (HarmonyReportForm)FormManager.GetForm("HarmonyReport");
            if (frm == null)
            {
                frm = new HarmonyReportForm(CurrentRecord.VarName);
            }
            frm.Show();
        }

        private void prefixListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrefixList frm = (PrefixList)FormManager.GetForm("PrefixList");
            if (frm == null)
            {
                frm = new PrefixList();
            }
            frm.Show();
        }

        private void unusedVarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VarNameUsage frm = (VarNameUsage)FormManager.GetForm("VarNameUsage");
            if (frm == null)
            { 
                frm = new VarNameUsage(CurrentRecord.VarName.VarName.Substring(0,3));
            }
            frm.Show();
        }

        private void renameVarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameVars frm = (RenameVars)FormManager.GetForm("RenameVars");
            if (frm == null)
            {
                frm = new RenameVars(CurrentRecord.VarName);
            }
            frm.Show();
        }
        #endregion

        #region Events
        private void SurveyEditor_Load(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                var state = Globals.CurrentUser.GetFormState("frmSurveyEntry", (int)Tag);
                if (state == null)
                    bs.Position = 0;
                else
                {
                    bs.Position = state.RecordPosition;
                    if (state.RecordPosition >= bs.Count)
                        state.RecordPosition = bs.Count-1;
                    lstQuestionList.Items[state.RecordPosition].EnsureVisible();
                }
            }

            CurrentRecord = (QuestionRecord)bs.Current;
            LoadQuestion();
        }

        protected void SurveyEditor_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// If a wording number changes for a member of the bound list, update CurrentRecord's wording text, mark it as Dirty and refresh the question text. This assumes
        /// that the modified member is the same as the CurrentRecord. TODO It is possible that this event is fired for other members than CurrentRecord but I have no way 
        /// of figuring that out right now.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEditor_ListChanged(object sender, ListChangedEventArgs e)
        {
            
            if (e.PropertyDescriptor == null) return;

            int index = e.NewIndex; // index of the changed item

            switch (e.PropertyDescriptor.Name)
            {
                case "PrePNum":
                    CurrentRecord.PreP = DBAction.GetWordingText("PreP", CurrentRecord.PrePNum);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "PreINum":
                    CurrentRecord.PreI = DBAction.GetWordingText("PreI", CurrentRecord.PreINum);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "PreANum":
                    CurrentRecord.PreA = DBAction.GetWordingText("PreA", CurrentRecord.PreANum);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "LitQNum":
                    CurrentRecord.LitQ = DBAction.GetWordingText("LitQ", CurrentRecord.LitQNum);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "PstINum":
                    CurrentRecord.PstI = DBAction.GetWordingText("PstI", CurrentRecord.PstINum);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "PstPNum":
                    CurrentRecord.PstP = DBAction.GetWordingText("PstP", CurrentRecord.PstPNum);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "RespName":
                    CurrentRecord.RespOptions = DBAction.GetResponseText(CurrentRecord.RespName);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "NRName":
                    CurrentRecord.NRCodes = DBAction.GetNonResponseText(CurrentRecord.NRName);
                    ((QuestionRecord)bs[index]).Dirty = true;
                    break;
                case "Qnum":
                    ((QuestionRecord)bs[index]).DirtyQnum = true;
                    CurrentSurvey.NeedsRenumber = true;
                    ShadeListItem(index, Color.Orange);
                    UpdateStatus();
                    return;
                case "AltQnum":
                case "AltQnum2":
                case "AltQnum3":
                    ((QuestionRecord)bs[index]).DirtyAltQnum = true;
                    ShadeListItem(index, Color.Orange);
                    UpdateStatus();
                    return;
                default:
                    return;
            }

            bs.ResetBindings(false);

            LoadQuestion();
            UpdateStatus();

            ShadeListItem(index, Color.Orange);
        }

        /// <summary>
        /// Updates subforms to match the current record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (QuestionRecord)bs.Current;

            if (CurrentRecord == null)
                return;

            bs.ResetBindings(false);         

            if (frmRelated != null && !frmRelated.IsDisposed)
                frmRelated.UpdateForm(CurrentRecord);

            if (frmComments != null && !frmComments.IsDisposed)
                frmComments.UpdateForm(CurrentRecord);

            if (frmTranslations != null && !frmTranslations.IsDisposed)
            {
                frmTranslations.UpdateForm(CurrentSurvey, CurrentRecord, (SurveyLanguage)toolStripLanguage.ComboBox.SelectedItem);
            }

            // deselect previous selection
            for (int i = 0; i < lstQuestionList.Items.Count; i++)
            {
                lstQuestionList.Items[i].Selected = false;
            }

            // select and ensure that the current item is visible
            for (int i = 0; i < lstQuestionList.Items.Count; i++)
            {
                if (lstQuestionList.Items[i].SubItems[3].Text.Equals(CurrentRecord.VarName.VarName))
                {
                    lstQuestionList.Items[i].Selected = true;
                    lstQuestionList.Items[i].EnsureVisible();
                    break;
                }
            }

            LoadQuestion();
            UpdateInfo();
            UpdateStatus();
        }

        private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null)
                return;

            if (CurrentSurvey.Questions.Any(x => x.Dirty))
            {
                if (MessageBox.Show("This survey has unsaved changes. Save before changing surveys?", "Confirm.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveChanges();
            }

            Survey selected = (Survey)cboSurvey.SelectedItem;
            ChangeSurvey(selected.SurveyCode);
        }

        private void cboGoToVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GoToQuestion(cboGoToVar.GetItemText(cboGoToVar.SelectedItem));

            cboGoToVar.SelectedValue = "";
        }

        private void cmdSaveSurvey_Click(object sender, EventArgs e)
        {
            if (CurrentSurvey.Locked)
            {
                MessageBox.Show("This survey needs to be unlocked before saving.");
                return;
            }
            SaveChanges();
            FillList();
            CurrentSurvey.NeedsRenumber = NeedsRenumber();
            UpdateStatus();
            lstQuestionList.Items[bs.Position].EnsureVisible();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // make the minimum size equal to the panel in the right side
            if (splitContainer1.Panel2.Width < panelQuestion.Width)
            {
                splitContainer1.SplitterDistance = splitContainer1.Width - panelQuestion.Width;
            }
        }

        /// <summary>
        /// Hide popup forms when the form is no longer the focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEditor_Leave(object sender, EventArgs e)
        {
            TogglePopups(false);
        }

        /// <summary>
        /// Show popup forms when the form is focused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEditor_Enter(object sender, EventArgs e)
        {
            TogglePopups(true);
        }

        /// <summary>
        /// Show popup forms when the form is focused TODO does this work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEditor_Activated(object sender, EventArgs e)
        {
            TogglePopups(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentSurvey.Questions.Any(x => x.Dirty))
            {
                if (MessageBox.Show("This survey has unsaved changes. Are you sure you want to close this survey and lose those changes?", "Confirm close.", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Save the survey and position for the current user. Dispose of the BindingSource. Remove the form from the FormManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            FormStateRecord state = new FormStateRecord();
            state.FormName = "frmSurveyEntry";
            state.FormNum = (int)Tag;
            state.FilterID = CurrentSurvey.SID;
            state.RecordPosition = bs.Position;
            Globals.UpdateUserFormState(state);

            CurrentSurvey.Questions.Clear();

            ClosePopups();

            bs.Dispose();

            FormManager.Remove(this);
        }

        private void cmdUnlock_Click(object sender, EventArgs e)
        {
            DBAction.UnlockSurvey(CurrentSurvey, 60);
            MessageBox.Show(CurrentSurvey.SurveyCode + " unlocked for 1 hour.");
        }

        private void Label_Validated(object sender, EventArgs e)
        {
            CurrentRecord.DirtyLabels = true;
            ShadeListItem(bs.Position, Color.Orange);
            UpdateStatus();
        }

        private void SurveyEditor_RefreshDomains(object sender, EventArgs e)
        {
            cboDomainLabel.DataSource = null;
            cboDomainLabel.DataSource = new List<DomainLabel>(Globals.AllDomainLabels);
            cboDomainLabel.ValueMember = "ID";
            cboDomainLabel.DisplayMember = "LabelText";
        }

        private void SurveyEditor_RefreshTopics(object sender, EventArgs e)
        {
            cboTopicLabel.DataSource = null;
            cboTopicLabel.DataSource = new List<TopicLabel>(Globals.AllTopicLabels);
            cboTopicLabel.ValueMember = "ID";
            cboTopicLabel.DisplayMember = "LabelText";
        }

        private void SurveyEditor_RefreshContents(object sender, EventArgs e)
        {
            cboContentLabel.DataSource = null;
            cboContentLabel.DataSource = new List<ContentLabel>(Globals.AllContentLabels);
            cboContentLabel.ValueMember = "ID";
            cboContentLabel.DisplayMember = "LabelText";
        }

        private void SurveyEditor_RefreshProducts(object sender, EventArgs e)
        {
            cboProductLabel.DataSource = null;
            cboProductLabel.DataSource = new List<ProductLabel>(Globals.AllProductLabels);
            cboProductLabel.ValueMember = "ID";
            cboProductLabel.DisplayMember = "LabelText";
        }
        #endregion

        #region Wording Buttons
        private void cmdOpenPreP_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PreP", CurrentRecord.PrePNum, CurrentRecord.PreP);
        }

        private void cmdOpenPreI_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PreI", CurrentRecord.PreINum, CurrentRecord.PreI);
        }

        private void cmdOpenPreA_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PreA", CurrentRecord.PreANum, CurrentRecord.PreA);
        }

        private void cmdOpenLitQ_Click(object sender, EventArgs e)
        {
            OpenWordingForm("LitQ", CurrentRecord.LitQNum, CurrentRecord.LitQ);
        }

        private void cmdOpenPstI_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PstI", CurrentRecord.PstINum, CurrentRecord.PstI);
        }

        private void cmdOpenPstP_Click(object sender, EventArgs e)
        {
            OpenWordingForm("PstP", CurrentRecord.PstPNum, CurrentRecord.PstP);
        }

        private void cmdOpenResp_Click(object sender, EventArgs e)
        {
            ResponseSet toBeEdited = new ResponseSet()
            {
                FieldName = "RespOptions",
                RespSetName = CurrentRecord.RespName,
                RespList = CurrentRecord.RespOptions
            };

            ResponseOptionUsage frm = new ResponseOptionUsage(toBeEdited);

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK) // export button
            {
                UpdateResponseSet(frm.CurrentSet);
            }
            else
            {
                UpdateWording("RespOptions");
            }
        }

        private void cmdOpenNonResp_Click(object sender, EventArgs e)
        {
            ResponseSet toBeEdited = new ResponseSet()
            {
                FieldName = "NRCodes",
                RespSetName = CurrentRecord.NRName,
                RespList = CurrentRecord.NRCodes
            };

            ResponseOptionUsage frm = new ResponseOptionUsage(toBeEdited);

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK) // export button
            {
                UpdateResponseSet(frm.CurrentSet);
            }
            else
            {
                UpdateWording("NRCodes");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load data for surveycode.
        /// </summary>
        /// <param name="surveycode"></param>
        public void ChangeSurvey(string surveycode)
        {
            LoadData(surveycode);

            // ensure the currently displayed item in the survey filter is the chosen survey
            SetSurvey();

            bs.DataSource = CurrentSurvey.Questions;

            CurrentRecord = (QuestionRecord)bs.Current;
            
            // go to box
            cboGoToVar.ValueMember = "refVarName";
            cboGoToVar.DataSource = CurrentSurvey.Questions.Select(x => x.VarName).OrderBy(x=>x.RefVarName).ToList<VariableName>();
            cboGoToVar.DisplayMember = "refVarName";
            cboGoToVar.SelectedValue = "";

            toolStripLanguage.ComboBox.DataSource = RefreshLanguages();
            toolStripLanguage.ComboBox.DisplayMember = "SurvLanguage";
            toolStripLanguage.ComboBox.ValueMember = "SurvLanguage";

            if (this.Parent is TabPage)
            {
                TabPage page = (TabPage)this.Parent;
                page.Text = "Survey Editor - " + CurrentSurvey.SurveyCode;
            }

            this.Text = "Survey Editor - " + CurrentSurvey.SurveyCode;
            cmdUnlock.Visible = CurrentSurvey.Locked;
            
            FillList();
            ReNumberSurvey();
            LockForm();
            UpdateStatus();
        }

        /// <summary>
        /// Sets the Survey drop down without triggering a survey change.
        /// </summary>
        private void SetSurvey()
        {
            cboSurvey.SelectedIndexChanged -= cboSurvey_SelectedIndexChanged;
            cboSurvey.SelectedItem = CurrentSurvey;
            cboSurvey.SelectedIndexChanged += cboSurvey_SelectedIndexChanged;
        }

        /// <summary>
        /// Update the question text with the current question.
        /// </summary>
        public void LoadQuestion()
        {
            if (CurrentRecord == null)
                return;

            string rich = CurrentRecord.GetQuestionTextRich(true);

            rtbQuestionText.Rtf = "";
            rtbQuestionText.Rtf = rich;
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
                CurrentRecord.PrePNum = previousQ.PrePNum;
                CurrentRecord.PreINum = previousQ.PreINum;
                CurrentRecord.PreANum = previousQ.PreANum;
                // litq not copied -- CurrentRecord.LitQNum = previousQ.LitQNum;
                CurrentRecord.PstINum = previousQ.PstINum;
                CurrentRecord.PstPNum = previousQ.PstPNum;
                CurrentRecord.RespName = previousQ.RespName;
                CurrentRecord.NRName = previousQ.NRName;

                // copy labels only if they are blank
                if (CurrentRecord.VarName.Domain.ID == 0) CurrentRecord.VarName.Domain = previousQ.VarName.Domain;
                if (CurrentRecord.VarName.Topic.ID == 0) CurrentRecord.VarName.Topic = previousQ.VarName.Topic;
                // content label not copied -- if (CurrentRecord.VarName.Content.ID== 0) CurrentRecord.VarName.Content = previousQ.VarName.Content;
                if (CurrentRecord.VarName.Product.ID == 0) CurrentRecord.VarName.Product = previousQ.VarName.Product;

                bs.ResetCurrentItem();
            }
            catch
            {
                MessageBox.Show("You are at the first record!");
            }
        }

        /// <summary>
        /// Open the WordingUsage form and filter for records matching the clipboard text
        /// </summary>
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

            
            ResponseOptionUsage frmRespOptions = new ResponseOptionUsage("RespOptions");

            if (frmRespOptions.FilterWordings(Clipboard.GetText()) > 0)
            {
                frmRespOptions.Visible = true;
                return;
            }


            ResponseOptionUsage frmNonRespOptions = new ResponseOptionUsage("NRCodes");

            if (frmNonRespOptions.FilterWordings(Clipboard.GetText()) > 0)
            {
                frmNonRespOptions.Visible = true;
                return;
            }
        }

        /// <summary>
        /// TODO multi deletes
        /// TODO hilarious use of string
        /// </summary>
        private void PerformDelete()
        {
            string deletions = "";
            if (lstQuestionList.SelectedIndices.Count == 1)
            {
                deletions = ((QuestionRecord)lstQuestionList.SelectedItems[0].Tag).VarName.RefVarName;
            }
            else if (lstQuestionList.SelectedIndices.Count == 0)
                return;
            else
            {
                deletions = lstQuestionList.SelectedIndices.Count.ToString();
            }

            if (MessageBox.Show(deletions + " will be deleted from " + CurrentSurvey.SurveyCode + ". \r\nDo you want to proceed?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                 return;
            

            // get list of selected items
            foreach (ListViewItem item in lstQuestionList.SelectedItems)
            { 
                QuestionRecord toDelete = (QuestionRecord)item.Tag;

                ShadeListItem(item.Index, Color.Red);
                PendingDeletes.Add(toDelete);
                
            }
            ReNumberSurvey();
            UpdateStatus();

        }

        /// <summary>
        /// Delete the current questions from the survey.
        /// </summary>
        /// <returns>0 = success, 1 = error</returns>
        private int DeleteQuestion(QuestionRecord record)
        {
            try
            {
                // backup comments
                DBAction.BackupComments(record.ID);
                // delete question from database
                DBAction.DeleteQuestion(record.VarName.VarName, record.SurveyCode);
                // remove question from the list
                CurrentSurvey.Questions.Remove(record);
                // remove current item from bindingsource
                bs.Remove(record);
                // remove item from list
                foreach (ListViewItem item in lstQuestionList.Items)
                    if (item.Tag == record) lstQuestionList.Items.Remove(item);
            }
            catch (Exception)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Allow the user 
        /// </summary>
        /// <param name="deletes"></param>
        private void DocumentDeletes(List<QuestionRecord> deletes)
        {
            CommentEntry frm = new CommentEntry(NoteScope.Deleted, deletes);
            frm.ShowDialog();

            if (deletes.Count(x => x.Comments.Count > 0) > 0)
            {
                CleanupComments cleanupFrm = new CleanupComments(deletes);
                cleanupFrm.ShowDialog();
            }
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
            CurrentRecord.VarName.VarLabel = varlabel;
            CurrentRecord.VarName.Domain = domain;
            CurrentRecord.VarName.Topic = topic;
            CurrentRecord.VarName.Content = content;
            CurrentRecord.VarName.Product = product;
        }

        private List<SurveyLanguage> RefreshLanguages()
        {
            List<SurveyLanguage> langs = CurrentSurvey.LanguageList;
            langs.RemoveAll(x => x.SurvLanguage.LanguageName.Equals("English"));
            SurveyLanguage all = new SurveyLanguage() { ID = 0, SurvID = CurrentSurvey.SID, SurvLanguage = new Language() { LanguageName = "<All>" } };
            langs.Insert(0, all);
            return langs;
        }

        /// <summary>
        /// Opens the wording form popup to a specific wording.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="number"></param>
        public void OpenWordingForm(string field, int number, string wording)
        {
            if (frmWordings != null)
                frmWordings.Close();

            Wording toBeEdited = new Wording(number, field, wording);

            frmWordings = new WordingUsage(toBeEdited);
            frmWordings.ShowDialog();

            if (frmWordings.DialogResult == DialogResult.OK) // export button
            {
                UpdateWording(frmWordings.CurrentWording);
            }
            else
            {
                UpdateWording(field);
            }
            LoadQuestion();
        }

        private void UpdateWording(string wordingField)
        {
            switch (wordingField)
            {
                case "PreP":
                    CurrentRecord.PreP = DBAction.GetWordingText("PreP", CurrentRecord.PrePNum);
                    break;
                case "PreI":
                    CurrentRecord.PreI = DBAction.GetWordingText("PreI", CurrentRecord.PreINum);
                    break;
                case "PreA":
                    CurrentRecord.PreA = DBAction.GetWordingText("PreA", CurrentRecord.PreANum);
                    break;
                case "LitQ":
                    CurrentRecord.LitQ = DBAction.GetWordingText("LitQ", CurrentRecord.LitQNum);
                    break;
                case "PstI":
                    CurrentRecord.PstI = DBAction.GetWordingText("PstI", CurrentRecord.PstINum);
                    break;
                case "PstP":
                    CurrentRecord.PstP = DBAction.GetWordingText("PstP", CurrentRecord.PstPNum);
                    break;
                case "RespOptions":
                    CurrentRecord.RespOptions = DBAction.GetResponseText(CurrentRecord.RespName);
                    break;
                case "NRCodes":
                    CurrentRecord.NRCodes = DBAction.GetNonResponseText(CurrentRecord.NRName);
                    break;
            }
            LoadQuestion();
        }

        private void UpdateWording(Wording wording)
        {
            switch (wording.FieldName)
            {
                case "PreP":
                    CurrentRecord.PrePNum = wording.WordID;
                    CurrentRecord.PreP = wording.WordingText;
                    txtPreP.Text = wording.WordID.ToString();
                    break;
                case "PreI":
                    CurrentRecord.PreINum = wording.WordID;
                    CurrentRecord.PreI = wording.WordingText;
                    txtPreI.Text = wording.WordID.ToString();
                    break;
                case "PreA":
                    CurrentRecord.PreANum = wording.WordID;
                    CurrentRecord.PreA = wording.WordingText;
                    txtPreA.Text = wording.WordID.ToString();
                    break;
                case "LitQ":
                    CurrentRecord.LitQNum = wording.WordID;
                    CurrentRecord.LitQ = wording.WordingText;
                    txtLitQ.Text = wording.WordID.ToString();
                    break;
                case "PstI":
                    CurrentRecord.PstINum = wording.WordID;
                    CurrentRecord.PstI = wording.WordingText;
                    txtPstI.Text = wording.WordID.ToString();
                    break;
                case "PstP":
                    CurrentRecord.PstPNum = wording.WordID;
                    CurrentRecord.PstP = wording.WordingText;
                    txtPstP.Text = wording.WordID.ToString();
                    break;
            }
            
        }

        private void UpdateResponseSet(ResponseSet response)
        {
            switch (response.FieldName)
            {
                case "RespOptions":
                    CurrentRecord.RespName = response.RespSetName;
                    CurrentRecord.RespOptions = response.RespList;
                    txtRO.Text = response.RespSetName;
                    break;
                case "NRCodes":
                    CurrentRecord.NRName = response.RespSetName;
                    CurrentRecord.NRCodes = response.RespList;
                    txtNR.Text = response.RespSetName;
                    break;
                
            }

        }

        private void UpdateStatus()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("This survey has unsaved changes:");

            bool showMessage = false;

            var added = CurrentSurvey.Questions.Where(x => x.ID == 0);
            int edits = CurrentSurvey.Questions.Where(x => x.Dirty || x.DirtyLabels || x.DirtyQnum || x.DirtyAltQnum).Count();
            int adds = PendingAdds.Count;
            int deletes = PendingDeletes.Count;

            if (edits > 0)
            {
                sb.AppendLine(edits + " edited question(s).");
                showMessage = true;
            }

            if (adds>0)
            {
                sb.AppendLine(adds + " new question(s).");
                showMessage = true;

            }

            if (deletes>0)
            {
                sb.AppendLine(deletes + " question(s) pending deletion.");
                showMessage = true;
            }

            if (NeedsRenumber())
            {
                sb.AppendLine("This survey needs to be renumbered.");
                showMessage = true;
            }

            if (CurrentRecord == null)
            {
                lblStatus.Text = "This survey has no questions!";
                return;
            }

            if (CurrentRecord.NewRecord)
            {
                sb.AppendLine("Current question is new.");
                showMessage = true;
            }
            else if (CurrentRecord.IsEdited())
            {
                sb.AppendLine("Current question has been edited.");
                showMessage = true;
            }

            if (showMessage)
            {
                lblStatus.Text = sb.ToString();
                lblStatus.Visible = true;
            }
            else
                lblStatus.Visible = false;
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

        public void GoToQuestion(string refVarName)
        {
            int index = 0;
            bool found = false;

            foreach (QuestionRecord qr in CurrentSurvey.Questions)
            {
                if (qr.VarName.RefVarName == refVarName)
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
            bool found = false;

            foreach (QuestionRecord qr in CurrentSurvey.Questions)
            {
                if (qr.Qnum == qnum)
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

        private void ReNumberSurvey()
        {
            RenumberList();
            RenumberQuestions();
            ColorRows();
        }

        private void ColorRows()
        {
            foreach (ListViewItem item in lstQuestionList.Items)
            {
                QuestionRecord question = (QuestionRecord)item.Tag;

                if (question.IsEdited())
                {
                    ShadeListItem(item.Index, Color.Orange);
                }
                else if (PendingAdds.Contains(question))
                    ShadeListItem(item.Index, Color.LightGreen);
                else if (PendingDeletes.Contains(question))
                    ShadeListItem(item.Index, Color.Red);
                else
                {
                    ShadeListItem(item.Index, Color.White);
                }
            }
            bs.ResetBindings(false);
        }

        private void RenumberQuestions()
        {
            foreach (ListViewItem item in lstQuestionList.Items)
            {
                QuestionRecord question = (QuestionRecord)item.Tag;
                string newQnum, oldQnum;
                newQnum = item.SubItems[0].Text;
                oldQnum = item.SubItems[1].Text;
                if (newQnum.Equals(oldQnum))
                {
                    // set the qnum but then turn off the dirty flag because we know this is an "undo" change
                    question.Qnum = newQnum;
                    question.DirtyQnum = false;
                }
                else
                {
                    question.Qnum = newQnum;
                }
            }
            bs.ResetBindings(false);
        }

        /// <summary>
        /// Sets the New Q# column by analyzing the current Qnum and deciding what type of question it is (standalone vs. series vs. heading). The row is also colored based on the type.
        /// </summary>
        private void RenumberList()
        {
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
                QuestionRecord q = (QuestionRecord)row.Tag;

                if (PendingDeletes.Contains(q))
                    continue;

                qType = (QuestionType)Int32.Parse(row.SubItems[7].Text);

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

                if (qType == QuestionType.Heading || qType == QuestionType.Subheading)
                {
                    newQnum += "zz";
                }
                else if (qType != QuestionType.Standalone)
                {
                    newQnum += new string('z', (qLet - 1) / 26);
                    newQnum += Char.ConvertFromUtf32(96 + qLet - 26 * ((qLet - 1) / 26));
                }

                if (hcount > 0)
                    newQnum += "!" + hcount.ToString("00");

                row.SubItems[0].Text = newQnum;

                // add 'a' to series starters
                if (qType == QuestionType.Standalone)
                {
                    i = row.Index;
                            
                    QuestionType subQType = (QuestionType)Int32.Parse(lstQuestionList.Items[i].SubItems[7].Text);
                    do
                    {
                        if (i < lstQuestionList.Items.Count - 1)
                            i++;
                        else
                            break;

                        subQType = (QuestionType)Int32.Parse(lstQuestionList.Items[i].SubItems[7].Text);
                    } while (subQType == QuestionType.Heading || subQType == QuestionType.InterviewerNote);

                    if (subQType == QuestionType.Series)
                        row.SubItems[0].Text += "a";
                }

                FormUtilities.FormatListItem(row, qType); // add color and style to row
                // color rows with new Qnums in red, otherwise, set their DirtyQnum flag to false, in case the numbering was "undone"
                if (row.SubItems[0].Text != row.SubItems[1].Text)
                {
                    row.SubItems[0].ForeColor = Color.Red;
                    //((QuestionRecord)row.Tag).Qnum = row.SubItems[0].Text;
                }
                else
                {
                    //((QuestionRecord)row.Tag).DirtyQnum = false;
                    //ShadeListItem(row.Index, Color.White);
                }
            }
        }

        private bool NeedsRenumber()
        {
            foreach (ListViewItem row in lstQuestionList.Items)
            {
                if (row.SubItems[0].Text != row.SubItems[1].Text)
                    return true;
            }
            return false;
        }

        public void ImportWording(string field, int wnum)
        {
            switch (field) {
                case "PreP":
                    CurrentRecord.PrePNum = wnum;
                    break;
                case "PreI":
                    CurrentRecord.PreINum = wnum;
                    break;
                case "PreA":
                    CurrentRecord.PreANum = wnum;
                    break;
                case "LitQ":
                    CurrentRecord.LitQNum = wnum;
                    break;

                case "PstI":
                    CurrentRecord.PstINum = wnum;
                    break;
                case "PstP":
                    CurrentRecord.PstPNum = wnum;
                    break;
            }
        }

        public void ImportWording(string field, string respname)
        {
            switch (field)
            {
                case "RespOptions":
                    CurrentRecord.RespName = respname;
                    break;
                case "NRCodes":
                    CurrentRecord.NRName = respname;
                    break;
            }
        }

        public void ImportWordings(SurveyQuestion question)
        {
            ImportWording("PreP", question.PrePNum);
            ImportWording("PreI", question.PreINum);
            ImportWording("PreA", question.PreANum);
            ImportWording("LitQ", question.LitQNum);
            ImportWording("PstI", question.PstINum);
            ImportWording("PstP", question.PstPNum);
            ImportWording("RespOptions", question.RespName);
            ImportWording("NRCodes", question.NRName);
        }

        /// <summary>
        /// Refreshes the count of comments, translations and corrected questions.
        /// </summary>
        private void UpdateInfo()
        {
            if (CurrentRecord == null)
                return;

            lblCommentCount.Text = CurrentRecord.Comments.Count() + " Comment(s).";
            lblTranslationCount.Text = CurrentRecord.Translations.Count() + " Translation(s).";
            lblCorrectCount.Text = CurrentSurvey.CorrectedQuestions.Where(x => x.VarName.VarName.Equals(CurrentRecord.VarName.VarName)).Count() + " Corrected wording(s).";
        }

        private void AddQuestions()
        {
            string qnum = "0";
            if (CurrentRecord != null)
                qnum = CurrentRecord.Qnum;

            NewQuestionEntry frm = new NewQuestionEntry(CurrentSurvey, qnum);
            frm.ShowDialog();

            // if the dialog was closed with an 'OK' result
            if (frm.DialogResult == DialogResult.OK)
            {
                int pos = bs.Position + 1;
                foreach (QuestionRecord r in frm.QuestionsToAdd)
                {
                    if (CurrentSurvey.QuestionByVar(r.VarName.VarName) == null)
                    {
                        CurrentSurvey.AddQuestion(r, pos, true);
                        CurrentSurvey.QuestionsAdded = true;
                        PendingAdds.Add(r);
                        pos++;
                    }
                }
                
                // refresh the list view
                FillList();
                // go to the first new question
                GoToQuestion(frm.QuestionsToAdd[0].VarName.RefVarName);
                
                UpdateStatus();
            }
        }

        private void DisplayQuestion()
        {
            if (frmQuestionViewer == null || frmQuestionViewer.IsDisposed)
            {
                frmQuestionViewer = new QuestionViewer(new List<SurveyQuestion>() { CurrentRecord });
                frmQuestionViewer.Owner = this;
                frmQuestionViewer.Show();
            }
            else
            {
                frmQuestionViewer.Focus();
            }
        }

        private void ExportQuestion()
        {
            if (CurrentRecord == null)
            {
                MessageBox.Show("No VarNames to export!");
                return;
            }

            bool q, t, c, f;

            q = toolStripQ.Checked;
            t = toolStripT.Checked;
            c = toolStripC.Checked;
            f = toolStripF.Checked;

            List<SurveyQuestion> questions = new List<SurveyQuestion>();
            SurveyQuestion question = CurrentRecord;
            question.Translations.AddRange(CurrentRecord.Translations);
            
            questions.Add(CurrentRecord);

            QuestionReport report = new QuestionReport();
            report.SelectedSurvey = CurrentSurvey;
            report.Questions = questions;
            report.IncludeQuestion = q;
            report.IncludeComments = c;
            report.IncludeTranslation = t;
            report.IncludeFilters = f;

            report.CreateReport();
        }

        private void ViewComments()
        {
            if (frmComments == null || frmComments.IsDisposed)
            {
                frmComments = new CommentEntry(CurrentRecord);
                frmComments.CreatedComment += SurveyEditor_RefreshCommentCount;

                frmComments.UpdateForm(CurrentRecord);
                frmComments.Owner = this;
                frmComments.Show();
            }
            else
            {
                frmComments.Focus();
            }
        }

        private void ViewTranslation()
        {

            if (CurrentRecord.Translations.Count == 0)
            {
                MessageBox.Show("No translations found for this question.");
                return;
            }

            if (frmTranslations == null || frmTranslations.IsDisposed)
            {
                frmTranslations = new TranslationViewer(CurrentSurvey, CurrentRecord);
                frmTranslations.Owner = this;
                frmTranslations.Show();
            }
            else
            {
                frmTranslations.Focus();
            }
        }

        private void ViewDeletedVars()
        {
            if (frmDeleted == null || frmDeleted.IsDisposed)
            {
                frmDeleted = new DeletedSurveyQuestions(CurrentSurvey);
                frmDeleted.Owner = this;
                frmDeleted.Show();
            }
            else
            {
                frmDeleted.Focus();
            }
        }

        private void ViewRelatedQuestions()
        {
            if (frmRelated == null || frmRelated.IsDisposed)
            {
                frmRelated = new RelatedQuestions(CurrentRecord, (int)Tag);
                frmRelated.Owner = this;
                frmRelated.Show();
            }
            else
            {
                frmRelated.Focus();
            }
        }

        private void ViewCorrectedQuestions()
        {
            MessageBox.Show("Not implemented yet.");
        }

        private void OpenSearch()
        {
            // open search popup
            if (frmSearch == null || frmSearch.IsDisposed)
            {
                searchStart = 0;
                frmSearch = new SurveyEditorSearch(this);
                frmSearch.Owner = this;
                frmSearch.Show();
            }
            else
            {
                frmSearch.Focus();
            }
        }

        private void ShadeListItem(int index, Color c)
        {
            try
            {
                QuestionRecord r = (QuestionRecord)lstQuestionList.Items[index].Tag;
                lstQuestionList.Items[index].BackColor = c;
            }
            catch
            {

            }
        }

        /// <summary>
        /// Commit all changes to the database. Any failed commits are displayed.
        /// </summary>
        private void SaveChanges()
        {
            List<QuestionRecord> modifyFails = new List<QuestionRecord>();
            List<QuestionRecord> newFails = new List<QuestionRecord>();
            List<QuestionRecord> deleteFails = new List<QuestionRecord>();
            List<QuestionRecord> deleteWins = new List<QuestionRecord>();

            // save modified questions

            foreach (QuestionRecord qr in CurrentSurvey.Questions)
            {
                if (qr.SaveRecord() == 1)
                    modifyFails.Add(qr);
            }

            // add new questions
            foreach (QuestionRecord nq in PendingAdds)
            {
                if (nq.SaveRecord() == 1)
                    newFails.Add(nq);
            }
            PendingAdds.Clear();
            PendingAdds.AddRange(newFails);

            // delete questions 
            QuestionRecord dummy = CurrentSurvey.Questions.FirstOrDefault(x => x.VarName.RefVarName.Equals("DUMMY"));
            if (CurrentSurvey.Questions.Count > 1 && dummy != null)
                PendingDeletes.Add(dummy);

            foreach (QuestionRecord dq in PendingDeletes)
            {
                if (DeleteQuestion(dq) == 1)
                    deleteFails.Add(dq);
                else
                {
                    deleteWins.Add(dq);
                }

            }
            PendingDeletes.Clear();
            PendingDeletes.AddRange(deleteFails);

            // ask to document
            bool skipDocument = false;
            if (deleteWins.Count == 1 && deleteWins[0].VarName.VarName.Equals("DUMMY"))
                skipDocument = true;

            if (deleteWins.Count>0 && !skipDocument)
            {
                DialogResult result = MessageBox.Show("Do you want to document these deletes?", "Document Deletes", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    DocumentDeletes(deleteWins);  
                }
            }

            // display fails
            StringBuilder sb = new StringBuilder();
            if (modifyFails.Count > 0)
                sb.AppendLine(modifyFails.Count + " edited questions failed to save properly.");
            if (newFails.Count > 0)
                sb.AppendLine(newFails.Count + " new questions failed to save properly.");
            if (deleteFails.Count > 0)
                sb.AppendLine(deleteFails.Count + " deleted questions failed to delete properly.");

            if (sb.Length>0)
                MessageBox.Show(sb.ToString());
            else
            {
                DBAction.DeleteRenumberedSurvey(CurrentSurvey);
            }
        }

        private void TogglePopups(bool show)
        {
            if (frmTranslations != null && !frmTranslations.IsDisposed)
                frmTranslations.Visible = show;

            if (frmRelated != null && !frmRelated.IsDisposed)
                frmRelated.Visible = show;

            if (frmComments != null && !frmComments.IsDisposed)
                frmComments.Visible = show;

            if (frmDeleted != null && !frmDeleted.IsDisposed)
                frmDeleted.Visible = show;

            if (frmQuestionViewer != null && !frmQuestionViewer.IsDisposed)
                frmQuestionViewer.Visible = show;
        }

        private void ClosePopups()
        {
            if (frmRelated != null && !frmRelated.IsDisposed)
                frmRelated.Close();

            if (frmComments != null && !frmComments.IsDisposed)
                frmComments.Close();

            if (frmTranslations != null && !frmTranslations.IsDisposed)
                frmTranslations.Close();

            if (frmDeleted != null && !frmDeleted.IsDisposed)
                frmDeleted.Close();

            if (frmQuestionViewer != null && !frmQuestionViewer.IsDisposed)
                frmQuestionViewer.Close();
        }

        
        public void FindNextQuestion (string searchText, string field, bool startover = false)
        {
            if (string.IsNullOrEmpty(searchText) || string.IsNullOrEmpty(field))
                return;

            int currentPos = bs.Position;
            if (startover) searchStart = 0;

            // check this form first
            bool found = false;
            if (field == "<All>")
                found = rtbQuestionText.Text.IndexOf(searchText, searchStart) > -1; 
            else
                found = CurrentRecord.ContainsString(field, searchText, searchStart);

            // if no match, then search through questions until a match is found
            if (found)
            {
                HighlightQuestion(searchText, searchStart);
            }
            else
            {
                searchStart = 0;
                for (int i = currentPos + 1;i<bs.Count; i++)
                {
                    if (field == "<All>")
                        found = CurrentSurvey.Questions[i].ContainsString(searchText, searchStart);
                    else
                        found = CurrentSurvey.Questions[i].ContainsString(field, searchText, searchStart);

                    if (found)
                    {
                        bs.Position = i;
                        HighlightQuestion(searchText, 0);
                        break;
                    }
                }

                if (!found)
                {
                    for (int i = 0; i < currentPos; i++)
                    {
                        if (field == "<All>")
                            found = CurrentSurvey.Questions[i].ContainsString(searchText, searchStart);
                        else
                            found = CurrentSurvey.Questions[i].ContainsString(field, searchText, searchStart);

                        if (found)
                        {
                            bs.Position = i;
                            HighlightQuestion(searchText, 0);
                            break;
                        }
                    }
                }
            }
        }

        public void FindPreviousQuestion(string searchText, string field, bool startOver = false)
        {
            if (string.IsNullOrEmpty(searchText) || string.IsNullOrEmpty(field))
                return;

            int currentPos = bs.Position;
            if (startOver) searchStart = 0;

            // check this form first
            bool found = false;
            if (field == "<All>")
                found = rtbQuestionText.Text.IndexOf(searchText, searchStart) > -1;
            else
                found = CurrentRecord.ContainsString(field, searchText, searchStart);

            // if no match, then search through questions until a match is found
            if (found)
            {
                HighlightQuestion(searchText, searchStart);
            }
            else
            {
                searchStart = 0;
                for (int i = currentPos - 1; i > 0; i--)
                {
                    if (field == "<All>")
                        found = CurrentSurvey.Questions[i].ContainsString(searchText, searchStart);
                    else
                        found = CurrentSurvey.Questions[i].ContainsString(field, searchText, searchStart);

                    if (found)
                    {
                        bs.Position = i;
                        HighlightQuestion(searchText, 0);
                        break;
                    }
                }

                if (!found)
                {
                    for (int i = bs.Count; i > currentPos; i--)
                    {
                        if (field == "<All>")
                            found = CurrentSurvey.Questions[i].ContainsString(searchText, searchStart);
                        else
                            found = CurrentSurvey.Questions[i].ContainsString(field, searchText, searchStart);

                        if (found)
                        {
                            bs.Position = i;
                            HighlightQuestion(searchText, 0);
                            break;
                        }
                    }
                }
            }
        }

        private void HighlightQuestion(string searchText, int start)
        {
            int foundLocation = rtbQuestionText.Text.IndexOf(searchText, start);
            
            if (foundLocation > -1 )
            {
                string [] lines = rtbQuestionText.Text.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
                
                // clear any highlighting
                rtbQuestionText.SelectAll();
                rtbQuestionText.SelectionBackColor = Color.White;
                // apply new highlighting at foundLocation
                rtbQuestionText.SelectionStart = foundLocation - lines.Length + 1;
                rtbQuestionText.SelectionLength = searchText.Length ;
                rtbQuestionText.SelectionBackColor = Color.Yellow;
                searchStart = foundLocation + searchText.Length + 1;
                return;
            }
            else
            {
                rtbQuestionText.SelectAll();
                rtbQuestionText.SelectionBackColor = Color.White;
            }
        }

        #endregion

        #region Navigation buttons
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            bs.MoveFirst();
        }
        #endregion

        #region ListView Events

        /// <summary>
        /// Start the drag and drop procedure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuestionList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lstQuestionList.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// Change the cursor so the user knows they are dragging.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuestionList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// Make sure the item being dragged over is visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuestionList_DragOver(object sender, DragEventArgs e)
        {
            Point cp = lstQuestionList.PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = lstQuestionList.GetItemAt(cp.X, cp.Y);
            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (ListViewItem moveItem in lstQuestionList.SelectedItems)
            {
                if (moveItem.Index == hoverItem.Index)
                {
                    e.Effect = DragDropEffects.None;
                    hoverItem.EnsureVisible();
                    return;
                }
            }
           
            e.Effect = DragDropEffects.Move;
            hoverItem.EnsureVisible();
        }

        /// <summary>
        /// Drop the item and re-order the questions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuestionList_DragDrop(object sender, DragEventArgs e)
        {
            if (lstQuestionList.SelectedItems.Count == 0)
            {
                return;
            }

            Point cp = lstQuestionList.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = lstQuestionList.GetItemAt(cp.X, cp.Y);

            if (dragToItem == null)
            {
                return;
            }

            int dropIndex = dragToItem.Index;

            if (dropIndex > lstQuestionList.SelectedItems[0].Index)
            {
                dropIndex++;
            }
            
            ArrayList insertItems = new ArrayList(lstQuestionList.SelectedItems.Count);

            foreach (ListViewItem item in lstQuestionList.SelectedItems)
            {
                insertItems.Add(item.Clone());
            }

            foreach (ListViewItem removeItem in lstQuestionList.SelectedItems)
            {
                lstQuestionList.Items.Remove(removeItem);
                CurrentSurvey.Questions.Remove((QuestionRecord)removeItem.Tag);
            }

            for (int i = insertItems.Count - 1; i >= 0; i--)
            {
                ListViewItem insertItem = (ListViewItem)insertItems[i];
                lstQuestionList.Items.Insert(dropIndex, insertItem);
               
                CurrentSurvey.Questions.Insert(dropIndex, (QuestionRecord)insertItem.Tag);
            }
            
            ReNumberSurvey();

            // Show the user that a drag operation is happening
            Cursor = Cursors.Arrow;
            if (NeedsRenumber())
                CurrentSurvey.NeedsRenumber = true;

            UpdateStatus();
        }

        /// <summary>
        /// Go to the question that was clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuestionList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = lstQuestionList.SelectedIndices[0];
            string varname = lstQuestionList.Items[index].SubItems[3].Text;

            GoToQuestion(Utilities.ChangeCC(varname));
          
        }

        /// <summary>
        /// Toggle a question between standalone and series.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuestionList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // toggle standalone/series
            if (CurrentSurvey.Locked)
            {
                MessageBox.Show("Cannot modify locked surveys.");
                return;
            }

            bool renumber = false;
            var items = lstQuestionList.SelectedItems;
            if (items.Count == 0)
                return;

            bool newQ = !items[0].Font.Bold;
            foreach (ListViewItem item in items)
            {
                QuestionType qt = Utilities.GetQuestionType((QuestionRecord)item.Tag);
                if (qt == QuestionType.Heading || qt == QuestionType.Subheading)
                    continue;

                if (newQ)
                {
                    item.SubItems[7].Text = ((int)QuestionType.Standalone).ToString();
                    item.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    item.ForeColor = Color.Blue;
                }
                else
                {
                    item.SubItems[7].Text = ((int)QuestionType.Series).ToString();
                    item.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                    item.ForeColor = Color.Black;
                }
                // at least one selected item was renumbered
                renumber = true;
            }

            if (renumber)
            {
                ReNumberSurvey();
            }

            UpdateStatus();
        }

        private void lstQuestionList_DragLeave(object sender, EventArgs e)
        {
            
        }

        #endregion

        private void SurveyEditor_RefreshCommentCount (object sender, QuestionCommentCreated e)
        {
            foreach (QuestionCommentRecord qc in e.comments)
            {
                if (qc.Survey.Equals(CurrentSurvey.SurveyCode))
                {
                    CurrentSurvey.QuestionByVar(qc.VarName).Comments.Add(qc);
                }
            }
            UpdateInfo();
        }
    }
}
