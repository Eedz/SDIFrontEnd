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
using XMLSheet = DocumentFormat.OpenXml.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

using ITCLib;

namespace ISISFrontEnd
{
    public partial class PraccingSheet : Form
    {
        public PraccingSheet()
        {
            InitializeComponent();

            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.DataSource = Globals.AllSurveys;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Survey Selected;
            if (cboSurvey.SelectedItem == null)
                Selected = null;
            else
                Selected = (Survey)cboSurvey.SelectedItem;

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

        private void CreatePraccingSheetWRD(Survey survey)
        {
            List<SurveyQuestion> questionList = DBAction.GetSurveyQuestions(survey).ToList();
            int num_ids = 10;
            string filePath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Access\Reports\Praccing\" + survey.SurveyCode + " Praccing Sheet - " + DateTime.Now.ToString("g").Replace(":", ",") + ".docx";
            string templateFile = @"\\psychfile\psych$\psych-lab-gfong\SMG\Access\Reports\Templates\SMGLandLet.dotx";

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

                foreach (SurveyQuestion q in questionList)
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



                    table.Append(row);
                }

                body.Append(table);
            }

            try
            {
                doc = appWord.Documents.Open(filePath);

                // footer text                  
                foreach (Word.Section s in doc.Sections)
                    s.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InsertAfter("\t" + survey.SurveyCode + " Praccing Sheet" +
                        "\t\t" + "Generated on " + DateTime.Today.ToString("d"));

                appWord.Visible = true;
            }
            catch (Exception)
            {
                appWord.Quit();
            }
        }

        private void CreatePraccingSheetXLS(Survey survey)
        {
            List<SurveyQuestion> questionList = DBAction.GetSurveyQuestions(survey).ToList();
            int num_ids = 10;
            string filePath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Access\Reports\Praccing\" + survey.SurveyCode + " Praccing Sheet - " + DateTime.Now.ToString("g").Replace(":", ",") + ".xlsx";

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

        
    }
}
