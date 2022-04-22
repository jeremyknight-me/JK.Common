using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using JK.Common.OpenXml.Excel.Extensions;
using Xunit;

namespace JK.Common.OpenXml.Tests.Excel.Extensions;

public class SheetExtensionsTests
{
    [Fact]
    public void GetWorksheet_NullWorkbookPart_Exception()
    {
        var sut = new Sheet();
        var ex = Assert.Throws<ArgumentNullException>(() => sut.GetWorksheet(null));
    }

    [Fact]
    public void GetWorksheet_FullSetup()
    {
        using var stream = new MemoryStream();
        using var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
        var workbookPart = document.AddWorkbookPart();
        workbookPart.Workbook = new Workbook { Sheets = new Sheets() };

        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet(new SheetData());
        worksheetPart.Worksheet.Save();

        var sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
        var relationshipId = workbookPart.GetIdOfPart(worksheetPart);

        var sheet = new Sheet { Id = relationshipId };
        _ = sheets.AppendChild(sheet);
        workbookPart.Workbook.Save();

        var result = sheet.GetWorksheet(workbookPart);
        var resultId = workbookPart.GetIdOfPart(result.WorksheetPart);
        Assert.Equal("worksheet", result.LocalName);
        Assert.Equal(relationshipId, resultId);
    }
}
