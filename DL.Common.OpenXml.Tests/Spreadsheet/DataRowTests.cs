using System;
using DL.Common.OpenXml.Spreadsheet;
using Xunit;

namespace DL.Common.OpenXml.Tests.Spreadsheet
{
    public class DataRowTests
    {
        #region String Indexer Tests

        [Fact]
        public void StringIndexer_GetNotFound_Exception()
        {
            var sut = new DataRow(new DataTable());
            var ex = Assert.Throws<IndexOutOfRangeException>(() => sut["unknown"]);
        }

        [Fact]
        public void StringIndexer_SetNotFound_Exception()
        {
            var sut = new DataRow(new DataTable());
            var ex = Assert.Throws<IndexOutOfRangeException>(() => sut["unknown"] = "test");
        }

        [Fact]
        public void StringIndexer_Found_Value()
        {
            var table = new DataTable();
            table.NewColumn("known");
            var sut = new DataRow(table);
            sut["known"] = "test";
            var result = sut["known"];
            Assert.Equal("test", result);
        }

        #endregion

        #region Int Indexer Tests

        [Fact]
        public void IntIndexer_GetNotFound_Exception()
        {
            var sut = new DataRow(new DataTable());
            var ex = Assert.Throws<IndexOutOfRangeException>(() => sut[3]);
        }

        [Fact]
        public void IntIndexer_SetNotFound_Exception()
        {
            var sut = new DataRow(new DataTable());
            var ex = Assert.Throws<IndexOutOfRangeException>(() => sut[3] = "test");
        }

        [Fact]
        public void IntIndexer_Found_Value()
        {
            var table = new DataTable();
            table.NewColumn("known");
            var sut = new DataRow(table);
            sut[0] = "test";
            var result = sut[0];
            Assert.Equal("test", result);
        }

        #endregion
    }
}
