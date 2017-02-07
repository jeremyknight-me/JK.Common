using System;
using DL.Common.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Data
{
    /// <summary>
    /// Unit test class for DatabaseValueParser.
    /// </summary>
    [TestClass]
    public class DatabaseValueParserTests
    {
        #region GetValueOrDefault() Tests

        [TestMethod]
        public void GetValueOrDefault_DbNullInt()
        {
            object target = DBNull.Value;
            int actual = DatabaseValueParser.GetValueOrDefault<int>(target);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GetValueOrDefault_NonDbNullInt()
        {
            object target = 123;
            int actual = DatabaseValueParser.GetValueOrDefault<int>(target);
            Assert.AreEqual(123, actual);
        }

        #endregion

        #region GetValueOrNull() Tests

        [TestMethod]
        public void GetValueOrNull_NullString()
        {
            string target = null;
            string actual = DatabaseValueParser.GetValueOrNull<string>(target);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetValueOrNull_NonNullString()
        {
            string actual = DatabaseValueParser.GetValueOrNull<string>("abc123");
            Assert.AreEqual("abc123", actual);
        }

        #endregion
    }
}
