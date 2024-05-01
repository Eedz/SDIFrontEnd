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

namespace SDIFrontEnd
{
    /// <summary>
    /// Class for importing a table inside a Word  doc
    /// </summary>
    public class DocImporter
    {
        public string fileName { get; set; }

        List<string> Headers = new List<string>();

        public List<object> imported;
        public List<object> empties;
        public List<object> duplicates;

        public DocImporter()
        {
            this.imported = new List<object>();
            this.empties = new List<object>();
            this.duplicates = new List<object>();
        }

        /// <summary>
        /// Returns the text contents from the specified cell in a group of cells. If a cell doesn't exist at that index, an empty string is returned.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected string GetContentFromCell(IEnumerable<TableCell> cells, int index, bool richText)
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

        /// <summary>
        /// Populate the Header list with values found in the header cells.
        /// </summary>
        /// <param name="headerCells"></param>
        protected void GetHeaders(Body body)
        {
            var rows = body.Descendants<TableRow>();

            List<TableCell> headerCells = rows.ElementAt(0).Elements<TableCell>().ToList<TableCell>();

            foreach (TableCell cell in headerCells)
            {
                Headers.Add(cell.GetCellText());
            }
        }

        protected string RemoveTags(string input)
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
