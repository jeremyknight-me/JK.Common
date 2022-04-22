using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JK.Common.OpenXml.Tests.Excel;

internal static class MockSpreadsheetDocumentFactory
{
    internal static SpreadsheetDocument Make(MemoryStream stream)
    {
        var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

        var workbookPart = document.AddWorkbookPart();
        workbookPart.Workbook = new Workbook { Sheets = new Sheets() };

        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet(new SheetData());
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
