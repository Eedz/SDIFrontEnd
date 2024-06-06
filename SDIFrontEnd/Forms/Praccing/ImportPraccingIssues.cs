using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Wordprocessing;
using ITCLib;
//using OpenXMLHelper;
using System.Text.RegularExpressions;
using System.IO;
using FM = FormManager;
using HtmlRtfConverter;

namespace SDIFrontEnd
{
    public partial class ImportPraccingIssues : Form
    {
        BindingSource bsIssues;
        BindingSource bsExistingResponses;
        BindingSource bsNewResponses;

        List<PraccingIssue> ReferenceList;      // list of existing issues to compare against
        Survey ReferenceSurvey;                 // the survey that the imported issues should belong to
        
        List<PraccingIssue> importIssues;       // the 'keep' issues
        List<PraccingResponse> importResponses; // the 'keep' responses
        List<PraccingIssue> mainIssues;         // the issues from the file

        // names and categories from the import document will be checked against these
        List<Person> personList;
        List<PraccingCategory> categoryList;

        PraccingIssue CurrentIssue;
        PraccingResponse CurrentResponse;

        List<StringPair> datesToFix;
        List<StringPair> namesToFix;
        List<StringPair> images;

        bool loaded;

        // form layout values
        int doubleResponseHeight;
        int singleResponseHeight;

        //image paths
        string AppImageRepo;
        string DBImageRepo = @"\\psychfile\psych$\psych-lab-gfong\SMG\Praccing Images";

        public ImportPraccingIssues()
        {
            InitializeComponent();

            SetupMouseWheelEvents();

            doubleResponseHeight = 488;
            singleResponseHeight = 244;

            FillLists();

            AppImageRepo = System.IO.Path.GetDirectoryName(Application.StartupPath);

            bsIssues = new BindingSource();
            bsIssues.PositionChanged += BsIssues_PositionChanged;

            bsExistingResponses = new BindingSource();

            bsNewResponses = new BindingSource();

            FillBoxes();
        }

        #region Form Setup

        private void SetupMouseWheelEvents()
        {
            this.MouseWheel += Form_OnMouseWheel;
            cboSurvey.MouseWheel += ComboBox_MouseWheel;
            cboFrom.MouseWheel += ComboBox_MouseWheel;
            cboTo.MouseWheel += ComboBox_MouseWheel;
            cboCategory.MouseWheel += ComboBox_MouseWheel;
            cboResName.MouseWheel += ComboBox_MouseWheel;
            cboNewFrom.MouseWheel += ComboBox_MouseWheel;
            cboNewTo.MouseWheel += ComboBox_MouseWheel;
        }

        private void FillLists()
        {
            importIssues = new List<PraccingIssue>();
            importResponses = new List<PraccingResponse>();
            mainIssues = new List<PraccingIssue>();

            datesToFix = new List<StringPair>();
            namesToFix = new List<StringPair>();
            images = new List<StringPair>();

            personList = new List<Person>(Globals.AllPeople);
            categoryList = DBAction.GetPraccingCategories();

        }

        private void FillBoxes()
        {
            // get list of surveys
            cboSurvey.ValueMember = "SID";
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);

            cboCategory.ValueMember = "ID";
            cboCategory.DisplayMember = "Category";
            cboCategory.DataSource = categoryList;

            cboFrom.ValueMember = "ID";
            cboFrom.DisplayMember = "Name";
            cboFrom.DataSource = new List<Person>(personList);

            cboTo.ValueMember = "ID";
            cboTo.DisplayMember = "Name";
            cboTo.DataSource = new List<Person>(personList);

            cboResName.ValueMember = "ID";
            cboResName.DisplayMember = "Name";
            cboResName.DataSource = new List<Person>(personList);

            cboNewFrom.ValueMember = "ID";
            cboNewFrom.DisplayMember = "Name";
            cboNewFrom.DataSource = new List<Person>(personList);

            cboNewTo.ValueMember = "ID";
            cboNewTo.DisplayMember = "Name";
            cboNewTo.DataSource = new List<Person>(personList);
        }

        #endregion

        #region Methods

