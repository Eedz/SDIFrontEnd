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
    public enum ImportType { Single, Multi };
    /// <summary>
    /// Creates a list of translation objects from a Word document. Objects are placed into appropriate lists if they are matched with a record from the database.
    /// </summary>
    public class WaveTranslationImporter : DocImporter
    {

        int VarNameColumn;
        int QuestionTextColumn;
        int SurveysColumn;

        public StudyWave TargetWave { get; set; }
        public Language TargetLanguage { get; set; }

        public bool Bilingual { get; set; }

        public new List<Translation> imported;
        public new List<Translation> empties;
        public new List<Translation> duplicates;

        public WaveTranslationImporter()
        {
            TargetWave = new StudyWave();

            TargetLanguage = new Language();

            imported = new List<Translation>();
            empties = new List<Translation>();
            duplicates = new List<Translation>();

 
        }

        /// <summary>
        /// Opens the specified document and converts each row into a translation object for each Survey specified in the Surveys column.
        /// </summary>
        /// <param name="fileName"></param>
        public void Import()
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

                foreach (Table t in tables)
                {
                    var rows = t.Elements<TableRow>();

                    foreach (TableRow row in rows.Skip(1))
                    {
                        string varname = "";
                        string questionText = "";
                        string surveys = "";
                        string[] surveyList;

                        var cells = row.Elements<TableCell>();

                        varname = GetContentFromCell(cells, VarNameColumn, false);
                        questionText = GetContentFromCell(cells, QuestionTextColumn, true);
                        surveys = GetContentFromCell(cells, SurveysColumn, false);

                        surveyList = surveys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string surv in surveyList)
                        {
                            string trimmed = Utilities.TrimString(surv, " ");
                            Translation tq = new Translation();
                            Translation existingT = DBAction.GetSurveyTranslation(trimmed, varname, TargetLanguage.LanguageName) ?? new Translation();
                            tq.ID = existingT.ID;
                            tq.QID = DBAction.GetQuestionID(trimmed, varname);
                            tq.LanguageName = TargetLanguage;
                            tq.Survey = trimmed;
                            tq.VarName = varname;
                            tq.TranslationText = FormatTranslation(questionText);

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
                        }
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

                    if (SurveysColumn == -1)
                        errors.AppendLine("Surveys column not found.");

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
            SurveysColumn = -1;

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
                    case "Survey":
                    case "survey":
                    case "Surveys":
                    case "surveys":
                        SurveysColumn = i;
                        break;


                }

                if (cellText.Equals(TargetLanguage.LanguageName))
                {
                    QuestionTextColumn = i;
                }
            }

            // it is too risky to assume which column contains the translation without enumerating every possible scenario
            // if varname is found, and there are 2 columns, 2nd column is question text 
            // if qnum and varname is found, and there are 3 columns, 3rd column is question text
            // if varname and surveys are found, and there are 3 columns, the other column is question text
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

      
    }
}
