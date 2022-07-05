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
using ITCLib;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Word = Microsoft.Office.Interop.Word;

namespace ISISFrontEnd
{
    public partial class PraccingMenu : Form
    {
        public PraccingMenu()
        {
            InitializeComponent();
        }

        #region Buttons 

        private void cmdOpenPraccingEntry_Click(object sender, EventArgs e)
        {

            if (FormManager.FormOpen("PraccingEntry", 1))
            {
                ((MainMenu)FormManager.GetForm("MainMenu")).SelectTab("PraccingEntry1");
                return;
            }

            var state = Globals.CurrentUser.FormStates.Where(x => x.FormName.Equals("frmIssuesTracking") && x.FormNum == 1).First();
            int survID=899;
            if (state != null) survID = state.FilterID;
            PraccingEntry frm = new PraccingEntry(survID);

            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenIssuesImport_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("frmPraccingIssuesImport", 1))
            {
                ((MainMenu)FormManager.GetForm("MainMenu")).SelectTab("frmPraccingIssuesImport1");
                return;
            }

            frmPraccingIssuesImport frm = new frmPraccingIssuesImport();

            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdOpenPraccingReport_Click(object sender, EventArgs e)
        {
            if (FormManager.FormOpen("PraccingReportForm", 1))
            {
                ((MainMenu)FormManager.GetForm("MainMenu")).SelectTab("PraccingReportForm1");
                return;
            }

            PraccingReportForm frm = new PraccingReportForm();
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        private void cmdPraccingSheet_Click(object sender, EventArgs e)
        {
            SurveySelector frm = new SurveySelector();
            frm.ShowDialog();
            Survey survey = frm.Selected;

            if (survey == null)
                return;

            CreatePraccingSheet(survey);
        }

        private void cmdPraccingForm_Click(object sender, EventArgs e)
        {
            PraccingReportBlank report = new PraccingReportBlank();

            report.CreateReport();
        }

        private void PraccingMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Remove(this);
        }
        #endregion

        private void CreatePraccingSheet(Survey survey)
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

                foreach(SurveyQuestion q in questionList)
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

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            FormManager.Remove(this);
        }
    }
}
