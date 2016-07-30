using DL.Core.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Specifications
{
    [TestClass]
    public class USPhoneNumberSpecificationTests
    {
        private USPhoneNumberSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new USPhoneNumberSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidWithAreaCodeWithNoFormatting_ReturnsTrue()
        {
            const string phone = "5555551234";
            bool actual = this.specification.IsSatisfiedBy(phone);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidWithAreaCodeParentheses_ReturnsTrue()
        {
            const string phone = "(555) 555-1234";
            bool actual = this.specification.IsSatisfiedBy(phone);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidWithAreaCodeHyphenated_ReturnsTrue()
        {
            const string phone = "555-555-1234";
            bool actual = this.specification.IsSatisfiedBy(phone);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidWithNoAreaCodeWithNoFormatting_ReturnsTrue()
        {
            const string phone = "5551234";
            bool actual = this.specification.IsSatisfiedBy(phone);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidWithNoAreaCode_ReturnsTrue()
        {
            const string phone = "555-1234";
            bool actual = this.specification.IsSatisfiedBy(phone);
            Assert.IsTrue(actual);
        }
    }
}
