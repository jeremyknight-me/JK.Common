using System;
using System.IO;
using DL.Common.OpenXml.Spreadsheet.Extensions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Xunit;

namespace DL.Common.OpenXml.Tests.Spreadsheet.Extensions
{
    public class SpreadsheetDocumentExtensionsTests
    {
        #region ConvertToTableList() Tests



        #endregion

        #region ConvertToDataTable() Tests

        [Fact]
        public void ConvertToDataTable_NullSheetName_Exception()
        {
            ArgumentNullException actual;
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                actual = Assert.Throws<ArgumentNullException>(() => document.ConvertToDataTable(null));
            }
        }

        [Fact]
        public void ConvertToDataTable_EmptySheetName_Exception()
        {
            ArgumentNullException actual;
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                actual = Assert.Throws<ArgumentNullException>(() => document.ConvertToDataTable(string.Empty));
            }
        }

        [Fact]
        public void ConvertToDataTable_WhitespaceSheetName_Exception()
        {
            ArgumentNullException actual;
            using (var stream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                actual = Assert.Throws<ArgumentNullException>(() => document.ConvertToDataTable(" "));
            }
        }

        [Fact]
        public void ConvertToDataTable_NoHeadersNoGaps_DataTable()
        {
            void AppendCells(SheetData sheetData)
            {
                var row = new Row();
                row.AppendChild(new Cell { CellReference = "A1", DataType = CellValues.String, CellValue = new CellValue("A,1") });
                row.AppendChild(new Cell { CellReference = "B1", DataType = CellValues.String, CellValue = new CellValue("B,1") });
                row.AppendChild(new Cell { CellReference = "C1", DataType = CellValues.String, CellValue = new CellValue("C,1") });
                sheetData.AppendChild(row);
            }

            using (var stream = new MemoryStream())
            using (var document = this.GetDocument(stream, AppendCells))
            {
                var result = document.ConvertToDataTable("Sheet1");
                Assert.Equal("Sheet1", result.Name);
                Assert.Equal(1, result.Rows.Count);
                Assert.Equal(3, result.Columns.Count);
                Assert.Equal("C,1", result.Rows[0][2].ToString());
            }
        }

        [Fact]
        public void ConvertToDataTable_Headers_DataTable()
        {
            void AppendCells(SheetData sheetData)
            {
                var headerRow = new Row();
                headerRow.AppendChild(new Cell { CellReference = "A1", DataType = CellValues.String, CellValue = new CellValue("A,1") });
                headerRow.AppendChild(new Cell { CellReference = "B1", DataType = CellValues.String, CellValue = new CellValue("B,1") });
                headerRow.AppendChild(new Cell { CellReference = "C1", DataType = CellValues.String, CellValue = new CellValue("C,1") });
                sheetData.AppendChild(headerRow);

                var row = new Row();
                row.AppendChild(new Cell { CellReference = "A2", DataType = CellValues.String, CellValue = new CellValue("A,2") });
                row.AppendChild(new Cell { CellReference = "B2", DataType = CellValues.String, CellValue = new CellValue("B,2") });
                row.AppendChild(new Cell { CellReference = "C2", DataType = CellValues.String, CellValue = new CellValue("C,2") });
                sheetData.AppendChild(row);
            }

            using (var stream = new MemoryStream())
            using (var document = this.GetDocument(stream, AppendCells))
            {
                var headerRowCount = 1;
                var result = document.ConvertToDataTable("Sheet1", headerRowCount);
                Assert.Equal("Sheet1", result.Name);
                Assert.Equal(1, result.Rows.Count);
                Assert.Equal(3, result.Columns.Count);
                Assert.Equal("C,2", result.Rows[0][2].ToString());
            }
        }
        
        [Fact]
        public void ConvertToDataTable_Gaps_DataTable()
        {
            void AppendCells(SheetData sheetData)
            {
                var row = new Row();
                row.AppendChild(new Cell { CellReference = "A1", DataType = CellValues.String, CellValue = new CellValue("A,1") });
                row.AppendChild(new Cell { CellReference = "C1", DataType = CellValues.String, CellValue = new CellValue("C,1") });
                sheetData.AppendChild(row);
            }

            using (var stream = new MemoryStream())
            using (var document = this.GetDocument(stream, AppendCells))
            {
                var result = document.ConvertToDataTable("Sheet1");
                Assert.Equal("Sheet1", result.Name);
                Assert.Equal(1, result.Rows.Count);
                Assert.Equal(3, result.Columns.Count);
                Assert.Equal("C,1", result.Rows[0][2].ToString());
            }
        }
        
        #endregion       

        private SpreadsheetDocument GetDocument(MemoryStream stream, Action<SheetData> appendCells)
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
