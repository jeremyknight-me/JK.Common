using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DL.Common.OpenXml.Spreadsheet.Extensions
{
    public static class DataSetExtensions
    {
        public static void Export(this IEnumerable<DataTable> tables, string destination)
        {
            using (var document = SpreadsheetDocument.Create(destination, SpreadsheetDocumentType.Workbook))
            {
                Export(tables, document);
            }
        }

        public static void Export(this IEnumerable<DataTable> tables, Stream stream)
        {
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                Export(tables, document);
            }
        }

        private static void Export(IEnumerable<DataTable> tables, SpreadsheetDocument document)
        {
            var workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook { Sheets = new Sheets() };

            foreach (DataTable table in tables)
            {
                var sheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                sheetPart.Worksheet = new Worksheet(sheetData);

                var sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
                var relationshipId = workbookPart.GetIdOfPart(sheetPart);
                uint sheetId = 1;
                if (sheets.Elements<Sheet>().Any())
                {
                    sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                }

                var sheet = new Sheet { Id = relationshipId, SheetId = sheetId, Name = table.Name };
                sheets.AppendChild(sheet);

                var headerRow = new Row();
                var columns = new List<string>();

                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.Name);

                    var cell = new Cell { DataType = CellValues.String, CellValue = new CellValue(column.Name) };
                    headerRow.AppendChild(cell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    var newRow = new Row();
                    foreach (var col in columns)
                    {
                        var cell = new Cell
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(dsrow[col].ToString())
                        };
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }
            }
        }
    }
}
