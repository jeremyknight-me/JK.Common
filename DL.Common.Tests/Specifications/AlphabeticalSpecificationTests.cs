using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class AlphabeticalSpecificationTests
    {
        private AlphabeticalSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new AlphabeticalSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidCharacters_ReturnsTrue()
        {
            const string stringToValidate = "abc";
            bool actual = this.specification.IsSatisfiedBy(stringToValidate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidCharacters_ReturnsFalse()
        {
            const string stringToValidate = "asdf234";
            bool actual = this.specification.IsSatisfiedBy(stringToValidate);
            Assert.IsFalse(actual);
        }
    }
}
