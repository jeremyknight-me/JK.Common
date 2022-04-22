using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using JK.Common.OpenXml.Excel.Extensions;
using Xunit;

namespace JK.Common.OpenXml.Tests.Excel.Extensions;

public class CellExtensionsTests
{
    #region GetColumnIndex() Tests

    [Fact]
    public void GetColumnIndex_Initial_Exception()
    {
        var sut = new Cell();
        var ex = Assert.Throws<ArgumentException>(() => sut.GetColumnIndex());
    }

    [Fact]
    public void GetColumnIndex_Reference_Number()
    {
        var sut = new Cell { CellReference = "C2" };
        var result = sut.GetColumnIndex();
        Assert.Equal(2, result);
    }

    [Fact]
    public void GetColumnIndex_LargeReference_Number()
    {
        var sut = new Cell { CellReference = "BB2" };
        var result = sut.GetColumnIndex();
        Assert.Equal(53, result);
    }

    #endregion

    #region GetColumnName() Tests

    [Fact]
    public void GetColumnName_Initial_Exception()
    {
        var sut = new Cell();
        var ex = Assert.Throws<ArgumentException>(() => sut.GetColumnLetter());
    }

    [Fact]
    public void GetColumnName_Reference_Letter()
    {
        var sut = new Cell { CellReference = "B2" };
        var result = sut.GetColumnLetter();
        Assert.Equal("B", result);
    }

    #endregion

    #region GetColumnNumber() Tests

    [Fact]
    public void GetColumnNumber_Initial_Exception()
    {
        var sut = new Cell();
        var ex = Assert.Throws<ArgumentException>(() => sut.GetColumnNumber());
    }

    [Fact]
    public void GetColumnNumber_Reference_Number()
    {
        var sut = new Cell { CellReference = "C2" };
        var result = sut.GetColumnNumber();
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetColumnNumber_LargeReference_Number()
    {
        var sut = new Cell { CellReference = "BB2" };
        var result = sut.GetColumnNumber();
        Assert.Equal(54, result);
    }

    #endregion

    #region GetValue() Tests

    [Fact]
    public void GetValue_NullPart_Exception()
    {
        var sut = new Cell();
        var ex = Assert.Throws<ArgumentNullException>(() => sut.GetValue(null));
    }

    [Fact]
    public void GetValue_Initial_Empty()
    {
        var sut = new Cell();
        string result;
        using (var stream = new MemoryStream())
        using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
        {
            var workbookPart = document.AddWorkbookPart();
            result = sut.GetValue(workbookPart);
        }
        Assert.Equal("", result);
    }

    [Fact]
    public void GetValue_NonSharedString_CellValue()
    {
        var sut = new Cell { CellValue = new CellValue("test") };
        string result;
        using (var stream = new MemoryStream())
        using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
        {
            var workbookPart = document.AddWorkbookPart();
            result = sut.GetValue(workbookPart);
        }
        Assert.Equal("test", result);
    }

    [Fact]
    public void GetValue_Date_CellValue()
    {
        var sut = new Cell
        {
            CellValue = new CellValue("43012"),
            DataType = new EnumValue<CellValues>(CellValues.Date)
        };
        string result;
        using (var stream = new MemoryStream())
        using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
        {
            var workbookPart = document.AddWorkbookPart();
            result = sut.GetValue(workbookPart);
        }
        Assert.Equal("10/04/2017 00:00:00", result);
    }

    [Fact]
    public void GetValue_SharedString_SharedStringValue()
    {
        // ref: https://msdn.microsoft.com/en-us/library/office/cc861607.aspx
        var sut = new Cell
        {
            CellValue = new CellValue("0"),
            DataType = new EnumValue<CellValues>(CellValues.SharedString)
        };
        string result;
        using (var stream = new MemoryStream())
        using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
        {
            var workbookPart = document.AddWorkbookPart();

            var sharedStringTablePart = workbookPart.AddNewPart<SharedStringTablePart>();
            sharedStringTablePart.SharedStringTable = new SharedStringTable();
            workbookPart.SharedStringTablePart.SharedStringTable.AppendChild(new SharedStringItem(new Text("hello world")));
            workbookPart.SharedStringTablePart.SharedStringTable.Save();
            result = sut.GetValue(workbookPart);
        }
        Assert.Equal("hello world", result);
    }

    #endregion
}
