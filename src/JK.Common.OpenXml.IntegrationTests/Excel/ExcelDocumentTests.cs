using System;
using JK.Common.OpenXml.Excel;
using Xunit;

namespace JK.Common.OpenXml.IntegrationTests.Excel
{
    public class ExcelDocumentTests
    {
        [Fact]
        public void Load_Tests()
        {
            var path = this.GetPath();
            using var doc = new ExcelDocument(path);
            Assert.NotNull(doc);
            Assert.IsType<ExcelDocument>(doc);
        }

        [Fact]
        public void GetDataTableBySheetName_Test()
        {
            var path = this.GetPath();
            using var doc = new ExcelDocument(path);
            var table = doc.GetDataTableBySheetName("MySheet", 1);
            Assert.Equal(7, table.Columns.Count);
            Assert.Equal(43, table.Rows.Count); // turns off header row
        }

        [Fact]
        public void GetDataSet_Test()
        {
            var path = this.GetPath();
            using var doc = new ExcelDocument(path);
            var set = doc.GetDataSet();
            Assert.Single(set.Tables);
            var table = set.Tables[0];
            Assert.Equal(7, table.Columns.Count);
            Assert.Equal(44, table.Rows.Count); // includes header row
        }

        private string GetPath()
        {
            var current = Environment.CurrentDirectory;
            var path = System.IO.Path.Combine(current, "sample.xlsx");
            return path;
        }
    }
}
