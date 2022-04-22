using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JK.Common.OpenXml.Tests.Excel;

internal static class MockSpreadsheetDocumentFactory
{
    internal static SpreadsheetDocument Make(MemoryStream stream, Action<SheetData> appendCells = null)
    {
        var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

        var workbookPart = document.AddWorkbookPart();
        workbookPart.Workbook = new Workbook { Sheets = new Sheets() };

        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        var sheetData = new SheetData();
        appendCells?.Invoke(sheetData);
        worksheetPart.Worksheet = new Worksheet(sheetData);
        worksheetPart.Worksheet.Save();

        var sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
        var relationshipId = workbookPart.GetIdOfPart(worksheetPart);

        uint sheetId = 1;
        var sheetName = "Sheet1";
        var sheet = new Sheet { Id = relationshipId, SheetId = sheetId, Name = sheetName };
        _ = sheets.AppendChild(sheet);

        workbookPart.Workbook.Save();
        return document;
    }
}
