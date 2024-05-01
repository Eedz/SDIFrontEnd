using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using OpenXMLHelper;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using XMLSheet = DocumentFormat.OpenXml.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

using ITCLib;


namespace SDIFrontEnd
{
    public partial class PraccingSheet : Form
    {
        public bool IncludeLegend { get; set; }

        public PraccingSheet()
        {
            InitializeComponent();

            dgvHighlightingRanges.AllowUserToAddRows = true;
            dgvHighlightingRanges.Rows.Add();
            dgvHighlightingRanges.Rows.Add();
            dgvHighlightingRanges.Rows.Add();

            dgvHighlightingRanges.Rows[0].Cells[2].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#833C0B");
            dgvHighlightingRanges.Rows[0].Cells[2].Style.ForeColor = System.Drawing.Color.White;
            dgvHighlightingRanges.Rows[0].Cells[3].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4B083");
            dgvHighlightingRanges.Rows[0].Cells[4].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FBE4D5");

            dgvHighlightingRanges.Rows[1].Cells[2].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F4E79");
            dgvHighlightingRanges.Rows[1].Cells[2].Style.ForeColor = System.Drawing.Color.White;
            dgvHighlightingRanges.Rows[1].Cells[3].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#9CC2E5");
            dgvHighlightingRanges.Rows[1].Cells[4].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#DEEAF6");

            dgvHighlightingRanges.Rows[2].Cells[2].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#385623");
            dgvHighlightingRanges.Rows[2].Cells[2].Style.ForeColor = System.Drawing.Color.White;
            dgvHighlightingRanges.Rows[2].Cells[3].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#A8D08D");
            dgvHighlightingRanges.Rows[2].Cells[4].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#E2EFD9");
            dgvHighlightingRanges.AllowUserToAddRows = false;

            FillLists();
        }

        #region Form Setup
        private void FillLists()
        {
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
        }
        #endregion

        #region Methods
        

        private void CreatePraccingSheetWRD(Survey survey)
        {
            List<LinkedQuestion> questionList = new List<LinkedQuestion>();

            foreach (SurveyQuestion sq in DBAction.GetSurveyQuestions(survey))
            {
                questionList.Add(new LinkedQuestion(sq));
            }

            PopulateFilters(questionList);
            

            int num_ids = 10;
            string filePath = @"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports\Praccing\" + survey.SurveyCode + " Praccing Sheet - " + DateTime.Now.DateTimeForFile() + ".docx";
            string templateFile = @"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports\Templates\SMGLandLet.dotx";

            Word.Application appWord;
            appWord = new Word.Application();
            appWord.Visible = false;
            Word.Document doc = appWord.Documents.Add(templateFile);
            doc.SaveAs2(filePath);
            doc.Close();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                Body body = new Body();
                wordDoc.MainDocumentPart.Document.Append(body);

                body.Append(XMLUtilities.NewParagraph(survey.SurveyCode + " Praccing Sheet", JustificationValues.Center, "32", "Verdana"));
                body.Append(XMLUtilities.NewParagraph("", JustificationValues.Center, "32", "Verdana"));

                if (IncludeLegend)
                    CreateLegend(body);

                Table table = XMLUtilities.NewTable(12);

                XMLUtilities.SetColumnWidths(table, new double[] { 0.92, 0.92, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7 });

                TableRow header = XMLUtilities.CreateHeaderRow(new string[] { "Qnum", "VarName", "", "", "", "", "", "", "", "", "", "" });

                IEnumerable<TableCell> cells = header.Elements<TableCell>();

                foreach (TableCell c in cells)
                {
                    RunProperties rPr = c.Descendants<RunProperties>().First();
                    rPr.Append(new RunFonts() { Ascii = "Verdana" });
                    rPr.Append(new FontSize() { Val = "20" });

                }

                table.Append(header);

                foreach (LinkedQuestion q in questionList)
                {
                    TableRow row = new TableRow();

                    TableCell qnum = new TableCell();

                    ParagraphProperties pPr = new ParagraphProperties(new SpacingBetweenLines() { Before = "0", After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto, AfterAutoSpacing = false, BeforeAutoSpacing = false });
                    qnum.Append(new Paragraph(pPr, new Run(new Text(q.Qnum))));
                    row.Append(qnum);

                    TableCell varname = new TableCell();
                    ParagraphProperties pPr2 = new ParagraphProperties(new SpacingBetweenLines() { Before = "0", After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto, AfterAutoSpacing = false, BeforeAutoSpacing = false });
                    varname.Append(new Paragraph(pPr2, new Run(new Text(q.VarName.VarName))));
                    row.Append(varname);

                    for (int c = 0; c < num_ids; c++)
                    {
                        TableCell cell = new TableCell();
                        ParagraphProperties pPr3 = new ParagraphProperties(new SpacingBetweenLines() { Before = "0", After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto, AfterAutoSpacing = false, BeforeAutoSpacing = false });

                        row.Append(new TableCell(new Paragraph(pPr3, new Run(new Text()))));
                    }

                    //if (!string.IsNullOrEmpty(q.PreP))
                    if (IncludeLegend && !string.IsNullOrEmpty(q.PrePW.WordingText))
                        ShadeCells(row, q);

                    table.Append(row);
                }

                foreach (TableCell cell in table.Descendants<TableCell>())
                {
                    cell.Append(new TableCellProperties(XMLUtilities.BlackSingleCellBorder()));
                }

                body.Append(table);
            }

