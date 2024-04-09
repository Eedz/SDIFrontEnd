using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        

        private void CreateLegend(Body body)
        {
            Table legendTable = XMLUtilities.NewTable(4, TableLayoutValues.Autofit);

            TableRow row1 = new TableRow();
            TableCell cell1 = new TableCell(new Paragraph(new Run(new Text("Cigarettes"))));
            TableCell cell2 = new TableCell(new Paragraph(new Run(new Text("FR309v=1-3"))));
            XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "833C0B" });
            TableCell cell3 = new TableCell(new Paragraph(new Run(new Text("FR309v=1-5"))));
            XMLUtilities.ShadeCell(cell3, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "F4B083" });
            TableCell cell4 = new TableCell(new Paragraph(new Run(new Text("FR309v=1-7"))));
            XMLUtilities.ShadeCell(cell4, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FBE4D5" });

            row1.Append(cell1);
            row1.Append(cell2);
            row1.Append(cell3);
            row1.Append(cell4);

            legendTable.Append(row1);

            TableRow row2 = new TableRow();
            TableCell cell5 = new TableCell(new Paragraph(new Run(new Text("E-cigarettes"))));
            TableCell cell6 = new TableCell(new Paragraph(new Run(new Text("EC309v=1-3"))));
            XMLUtilities.ShadeCell(cell6, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "1F4E79" });
            TableCell cell7 = new TableCell(new Paragraph(new Run(new Text("EC309v=1-5 (NC302=1)"))));
            XMLUtilities.ShadeCell(cell7, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "9CC2E5" });
            TableCell cell8 = new TableCell(new Paragraph(new Run(new Text("EC309v=1-6 (NC302=1 or 2)"))));
            XMLUtilities.ShadeCell(cell8, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "DEEAF6" });

            row2.Append(cell5);
            row2.Append(cell6);
            row2.Append(cell7);
            row2.Append(cell8);

            legendTable.Append(row2);

            TableRow row3 = new TableRow();
            TableCell cell9 = new TableCell(new Paragraph(new Run(new Text("HTPs"))));
            TableCell cell10 = new TableCell(new Paragraph(new Run(new Text("HN309v=10-32"))));
            XMLUtilities.ShadeCell(cell10, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "385623" });
            TableCell cell11 = new TableCell(new Paragraph(new Run(new Text("HN309v=10-60 (HN106=1)"))));
            XMLUtilities.ShadeCell(cell11, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "A8D08D" });
            TableCell cell12 = new TableCell(new Paragraph(new Run(new Text("HN309v=31-70"))));
            XMLUtilities.ShadeCell(cell12, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "E2EFD9" });

            row3.Append(cell9);
            row3.Append(cell10);
            row3.Append(cell11);
            row3.Append(cell12);

            legendTable.Append(row3);

            body.Append(legendTable);
            body.Append(XMLUtilities.NewParagraph(string.Empty, JustificationValues.Center));
        }

        private bool IsFilteredOn (LinkedQuestion question, string varname, List<int> values)
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

            if (IsFilteredOn(question, "FR309v", Enumerable.Range(1, 3).ToList()))
            {
                XMLUtilities.ShadeCell(cell1, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "833C0B" });
            }
            else if (IsFilteredOn(question, "FR309v", Enumerable.Range(1, 5).ToList()))
            {
                XMLUtilities.ShadeCell(cell1, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "F4B083" });
            }
            else if (IsFilteredOn(question, "FR309v", Enumerable.Range(1, 7).ToList()))
            {
                XMLUtilities.ShadeCell(cell1, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FBE4D5" });
            }

            // EC309v
            if (IsFilteredOn(question, "EC309v", Enumerable.Range(1,3).ToList()))
            {
                XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "1F4E79" });
            }
            else if (IsFilteredOn(question, "EC309v", Enumerable.Range(1, 5).ToList()) || IsFilteredOn(question, "NC302", new List<int> { 1 }))
            {
                XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "9CC2E5" });
            }
            else if (IsFilteredOn(question, "EC309v", Enumerable.Range(1, 6).ToList()) || IsFilteredOn(question, "NC302", new List<int> { 1, 2 }))
            {
                XMLUtilities.ShadeCell(cell2, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "DEEAF6" });
            }

            // HN309v
            if (IsFilteredOn(question, "HN309v", Enumerable.Range(10, 23).ToList()))
            {
                XMLUtilities.ShadeCell(cell3, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "385623" });
            }
            else if (IsFilteredOn(question, "HN309v", Enumerable.Range(10, 51).ToList()) || IsFilteredOn(question, "HN106", new List<int> { 1 })) // new List<int> { 10, 20, 31, 32, 40, 50, 60 }) 
            {
                XMLUtilities.ShadeCell(cell3, new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "A8D08D" });
            }
            else if (IsFilteredOn(question, "HN309v", Enumerable.Range(31, 39).ToList())) 
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
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
