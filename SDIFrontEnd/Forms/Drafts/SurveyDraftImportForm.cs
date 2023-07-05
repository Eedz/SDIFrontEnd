using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using ITCLib;

using OpenXMLHelper;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;

namespace SDIFrontEnd
{
    // TODO set column numbers after Import is clicked, not on combo box event
    // TODO more general tag removal
    // TODO remove from combobox after item is selected, preventing column from being used twice
    public partial class SurveyDraftImportForm : Form
    {
        #region Properties
        int QnumColumn;
        int VarNameColumn;
        int AltQnumColumn;
        int QuestionTextColumn;
        int CommentsColumn;
        int Extra1Column;
        int Extra2Column;
        int Extra3Column;
        int Extra4Column;
        int Extra5Column;
        int MarginCommentsColumn;

        List<string> Headers;
        List<string> columns = new List<string>() { "Qnum", "AltQnum", "VarName", "Question Text", "Comments", "Extra1", "Extra2", "Extra3", "Extra4", "Extra5" };
        SurveyDraftRecord newDraft; // the new draft to be created
        bool errorsExist;
        #endregion


        public SurveyDraftImportForm()
        {
            InitializeComponent();

            QnumColumn = -1;
            VarNameColumn = -1;
            QuestionTextColumn = -1;
            CommentsColumn = -1;
            Extra1Column = -1;
            Extra2Column = -1;
            Extra3Column = -1;
            Extra4Column = -1;
            Extra5Column = -1;
            MarginCommentsColumn = -1;

            cboSurvey.ValueMember = "SID";
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);

            newDraft = new SurveyDraftRecord();

            cboSurvey.DataBindings.Add("SelectedValue", newDraft, "SurvID");
            txtDraftTitle.DataBindings.Add("Text", newDraft, "DraftTitle");
            dtDraftDate.DataBindings.Add("Value", newDraft, "DraftDate", true);
            txtDraftComment.DataBindings.Add("Text", newDraft, "DraftComments");
        }

        #region Event Handlers
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            cboSurvey.SelectedIndex = -1;
            txtDraftTitle.Text = "";
            txtDraftComment.Text = "";
            dtDraftDate.Value = DateTime.Today;
            txtFileName.Text = "";

            pnlColumns.Visible = false;
            cmdImport.Enabled = false;

