using DL.Common.OpenXml.Spreadsheet;
using System;
using Xunit;

namespace DL.Common.OpenXml.Tests.Spreadsheet
{
    public class DataTableTests
    {
        #region NewColumn(string) Tests

        [Fact]
        public void NewColumn_EmptyString_Exception()
        {
            var table = new DataTable();
            var ex = Assert.Throws<ArgumentNullException>(() => table.NewColumn(string.Empty));
        }

        [Fact]
        public void NewColumn_Whitespace_Exception()
        {
            var table = new DataTable();
            var ex = Assert.Throws<ArgumentNullException>(() => table.NewColumn(" "));
        }

        [Fact]
        public void NewColumn_DuplicateName_Null()
        {
            var table = new DataTable();
            table.NewColumn("test");
            var actual = table.NewColumn("test");
            Assert.Null(actual);
        }

        [Fact]
        public void NewColumn_Multiple_Object()
        {
            var table = new DataTable();
            var first = table.NewColumn("first");
            var second = table.NewColumn("second");
            Assert.Equal("first", first.Name);
            Assert.Equal(0, first.Index);
            Assert.Equal("second", second.Name);
            Assert.Equal(1, second.Index);
        }

        #endregion
    }
}
