using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ITCLib;
using ITCReportLib;
using FM = FormManager;
using HtmlRtfConverter;

namespace SDIFrontEnd
{
    public partial class PraccingEntry : Form
    {
        List<PraccingIssueRecord> Records;
        PraccingIssueRecord CurrentRecord;

        PraccingResponse CurrentResponse;
        List<Person> PeopleList;
        List<PraccingCategory> CategoryList;

        BindingSource bsRecords;
        BindingSource bsCurrent;
        
        BindingSource bsResponses;
        BindingSource bsImages;
        BindingSource bsResponseImages;

        string DBImageRepo = @"\\psychfile\psych$\psych-lab-gfong\SMG\Praccing Images";

        // picture box panning properties
        private Point startingPoint = Point.Empty;
        private Point movingPoint = Point.Empty;
        private bool panning = false;

        public PraccingEntry(int survID)
        {
            InitializeComponent();
            AddMouseWheelEvents();

            Records = new List<PraccingIssueRecord>();
            PeopleList = Globals.AllPeople;
            CategoryList = DBAction.GetPraccingCategories();

            SetupBindingSources();

            LoadSurveyIssues(survID);

            FillBoxes();
           
            BindProperties();

            cboGoToSurvey.SelectedValue = survID;
            cboGoToSurvey.SelectedValueChanged += cboGoToSurvey_SelectedValueChanged;
        }

        #region Form Setup

        private void AddMouseWheelEvents()
        {
            //this.MouseWheel += PraccingEntry_OnMouseWheel;
            cboGoToSurvey.MouseWheel += ComboBox_MouseWheel;
            cboGoToIssueNo.MouseWheel += ComboBox_MouseWheel;
            cboIssueFrom.MouseWheel += ComboBox_MouseWheel;
            cboIssueTo.MouseWheel += ComboBox_MouseWheel;
            cboIssueCategory.MouseWheel += ComboBox_MouseWheel;
            //rtbDescription.MouseWheel += PraccingEntry_OnMouseWheel;
            cboResolvedBy.MouseWheel += ComboBox_MouseWheel;
            cboResponseFrom.MouseWheel += ComboBox_MouseWheel;
            cboResponseTo.MouseWheel += ComboBox_MouseWheel;
        }

        private void SetupBindingSources()
        {
            bsRecords = new BindingSource()
            {
                DataSource = Records
            };
            bsRecords.PositionChanged += BsMainIssues_PositionChanged;

            bsCurrent = new BindingSource
            {
                DataSource = bsRecords,
                DataMember = "Item"
            };
            bsCurrent.ListChanged += BsCurrent_ListChanged;

            bsImages = new BindingSource
            {
                DataSource = bsCurrent,
                DataMember = "Images"
            };

            bsResponses = new BindingSource
            {
                DataSource = bsCurrent,
                DataMember = "Responses"
            };
            bsResponses.PositionChanged += BsResponses_PositionChanged;
            bsResponses.ListChanged += BsResponses_ListChanged;

            bsResponseImages = new BindingSource
            {
                DataSource = bsResponses,
                DataMember = "Images"
            };

            navMainIssues.BindingSource = bsRecords;
            navMainImages.BindingSource = bsImages;
            navResponseImages.BindingSource = bsResponseImages;
        }

