using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using JK.Common.OpenXml.Excel.Extensions;

namespace JK.Common.OpenXml.Excel;

public class ExcelDocument : IDisposable
{
    private SpreadsheetDocument spreadsheet;

    internal ExcelDocument(SpreadsheetDocument spreadsheetDocument)
    {
        this.spreadsheet = spreadsheetDocument;
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
        this.spreadsheet.Dispose();   
    }

    public ExcelSheet GetSheetByName(string sheetName, int headerRows = 0)
    {
        if (string.IsNullOrWhiteSpace(sheetName))
        {
            throw new ArgumentNullException(nameof(sheetName));
        }

        var workbookPart = this.spreadsheet.WorkbookPart;
        var sheet = workbookPart.GetSheetByName(sheetName);
        var worksheet = sheet.GetWorksheet(workbookPart);
        var rows = worksheet.Elements<SheetData>().First().Elements<Row>().ToArray();
        //return GetDataTableFromRows(workbookPart, rows, sheetName, headerRows);
        return null;
    }
}