        private void RefreshCurrentRecord()
        {
            CurrentIssue = (PraccingIssue)bsIssues.Current;

            if (CurrentIssue == null)
                return;

            bool isNewIssue = CurrentIssue.ID == 0;
            bool hasImages = CurrentIssue.Images.Count > 0;

            chkKeepIssue.Visible = isNewIssue;
            cmdMoveIssue.Visible = isNewIssue;

            if (CurrentIssue.ID == 0)
                txtStatus.Text = "New";
            else
                txtStatus.Text = "Existing";

            dtpResDate.Enabled = CurrentIssue.Resolved;
            cboResName.Enabled = CurrentIssue.Resolved;

            rtbDescription.Rtf = null;
            rtbDescription.Rtf = Converter.HTMLToRtf(CurrentIssue.Description);

            if (CurrentIssue.Images.Count == 1)
                lblIssueImages.Text = CurrentIssue.Images.Count + " image found for this issue.";
            else if (CurrentIssue.Images.Count > 1)
                lblIssueImages.Text = CurrentIssue.Images.Count + " images found for this issue.";

            lblIssueImages.Visible = hasImages;
        }

        private void ToggleIssueStatus(bool keep)
        {
            if (keep)
            {
                importIssues.Add((PraccingIssue)bsIssues.Current);
                chkKeepIssue.Text = "Saved";
            }
            else
            {
                importIssues.Remove((PraccingIssue)bsIssues.Current);
                chkKeepIssue.Text = "Keep?";
            }
        }

        private void ToggleResolved(bool resolved)
        {
            if (resolved)
            {
                CurrentIssue.ResolvedDate = DateTime.Today;
                CurrentIssue.ResolvedBy.ID = Globals.CurrentUser.userid;
            }
            else
            {
                CurrentIssue.ResolvedDate = null;
                CurrentIssue.ResolvedBy.ID = 0;
            }

            dtpResDate.Enabled = resolved;
            cboResName.Enabled = resolved;
            if (!importIssues.Contains(CurrentIssue))
                importIssues.Add(CurrentIssue);
        }

        /// <summary>
        /// Scan the document for a table. Each unique issue number found in the table corresponds to 1 Praccing Issue and its related responses.
        /// </summary>
       
        private void LoadRecords(List<PraccingIssue> issues)
        {
            // check for valid names and have the user correct them
            namesToFix.Clear();
            var people = Globals.AllPeople;
            foreach (PraccingIssue issue in issues)
            {
                var matchingTo = people.FirstOrDefault(x => x.Name.Equals(issue.IssueTo.Name));
                if (matchingTo != null) 
                    issue.IssueTo.ID = matchingTo.ID; 
                else 
                    namesToFix.Add(new StringPair(issue.IssueTo.Name));

                var matchingFrom =  people.FirstOrDefault(x=>x.Name.Equals(issue.IssueFrom.Name));
                if (matchingFrom != null)
                    issue.IssueFrom.ID = matchingFrom.ID;
                else
                    namesToFix.Add(new StringPair(issue.IssueFrom.Name));
            }   
            
            if (namesToFix.Count > 0)
            {
                FixNames frm = new FixNames(namesToFix);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel)
                {
                    MessageBox.Show("Some names may appear blank.");
                }
            }

            foreach (StringPair stringPair in namesToFix)
            {
                var matchingTo = issues.Where(x => x.IssueTo.Name.Equals(stringPair.String1));
                foreach (PraccingIssue issue in issues)
                {
                    issue.IssueTo.ID = people.FirstOrDefault(x => x.Name.Equals(stringPair.String2)).ID;
                }

                var matchingFrom = issues.Where(x => x.IssueFrom.Name.Equals(stringPair.String1));
                foreach (PraccingIssue issue in issues)
                {
                    issue.IssueFrom.ID = people.FirstOrDefault(x => x.Name.Equals(stringPair.String2)).ID;
                }
            }

            // now compare to existing issues
            foreach (PraccingIssue issue in issues)
            {
                var existingIssue = ReferenceList.FirstOrDefault(x => x.IssueNo == issue.IssueNo);
                if (existingIssue != null) 
                {
                    issue.ID = existingIssue.ID;

                    foreach (PraccingResponse response in issue.Responses)
                    {
                        var matchingResponse = existingIssue.Responses.FirstOrDefault(x => Utilities.PrepareTextCompare(x.Response).Equals(Utilities.PrepareTextCompare(response.Response)));
                        if (matchingResponse != null)
                            response.ID = matchingResponse.ID;

                        response.IssueID = existingIssue.ID;
                    }
                }
            }