        /// <summary>
        /// Retrieve the praccing records from the database and populate the binding sources for the issues.
        /// </summary>
        /// <param name="SurvID"></param>
        private void GetRecords(int SurvID)
        {
            var issues = DBAction.GetPraccingIssues(SurvID);
            Records = new List<PraccingIssueRecord>();
            foreach (PraccingIssue issue in issues)
            {
                Records.Add(new PraccingIssueRecord(issue));
            }

            bsRecords.DataSource = Records;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Update the user's profile with the currently selected survey.
        /// </summary>
        private void SaveSurveyFilter()
        {
            FormState state = new FormState()
            {
                FormName = "frmIssuesTracking",
                FormNum = (int)Tag,
                FilterID = ((Survey)cboGoToSurvey.SelectedItem).SID,
                RecordPosition = bsRecords.Position
            };

            Globals.UpdateUserFormState(state);
        }

        /// <summary>
        /// Load the praccing records for the selected survey.
        /// </summary>
        /// <param name="survID"></param>
        private void LoadSurveyIssues(int survID)
        {
            GetRecords(survID);
            
            if (Records.Count == 0)
            {
                CreateFirst(survID);
                return;
            }

            SetLanguageOptions(survID);

            RefreshCurrentIssue();
            UpdateSummary();

            FillIssueNumberBox();
        }

        private void SetLanguageOptions(int survID)
        {
            var langList = Globals.AllSurveys.Where(x => x.SID == survID).First().LanguageList.Select(x => x.SurvLanguage.LanguageName).ToList(); // DBAction.ListLanguages(new Survey() { SID = survID }).Select(x => x.LanguageName).ToList();
            if (!langList.Contains("English")) langList.Add("English");

            lstLanguage.DataSource = langList;
            lstLanguage.SelectedItem = null;
        }

        private void FillIssueNumberBox()
        {
            cboGoToIssueNo.SelectedValueChanged -= cboGoToIssueNo_SelectedIndexChanged;
            cboGoToIssueNo.DataSource = Records.Select(x => x.Item).ToList();
            cboGoToIssueNo.SelectedValueChanged += cboGoToIssueNo_SelectedIndexChanged;
        }


        /// <summary>
        /// Navigate to the specified issue number.
        /// </summary>
        /// <param name="issueNum"></param>
        private void GoToIssue(int issueNum)
        {
            int issuePosition = 0;

            for (int i = 0; i < bsRecords.Count; i++)
            {
                if (((PraccingIssueRecord)bsRecords[i]).Item.IssueNo == issueNum)
                {
                    issuePosition = i;
                    break;
                }
            }

            bsRecords.Position = issuePosition;
        }

        /// <summary>
        /// Set the CurrentIssue, update the description and load the responses.
        /// </summary>
        private void RefreshCurrentIssue()
        {
            txtIssueNo.Focus();
            CurrentRecord = (PraccingIssueRecord)bsRecords.Current;
            movingPoint = new Point(0, 0);

            if (CurrentRecord == null)
            {
                CurrentResponse = null;
                RefreshCurrentResponse();
                return;
            }

            if (!CurrentRecord.NewRecord)
                cmdDeleteIssue.Text = "X";

            if (CurrentRecord.Item.EnteredBy.ID != 0)
            {
                lblEnteredBy.Visible = true;
                lblEnteredBy.Text = "Entered by " + CurrentRecord.Item.EnteredBy.Name;
            }
            else
                lblEnteredBy.Visible = false;

            CurrentRecord.Item.Responses.Sort((x, y) => x.ResponseDate.Value.CompareTo(y.ResponseDate));
            
            extraRichTextBox1.Rtf = null;
            extraRichTextBox1.Rtf = Converter.HTMLToRtf(CurrentRecord.Item.Description);

            RefreshCurrentResponse();
        }

        private void RefreshCurrentResponse()
        {
            CurrentResponse = (PraccingResponse)bsResponses.Current;

            if (CurrentResponse == null)
            {
                picResponse.ImageLocation = "";
                picResponse.DataBindings.Clear();
                return;
            }

            BindControl(picResponse, "ImageLocation", bsResponseImages, "Path");
        }

        /// <summary>
        /// Refresh the summary section by counting the different types of issues and how many are resolved/unresolved.
        /// </summary>
        private void UpdateSummary()
        {
            int total = Records.Count();
            int unres_total = Records.Where(x => !x.Item.Resolved).Count();

            List<KeyValuePair<int, string>> totals = new List<KeyValuePair<int, string>>();

            foreach (PraccingCategory pc in CategoryList)
            {
                totals.Add(new KeyValuePair<int, string>(Records.Where(x => x.Item.Category.ID == pc.ID).Count(),
                    Records.Where(x => x.Item.Category.ID == pc.ID).Count() + " " + pc.Category + " issues. " +
                    Records.Where(x => x.Item.Category.ID == pc.ID && !x.Item.Resolved).Count() + " unresolved."));
            }

            totals = totals.OrderByDescending(x => x.Key).ToList();

            lblUnresolvedIssues.Text = unres_total + " unresolved. ";
            lblTotalIssues.Text = total + " Total issue(s).";
            lblIssueType1.Text = totals[0].Value;
            lblIssueType2.Text = totals[1].Value;
            lblIssueType3.Text = totals[2].Value;
            lblIssueType4.Text = totals[3].Value;
            lblIssueType5.Text = totals[4].Value;
            lblIssueType6.Text = totals[5].Value;
            lblIssueType7.Text = totals[6].Value;

        }

        /// <summary>
        /// Fill the combo boxes in the main issue area.
        /// </summary>
        private void FillBoxes()
        {
            cboGoToSurvey.ValueMember = "SID";
            cboGoToSurvey.DisplayMember = "SurveyCode";
            cboGoToSurvey.DataSource = new List<Survey>(Globals.AllSurveys);

            cboGoToIssueNo.DisplayMember = "IssueNo";
            cboGoToIssueNo.ValueMember = "ID";
            cboGoToIssueNo.DataSource = Records.Select(x => x.Item).ToList();

            cboIssueCategory.DisplayMember = "Category";
            cboIssueCategory.ValueMember = "ID";
            cboIssueCategory.DataSource = new List<PraccingCategory>(CategoryList);

            FillNameBoxes(false);
        }

        private void FillNameBoxes(bool all)
        {
            IEnumerable<Person> filteredNames = GetNames(all);

            cboIssueFrom.DisplayMember = "Name";
            cboIssueFrom.ValueMember = "ID";
            cboIssueFrom.DataSource = new List<Person>(filteredNames);

            cboIssueTo.DisplayMember = "Name";
            cboIssueTo.ValueMember = "ID";
            cboIssueTo.DataSource = new List<Person>(filteredNames);

            cboResolvedBy.DisplayMember = "Name";
            cboResolvedBy.ValueMember = "ID";
            cboResolvedBy.DataSource = new List<Person>(filteredNames);
        }

        private IEnumerable<Person> GetNames(bool all)
        {
            if (all)
                return PeopleList.OrderByDescending(x => x.Active || x.ID == 0).ThenBy(x => x.FirstName).ThenBy(x => x.LastName);
            else
                return PeopleList.Where(x => x.PraccEntry || x.ID == 0).OrderByDescending(x => x.Active).ThenBy(x => x.FirstName).ThenBy(x => x.LastName);
        }

        private void BindControl(System.Windows.Forms.Control ctl, string prop, object datasource, string dataMember, bool formatting = false)
        {
            ctl.DataBindings.Clear();
            ctl.DataBindings.Add(prop, datasource, dataMember, formatting, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Bind controls to data. Not data repeater controls.
        /// </summary>
        private void BindProperties()
        {
            BindControl(txtSurveyCode, "Text", bsCurrent, "Survey.SurveyCode");
            BindControl(txtIssueNo, "Text", bsCurrent, "IssueNo");
            BindControl(txtVarNames, "Text", bsCurrent, "VarNames");
            BindControl(dtpIssueDate, "Value", bsCurrent, "IssueDate", true);
            BindControl(cboIssueFrom, "SelectedItem", bsCurrent, "IssueFrom");
            BindControl(cboIssueTo, "SelectedItem", bsCurrent, "IssueTo");
            BindControl(cboIssueCategory, "SelectedItem", bsCurrent, "Category");
            BindControl(txtPIN, "Text", bsCurrent, "PinNo");

            Binding languageBinding = new Binding("SelectedItem", bsCurrent, "Language", true);
            //languageBinding.NullValue = "English";
            lstLanguage.DataBindings.Add(languageBinding);

            BindControl(chkResolved, "Checked", bsCurrent, "Resolved");
            BindControl(cboResolvedBy, "SelectedItem", bsCurrent, "ResolvedBy");
            BindControl(dtpResolvedDate, "Value", bsCurrent, "ResolvedDate", true);

            BindControl(picMain, "ImageLocation", bsImages, "Path");

            // responses
            BindControl(dtpResponseDate, "Value", bsResponses, "ResponseDate");
            BindControl(dtpResponseTime, "Value", bsResponses, "ResponseDate");
            BindControl(txtResponsePIN, "Text", bsResponses, "PinNo");
        }

        /// <summary>
        /// Remove the current item, set the NewRecord flag to false and set the delete button to delete.
        /// </summary>
        private void CancelNew()
        {
            bsRecords.RemoveCurrent();
            CurrentRecord.NewRecord = false;
            cmdDeleteIssue.Text = "X";
        }

        /// <summary>
        /// Delete the current issue from the database and remove the item from the underlying list.
        /// </summary>
        private void DeleteIssue()
        {
            if (CurrentRecord == null)
                return;
            if (MessageBox.Show("Are you sure you want to delete this praccing issue?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAction.DeleteRecord(CurrentRecord.Item);
                bsRecords.RemoveCurrent();
                RefreshGoToIssues();
            }
        }

        /// <summary>
        /// Delete the current response from the database and remove the item from the underlying list.
        /// </summary>
        private void DeleteResponse()
        {
            int index = dataRepeater1.CurrentItem.ItemIndex;
            PraccingResponse currentReponse = CurrentRecord.Item.Responses[index];

            CurrentRecord.DeletedResponses.Add(CurrentResponse);
            dataRepeater1.RemoveAt(index);
        }


        private int SaveRecord()
        {
            if (CurrentRecord == null)
                return 1;

            if (CanSave()==1)
                return 1;

            
            bool newRec = CurrentRecord.NewRecord;

            int updated = CurrentRecord.SaveRecord();

            if (updated == 0)
            {
                CurrentRecord.Dirty = false;
            }
            else
            {
                MessageBox.Show("Unable to save record.");
            }

            if (newRec)
            {
                RefreshGoToIssues();
            }

            return 0;
        }

        private void RefreshGoToIssues()
        {
            // Get the currently selected item
            PraccingIssue selected = (PraccingIssue)cboGoToIssueNo.SelectedItem;

            // Temporarily remove the SelectedIndexChanged event handler
            cboGoToIssueNo.SelectedIndexChanged -= cboGoToIssueNo_SelectedIndexChanged;

            // Update the ComboBox items to match the list
            cboGoToIssueNo.DataSource = Records.Select(x => x.Item).ToList();

            // Restore the selection if it still exists in the new list
            if (Records.Any(x=>x.Item.ID == selected.ID))
            {
                cboGoToIssueNo.SelectedItem = selected;
            }

            // Reattach the SelectedIndexChanged event handler
            cboGoToIssueNo.SelectedIndexChanged += cboGoToIssueNo_SelectedIndexChanged;
        }

        private int CanSave()
        {
            try
            {
                bsCurrent.EndEdit();
                bsResponses.EndEdit();
                return 0;
            }catch (ArgumentException ex)
            {
                MessageBox.Show("Error saving record. Invalid selection.\r\n" + ex.Message);
                return 1;
            }
        }

        private void MoveRecord(int count)
        {
            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bsRecords.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bsRecords.MovePrevious();
                }
        }

        private void CreateNew()
        {
            Survey currentSurvey = new Survey(CurrentRecord.Item.Survey.SurveyCode);
            currentSurvey.SID = CurrentRecord.Item.Survey.SID;
            CurrentRecord = (PraccingIssueRecord)bsRecords.AddNew();
            CurrentRecord.NewRecord = true;
            CurrentRecord.Item.Survey = currentSurvey;
            CurrentRecord.Item.IssueNo = Records.Max(x => x.Item.IssueNo) + 1;
            CurrentRecord.Item.IssueDate = DateTime.Today;
            CurrentRecord.Item.ResolvedDate = null;
            CurrentRecord.Item.EnteredBy = PeopleList.Where(x => x.ID == Globals.CurrentUser.userid).FirstOrDefault();
            bsRecords.ResetBindings(false);
            cmdDeleteIssue.Text = "C";
        }

        private void AddResponse()
        {
            dataRepeater1.AddNew();
            ((DateTimePicker)dataRepeater1.CurrentItem.Controls["dtpResponseDate"]).Value = DateTime.Today;
            ((DateTimePicker)dataRepeater1.CurrentItem.Controls["dtpResponseTime"]).Value = DateTime.Now;

            CurrentRecord.AddedResponses.Add(CurrentResponse);
        }

        private void CreateFirst(int survID)
        {
            Survey currentSurvey = Globals.AllSurveys.FirstOrDefault(x=>x.SID==survID);

            Records.Clear();
            bsRecords.DataSource = Records;
            CurrentRecord = (PraccingIssueRecord)bsRecords.AddNew();
            CurrentRecord.NewRecord = true;
            CurrentRecord.Item.Survey = currentSurvey;
            CurrentRecord.Item.IssueNo = 1;
            CurrentRecord.Item.IssueDate = DateTime.Today;
            CurrentRecord.Item.ResolvedDate = null;
            CurrentRecord.Item.EnteredBy = PeopleList.Where(x => x.ID == Globals.CurrentUser.userid).FirstOrDefault();
            bsRecords.ResetBindings(false);
            cmdDeleteIssue.Text = "C";
        }

        
        #endregion

        #region Events
        private void PraccingEntry_Load(object sender, EventArgs e)
        {
            RefreshCurrentIssue();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            UpdateSummary();
            Survey selected = (Survey)cboGoToSurvey.SelectedItem;

            LoadSurveyIssues(selected.SID);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();

            Close();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("PraccingReport", 1))
            {
                ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("PraccingReport1");
                return;
            }

            PraccingReportForm frm = new PraccingReportForm();
            frm.Tag = 1;
            FM.FormManager.Add(frm);

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FM.FormManager.FormOpen("frmPraccingIssuesImport", 1))
            {
                ((MainMenu)FM.FormManager.GetForm("MainMenu")).SelectTab("frmPraccingIssuesImport1");
                return;
            }

            ImportPraccingIssues frm = new ImportPraccingIssues();
            frm.Tag = 1;
            FM.FormManager.Add(frm);
        }

        private void toolstripDisplay_Click(object sender, EventArgs e)
        {
            List<SurveyQuestion> questions = new List<SurveyQuestion>();
            string[] varnames = CurrentRecord.Item.VarNames.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            Survey survey = (Survey)cboGoToSurvey.SelectedItem;
            foreach (string v in varnames)
            {
                int id = DBAction.GetQuestionID(survey.SurveyCode, Utilities.ChangeCC(v, survey.CountryCode));
                if (id > 0)
                {
                    SurveyQuestion toAdd = DBAction.GetSurveyQuestion(id);

                    toAdd.Filters = string.Join("\r\n", toAdd.GetFilterVars());
                    toAdd.Translations = DBAction.GetQuestionTranslations(id);
                    toAdd.Comments = DBAction.GetQuesComments(toAdd);
                    questions.Add(toAdd);
                }
            }

            if (questions.Count() == 0)
            {
                MessageBox.Show("No VarNames to display!");
                return;
            }

            QuestionViewer viewer = new QuestionViewer(questions);
            viewer.Show();

        }

        private void toolstripExport_Click(object sender, EventArgs e)
        {
            bool q, t, c, f;

            q = toolstripQ.Checked;
            t = toolstripT.Checked;
            c = toolstripC.Checked;
            f = toolstripF.Checked;

            List<SurveyQuestion> questions = new List<SurveyQuestion>();

            string[] varnames = CurrentRecord.Item.VarNames.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            Survey survey = (Survey)cboGoToSurvey.SelectedItem;

            foreach (string v in varnames)
            {
                int id = DBAction.GetQuestionID(survey.SurveyCode, Utilities.ChangeCC(v, survey.CountryCode));
                if (id > 0)
                {

                    SurveyQuestion toAdd = new SurveyQuestion();


                    toAdd = DBAction.GetSurveyQuestion(id);

                    if (f)
                        toAdd.Filters = string.Join("\r\n", toAdd.GetFilterVars());

                    if (t)
                        toAdd.Translations = DBAction.GetQuestionTranslations(id);

                    if (c)
                        toAdd.Comments = DBAction.GetQuesComments(toAdd);

                    questions.Add(toAdd);
                }
            }

            if (questions.Count() == 0)
            {
                MessageBox.Show("No VarNames to export!");
                return;
            }

            QuestionReport report = new QuestionReport();
            report.SelectedSurvey = (Survey)cboGoToSurvey.SelectedItem;
            report.Questions = questions;
            report.IncludeQuestion = q;
            report.IncludeComments = c;
            report.IncludeTranslation = t;
            report.IncludeFilters = f;

            report.CreateReport();

        }

        private void BsMainIssues_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentIssue();
        }

