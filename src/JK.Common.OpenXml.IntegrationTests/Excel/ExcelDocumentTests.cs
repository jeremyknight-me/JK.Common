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
            using var doc = ExcelDocument.Load(path);
            Assert.NotNull(doc);
            Assert.IsType<ExcelDocument>(doc);
        }

        private string GetPath()
        {
            var current = Environment.CurrentDirectory;
            var path = System.IO.Path.Combine(current, "sample.xlsx");
            return path;
        }
    }
}
