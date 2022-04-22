using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using JK.Common.OpenXml.Excel.Extensions;
using Xunit;

namespace JK.Common.OpenXml.Tests.Excel.Extensions
{
    public class WorkbookPartExtensionsTests
    {
        [Fact]
        public void GetSheetFromName_WhitespaceSheetName_Exception()
        {
            ArgumentNullException actual;
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                actual = Assert.Throws<ArgumentNullException>(() => workbookPart.GetSheetFromName(" "));
            }
        }

        [Fact]
        public void GetSheetFromName_SheetName_Sheet()
        {
            using var stream = new MemoryStream();
            using var document = MockSpreadsheetDocumentFactory.Make(stream);
            var result = document.WorkbookPart?.GetSheetFromName("Sheet1");
            Assert.Equal("sheet", result?.LocalName);
            Assert.Equal(1U, result?.SheetId?.Value);
            Assert.Equal("Sheet1", result?.Name?.Value);
        }
    }
}