        private void BsResponses_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentResponse();
        }

        private void BsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;

            // get the question record that was modified
            PraccingIssue modifiedQuestion = (PraccingIssue)bsCurrent[e.NewIndex];
            PraccingIssueRecord modifiedRecord = Records.Where(x => x.Item == modifiedQuestion).FirstOrDefault();

            int index = bsRecords.IndexOf(modifiedRecord);

            if (modifiedRecord == null)
                return;

            switch (e.PropertyDescriptor.Name)
            {
                case "Responses":
                case "Images":
                    break;
                case "Resolved":
                    if (!modifiedRecord.Item.Resolved)
                    {
                        modifiedRecord.Item.ResolvedDate = null;
                        modifiedRecord.Item.ResolvedBy = new Person(string.Empty, 0);
                        bsCurrent.ResetCurrentItem();
                    }
                    modifiedRecord.Dirty = true;
                    break;
                default:
                    modifiedRecord.Dirty = true;
                    return;
            }          
        }

        private void BsResponses_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;

            // get the question record that was modified
            PraccingResponse modifiedResponse = (PraccingResponse)bsResponses[e.NewIndex];
            PraccingIssueRecord modifiedRecord = Records.Where(x => x.Item.Responses.Contains(modifiedResponse)).FirstOrDefault();

            int index = bsRecords.IndexOf(modifiedRecord);

            if (modifiedRecord == null)
                return;

            switch (e.PropertyDescriptor.Name)
            {
                case "Images":
                    break;
                default:
                    modifiedRecord.EditedResponses.Add(modifiedResponse);
                    return;
            }
        }

        void picMain_MouseDown(object sender, MouseEventArgs e)
        {
            panning = true;
            startingPoint = new Point(e.Location.X - movingPoint.X, e.Location.Y - movingPoint.Y);
        }

        void picMain_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        void picMain_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (panning)
            {
                movingPoint = new Point(e.Location.X - startingPoint.X, e.Location.Y - startingPoint.Y);
                picBox.Invalidate();
            }
        }

        void picMain_Paint(object sender, PaintEventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (picBox.Image == null) return;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(picBox.Image, movingPoint);
        }

        private void PraccingEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSurveyFilter();
            FM.FormManager.Remove(this);
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cboGoToSurvey_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboGoToSurvey.SelectedItem == null)
                return;

            if (SaveRecord() == 1)
            {
                return;
            }

            Survey selected = (Survey)cboGoToSurvey.SelectedItem;

            LoadSurveyIssues(selected.SID);

        }
        private void cboGoToIssueNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoToIssueNo.SelectedItem == null)
                return;

            if (SaveRecord() == 1)
            {
                return;
            }

            PraccingIssue selectedIssue = (PraccingIssue)cboGoToIssueNo.SelectedItem;
            GoToIssue(selectedIssue.IssueNo);
        }

        protected void PraccingEntry_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (SaveRecord() == 1)
            {
                return;
            }

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);
        }

        private void cboGoToIssueNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                foreach(PraccingIssue pi in cboGoToIssueNo.Items)
                {
                    if (pi.IssueNo == Int32.Parse(cboGoToIssueNo.Text))
                        cboGoToIssueNo.SelectedItem = pi;
                }
                
            }
        }

        private void cmdAddResponse_Click(object sender, EventArgs e)
        {
            AddResponse();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
            {
                return;
            }
        }

        private void cmdDeleteIssue_Click(object sender, EventArgs e)
        {
            if (CurrentRecord.NewRecord)
            {
                CancelNew();
            }
            else
            {
                DeleteIssue();
            }
        }

        private void cmdDeleteResponse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this praccing response?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteResponse();          
            }
        }

        private void cmdAddIssue_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
            {
                return;
            }

            CreateNew();
        }

        private void cmdBrowseIssue_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
            {
                return;
            }

            BrowseIssues frm = new BrowseIssues(Records.Select(x=>x.Item).ToList());

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                GoToIssue(frm.SelectedIssueNo);
            }
            else if (frm.DialogResult == DialogResult.No)
            {
                CreateNew();
            }
            else
            {
                // cancelled
            }
        }

        private void chkResolved_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResolved.Checked)
            {
               // dtpResolvedDate.Checked = true;
                //CurrentIssue.ResolvedDate = DateTime.Today;
                //CurrentIssue.ResolvedBy.ID = 0;
            }
            else
            {
               // dtpResolvedDate.Checked = false;
                
            }
        }

        private void chkFilterUnresolved_CheckedChanged(object sender, EventArgs e)
        {

            if (chkFilterUnresolved.Checked)
            {
                var unresolved = Records.Where(x => !x.Item.Resolved);
                if (unresolved.Count() == 0)
                {
                    MessageBox.Show("No unresolved issues found!");
                    return;
                }

                bsRecords.DataSource = unresolved; 
                cboGoToIssueNo.DataSource = unresolved.Select(x=>x.Item).ToList();
            }
            else
            {
                bsRecords.DataSource = Records;
                cboGoToIssueNo.DataSource = Records.Select(x => x.Item).ToList();
            }

            RefreshCurrentIssue();
        }

        private void cmdFilterText_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox("Description");

            input.ShowDialog();

            string crit = input.userInput;

            if (input.DialogResult == DialogResult.OK)
            {
                bsRecords.DataSource = Records.Where(x => x.Item.Description.Contains(crit)).ToList();
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PNG Files|*.png";
            dialog.ShowDialog();

            if (string.IsNullOrEmpty(dialog.FileName))
                return;

            string newFileName = "Praccing Image - " + DateTime.Now.Month.ToString().Trim() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() +
                        DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".png";

            // copy the image to the praccing images folder
            System.IO.File.Copy(dialog.FileName, DBImageRepo + @"\" + newFileName);

            PraccingImage newImage = new PraccingImage();
            newImage.PraccID = CurrentRecord.Item.ID;
            newImage.Path = DBImageRepo + @"\" + newFileName;
            CurrentRecord.Item.Images.Add(newImage);
            CurrentRecord.AddedImages.Add(newImage);
            bsImages.ResetBindings(false);
            CurrentRecord.Dirty = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            PraccingImage current = (PraccingImage)bsImages.Current;

            if (MessageBox.Show("Are you sure you want to delete this image?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (current.ID > 0)
                {
                    CurrentRecord.DeletedImages.Add(current);
                }

                bsImages.RemoveCurrent();
            }
        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            if (CurrentResponse == null)
                return;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PNG Files|*.png";
            dialog.ShowDialog();

            if (string.IsNullOrEmpty(dialog.FileName))
                return;

            string newFileName = "Praccing Response Image - " + DateTime.Now.Month.ToString().Trim() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() +
                        DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".png";

            // copy the image to the praccing images folder
            System.IO.File.Copy(dialog.FileName, DBImageRepo + @"\" + newFileName);

            PraccingImage newImage = new PraccingImage();
            newImage.PraccID = CurrentResponse.ID;
            newImage.Path = DBImageRepo + @"\" + newFileName;
            CurrentResponse.Images.Add(newImage);
            CurrentRecord.AddedResponseImages.Add(newImage);
            bsResponseImages.ResetBindings(false);
            
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            if (CurrentResponse == null)
                return;

            PraccingImage current = (PraccingImage)bsResponseImages.Current;

            if (MessageBox.Show("Are you sure you want to delete this image?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (current.ID > 0)
                {
                    CurrentRecord.DeletedResponseImages.Add(current);
                }

                bsResponseImages.RemoveCurrent();
            }
        }

        private void cboIssueCategory_Validating(object sender, CancelEventArgs e)
        {

            string s;
            ComboBox cbo = (ComboBox)sender;

            if (cbo.SelectedIndex == -1 && !string.IsNullOrEmpty(cbo.Text))
            {
                // Let's see if it ends with a slash
                s = cbo.Text;
                if (s.EndsWith("\\") || s.EndsWith("/"))
                    cbo.SelectedIndex = cbo.FindString(s);
            }
        }

        #region DataRepeater Events

        private void dataRepeater1_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            IEnumerable<Person> names = GetNames(false);

            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboResponseFrom", false)[0];
            //Set the data source
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
            combo.DataSource = new List<Person>(names);

            var combo2 = (ComboBox)e.DataRepeaterItem.Controls.Find("cboResponseTo", false)[0];
            //Set the data source
            combo2.DisplayMember = "Name";
            combo2.ValueMember = "ID";
            combo2.DataSource = new List<Person>(names);
        }

        /// <summary>
        /// After Item is cloned, draw item. The index is now available to select the proper data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).List;

            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboResponseFrom", false)[0];
            PraccingResponse item = datasource[e.DataRepeaterItem.ItemIndex];

            //Set the selected item based of the list item index
            combo.SelectedItem = item.ResponseFrom;

            var combo2 = (ComboBox)e.DataRepeaterItem.Controls.Find("cboResponseTo", false)[0];
            //Set the selected item based of the list item index
            combo2.SelectedItem = item.ResponseTo;

            var rtb2 = (ExtraRichTextBox)e.DataRepeaterItem.Controls.Find("rtbResponse", false)[0];
            rtb2.Rtf = Converter.HTMLToRtf(item.Response);

            var label = (Label)e.DataRepeaterItem.Controls.Find("lblImageCount", false)[0];
            int imageCount = item.Images.Count;

            label.Visible = true;
            if (imageCount > 1)
                label.Text = imageCount + " images attached.";
            else if (imageCount == 1)
                label.Text = imageCount + " image attached.";
            else
                label.Visible = false;

        }

        private void cboResponseFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;

            var source = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).List;
            source[dataRepeaterItem.ItemIndex].ResponseFrom = (Person)combo.SelectedItem;
    
        }

        private void cboResponseTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;

            var source = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).List;
            source[dataRepeaterItem.ItemIndex].ResponseTo = (Person)combo.SelectedItem;
            
        }

        private void dataRepeater1_ItemTemplate_Enter(object sender, EventArgs e)
        {
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)sender;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;

            var source = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).List;

            CurrentResponse = source[dataRepeaterItem.ItemIndex];
        }

        private void cboResponseFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!CurrentRecord.EditedResponses.Contains(CurrentResponse))
                CurrentRecord.EditedResponses.Add(CurrentResponse);
        }

        private void cboResponseTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!CurrentRecord.EditedResponses.Contains(CurrentResponse))
                CurrentRecord.EditedResponses.Add(CurrentResponse);
        }

        private void txtResponsePIN_Validated(object sender, EventArgs e)
        {
            if (!CurrentRecord.EditedResponses.Contains(CurrentResponse))
                CurrentRecord.EditedResponses.Add(CurrentResponse);
        }

        #endregion

        #region Navigation Bar events
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bsRecords.MoveLast();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bsRecords.MoveFirst();
        }
        #endregion

        #endregion

        private void extraRichTextBox1_Validated(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void UpdateDescription()
        {
            // change RTF tags to HTML tags
            string html = Converter.ConvertRTFtoHTML(extraRichTextBox1.Rtf);
            // now remove the extraneous tags
            html = HTMLUtilities.RemoveHtmlTag(html, "div");
            html = HTMLUtilities.RemoveEmptyParagraphsWithBr(html);
            html = HTMLUtilities.RemoveStyleAttribute(html, "p");
            html = html.Replace("<p>", "<br>");
            html = html.Replace("</p>", "");
            html = html.TrimAndRemoveAll("<br>");

            CurrentRecord.Item.Description = html;
        }

        private void rtbResponse_Validated(object sender, EventArgs e)
        {
            ExtraRichTextBox rtb = (ExtraRichTextBox)sender;

            // change RTF tags to HTML tags
            string html = Converter.ConvertRTFtoHTML(rtb.Rtf);
            // now remove the extraneous tags
            html = HTMLUtilities.RemoveHtmlTag(html, "div");
            html = HTMLUtilities.RemoveEmptyParagraphsWithBr(html);
            html = HTMLUtilities.RemoveStyleAttribute(html, "p");
            html = html.Replace("<p>", "<br>");
            html = html.Replace("</p>", "");
            html = html.TrimAndRemoveAll("<br>");

            CurrentResponse.Response = html;

            CurrentRecord.EditedResponses.Add(CurrentResponse);           
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem == null)
            {
                comboBox.SelectedValue = 0;
            }
        }
    }
}
