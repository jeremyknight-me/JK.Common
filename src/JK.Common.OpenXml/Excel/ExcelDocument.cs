using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using JK.Common.OpenXml.Excel.Extensions;

namespace JK.Common.OpenXml.Excel;

public class ExcelDocument : IDisposable
{
    private SpreadsheetDocument spreadsheet;
    private WorkbookPart workbookPart;

    internal ExcelDocument(SpreadsheetDocument spreadsheetDocument)
    {
        this.spreadsheet = spreadsheetDocument;
        if (spreadsheetDocument != null)
        {
            this.workbookPart = this.spreadsheet.WorkbookPart;
        }
        
    }

    public static ExcelDocument Load(string path, bool editable = false)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        using (var spreadsheetDocument = SpreadsheetDocument.Open(path, isEditable: editable))
        {
            var excelDocument = new ExcelDocument(spreadsheetDocument);
            return excelDocument;
        }
    }

    public void Dispose()
    {
        this.workbookPart = null;
        this.spreadsheet.Dispose();
    }

    public DataSet GetDataSet()
    {
        var sheets = this.workbookPart.GetNamedWorksheets();
        var set = new DataSet();
        foreach (var sheet in sheets)
        {
            var table = this.BuildDataTable(sheet.Value, sheet.Key);
        }
        return set;
    }

    public DataTable GetDataTableBySheetName(string sheetName, int headerRows = 0)
    {
        if (string.IsNullOrWhiteSpace(sheetName))
        {
            throw new ArgumentNullException(nameof(sheetName));
        }

        var workbookPart = this.spreadsheet.WorkbookPart;
        var sheet = workbookPart.GetSheetByName(sheetName);
        var worksheet = sheet.GetWorksheet(workbookPart);
        return this.BuildDataTable(worksheet, sheetName, headerRows);
    }

    private DataTable BuildDataTable(Worksheet worksheet, string sheetName, int headerRows = 0)
    {
        var rows = worksheet.Elements<SheetData>().First().Elements<Row>().ToArray();
        var table = new DataTable(sheetName);
        if (!rows.Any())
        {
            return table;
        }

        var columnCells = rows.ElementAt(0).Cast<Cell>();
        int columnIndex = 0;
        foreach (var cell in columnCells)
        {
            int cellColumnIndex = cell.GetColumnIndex();
            while (columnIndex < cellColumnIndex)
            {
                table.Columns.Add($"Column{columnIndex + 1}");
                columnIndex++;
            }

            var value = cell.GetValue(workbookPart);
            var valueColumnName = string.IsNullOrWhiteSpace(value)
                ? $"Column{columnIndex + 1}"
                : $"Column{columnIndex + 1}_{value}";
            table.Rows.Add(valueColumnName);
            columnIndex++;
        }

        //foreach (var row in rows)
        //{
        //    ProcessRow(row, dataTable, workbookPart);
        //}

        //for (int i = 0; i < headerRows; i++)
        //{
        //    dataTable.Rows.RemoveAt(0);
        //}

        return table;
    }
}
