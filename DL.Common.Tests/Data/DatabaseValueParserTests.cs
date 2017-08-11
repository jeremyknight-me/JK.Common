using System;
using DL.Common.Data;
using Xunit;

namespace DL.Common.Tests.Data
{
    public class DatabaseValueParserTests
    {
        #region GetValueOrDefault() Tests

        [Fact]
        public void GetValueOrDefault_DbNullInt()
        {
            object target = DBNull.Value;
            int actual = DatabaseValueParser.GetValueOrDefault<int>(target);
            Assert.Equal(0, actual);
        }

        [Fact]
        public void GetValueOrDefault_NonDbNullInt()
        {
            object target = 123;
            int actual = DatabaseValueParser.GetValueOrDefault<int>(target);
            Assert.Equal(123, actual);
        }

        #endregion

        #region GetValueOrNull() Tests

        [Fact]
        public void GetValueOrNull_NullString()
        {
            string target = null;
            string actual = DatabaseValueParser.GetValueOrNull<string>(target);
            Assert.Null(actual);
        }

        [Fact]
        public void GetValueOrNull_NonNullString()
        {
            string actual = DatabaseValueParser.GetValueOrNull<string>("abc123");
            Assert.Equal("abc123", actual);
        }

        #endregion
    }
}
