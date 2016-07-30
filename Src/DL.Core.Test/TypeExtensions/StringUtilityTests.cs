using DL.Core.TypeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.TypeExtensions
{
    [TestClass]
    public class StringUtilityTests
    {
        private StringUtility target;

        [TestInitialize]
        public void TestInitialize()
        {
            this.target = new StringUtility();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.target = null;
        }

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
