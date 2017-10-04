using System;
using System.IO;
using DL.Common.OpenXml.Spreadsheet.Extensions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Xunit;

namespace DL.Common.OpenXml.Tests.Spreadsheet.Extensions
{
    public class WorksheetPartExtensionsTests
    {
        [Fact]
        public void GetSheet_NullWorkbookPart_Exception()
        {
            ArgumentNullException actual;
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                actual = Assert.Throws<ArgumentNullException>(() => worksheetPart.GetSheet(null));
            }
        }

        [Fact]
        public void GetSheet_FullSetup()
        {
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook { Sheets = new Sheets() };

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());
                worksheetPart.Worksheet.Save();

                var sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
                string relationshipId = workbookPart.GetIdOfPart(worksheetPart);

                uint sheetId = 1;
                string sheetName = "Sheet1";
                var sheet = new Sheet { Id = relationshipId, SheetId = sheetId, Name = sheetName };
                sheets.AppendChild(sheet);
                workbookPart.Workbook.Save();

                var result = worksheetPart.GetSheet(workbookPart);
                Assert.Equal("sheet", result.LocalName);
                Assert.Equal(relationshipId, result.Id.Value);
                Assert.Equal(sheetId, result.SheetId.Value);
                Assert.Equal(sheetName, result.Name.Value);
            }
        }
    }
}