            try
            {
                doc = appWord.Documents.Open(filePath);

                // footer text                  
                foreach (Word.Section s in doc.Sections)
                    s.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InsertAfter("\t" + survey.SurveyCode + " Praccing Sheet" +
                        "\t\t" + "Generated on " + DateTime.Today.ShortDateDash());

                doc.Save();

                appWord.Visible = true;
            }
            catch (Exception)
            {
                appWord.Quit();
            }
        }

        /// <summary>
        /// For each question, get any VarNames appearing in the PreP and then get a reference to that question in the master list and
        /// add this reference to the list of filter questions.
        /// </summary>
        public void PopulateFilters(List<LinkedQuestion> Questions)
        {
            foreach (LinkedQuestion q in Questions)
            {
                string prep = "";
                if (q.PrePW.WordingText.Contains("."))
                    prep = q.PrePW.WordingText.Substring(0, q.PrePW.WordingText.IndexOf("."));
                else
                    prep = q.PrePW.WordingText;

                // get the list of filter instructions for this question (both standard and non-standard VarNames)
                var filters = q.GetFilterInstructions();
               
                // move on if there are no filters
                if (filters.Count == 0)
                    continue;

                foreach (FilterInstruction fi in filters)
                {
                    if (fi.VarName.Equals(q.VarName.RefVarName))
                        continue;

                    // add the SurveyQuestion represented by this filter instruction to the list of FilteredOn questions
                    LinkedQuestion filterVar = Questions.Find(x => x.VarName.RefVarName.Equals(fi.VarName));
                    if (filterVar != null && filterVar.GetQnumValue() <= q.GetQnumValue())
                    {
                        q.FilteredOn.Add(filterVar);
                    }
                }
            }
        }

        

        private LegendEntry GetRow(int index)
        {
            LegendEntry entry = new LegendEntry();

            if (index > dgvHighlightingRanges.Rows.Count)
                return entry;

            var row = dgvHighlightingRanges.Rows[index-1];

            entry.label = row.Cells[0].Value.ToString();
            entry.varname = row.Cells[1].Value.ToString();
            entry.range1 = row.Cells[2].Value.ToString();
            entry.range2 = row.Cells[3].Value.ToString();
            entry.range3 = row.Cells[4].Value.ToString();

            return entry;
        }

