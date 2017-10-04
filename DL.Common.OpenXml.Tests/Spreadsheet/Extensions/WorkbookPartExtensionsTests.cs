using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Linq;
using DL.Common.OpenXml.Spreadsheet.Extensions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Xunit;

namespace DL.Common.OpenXml.Tests.Spreadsheet.Extensions
{
    public class WorkbookPartExtensionsTests
    {
        #region GetNamedWorksheets() Tests

        [Fact]
        public void GetNamedWorksheets_FullSetup_List()
        {
            using (var stream = new MemoryStream())
            using (var document = this.GetDocument(stream))
            {
                var result = document.WorkbookPart.GetNamedWorksheets().ToArray();
                Assert.IsType<KeyValuePair<string, Worksheet>[]>(result);
                Assert.Equal(1, result.Length);
                Assert.Equal("Sheet1", result.Select(x => x.Key).First());
            }
        }

        #endregion

        #region GetNamedWorksheetsDictionary() Tests

        [Fact]
        public void GetNamedWorksheetsDictionary_FullSetup_Dictionary()
        {
            using (var stream = new MemoryStream())
            using (var document = this.GetDocument(stream))
            {
                var result = document.WorkbookPart.GetNamedWorksheetsDictionary();
                Assert.IsType<Dictionary<string, Worksheet>>(result);
                Assert.Equal(1, result.Count);
                Assert.Equal("Sheet1", result.Keys.First());
            }
        }

        #endregion

        #region GetSheetFromName() Tests

        [Fact]
        public void GetSheetFromName_NullSheetName_Exception()
        {
            ArgumentNullException actual;
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                actual = Assert.Throws<ArgumentNullException>(() => workbookPart.GetSheetFromName(null));
            }
        }

        [Fact]
        public void GetSheetFromName_EmptySheetName_Exception()
        {
            ArgumentNullException actual;
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                actual = Assert.Throws<ArgumentNullException>(() => workbookPart.GetSheetFromName(string.Empty));
            }
        }

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
            using (var stream = new MemoryStream())
            using (var document = this.GetDocument(stream))
            {
                var result = document.WorkbookPart.GetSheetFromName("Sheet1");
                Assert.Equal("sheet", result.LocalName);
                Assert.Equal(1U, result.SheetId.Value);
                Assert.Equal("Sheet1", result.Name.Value);
            }
        }

        #endregion

        private SpreadsheetDocument GetDocument(MemoryStream stream)
        {
            var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            
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

            return document;
        }
    }
}
