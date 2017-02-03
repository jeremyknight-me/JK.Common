using DL.Common.TypeHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.TypeHelpers
{
    [TestClass]
    public class StringUtilityTests
    {
        private StringHelper target;

        [TestInitialize]
        public void TestInitialize()
        {
            this.target = new StringHelper();
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

        #region RemoveUSCurrencyFormat() Tests

        [TestMethod]
        public void RemoveUnitedStatesCurrencyFormat_WithCharacters()
        {
            const string currency = "$1,000,000.00";
            string actual = this.target.RemoveUnitedStatesCurrencyFormat(currency);
            Assert.AreEqual("1000000.00", actual);
        }

        [TestMethod]
        public void RemoveUnitedStatesCurrencyFormat_WithoutCharacters()
        {
            const string currency = "1000.00";
            string actual = this.target.RemoveUnitedStatesCurrencyFormat(currency);
            Assert.AreEqual("1000.00", actual);
        }

        [TestMethod]
        public void RemoveUnitedStatesCurrencyFormat_WithOnlyFormatting()
        {
            const string currency = "$,";
            string actual = this.target.RemoveUnitedStatesCurrencyFormat(currency);
            Assert.AreEqual("0", actual);
        }

        #endregion

        #region Reverse() Tests

        [TestMethod]
        public void Reverse_Test()
        {
            const string s = "Sample Text";
            string actual = this.target.Reverse(s);
            Assert.AreEqual("txeT elpmaS", actual);
        }

        #endregion

        #region StripXml() Tests

        /// <summary>
        /// A test for StringXML() that ensures XML/HTML tags are removed.
        /// </summary>
        [TestMethod]
        public void StripXml_Test()
        {
            const string s = "<xml>Inner Text</xml>";
            string actual = this.target.StripXml(s);
            Assert.AreEqual("Inner Text", actual);
        }

        #endregion  
    }
}
