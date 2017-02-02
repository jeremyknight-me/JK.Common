using DL.Common.Specifications.UnitedStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications.UnitedStates
{
    [TestClass]
    public class PhoneNumberSpecificationTests
    {
        private PhoneNumberSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new PhoneNumberSpecification();
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