        private void CreateLegend(Body body)
        {
            Table legendTable = XMLUtilities.NewTable(4, TableLayoutValues.Autofit);

            // first row of data
            LegendEntry row1Info = GetRow(1);

            TableRow row1 = new TableRow();
            //TableCell cell1 = new TableCell(new Paragraph(new Run(new Text("Cigarettes"))));
            TableCell cell1 = new TableCell(new Paragraph(new Run(new Text(row1Info.label))));
            //TableCell cell2 = new TableCell(new Paragraph(new Run(new Text("FR309v=1-3"))));
            TableCell cell2 = new TableCell(new Paragraph(new Run(new Text(row1Info.GetRange(1)))));
            XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "833C0B" });
            //TableCell cell3 = new TableCell(new Paragraph(new Run(new Text("FR309v=1-5"))));
            TableCell cell3 = new TableCell(new Paragraph(new Run(new Text(row1Info.GetRange(2)))));
            XMLUtilities.ShadeCell(cell3, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "F4B083" });
            //TableCell cell4 = new TableCell(new Paragraph(new Run(new Text("FR309v=1-7"))));
            TableCell cell4 = new TableCell(new Paragraph(new Run(new Text(row1Info.GetRange(3)))));
            XMLUtilities.ShadeCell(cell4, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FBE4D5" });

            row1.Append(cell1);
            row1.Append(cell2);
            row1.Append(cell3);
            row1.Append(cell4);

            legendTable.Append(row1);

            // second row of data
            LegendEntry row2Info = GetRow(2);

            TableRow row2 = new TableRow();
            //TableCell cell5 = new TableCell(new Paragraph(new Run(new Text("E-cigarettes"))));
            TableCell cell5 = new TableCell(new Paragraph(new Run(new Text(row2Info.label))));
            //TableCell cell6 = new TableCell(new Paragraph(new Run(new Text("EC309v=1-3"))));
            TableCell cell6 = new TableCell(new Paragraph(new Run(new Text(row2Info.GetRange(1)))));
            XMLUtilities.ShadeCell(cell6, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "1F4E79" });
            //TableCell cell7 = new TableCell(new Paragraph(new Run(new Text("EC309v=1-5 (NC302=1)"))));
            TableCell cell7 = new TableCell(new Paragraph(new Run(new Text(row2Info.GetRange(2)))));
            XMLUtilities.ShadeCell(cell7, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "9CC2E5" });
            //TableCell cell8 = new TableCell(new Paragraph(new Run(new Text("EC309v=1-6 (NC302=1 or 2)"))));
            TableCell cell8 = new TableCell(new Paragraph(new Run(new Text(row2Info.GetRange(3)))));
            XMLUtilities.ShadeCell(cell8, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "DEEAF6" });

            row2.Append(cell5);
            row2.Append(cell6);
            row2.Append(cell7);
            row2.Append(cell8);

            legendTable.Append(row2);

            // third row of data
            LegendEntry row3Info = GetRow(3);

            TableRow row3 = new TableRow();
            //TableCell cell9 = new TableCell(new Paragraph(new Run(new Text("HTPs"))));
            TableCell cell9 = new TableCell(new Paragraph(new Run(new Text(row3Info.label))));
            //TableCell cell10 = new TableCell(new Paragraph(new Run(new Text("HN309v=10-32"))));
            TableCell cell10 = new TableCell(new Paragraph(new Run(new Text(row3Info.GetRange(1)))));
            XMLUtilities.ShadeCell(cell10, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "385623" });
            //TableCell cell11 = new TableCell(new Paragraph(new Run(new Text("HN309v=10-60 (HN106=1)"))));
            TableCell cell11 = new TableCell(new Paragraph(new Run(new Text(row3Info.GetRange(2)))));
            XMLUtilities.ShadeCell(cell11, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "A8D08D" });
            //TableCell cell12 = new TableCell(new Paragraph(new Run(new Text("HN309v=31-70"))));
            TableCell cell12 = new TableCell(new Paragraph(new Run(new Text(row3Info.GetRange(3)))));
            XMLUtilities.ShadeCell(cell12, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "E2EFD9" });

            row3.Append(cell9);
            row3.Append(cell10);
            row3.Append(cell11);
            row3.Append(cell12);

            legendTable.Append(row3);

            body.Append(legendTable);
            body.Append(XMLUtilities.NewParagraph(string.Empty, JustificationValues.Center));
        }

        private bool IsFilteredOn (LinkedQuestion question, string varname, IEnumerable<int> values)
        {
            var filters = question.GetFilterInstructions();

            if (filters.Any(x => x.VarName.Equals(varname) && !x.Values.Except(values).Any()))
                return true;

            if (question.FilteredOn.Any(x => IsFilteredOn(x, varname, values)))
                return true;
            
            return false;
        }

        private void ShadeCells(TableRow row, LinkedQuestion question)
        {
            TableCell cell1 = row.Elements<TableCell>().First();
            TableCell cell2 = row.Elements<TableCell>().Skip(1).First();
            TableCell cell3 = row.Elements<TableCell>().Skip(2).First();

            LegendEntry entry1 = GetRow(1);
            LegendEntry entry2 = GetRow(2);
            LegendEntry entry3 = GetRow(3);

            // first product
            if (IsFilteredOn(question, entry1.varname, entry1.GetRangeNumbers(1)))
            {
                XMLUtilities.ShadeCell(cell1, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "833C0B" });
            }
            else if (IsFilteredOn(question, entry1.varname, entry1.GetRangeNumbers(2).ToList()))
            {
                XMLUtilities.ShadeCell(cell1, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "F4B083" });
            }
            else if (IsFilteredOn(question, entry1.varname, entry1.GetRangeNumbers(3).ToList()))
            {
                XMLUtilities.ShadeCell(cell1, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FBE4D5" });
            }

            // second product
            if (IsFilteredOn(question, entry2.varname, entry2.GetRangeNumbers(1)))
            {
                XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "1F4E79" });
            }
            else if (IsFilteredOn(question, entry2.varname, entry2.GetRangeNumbers(2)))
            {
                XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "9CC2E5" });
            }
            else if (IsFilteredOn(question, entry2.varname, entry2.GetRangeNumbers(3)))
            {
                XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "DEEAF6" });
            }

            // third product
            if (IsFilteredOn(question, entry3.varname, entry3.GetRangeNumbers(1)))
            {
                XMLUtilities.ShadeCell(cell3, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "385623" });
            }
            else if (IsFilteredOn(question, entry3.varname, entry3.GetRangeNumbers(2))) 
            {
                XMLUtilities.ShadeCell(cell3, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "A8D08D" });
            }
            else if (IsFilteredOn(question, entry3.varname, entry3.GetRangeNumbers(3)))
            {
                XMLUtilities.ShadeCell(cell3, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "E2EFD9" });
            }
        }

        private void CreatePraccingSheetXLS(Survey survey)
        {
            List<SurveyQuestion> questionList = DBAction.GetSurveyQuestions(survey).ToList();

            string filePath = @"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports\Praccing\" + survey.SurveyCode + " Praccing Sheet - " + DateTime.Now.DateTimeForFile() + ".xlsx";

            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadSheet.AddWorkbookPart();
                workbookpart.Workbook = new XMLSheet.Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new XMLSheet.Worksheet(new XMLSheet.SheetData());

                // Add Sheets to the Workbook.
                XMLSheet.Sheets sheets = spreadSheet.WorkbookPart.Workbook.AppendChild<XMLSheet.Sheets>(new XMLSheet.Sheets());

                // Append a new worksheet and associate it with the workbook.
                XMLSheet.Sheet sheet = new XMLSheet.Sheet()
                {
                    Id = spreadSheet.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = survey.SurveyCode + " Pracc Sheet"
                };
                sheets.Append(sheet);


                XMLSheet.SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<XMLSheet.SheetData>();


                XMLSheet.Row headings = new XMLSheet.Row();
                headings.RowIndex = 1;
                sheetData.Append(headings);

                XMLSheet.Cell qnumHeading = new XMLSheet.Cell() { CellReference = "A1" };
                headings.Append(qnumHeading);
                qnumHeading.CellValue = new XMLSheet.CellValue("Qnum");
                qnumHeading.DataType = new EnumValue<XMLSheet.CellValues>(XMLSheet.CellValues.String);


                XMLSheet.Cell varHeading = new XMLSheet.Cell() { CellReference = "B1" };
                headings.Append(varHeading);
                varHeading.CellValue = new XMLSheet.CellValue("VarName");
                varHeading.DataType = new EnumValue<XMLSheet.CellValues>(XMLSheet.CellValues.String);


                int index = 2;

                foreach (SurveyQuestion q in questionList)
                {
                    XMLSheet.Row contentRow = new XMLSheet.Row();

                    contentRow.RowIndex = (UInt32)index;

                    XMLSheet.Cell qnumValue = new XMLSheet.Cell() { CellReference = "A" + index };
                    contentRow.AppendChild(qnumValue);
                    qnumValue.CellValue = new XMLSheet.CellValue(q.Qnum);
                    qnumValue.DataType = new EnumValue<XMLSheet.CellValues>(XMLSheet.CellValues.String);


                    XMLSheet.Cell varValue = new XMLSheet.Cell() { CellReference = "B" + index };
                    contentRow.AppendChild(varValue);
                    varValue.CellValue = new XMLSheet.CellValue(q.VarName.VarName);
                    varValue.DataType = new EnumValue<XMLSheet.CellValues>(XMLSheet.CellValues.String);

                    sheetData.AppendChild(contentRow);

                    index++;
                }
            }

            Excel.Application appExcel;
            appExcel = new Excel.Application();
            try
            {
                Excel.Workbook wrkbk = appExcel.Workbooks.Open(filePath);
                appExcel.Visible = true;
            }
            catch (Exception)
            {
                appExcel.Quit();
            }
        }

        #endregion

        #region Events

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Survey Selected;
            if (cboSurvey.SelectedItem == null)
                Selected = null;
            else
                Selected = (Survey)cboSurvey.SelectedItem;

            IncludeLegend = chkIncludeLegend.Checked;

            if (rbWord.Checked)
            {
                CreatePraccingSheetWRD(Selected);
            }
            else if (rbExcel.Checked)
            {
                CreatePraccingSheetXLS(Selected);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void chkIncludeLegend_CheckedChanged(object sender, EventArgs e)
        {
            dgvHighlightingRanges.Enabled = chkIncludeLegend.Checked;
        }

        private void dgvHighlightingRanges_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex < 2)
                return;

            if (string.IsNullOrEmpty((string)e.FormattedValue))
                return;
            if (!Regex.IsMatch((string)e.FormattedValue, @"^\d+-\d+$"))
            {
                MessageBox.Show("Enter ranges in the format: #-#");
                e.Cancel = true;
            }
        }

        struct LegendEntry
        {
            public string label;
            public string varname;
            public string range1;
            public string range2;
            public string range3;

            public string GetRange(int index)
            {
                switch (index)
                {
                    case 1:
                        return varname + "=" + range1;
                    case 2:
                        return varname + "=" + range2;
                    case 3:
                        return varname + "=" + range3;
                    default:
                        return varname;
                }
            }

            public IEnumerable<int> GetRangeNumbers(int index)
            {
                switch (index)
                {
                    case 1:
                        return GetRangeFromString(range1);
                    case 2:
                        return GetRangeFromString(range2);
                    case 3:
                        return GetRangeFromString(range3);
                    default:
                        return null;
                }
            }

            private IEnumerable<int> GetRangeFromString(string input)
            {
                // Split the input string by '-'
                string[] parts = input.Split('-');

                // Check if the input has correct format and contains two parts
                if (parts.Length != 2 || !int.TryParse(parts[0], out int start) || !int.TryParse(parts[1], out int end))
                {
                    throw new ArgumentException("Invalid input format. Input should be in the format #-#.");
                }

                // Generate and return the range of integers between start and end
                for (int i = start; i <= end; i++)
                {
                    yield return i;
                }
            }

        }
    }
}