            mainIssues = issues;
            
            
            loaded = true;
        }

        private void ShowResults()
        {
            UnBindProperties();
            RefreshMainIssues();

            if (this.mainIssues.Count() == 0)
            {
                MessageBox.Show("No new issues or responses found.");
                return;
            }

            BindProperties();
            navIssues.BindingSource = bsIssues;
            panelResults.Visible = true;
            cmdImport.Visible = true;
        }

        private void RefreshMainIssues()
        {
            mainIssues = mainIssues.Where(x => x.Responses.Where(y => y.ID < 0).Count() > 0 || x.ID == 0).ToList();

            bsIssues.DataSource = null;
            bsIssues.DataSource = mainIssues;
        }

        private void RefreshResponses()
        {

            bsNewResponses.DataSource = CurrentIssue.Responses.Where(x => x.ID < 0).ToList();

            CurrentResponse = (PraccingResponse)bsNewResponses.Current;

            bsExistingResponses.DataSource = CurrentIssue.Responses.Where(x => x.ID > 0).ToList();

            drExisting.DataSource = bsExistingResponses;
            drNewResponses.DataSource = bsNewResponses;

            panelExisting.Visible = bsExistingResponses.Count != 0;
            panelNew.Visible = bsNewResponses.Count != 0;
            if (bsExistingResponses.Count == 0)
            {
                panelNew.Top = panelExisting.Top;
                panelNew.Height = doubleResponseHeight;
            }
            else
            {
                panelNew.Top = panelExisting.Top + panelExisting.Height + 5;
                panelNew.Height = singleResponseHeight;
            }
        }

        /// <summary>
        /// Turn an issue into a response for another issue.
        /// </summary>
        /// <param name="issue">The original main issue to be moved.</param>
        /// <param name="newIssueNo">The Issue Number of the destination issue.</param>
        private void MoveIssue(PraccingIssue issue, PraccingIssue newIssue)
        {
            PraccingResponse newResponse = new PraccingResponse();

            PraccingIssue mainIssue = mainIssues.Where(x => x.IssueNo == newIssue.IssueNo).FirstOrDefault();

            if (mainIssue == null)
            {
                // get mainIssue from DB
                mainIssue = DBAction.GetPraccingIssue(newIssue.ID);
                mainIssues.Add(mainIssue);
            }

            newResponse.IssueID = mainIssue.ID;
            newResponse.ID = -1;
            newResponse.Response = issue.Description;
            newResponse.ResponseFrom = issue.IssueFrom;
            newResponse.ResponseTo = issue.IssueTo;
            newResponse.ResponseDate = issue.IssueDate;
            newResponse.Images = issue.Images;

            mainIssue.Responses.Add(newResponse);

            mainIssues.Remove(issue);

            UnBindProperties();
            RefreshMainIssues();
            BindProperties();
        }

        /// <summary>
        /// Reassign a response to a new main issue.
        /// </summary>
        /// <param name="response">Response to be reassigned.</param>
        /// <param name="newIssueNo">Issue Number of the new main issue.</param>
        private void MoveResponse(PraccingResponse response, PraccingIssue newIssue)
        {
            PraccingIssue parentIssue = mainIssues.Where(x => x.Responses.Contains(response)).FirstOrDefault();
            PraccingIssue mainIssue = mainIssues.Where(x => x.IssueNo == newIssue.ID).FirstOrDefault();

            if (mainIssue == null)
            {
                // get mainIssue from DB
                mainIssue = DBAction.GetPraccingIssue(newIssue.ID);
                mainIssues.Add(mainIssue);
            }

            mainIssue.Responses.Add(response);
            parentIssue.Responses.Remove(response);
            response.IssueID = mainIssue.ID;

            RefreshResponses();
        }

        private void ImportRecords()
        {
            int issueCount = SaveIssues();
            int responseCount = SaveResponses();

            UpdateKeepToggles();

            MessageBox.Show(issueCount + " issue(s) imported and " + responseCount + " response(s) imported.");

        }

        private int SaveIssues()
        {
            int issueCount = 0;

            // for each "saved" issue, add it to the database
            foreach (PraccingIssue pi in importIssues)
            {
                // update those that are already in the database
                if (pi.ID > 0)
                {
                    DBAction.UpdatePraccingIssue(pi);
                    continue;
                }


                int tempIssueNo = pi.IssueNo;
                pi.IssueNo = DBAction.GetNextPraccingIssueNo(pi.Survey.SID);
                if (DBAction.InsertPraccingIssue(pi) == 1)
                    pi.IssueNo = tempIssueNo;
                else
                {
                    foreach (PraccingResponse pr in pi.Responses)
                        pr.IssueID = pi.ID;

                    // save images
                    // copy images to network path
                    foreach (PraccingImage img in pi.Images)
                    {
                        if (!File.Exists(DBImageRepo + @"\" + img.Path))
                            File.Copy(img.Path, DBImageRepo + @"\" + img.Path);

                        if (!img.Path.StartsWith(DBImageRepo))
                            img.Path = DBImageRepo + @"\" + img.Path;
                    }

                    
                    DBAction.InsertPraccingImage(pi.ID, pi.Images);

                    issueCount++;
                }

            }
            // if the issue was inserted successfully, remove it from the list
            for (int i = 0; i < importIssues.Count; i++)
            {
                if (importIssues[i].ID > 0)
                    importIssues.Remove(importIssues[i]);
            }

            return issueCount;
        }

        private int SaveResponses()
        {
            int responseCount = 0;

            // for each "saved" response, add it to the database
            foreach (PraccingResponse pr in importResponses)
            {
                // skip those that are already in the database
                if (pr.ID > 0)
                    continue;

                if (DBAction.InsertPraccingResponse(pr) != 1)
                    responseCount++;

                // save images
                // copy images to network path
                foreach (PraccingImage img in pr.Images)
                {
                    if (!File.Exists(DBImageRepo + @"\" + img.Path))
                        File.Copy(AppImageRepo + @"\" + img.Path, DBImageRepo + @"\" + img.Path);
                }


                DBAction.InsertPraccingResponseImage(pr.ID, pr.Images);

            }
            // if the response was inserted successfully, remove it from the list
            for (int i = 0; i < importResponses.Count; i++)
            {
                if (importResponses[i].ID > 0)
                    importResponses.Remove(importResponses[i]);
            }

            return responseCount;
        }

        private void BindProperties()
        {
            BindControl(txtIssueNo, "Text", bsIssues, "IssueNo");
            BindControl(txtVarNames, "Text", bsIssues, "VarNames");


            BindControl(cboFrom, "SelectedItem", bsIssues, "IssueFrom");
            BindControl(cboTo, "SelectedItem", bsIssues, "IssueTo");
            BindControl(cboCategory, "SelectedItem", bsIssues, "Category");
            BindControl(dtpIssueDate, "Value", bsIssues, "IssueDate", true);
            BindControl(chkResolved, "Checked", bsIssues, "Resolved");
            BindControl(dtpResDate, "Value", bsIssues, "ResolvedDate", true);
            BindControl(cboResName, "SelectedItem", bsIssues, "ResolvedBy");
            BindControl(txtPinNo, "Text", bsIssues, "PinNo");

            BindControl(dtpOldTime, "Value", bsExistingResponses, "ResponseDate", true);
            BindControl(dtpOldDate, "Value", bsExistingResponses, "ResponseDate", true);


            BindControl(dtpNewTime, "Value", bsNewResponses, "ResponseDate", true);
            BindControl(dtpNewDate, "Value", bsNewResponses, "ResponseDate", true);
            //BindControl(rtbNewResponse, "Text", bsNewResponses, "Response");

        }

        private void UnBindProperties()
        {
            txtIssueNo.DataBindings.Clear();
            txtVarNames.DataBindings.Clear();
            rtbDescription.DataBindings.Clear();
            cboFrom.DataBindings.Clear();
            cboTo.DataBindings.Clear();
            cboCategory.DataBindings.Clear();
            dtpIssueDate.DataBindings.Clear();
            chkResolved.DataBindings.Clear();
            cboResName.DataBindings.Clear();
            dtpResDate.DataBindings.Clear();
            txtPinNo.DataBindings.Clear();


            dtpOldTime.DataBindings.Clear();
            dtpOldDate.DataBindings.Clear();


            dtpNewTime.DataBindings.Clear();
            dtpNewDate.DataBindings.Clear();
            //cboNewFrom.DataBindings.Clear();
            //cboNewTo.DataBindings.Clear();
            // rtbNewResponse.DataBindings.Clear();

        }

        private void BindControl(System.Windows.Forms.Control ctl, string prop, object datasource, string dataMember, bool formatting = false)
        {
            ctl.DataBindings.Clear();
            ctl.DataBindings.Add(prop, datasource, dataMember, formatting);
        }

        private void UpdateKeepToggles()
        {
            if (importIssues.Contains(CurrentIssue))
            {
                chkKeepIssue.Text = "Saved";
                chkKeepIssue.CheckedChanged -= chkKeepIssue_CheckedChanged;
                chkKeepIssue.Checked = true;
                chkKeepIssue.CheckedChanged += chkKeepIssue_CheckedChanged;
            }
            else
            {
                chkKeepIssue.Text = "Keep?";
                chkKeepIssue.CheckedChanged -= chkKeepIssue_CheckedChanged;
                chkKeepIssue.Checked = false;
                chkKeepIssue.CheckedChanged += chkKeepIssue_CheckedChanged;
            }
        }

        private PraccingIssue SelectIssue()
        {
            List<PraccingIssue> issueNumbers = DBAction.GetPraccingIssues(((Survey)cboSurvey.SelectedItem).SID);

            issueNumbers.AddRange(mainIssues);
            BrowseIssues frm = new BrowseIssues(issueNumbers);

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                return frm.SelectedIssue;
            }
            else
            {
                // user cancelled
                return null;
            }
        }

        /// <summary>
        /// Start a new import procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearForm()
        {
            panelResults.Visible = false;
            cmdLoad.Visible = false;
            cmdImport.Visible = false;
            mainIssues.Clear();
            namesToFix.Clear();
            datesToFix.Clear();

            foreach (StringPair sp in images)
            {
                // delete images from app path
                File.Delete(AppImageRepo + @"\" + sp.String2);
            }

            images.Clear();
            CurrentIssue = null;
            CurrentResponse = null;
            txtPath.Text = string.Empty;

            loaded = false;

        }
        #endregion

        #region Control Events

        private void ImportPraccingIssues_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (StringPair sp in images)
            {
                // delete images from app path
                File.Delete(AppImageRepo + @"\" + sp.String2);
            }
            FM.FormManager.Remove(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BsIssues_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentRecord();
            
            RefreshResponses();

            UpdateKeepToggles();
        }

        private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null)
                return;
            if (loaded)
                ClearForm();

            ReferenceSurvey = (Survey)cboSurvey.SelectedItem;
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.doc|*.docx";
            dialog.ShowDialog();

            txtPath.Text = dialog.FileName;
            cmdLoad.Visible = true;
            cmdLoad.Enabled = true;
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null)
            {
                MessageBox.Show("Choose a survey before continuing.");
                return;
            }

            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Choose a file before continuing.");
                return;
            }

            try
            {
                Survey survey = (Survey)cboSurvey.SelectedItem;
                PraccingIssueImporter importer = new PraccingIssueImporter(survey, txtPath.Text);
                importer.PeopleList = Globals.AllPeople;
                importer.CategoryList = DBAction.GetPraccingCategories();
                importer.ImportData();

                images = importer.Images; // save the reference to all the images gathered from the document

                // now check the imported data against already existing issues
                ReferenceList = DBAction.GetPraccingIssues(ReferenceSurvey.SID);                
                LoadRecords(importer.ImportedIssues);

                ShowResults();
                cmdLoad.Enabled = false;

            }
            catch (IOException)
            {
                MessageBox.Show("Unable to access the file. Make sure it is not open in the background and try again.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            ImportRecords();
        }

        private void cmdMoveIssue_Click(object sender, EventArgs e)
        {
            PraccingIssue targetIssueNo = SelectIssue();

            if (targetIssueNo == null)
                return;

            // move issue to target issue as a response
            MoveIssue(CurrentIssue, targetIssueNo);
        }

        private void cmdNewResponse_Click(object sender, EventArgs e)
        {
            bsNewResponses.AddNew();
        }

        private void cmdMoveResponse_Click(object sender, EventArgs e)
        {
            PraccingIssue targetIssueNo = SelectIssue();

            if (targetIssueNo == null)
                return;

            // move issue to target issue as a response
            MoveResponse(CurrentResponse, targetIssueNo);
        }

        private void chkKeepIssue_CheckedChanged(object sender, EventArgs e)
        {
            ToggleIssueStatus(chkKeepIssue.Checked);
        }

        private void chkResolved_Click(object sender, EventArgs e)
        {
            ToggleResolved(chkResolved.Checked);
        }

        private void chkKeepResponse_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)checkBox.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)checkBox.Parent.Parent;
            var datasource = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).DataSource;
            PraccingResponse response = datasource[dataRepeaterItem.ItemIndex];

            if (checkBox.Checked)
            {
                if (response.ID == -2)
                    CurrentIssue.Responses.Add(response);

                importResponses.Add(response);
                checkBox.Text = "Saved";
                if (!importIssues.Contains(CurrentIssue))
                {
                    importIssues.Add(CurrentIssue);
                    chkKeepIssue.CheckedChanged -= chkKeepIssue_CheckedChanged;
                    chkKeepIssue.Checked = true;
                    chkKeepIssue.CheckedChanged += chkKeepIssue_CheckedChanged;
                }
            }
            else
            {
                importResponses.Remove(response);
                checkBox.Text = "Keep?";
            }
        }

        protected void Form_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bsIssues.MoveNext();
            else if (e.Delta == 120)
                bsIssues.MovePrevious();
        }

        #region DataRepeater Events

        /// <summary>
        /// After Item is cloned, draw item. The index is now available to select the proper data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drExisting_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).DataSource;

            var oldFrom = (TextBox)e.DataRepeaterItem.Controls.Find("txtOldFrom", false)[0];
            oldFrom.Text = datasource[e.DataRepeaterItem.ItemIndex].ResponseFrom.Name;

            var oldTo = (TextBox)e.DataRepeaterItem.Controls.Find("txtOldTo", false)[0];
            oldTo.Text = datasource[e.DataRepeaterItem.ItemIndex].ResponseTo.Name;

            var oldPin = (TextBox)e.DataRepeaterItem.Controls.Find("txtOldPinNo", false)[0];
            oldPin.Text = datasource[e.DataRepeaterItem.ItemIndex].PinNo;

            var rtb = (RichTextBox)e.DataRepeaterItem.Controls.Find("rtbOldResponse", false)[0];
            rtb.Rtf = Converter.HTMLToRtf(datasource[e.DataRepeaterItem.ItemIndex].Response);
        }

        private void drNewResponses_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).DataSource;
            var item = datasource[e.DataRepeaterItem.ItemIndex];

            var newFrom = (ComboBox)e.DataRepeaterItem.Controls.Find("cboNewFrom", false)[0];
            newFrom.SelectedItem = item.ResponseFrom;

            var newTo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboNewTo", false)[0];
            newTo.SelectedItem = item.ResponseTo;

            var rtb = (RichTextBox)e.DataRepeaterItem.Controls.Find("rtbNewResponse", false)[0];
            rtb.Rtf = Converter.HTMLToRtf(item.Response);

            var checkbox = (System.Windows.Forms.CheckBox)e.DataRepeaterItem.Controls.Find("chkKeepResponse", false)[0];

            // update toggle
            if (importResponses.Contains(item))
            {
                checkbox.Text = "Saved";
                checkbox.Checked = true;
            }
            else
            {
                checkbox.Text = "Keep?";
                checkbox.Checked = false;
            }

            // update image message
            var lbl = (Label)e.DataRepeaterItem.Controls.Find("lblResponseImages", false)[0];
            if (item != null)
            {
                if (item.Images.Count == 1)
                {
                    lbl.Text = item.Images.Count + " image found for this response.";
                    lbl.Visible = true;
                }
                else if (item.Images.Count > 1)
                {
                    lbl.Text = item.Images.Count + " images found for this response.";
                    lbl.Visible = true;
                }
                else
                {
                    lbl.Visible = false;
                }
            }
            else
            {
                lbl.Visible = false;
            }

            if (item.ID == 0) // this is added manually, so add it to the main issue's response list
            {
                item.ID = -1;
                CurrentIssue.Responses.Add(item);
            }
        }

        private void drNewResponses_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboNewFrom", false)[0];
            //Set the data source
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
            combo.DataSource = new List<Person>(personList);

            var combo2 = (ComboBox)e.DataRepeaterItem.Controls.Find("cboNewTo", false)[0];
            //Set the data source
            combo2.DisplayMember = "Name";
            combo2.ValueMember = "ID";
            combo2.DataSource = new List<Person>(personList);
        }

        private void cboNewFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].ResponseFrom = (Person)combo.SelectedItem;
        }

        private void cboNewTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].ResponseTo = (Person)combo.SelectedItem;
        }

        private void rtbNewResponse_Validated(object sender, EventArgs e)
        {
            var rtb = (RichTextBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)rtb.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)rtb.Parent.Parent;

            var source = (List<PraccingResponse>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].Response = rtb.Text;
        }

        #endregion
        #endregion

    
    }
}