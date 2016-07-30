using DL.Core.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Specifications
{
    [TestClass]
    public class USSocialSecurityNumberSpecificationTests
    {
        private USSocialSecurityNumberSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new USSocialSecurityNumberSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidNoFormatting_ReturnsTrue()
        {
            const string ssn = "078051120";
            bool actual = this.specification.IsSatisfiedBy(ssn);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidWithSpaces_ReturnsTrue()
        {
            const string ssn = "078 05 1120";
            bool actual = this.specification.IsSatisfiedBy(ssn);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidWithDashes_ReturnsTrue()
        {
            const string ssn = "078-05-1120";
            bool actual = this.specification.IsSatisfiedBy(ssn);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidNoFormatting_ReturnsFalse()
        {
            const string ssn = "000000000";
            bool actual = this.specification.IsSatisfiedBy(ssn);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidWithSpaces_ReturnsFalse()
        {
            const string ssn = "000 00 0000";
            bool actual = this.specification.IsSatisfiedBy(ssn);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidWithDashes_ReturnsFalse()
        {
            const string ssn = "000-00-0000";
            bool actual = this.specification.IsSatisfiedBy(ssn);
            Assert.IsFalse(actual);
        }
    }
}
