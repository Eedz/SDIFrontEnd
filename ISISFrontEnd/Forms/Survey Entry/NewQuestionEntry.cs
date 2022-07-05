﻿using System;
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
    // TODO restrict to temp names?
    // TODO series entry
    public partial class NewQuestionEntry : Form
    {
        public enum EntryMode { Copy, Create }

        public EntryMode EnterMode;
        public SurveyRecord DestinationSurvey;
        public string DestinationQnum;
        public List<QuestionRecord> QuestionsToAdd;
        List<VariableName> RelatedQuestions;


        int copyWidth = 1200;
        int copyHeight = 500;

        int newWidth = 750;
        int newHeight = 500;

        public NewQuestionEntry(SurveyRecord destinationSurvey, string destinationQnum)
        {
            InitializeComponent();

            DestinationSurvey = destinationSurvey;
            DestinationQnum = destinationQnum;
            RelatedQuestions = new List<VariableName>();
            string tempPrefix = DBAction.GetTempPrefix(DestinationSurvey);

            cboSurveySource.DataSource = Globals.AllSurveys;
            cboSurveySource.ValueMember = "SID";
            cboSurveySource.DisplayMember = "SurveyCode";
            cboSurveySource.SelectedItem = null;
            cboSurveySource.SelectedIndexChanged += cboSurveySource_SelectedIndexChanged;

            txtVarLabel.Text = "[Blank]";

            cboDomain.DataSource = Globals.AllDomainLabels;
            cboDomain.ValueMember = "ID";
            cboDomain.DisplayMember = "LabelText";
            cboDomain.SelectedValue = 0;

            cboTopic.DataSource = Globals.AllTopicLabels;
            cboTopic.ValueMember = "ID";
            cboTopic.DisplayMember = "LabelText";
            cboTopic.SelectedValue = 0;

            cboContent.DataSource = Globals.AllContentLabels;
            cboContent.ValueMember = "ID";
            cboContent.DisplayMember = "LabelText";
            cboContent.SelectedValue = 0;

            cboProduct.DataSource = Globals.AllProductLabels;
            cboProduct.ValueMember = "ID";
            cboProduct.DisplayMember = "LabelText";
            cboProduct.SelectedValue = 0;

            optCopy.Checked = true;

            lblDestination.Text = "Adding to " + DestinationSurvey.SurveyCode + " at " + DestinationQnum;
            lblTempPrefix.Text = "Temp Prefix for " + DestinationSurvey.SurveyCode + " is " + tempPrefix;
        }

        #region DataGridView code
        private void dgvRelatedVars_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                VariableName row = (VariableName)dgvRelatedVars.Rows[e.RowIndex].DataBoundItem;

                //if ((!string.IsNullOrEmpty(txtVarLabel.Text)) || (cboDomain.SelectedItem != null) || (cboTopic.SelectedItem != null) || (cboContent.SelectedItem != null) || 
                //    (cboProduct.SelectedItem != null))
                //{
                //    if (MessageBox.Show("This will replace any ") == MessageBoxOptions.No)
                //      return;
                //}
                txtVarLabel.Text = row.VarLabel;
                cboDomain.SelectedValue = row.Domain.ID;
                cboTopic.SelectedValue = row.Topic.ID;
                cboContent.SelectedValue = row.Content.ID;
                cboProduct.SelectedValue = row.Product.ID;
            }
            catch (Exception )
            {

            }
        }

        private void dgvRelatedVars_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvRelatedVars_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn c in dgvRelatedVars.Columns)
            {
                switch (c.Name)
                {
                    case "RefVarName":
                        c.DisplayIndex = 0;
                        break;
                    case "VarLabel":
                        c.DisplayIndex = 1;
                        break;
                    case "Content":
                        c.DisplayIndex = 2;
                        break;
                    case "Topic":
                        c.DisplayIndex = 3;
                        break;
                    case "Domain":
                        c.DisplayIndex = 4;
                        break;
                    case "Product":
                        c.DisplayIndex = 5;
                        break;
                    default:
                        c.Visible = false;
                        break;
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Shows the correct panel depending on which entry mode is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterMode_CheckedChanged(object sender, EventArgs e)
        {
            // copy mode
            if (optCopy.Checked)
            {
                EnterMode = EntryMode.Copy;
                MovePanel(panelCopy);
                panelCopy.Width = copyWidth;
                panelCopy.Height = copyHeight;
            }
            // create mode
            if (optNew.Checked)
            {
                EnterMode = EntryMode.Create;
                MovePanel(panelNew);
                panelNew.Width = newWidth;
                panelNew.Height = newHeight;
            }
            // show/hide panels
            panelNew.Visible = optNew.Checked;
            panelCopy.Visible = optCopy.Checked;
        }

        /// <summary>
        /// Close form without creating any new questions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Close form after creating the required new questions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            
            QuestionsToAdd = CreateQuestions();

            if (QuestionsToAdd == null || QuestionsToAdd.Count ==0)
            {
                if (EnterMode == EntryMode.Copy)
                    MessageBox.Show("Error: No questions selected. Ensure at least one question is selected.");
                else if (EnterMode == EntryMode.Create)
                    MessageBox.Show("Error: Question not created. Ensure VarName is not blank.");

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        #endregion

        #region Copy Events
        /// <summary>
        /// Fill the question source list with items from the selected survey.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSurveySource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSurveySource.SelectedItem == null) return;

            FillList((Survey)cboSurveySource.SelectedItem);
        }

        /// <summary>
        /// On double-click, add the selected item(s) in the source list to the "to copy" list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstQuestionSource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MoveSelected() == 1)
            {
                MessageBox.Show("Some questions could not be added because " + DestinationSurvey.SurveyCode + " already contains them.");
            }
        }

        /// <summary>
        /// On right-click, remove the selected item(s) from the "to copy" list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstToCopy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RemoveSelected();
            }
        }

        /// <summary>
        /// Add the selected item(s) in the source list to the "to copy" list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (MoveSelected() == 1)
            {
                MessageBox.Show("Some questions could not be added because " + DestinationSurvey.SurveyCode + " already contains them.");
            }
        }

        /// <summary>
        /// Remove the selected item(s) from the "to copy" list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }
        #endregion

        #region Create New Events

        /// <summary>
        /// Update the related list when the filter text changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            UpdateRelatedQuestions(txtFilter.Text);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get a list of VarNames that begin with the provided filter.
        /// </summary>
        /// <param name="filter">Filter pattern.</param>
        private void UpdateRelatedQuestions(string filter)
        {
            string newVar = txtFilter.Text;

            if (string.IsNullOrEmpty(filter))
                RelatedQuestions.Clear();
            else
                RelatedQuestions = Globals.AllVarNames.Where(x => x.RefVarName.StartsWith(filter)).ToList();

            dgvRelatedVars.DataSource = RelatedQuestions;            
        }

        /// <summary>
        /// Moves the provided panel into position.
        /// </summary>
        /// <param name="p"></param>
        private void MovePanel(Panel p)
        {
            int left = 35;
            int top = 75;

            p.Left = left;
            p.Top = top;

            p.Visible = true;
        }

        /// <summary>
        /// Filles the Question Source list with question items from the provided survey.
        /// </summary>
        /// <param name="s"></param>
        private void FillList(Survey s)
        {
            if (s == null) return;

            List<QuestionRecord> questions = DBAction.GetSurveyQuestionRecords(s).ToList();

            lstQuestionSource.Items.Clear();
            lstQuestionSource.View = View.Details;

            foreach (QuestionRecord sq in questions)
            {
                string corr;
                if (sq.CorrectedFlag)
                    corr = "Yes";
                else
                    corr = "No";

                ListViewItem li = new ListViewItem(new string[] { sq.Qnum, sq.VarName.VarName, sq.VarName.VarLabel, sq.RespName, corr });
                li.Tag = sq;
                lstQuestionSource.Items.Add(li);
                FormUtilities.FormatListItem(li, Utilities.GetQuestionType(sq));
            }
        }

        /// <summary>
        /// Copies selected items from the source list to the "to copy" list if they are not already present.
        /// </summary>
        private int MoveSelected()
        {
            var items = lstQuestionSource.SelectedItems;
            int skipped = 0; 
            foreach (ListViewItem i in items)
            {
                if (!lstToCopy.Items.Contains(i) && !DestinationSurvey.Questions.Contains((SurveyQuestion)i.Tag, new SurveyQuestionComparer()))
                    lstToCopy.Items.Add((ListViewItem)i.Clone());
                else
                    skipped = 1;
            }

            return skipped;
        }

        /// <summary>
        /// Removes selected items from the "to copy" list.
        /// </summary>
        private void RemoveSelected()
        {
            var items = lstToCopy.SelectedItems;

            foreach (ListViewItem i in items)
                lstToCopy.Items.Remove(i);
        }

        /// <summary>
        /// Creates a list of survey questions intended for the DestinationSurvey.
        /// </summary>
        /// <returns></returns>
        private List<QuestionRecord> CreateQuestions()
        {
            // for each item in the ToCopy list, 
            // create a VariableName that is to be created.
            // then check if it already exists,
            // if not, create it
            List<QuestionRecord> QuestionsToAdd = new List<QuestionRecord>();
            if (EnterMode == EntryMode.Copy)
            {
                int count = 1;
                foreach (ListViewItem i in lstToCopy.Items)
                {
                    QuestionRecord q = (QuestionRecord)i.Tag;
                    q.SurveyCode = DestinationSurvey.SurveyCode;
                    q.NewRecord = true;
                    string newVarCC = Utilities.ChangeCC(q.VarName.VarName, DestinationSurvey.CountryCode);
                    q.VarName.VarName = newVarCC;
                    q.VarName.RefVarName = Utilities.ChangeCC(newVarCC);
                    q.Qnum = DestinationQnum + new String('z', count);

                    // add to list of questions to create
                    QuestionsToAdd.Add(q);
                    count++;
                }
            }
            else
            {
                QuestionRecord q = GetEnteredQuestion();

                if (q != null)
                {
                    q.NewRecord = true;
                    q.Qnum = DestinationQnum + 'z';
                    QuestionsToAdd.Add(q);
                }
            }

            return QuestionsToAdd;
        }

        /// <summary>
        /// Returns a SurveyQuestion with the name and labels entered on the form.
        /// </summary>
        /// <returns>A new SurveyQuestion</returns>
        private QuestionRecord GetEnteredQuestion()
        {
            if (string.IsNullOrEmpty(txtNewVarName.Text))
                return null;

            QuestionRecord newQ = new QuestionRecord();
            newQ.SurveyCode = DestinationSurvey.SurveyCode;
            newQ.VarName.VarName = Utilities.ChangeCC(txtNewVarName.Text, DestinationSurvey.CountryCode);
            newQ.VarName.RefVarName = Utilities.ChangeCC(txtNewVarName.Text);
            if (string.IsNullOrEmpty(txtVarLabel.Text))
                newQ.VarName.VarLabel = "[blank]";
            else
                newQ.VarName.VarLabel = txtVarLabel.Text;
            newQ.VarName.Content = (ContentLabel)cboContent.SelectedItem;
            newQ.VarName.Topic = (TopicLabel)cboTopic.SelectedItem;
            newQ.VarName.Domain = (DomainLabel)cboDomain.SelectedItem;
            newQ.VarName.Product = (ProductLabel)cboProduct.SelectedItem;

            return newQ;
        }
        #endregion

    }
}