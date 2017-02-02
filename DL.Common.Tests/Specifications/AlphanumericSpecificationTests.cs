using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class AlphanumericSpecificationTests
    {
        private AlphanumericSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new AlphanumericSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidCharacters_ReturnsTrue()
        {
            const string stringToValidate = "abc123";
            bool actual = this.specification.IsSatisfiedBy(stringToValidate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidCharacters_ReturnsFalse()
        {
            const string stringToValidate = "asdf234*@#asdf";
            bool actual = this.specification.IsSatisfiedBy(stringToValidate);
            Assert.IsFalse(actual);
        }
    }
}
