using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace SDIFrontEnd
{
    /// <summary>
    /// Reads a Word file and imports the contents of the first table it finds into a DataTable.
    /// </summary>
    public class DataImporter
    {
        public DataTable Data { get; }

        public DataImporter()
        {
            Data = new DataTable();
        }

        public DataImporter(string path, bool headers)
        {
            Data = new DataTable();
            Import(path, headers);
        }

        public void Import(string path, bool headers) 
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(path, false))
            {
                
                // Get the first table in the document
                Table table = wordDocument.MainDocumentPart.Document.Body.Descendants<Table>().FirstOrDefault();

                if (table == null)
                    throw new Exception("Table not found.");

                if (table.Descendants<TableRow>().Count() == 0)
                    throw new Exception("Table contains no rows.");
                


                // Get the column headers 
                if (headers)
                {
                    foreach (TableCell cell in table.Descendants<TableRow>().First().Descendants<TableCell>())
                    {
                        DataColumn dataColumn = new DataColumn()
                        {
                            ColumnName = cell.InnerText
                        };
                        Data.Columns.Add(dataColumn);
                    }
                }
                else
                {
                    int i = 0;
                    foreach (GridColumn column in table.Descendants<GridColumn>()) 
                    {
                        DataColumn dataColumn = new DataColumn()
                        {
                            ColumnName = "Column" + i
                        };
                        i++; 
                    }
                }

                if (headers)
                    GetTableDataWithHeader(table);
                else 
                    GetTableData(table);
            }

            
        }

        private void GetTableDataWithHeader(Table table)
        {
            // Loop through the rows in the table
            foreach (TableRow row in table.Descendants<TableRow>().Skip(1))
            {
                DataRow newrow = Data.NewRow();

                for (int i = 0; i < Data.Columns.Count; i++)
                {
                    newrow[i] = row.Descendants<TableCell>().Skip(i).FirstOrDefault().InnerText;
                }
                Data.Rows.Add(newrow);
            }
        }

        private void GetTableData(Table table)
        {
            // Loop through the rows in the table
            foreach (TableRow row in table.Descendants<TableRow>().Skip(1))
            {
                DataRow newrow = Data.NewRow();

                for (int i = 0; i < Data.Columns.Count; i++)
                {
                    newrow[i] = row.Descendants<TableCell>().Skip(i).FirstOrDefault().InnerText;
                }
                Data.Rows.Add(newrow);
            }
        }
    }
}
