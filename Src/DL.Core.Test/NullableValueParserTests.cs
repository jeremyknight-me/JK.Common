using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test
{
    [TestClass]
    public class NullableValueParserTests
    {
        private NullableValueParser target;

        [TestInitialize]
        public void TestInitialize()
        {
            this.target = new NullableValueParser();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.target = null;
        }

        #region GetNullableDecimal() Tests

        [TestMethod]
        public void GetNullableDecimal_Null_Null()
        {
            var actual = this.target.GetNullableDecimal(null);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableDecimal_Empty_Null()
        {
            var actual = this.target.GetNullableDecimal(string.Empty);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableDecimal_Whitespace_Null()
        {
            var actual = this.target.GetNullableDecimal("   ");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableDecimal_Alpha_Null()
        {
            var actual = this.target.GetNullableDecimal("abc");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableDecimal_Integer_Number()
        {
            var actual = this.target.GetNullableDecimal("123");
            Assert.IsNotNull(actual);
            Assert.AreEqual(123m, actual.Value);
        }

        [TestMethod]
        public void GetNullableDecimal_Decimal_Number()
        {
            var actual = this.target.GetNullableDecimal("123.456");
            Assert.IsNotNull(actual);
            Assert.AreEqual(123.456m, actual.Value);
        }

        #endregion

        #region GetNullableInteger() Tests

        [TestMethod]
        public void GetNullableInteger_Null_Null()
        {
            var actual = this.target.GetNullableInteger(null);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableInteger_Empty_Null()
        {
            var actual = this.target.GetNullableInteger(string.Empty);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableInteger_Whitespace_Null()
        {
            var actual = this.target.GetNullableInteger("   ");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableInteger_Alpha_Null()
        {
            var actual = this.target.GetNullableInteger("abc");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableInteger_Decimal_Null()
        {
            var actual = this.target.GetNullableInteger("123.456");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNullableInteger_Integer_Number()
        {
            var actual = this.target.GetNullableInteger("123");
            Assert.IsNotNull(actual);
            Assert.AreEqual(123, actual.Value);
        }      

        #endregion
    }
}
