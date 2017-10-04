using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DL.Common.OpenXml.Spreadsheet.Extensions
{
    public static class SpreadsheetDocumentExtensions
    {
        public static IEnumerable<DataTable> ConvertToTableList(this SpreadsheetDocument spreadsheetDocument)
        {
            var tables = new List<DataTable>();
            var workbookPart = spreadsheetDocument.WorkbookPart;
            var worksheets = workbookPart.GetNamedWorksheets();
            foreach (var worksheet in worksheets)
            {
                var sheetData = worksheet.Value.Elements<SheetData>().First();
                var rows = sheetData.Elements<Row>().ToArray();
                var dataTable = GetDataTableFromRows(workbookPart, rows, worksheet.Key, 0);
                tables.Add(dataTable);
            }
            return tables;
        }

        public static DataTable ConvertToDataTable(this SpreadsheetDocument document, string sheetName, int headerRows = 0)
        {
            if (string.IsNullOrWhiteSpace(sheetName))
            {
                throw new ArgumentNullException(nameof(sheetName));
            }

            var workbookPart = document.WorkbookPart;
            var sheet = workbookPart.GetSheetFromName(sheetName);
            var worksheet = sheet.GetWorksheet(workbookPart);
            var rows = worksheet.Elements<SheetData>().First().Elements<Row>().ToArray();
            return GetDataTableFromRows(workbookPart, rows, sheetName, headerRows);
        }

        private static DataTable GetDataTableFromRows(WorkbookPart workbookPart, IEnumerable<Row> rows, string tableName, int headerRows)
        {
            if (rows == null)
            {
                throw new ArgumentNullException(nameof(rows));
            }

            var dataTable = new DataTable { Name = tableName };
            rows = rows.ToArray();

            if (!rows.Any())
            {
                return dataTable;
            }

            var columnCells = rows.ElementAt(0).Cast<Cell>();
            int columnIndex = 0;
            foreach (var cell in columnCells)
            {
                int cellColumnIndex = cell.GetColumnIndex();
                while (columnIndex < cellColumnIndex)
                {
                    dataTable.NewColumn($"Column{columnIndex + 1}");
                    columnIndex++;
                }

                var value = cell.GetValue(workbookPart);
                var valueColumnName = string.IsNullOrWhiteSpace(value) 
                    ? $"Column{columnIndex + 1}" 
                    : $"Column{columnIndex + 1}_{value}";
                dataTable.NewColumn(valueColumnName);
                columnIndex++;
            }

            foreach (var row in rows)
            {
                ProcessRow(row, dataTable, workbookPart);
            }

            for (int i = 0; i < headerRows; i++)
            {
                dataTable.Rows.RemoveAt(0);
            }

            return dataTable;
        }

        private static void ProcessRow(Row row, DataTable dataTable, WorkbookPart workbookPart)
        {
            var dataRow = dataTable.NewRow();
            var cells = row.Elements<Cell>().ToArray();
            int columnIndex = 0;
            foreach (var cell in cells)
            {
                int cellColumnIndex = cell.GetColumnIndex();
                while (columnIndex < cellColumnIndex)
                {
                    dataRow[columnIndex] = string.Empty;
                    columnIndex++;
                }

                dataRow[columnIndex] = cell.GetValue(workbookPart);
                columnIndex++;
            }
        }
    }
}
