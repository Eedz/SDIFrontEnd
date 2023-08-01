using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using OpenXMLHelper;

using ITCLib;

namespace SDIFrontEnd
{
   
    /// <summary>
    /// Creates a list of translation objects from a Word document. Objects are placed into appropriate lists if they are matched with a record from the database.
    /// </summary>
    public class SurveyTranslationImporter : DocImporter
    {
        int VarNameColumn;
        int QuestionTextColumn;

        public Survey TargetSurvey { get; set; }
        public Language TargetLanguage { get; set; }

        public bool Bilingual { get; set; }

        public new List<Translation> imported;
        public new List<Translation> empties;
        public new List<Translation> duplicates;

        public SurveyTranslationImporter()
        {
            TargetSurvey = new Survey();

            TargetLanguage = new Language();

            imported = new List<Translation>();
            empties = new List<Translation>();
            duplicates = new List<Translation>();

         }

        public void Import()
        {
            ImportTranslation(fileName);
        }

        /// <summary>
        /// Opens the specified document and converts each row into a translation object.
        /// </summary>
        /// <param name="fileName"></param>
        private void ImportTranslation(string fileName)
        {
            imported.Clear();
            empties.Clear();
            duplicates.Clear();

            using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(fileName, false))
            {
                Body body = wdDoc.MainDocumentPart.Document.Body;

                Table table = body.Elements<Table>().ElementAt(0);

                XMLUtilities.TagBold(body);
                XMLUtilities.TagItalics(body);
                XMLUtilities.TagUnderline(body);

                var tables = body.Elements<Table>();
                float rowNum = 0;
                foreach (Table t in tables)
                {
                    var rows = t.Elements<TableRow>();
                    bool firstRow = true;
                    bool subset = false;
                    string question = "";
                    string varname = "";
                    foreach (TableRow row in rows)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }

                        var cells = row.Elements<TableCell>();

                        // if this is the first part of a series in subtable format, save the question text, set the subset flag and move to the next row
                        if (cells.Count() == 1)
                        {
                            question = GetContentFromCell(cells, 0, true);
                            subset = true;
                            continue;
                        }
                        else
                        {
                            // save the VarName
                            varname = GetContentFromCell(cells, VarNameColumn, false);
                            varname = varname.Trim();

                            // if we are in a subset, insert the current question text into the previously saved question text
                            if (subset)
                            {
                                string seriesStartLitQ = GetContentFromCell(cells, QuestionTextColumn, true);
                                // insert this question text into the previously saved question text
                                question = GetSeriesStarterText(seriesStartLitQ, question);

                                // cancel the subset flag, the rest of the series will be imported as normal questions
                                subset = false;
                            }
                            else
                            {
                                question = GetContentFromCell(cells, QuestionTextColumn, true); //cells.ElementAt(QuestionTextColumn).GetCellText();//
                            }
                        }

                        Translation tq = new Translation();
                        Translation existingT = DBAction.GetSurveyTranslation(TargetSurvey.SurveyCode, varname, TargetLanguage.LanguageName) ?? new Translation();
                        tq.ID = existingT.ID;
                        tq.QID = DBAction.GetQuestionID(TargetSurvey.SurveyCode, varname);
                        tq.LanguageName = TargetLanguage;
                        tq.Survey = TargetSurvey.SurveyCode;
                        tq.VarName = varname;
                        tq.TranslationText = FormatTranslation(question);

                        // check VarName for empty or duplicate, if neither, add to import list
                        if (tq.QID == 0)
                        {
                            empties.Add(tq);
                        }
                        else if (imported.Any(x => x.QID == tq.QID))
                        {
                            duplicates.Add(tq);
                        }
                        else
                        {
                            imported.Add(tq);
                        }


                        rowNum++;
                    }
                }
            }

            
        }

        /// <summary>
        /// Ensure that the spaces between response code and label are correct.
        /// </summary>
        /// <param name="translation"></param>
        /// <returns></returns>
        private string FormatTranslation(string translation)
        {
            try
            {

                string[] lines = translation.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < lines.Length; i++)
                {
                    string l = lines[i];

                    if (Utilities.IsHebrew(l) || Utilities.IsArabic(l))
                    {

                        l = Utilities.FixBiDirectionalString(l);
                        char[] ch = l.ToCharArray();

                        Match m = Regex.Match(l, "([0-9]+\\s{2,})|(\\s{2,}[0-9]+)");
                        if (m.Length == 0)
                            continue;

                        string code = l.Substring(m.Index, m.Length);
                        string label = l.Substring(m.Index + m.Length);

                        lines[i] = code.Trim() + "    " + label.Trim();
                        lines[i] = Utilities.FixBiDirectionalString(lines[i]);
                    }
                    else
                    {
                        Match m = Regex.Match(l, "^[0-9]+\\s+");
                        if (m.Length == 0)
                            continue;


                        int firstSpace = l.IndexOf(" ");
                        int lastSpace = m.Length - 1;


                        lines[i] = l.Substring(0, firstSpace) + "    " + l.Substring(lastSpace + 1);
                    }

                }

                return string.Join("<br>", lines);
            }
            catch (Exception)
            {
                return translation;
            }
        }

        // check file for 
        // locked
        // at least one table
        // varname column present
        // surveys column present, if Multi 
        public string ErrorsExist(string fileName)
        {
            StringBuilder errors = new StringBuilder();
            try
            {
                using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(fileName, false))
                {
                    Body body = wdDoc.MainDocumentPart.Document.Body;

                    int tableCount = body.Descendants<Table>().Count();

                    if (tableCount == 0)
                        errors.AppendLine("The document needs to contain at least one table.");

                    GetHeaders(body);

                    if (VarNameColumn == -1)
                        errors.AppendLine("VarName column not found.");

                    if (QuestionTextColumn == -1)
                        errors.AppendLine("Translation column not found.");
                }
            }
            catch (Exception)
            {
                errors.Append("Error opening the file.");
            }

            return errors.ToString();
        }

        /// <summary>
        /// Populate the Header list with values found in the header cells.
        /// </summary>
        /// <param name="headerCells"></param>
        private void GetHeaders(Body body)
        {
            var rows = body.Descendants<TableRow>();

            List<TableCell> headerCells = rows.ElementAt(0).Elements<TableCell>().ToList<TableCell>();

            VarNameColumn = -1;
            QuestionTextColumn = -1;

            for (int i = 0; i < headerCells.Count(); i++)
            {
                string cellText = headerCells.ElementAt(i).GetCellText();
                cellText = cellText.Trim();

                switch (cellText)
                {
                    case "Q":
                    case "Qnum":
                    case "Q#":
                        break;
                    case "VarName":
                    case "Varname":
                    case "varname":
                        VarNameColumn = i;
                        break;
                }

                if (TargetSurvey != null && cellText.Equals(TargetSurvey))
                {
                    QuestionTextColumn = i;
                }
                else if (TargetSurvey != null && cellText.Equals(TargetSurvey + " " + TargetLanguage.LanguageName))
                {
                    QuestionTextColumn = i;
                }
                else if (cellText.Equals(TargetLanguage.LanguageName))
                {
                    QuestionTextColumn = i;
                }
            }

            // it is too risky to assume which column contains the translation without enumerating every possible scenario
            // if varname is found, and there are 2 columns, 2nd column is question text 
            // if qnum and varname is found, and there are 3 columns, 3rd column is question text
            // if varname and surveys are found, and there are 3 columns, the other column is question text
        }

        /// <summary>
        /// Returns the text contents from the specified cell in a group of cells. If a cell doesn't exist at that index, an empty string is returned.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetContentFromCell(IEnumerable<TableCell> cells, int index, bool richText)
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

        private string GetSeriesStarterText(string litq, string rest)
        {
            string completeQuestion;

            Regex rx = new Regex("[0-9]*   ");

            MatchCollection m = rx.Matches(rest);
            if (m.Count > 0)
            {
                string before = rest.Substring(0, m[0].Index);
                string after = rest.Substring(m[0].Index);
                before = Utilities.TrimString(before, "\r\n");

                completeQuestion = before + "\r\n" + litq + "\r\n" + after;
            }
            else
            {
                // resp options not found
                completeQuestion = rest + "\r\n" + litq;
            }

            return completeQuestion;
        }

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
    }
}
