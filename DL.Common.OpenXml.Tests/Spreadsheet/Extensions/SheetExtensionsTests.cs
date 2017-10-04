using System;
using System.IO;
using DL.Common.OpenXml.Spreadsheet.Extensions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Xunit;

namespace DL.Common.OpenXml.Tests.Spreadsheet.Extensions
{
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

                var sheet = new Sheet { Id = relationshipId };
                sheets.AppendChild(sheet);
                workbookPart.Workbook.Save();

                var result = sheet.GetWorksheet(workbookPart);
                var resultId = workbookPart.GetIdOfPart(result.WorksheetPart);
                Assert.Equal("worksheet", result.LocalName);
                Assert.Equal(relationshipId, resultId);
            }
        }
    }
}
