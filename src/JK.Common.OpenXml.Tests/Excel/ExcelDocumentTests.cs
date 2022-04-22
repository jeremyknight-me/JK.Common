using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using JK.Common.OpenXml.Excel;
using Xunit;

namespace JK.Common.OpenXml.Tests.Excel
{
    public class ExcelDocumentTests
    {
        #region GetDataTableBySheetName() Tests

        [Fact]
        public void ConvertToDataTable_NullSheetName_Exception()
        {
            ArgumentNullException actual;
            using var stream = new MemoryStream();
            using var spreadsheet = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            using var document = new ExcelDocument(spreadsheet);
            actual = Assert.Throws<ArgumentNullException>(() => document.GetDataTableBySheetName(null));
        }

        [Fact]
        public void ConvertToDataTable_EmptySheetName_Exception()
        {
            ArgumentNullException actual;
            using var stream = new MemoryStream();
            using var spreadsheet = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            using var document = new ExcelDocument(spreadsheet);
            actual = Assert.Throws<ArgumentNullException>(() => document.GetDataTableBySheetName(string.Empty));
        }

        [Fact]
        public void ConvertToDataTable_WhitespaceSheetName_Exception()
        {
            ArgumentNullException actual;
            using var stream = new MemoryStream();
            using var spreadsheet = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            using var document = new ExcelDocument(spreadsheet);
            actual = Assert.Throws<ArgumentNullException>(() => document.GetDataTableBySheetName(" "));
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

            using var stream = new MemoryStream();
            using var spreadsheet = MockSpreadsheetDocumentFactory.Make(stream, AppendCells);
            using var document = new ExcelDocument(spreadsheet);
            var result = document.GetDataTableBySheetName("Sheet1");
            Assert.Equal("Sheet1", result.TableName);
            Assert.Equal(1, result.Rows.Count);
            Assert.Equal(3, result.Columns.Count);
            Assert.Equal("C,1", result.Rows[0][2].ToString());
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

            var headerRowCount = 1;
            using var stream = new MemoryStream();
            using var spreadsheet = MockSpreadsheetDocumentFactory.Make(stream, AppendCells);
            using var document = new ExcelDocument(spreadsheet);
            var result = document.GetDataTableBySheetName("Sheet1", headerRowCount);
            Assert.Equal("Sheet1", result.TableName);
            Assert.Equal(1, result.Rows.Count);
            Assert.Equal(3, result.Columns.Count);
            Assert.Equal("C,2", result.Rows[0][2].ToString());
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

            using var stream = new MemoryStream();
            using var spreadsheet = MockSpreadsheetDocumentFactory.Make(stream, AppendCells);
            using var document = new ExcelDocument(spreadsheet);
            var result = document.GetDataTableBySheetName("Sheet1");
            Assert.Equal("Sheet1", result.TableName);
            Assert.Equal(1, result.Rows.Count);
            Assert.Equal(3, result.Columns.Count);
            Assert.Equal("C,1", result.Rows[0][2].ToString());
        }

        #endregion
    }
}