            newDraft = new SurveyDraftRecord();
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            
            ImportDraft();
        }

        /// <summary>
        /// Open a Select File dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>If the user selects a file, check it for required components.</remarks>
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            DialogResult result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFileName.Text = fd.FileName;

                CheckDocument(fd.FileName);

                if (!errorsExist)
                    DisplayHeaders();
            }
            else
            {
                txtFileName.Text = "";
            }
        }

        /// <summary>
        /// Set the column to the tag of the sending object whenever that object's selected item changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DestCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int tag = (int)cb.Tag;
            if (cb.SelectedItem == null)
                return;

            switch (cb.SelectedItem.ToString())
            {
                case "Qnum":
                    QnumColumn = tag;
                    break;
                case "AltQnum":
                    AltQnumColumn = tag;
                    break;
                case "VarName":
                    VarNameColumn = tag;
                    break;
                case "Question Text":
                    QuestionTextColumn = tag;
                    break;
                case "Comments":
                    CommentsColumn = tag;
                    break;
                case "Extra1":
                    Extra1Column = tag;
                    break;
                case "Extra2":
                    Extra2Column = tag;
                    break;
                case "Extra3":
                    Extra3Column = tag;
                    break;
                case "Extra4":
                    Extra4Column = tag;
                    break;
                case "Extra5":
                    Extra5Column = tag;
                    break;
            }

            tag++;

            if (pnlColumns.Controls["txtSource" + tag.ToString()].Text == "MarginComments")
            {
                MarginCommentsColumn = tag-1;
            }
        }
        #endregion

        #region Methods
        // check file for 
        // locked
        // at least one table
        // varname column present
        // 
        private void CheckDocument(string fileName)
        {
            string errors = "";
            try
            {
                using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(fileName, false))
                {
                    Body body = wdDoc.MainDocumentPart.Document.Body;

                    int tableCount = body.Descendants<Table>().Count();

                    if (tableCount == 0)
                        errors += "The document needs to contain at least one table.\r\n";

                    GetHeaders(body);

                    if (VarNameColumn == -1)
                        errors += "VarName column not found.\r\n";

                }
            } catch (Exception)
            {
                errors += "Error opening the file.";
            }

            if (!string.IsNullOrEmpty(errors))
            {
                errorsExist = true;
                MessageBox.Show("Errors found in document:\r\n" + errors);
            }
            else
            {
                errorsExist = false;
            }

            cmdImport.Enabled = !errorsExist;
        }

        /// <summary>
        /// Returns true if the minimum required fields have been entered.
        /// </summary>
        /// <returns></returns>
        private bool CheckSurveyDraft()
        {
            if (newDraft.SurvID == 0)
            {
                MessageBox.Show("Choose a survey.");
                return false;
            }

            if (newDraft.DraftTitle == "")
            {
                MessageBox.Show("Enter a draft title.");
                return false;
            }

            if (newDraft.DraftDate == null)
            {
                MessageBox.Show("Enter a draft date.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Attempt to create survey draft record and set the draft object DraftID field.
        /// </summary>
        private void CreateDraftInfo()
        {
            newDraft.Questions = new List<DraftQuestion>();

            int newID = DBAction.InsertSurveyDraft(newDraft);

            if (newID == -1)
            {
                MessageBox.Show("Error creating draft. Unable to import.");
                return;
            }
            else
            {
                newDraft.ID = newID;
            }
        }

        /// <summary>
        /// Inserts a record for each extra field that was set to a source column.
        /// </summary>
        private void SetExtraFieldInfo()
        {
            if (newDraft.ID == 0)
                return;
            int sourceNumber;
            if (Extra1Column >= 0)
            {
                sourceNumber = Extra1Column+1;
                DBAction.InsertSurveyDraftExtraInfo(newDraft.ID, 1, pnlColumns.Controls["txtSource" + sourceNumber].Text);
            }

            if (Extra2Column >= 0)
            {
                sourceNumber = Extra2Column + 1;
                DBAction.InsertSurveyDraftExtraInfo(newDraft.ID, 2, pnlColumns.Controls["txtSource" + sourceNumber].Text);
            }

            if (Extra3Column >= 0)
            {
                sourceNumber = Extra3Column + 1;
                DBAction.InsertSurveyDraftExtraInfo(newDraft.ID, 3, pnlColumns.Controls["txtSource" + sourceNumber].Text);
            }

            if (Extra4Column >= 0)
            {
                sourceNumber = Extra3Column + 1;
                DBAction.InsertSurveyDraftExtraInfo(newDraft.ID, 4, pnlColumns.Controls["txtSource" + sourceNumber].Text);
            }

            if (Extra5Column >= 0)
            {
                sourceNumber = Extra2Column + 1;
                DBAction.InsertSurveyDraftExtraInfo(newDraft.ID, 5, pnlColumns.Controls["txtSource" + sourceNumber].Text);
            }
        }

        private void ImportDraft() { 

            if (!CheckSurveyDraft())
                return;

            CreateDraftInfo();
            
            if (newDraft.ID == 0)
                return;

            SetExtraFieldInfo();

            string fileName = txtFileName.Text;

            if (string.IsNullOrEmpty(fileName)) {
                MessageBox.Show("Choose a file to import.");
                return;
            }

            using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(fileName, false))
            {

                Body body = wdDoc.MainDocumentPart.Document.Body;

                WordprocessingCommentsPart commentsPart = wdDoc.MainDocumentPart.WordprocessingCommentsPart;
                Comments commentPart= null;
                if (commentsPart != null )
                    commentPart = wdDoc.MainDocumentPart.WordprocessingCommentsPart.Comments;

                Table table = body.Elements<Table>().ElementAt(0);

                XMLUtilities.TagBold(body);
                XMLUtilities.TagRevisions(body);
                XMLUtilities.TagItalics(body);
                XMLUtilities.TagHighlighting(body);

                var tables = body.Elements<Table>();
                float rowNum = 0;
                foreach (Table t in tables)
                {
                    var rows = t.Elements<TableRow>();

                    bool firstRow = true;

                    foreach (TableRow row in rows)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }

                        DraftQuestionRecord dq = new DraftQuestionRecord();

                        dq.DraftID = newDraft.ID;

                        var cells = row.Elements<TableCell>();

                        // check for deleted/inserted row
                        // if the row properties have a deleted tag, set deleted = true
                        // if the row properties have an inserted tag, set deleted = false
                        TableRowProperties trPr = row.Elements<TableRowProperties>().FirstOrDefault();
                        if (trPr == null)
                        {

                        }
                        else if (trPr.Descendants<Deleted>().Count() != 0)
                        {
                            var dels = trPr.Descendants<Deleted>();
                            dq.Deleted = true;
                        }
                        else if (trPr.Descendants<Inserted>().Count() != 0)
                        {
                            dq.Inserted = true;
                        }
                        dq.SortBy = rowNum;

                        if (QnumColumn >= 0)
                        {
                            if (QnumColumn == MarginCommentsColumn)
                            {
                                dq.Qnum = GetMarginComments(commentPart, row, QnumColumn);
                            }else 
                                dq.Qnum = GetContentFromCell(cells, QnumColumn, false);
                        }

                        if (VarNameColumn >= 0)
                        {
                            if (VarNameColumn == MarginCommentsColumn)
                            {
                                dq.VarName = GetMarginComments(commentPart, row, VarNameColumn);
                            }
                            else
                            {
                                dq.VarName = GetContentFromCell(cells, VarNameColumn, false);
                                dq.VarName = Regex.Replace(dq.VarName, "<font style=\"BACKGROUND-COLOR:#[0-9A-F]{6}\">", "");
                                dq.VarName = Regex.Replace(dq.VarName, "</font>", "");
                            }
                        }

                        if (QuestionTextColumn >= 0)
                        {
                            if (QuestionTextColumn == MarginCommentsColumn)
                            {
                                dq.QuestionText = GetMarginComments(commentPart, row, QuestionTextColumn);
                            }
                            else
                                dq.QuestionText = GetContentFromCell(cells, QuestionTextColumn, true);
                        }

                        if (CommentsColumn >= 0)
                        {
                            if (CommentsColumn == MarginCommentsColumn)
                            {
                                dq.Comments = GetMarginComments(commentPart, row, CommentsColumn);
                            }
                            else
                                dq.Comments = GetContentFromCell(cells, CommentsColumn, true);
                        }

                        if (Extra1Column >= 0)
                        {
                            if (Extra1Column == MarginCommentsColumn)
                            {
                                dq.Extra1 = GetMarginComments(commentPart, row, Extra1Column);
                            }
                            else
                                dq.Extra1 = GetContentFromCell(cells, Extra1Column, true);
                        }

                        if (Extra2Column >= 0)
                        {
                            if (Extra2Column == MarginCommentsColumn)
                            {
                                dq.Extra2 = GetMarginComments(commentPart, row, Extra2Column);
                            }
                            else
                                dq.Extra2 = GetContentFromCell(cells, Extra2Column, true);
                        }

                        if (Extra3Column >= 0)
                        {
                            if (Extra3Column == MarginCommentsColumn)
                            {
                                dq.Extra3 = GetMarginComments(commentPart, row, Extra3Column);
                            }
                            else
                                dq.Extra3 = GetContentFromCell(cells, Extra3Column, true);
                        }

                        if (Extra4Column >= 0)
                        {
                            if (Extra4Column == MarginCommentsColumn)
                            {
                                dq.Extra4 = GetMarginComments(commentPart, row, Extra4Column);
                            }
                            else
                                dq.Extra4 = GetContentFromCell(cells, Extra4Column, true);
                        }

                        if (Extra5Column >= 0)
                        {
                            if (Extra5Column == MarginCommentsColumn)
                            {
                                dq.Extra5 = GetMarginComments(commentPart, row, Extra5Column);
                            }
                            else
                                dq.Extra5 = GetContentFromCell(cells, Extra5Column, true);
                        }

                        newDraft.Questions.Add(dq);
                        rowNum++;
                    }
                }
            }

            // once the rows are converted to survey draft question objects

            // if the row has no qnum, fill them with suffixed version of previous rows
            ProcessEmptyQnums();
            // if the row has no varname, fill it with the next generic varname
            ProcessEmptyVarNames();
            // check for duplicate varnames
            ProcessDuplicateVarNames();
            
            // insert each question into the database 
            foreach (DraftQuestionRecord q in newDraft.Questions)
            {
                DBAction.InsertDraftQuestion(q);
            }

            newDraft.Questions.Clear();

            MessageBox.Show("Done!");
        }

        private string GetMarginComments (Comments commentPart, TableRow row, int index)
        {
           
            string text = "";

            var commentRefs= row.Descendants<CommentReference>();

            

            foreach (CommentReference cRef in commentRefs)
            {
                var comments = commentPart.Elements<DocumentFormat.OpenXml.Wordprocessing.Comment>().Where(x => x.Id == cRef.Id);

                foreach (DocumentFormat.OpenXml.Wordprocessing.Comment c in comments)
                {
                    DateTime d = c.Date;
                    text += c.Author + " on " + d.ToString("dd MMM yyyy HH:mm:ss") + "<br>" + c.InnerText + "<br>";
                }
            }

            text = Utilities.TrimString(text, "<br>");

            return text;
        }

        /// <summary>
        /// Returns the text contents from the specified cell in a group of cells. If a cell doesn't exist at that index, an empty string is returned.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetContentFromCell (IEnumerable<TableCell> cells, int index, bool richText)
        {
            string text;
            try
            {
                text = cells.ElementAt(index).GetCellText();
                if (richText)
                    text = text.Replace("\r\n", "<br>");
            }
            catch (Exception)
            {
                text = "";
            }

            if (!richText)
                text = RemoveTags(text);

            return text;
        }

        // TODO highlighting (general tag removal)
        private string RemoveTags(string input)
        {
            string text = input;
            text = text.Replace("<Font Color=Red>", "");
            text = text.Replace("<Font Color=Blue>", "");
            text = text.Replace("</Font>", "");
            text = text.Replace("<strong>", "").Replace("</strong>", "");
            text = text.Replace("<em>", "").Replace("</em>", "");
            text = text.Replace("<u>", "").Replace("</u>", "");
            return text;

        }

        private void ProcessDuplicateVarNames()
        {
            string extra = "";
            char letter ='a';
            foreach (DraftQuestion q in newDraft.Questions)
            {
                List<DraftQuestion> list = newDraft.Questions.Where(x => x.VarName == q.VarName).ToList();

                if (list.Count() > 1)
                {
                    for (int i = 1; i < list.Count(); i++)
                    {

                        list[i].VarName += "-" + extra + letter;

                        if (letter == 'z')
                        {
                            letter = 'a';
                            if (extra == "")
                                extra += "a";
                            else if (extra.Length == 1)
                            {
                                char current = extra[0];
                                current++;
                                extra = current.ToString();
                            }else
                            {
                                char current = extra[extra.Length];
                                current++;
                                extra = extra[extra.Length - 1] + current.ToString();
                            }
                        }
                        else
                            letter++;

                    }
                }
                letter = 'a';
                extra = "";
            }
        }

        private void ProcessEmptyQnums()
        {
            char letter = 'a';
            string extra = "";
            // set the previous value to be the first question's qnum, and fill it in if it is blank
            string prev = newDraft.Questions[0].Qnum;
            if (string.IsNullOrEmpty(prev))
                newDraft.Questions[0].Qnum = "000";

            foreach (DraftQuestion q in newDraft.Questions)
            {
                if (string.IsNullOrEmpty(q.Qnum))
                {
                    q.Qnum = prev + "-" + extra + letter;

                    if (letter == 'z')
                    {
                        letter = 'a';
                        if (extra == "")
                            extra += "a";
                        else if (extra.Length == 1)
                        {
                            char current = extra[0];
                            current++;
                            extra = current.ToString();
                        }
                        else
                        {
                            char current = extra[extra.Length];
                            current++;
                            extra = extra[extra.Length - 1] + current.ToString();
                        }
                    }
                    else
                        letter++;

                }
                else
                {
                    prev = q.Qnum;
                    letter = 'a';
                    extra = "";
                }
                
                
            }
        }

        private void ProcessEmptyVarNames()
        {
            string nextVar = "N_000";

            foreach (DraftQuestion q in newDraft.Questions)
            {
                if (string.IsNullOrEmpty(q.VarName))
                {
                    q.VarName = nextVar;
                    int num = Int32.Parse(nextVar.Substring(2, 3)) + 1;
                    if (num > 999)
                    {
                        nextVar = "N_" + num;
                    }
                    else
                    {
                        nextVar = "N_" + num.ToString("D3");
                    }
                }
            }
        }

        /// <summary>
        /// List each heading in the document and give the user the ability to assign it to one of the survey draft object's fields
        /// </summary>
        private void DisplayHeaders()
        {
            pnlColumns.Controls.Clear();

            if (Headers.Count == 0)
            {
                pnlColumns.Visible = false;
                return;
            }

            pnlColumns.Visible = true;

            int c = 1;
            
            foreach (string s in Headers)
            {
                Label docColHeader = new Label();
                docColHeader.Text = "Document Columns";
                docColHeader.Top = 0;
                docColHeader.Left = 10;

                Label targetColHeader = new Label();
                targetColHeader.Text = "Target Columns";
                targetColHeader.Top = 0;
                targetColHeader.Left = 160;

                TextBox sourceCol = new TextBox();
                sourceCol.Name = "txtSource" + c;
                sourceCol.Left = 10;
                sourceCol.Top = 30 * c;
                sourceCol.Text = s;
                sourceCol.Width = 100;

                ComboBox destCol = new ComboBox();
                destCol.Name = "cboTarget" + c;
                destCol.Left = 160;
                destCol.Top = 30 * c;
                destCol.Width = 100;
                destCol.DataSource = columns.ToArray();
                destCol.Tag = c-1;
                destCol.SelectedIndexChanged += DestCol_SelectedIndexChanged;

                pnlColumns.Controls.Add(docColHeader);
                pnlColumns.Controls.Add(targetColHeader);
                pnlColumns.Controls.Add(sourceCol);
                pnlColumns.Controls.Add(destCol);

                if (columns.Contains(s))
                    destCol.SelectedIndex = columns.IndexOf(s); 
                else
                   destCol.SelectedIndex = -1;

                c++;
            }

            

        }

       
        /// <summary>
        /// Populate the Header list with values found in the header cells.
        /// </summary>
        /// <param name="headerCells"></param>
        private void GetHeaders(Body body)
        {
            

            var rows = body.Descendants<TableRow>();

            List<TableCell> headerCells = rows.ElementAt(0).Elements<TableCell>().ToList<TableCell>();
            Headers = new List<string>();

            QnumColumn = -1;
            VarNameColumn = -1;
            QuestionTextColumn = -1;
            CommentsColumn = -1;
            Extra1Column = -1;
            Extra2Column = -1;
            Extra3Column = -1;
            Extra4Column = -1;
            Extra5Column = -1;
            MarginCommentsColumn = -1;

            for (int i = 0; i <headerCells.Count(); i ++)
            {
                string cellText = headerCells.ElementAt(i).GetCellText();

                switch (cellText)
                {
                    case "Q":
                    case "Qnum":
                    case "Q#":
                        QnumColumn = i;
                        Headers.Add(cellText);
                        break;
                    case "VarName":
                        VarNameColumn = i;
                        Headers.Add(cellText);
                        break;
                    default:
                        Headers.Add(cellText);
                        break;
                }
            }
            if (body.Descendants<CommentReference>().Count() > 0)
            {
                Headers.Add("MarginComments");
            }


        }

        // TODO convert the list number to plain text and add it to the text element
        private void ConvertLists(Body body)
        {
            // paragraphs with numbering
            var paragraphs = body.Descendants<Paragraph>().Where (x=>x.Descendants<NumberingProperties>().Count()>0);

            foreach (Paragraph p in paragraphs)
            {
                
            }
        }

        #endregion

        
    }
}
