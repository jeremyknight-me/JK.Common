using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class ZipCodeSpecificationTests
    {
        private ZipCodeSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new ZipCodeSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_5ValidCharacters_ReturnsTrue()
        {
            const string zipcode = "12345";
            bool actual = this.specification.IsSatisfiedBy(zipcode);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_5CharactersWithInvalid_ReturnsFalse()
        {
            const string zipcode = "12X45";
            bool actual = this.specification.IsSatisfiedBy(zipcode);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_9ValidCharacters_ReturnsTrue()
        {
            const string zipcode = "12345-6789";
            bool actual = this.specification.IsSatisfiedBy(zipcode);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_9CharactersWithInvalidInFirstSection_ReturnsFalse()
        {
            const string zipcode = "12X45-6789";
            bool actual = this.specification.IsSatisfiedBy(zipcode);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_9CharactersWithInvalidInSecondSection_ReturnsFalse()
        {
            const string zipcode = "12345-67X9";
            bool actual = this.specification.IsSatisfiedBy(zipcode);
            Assert.IsFalse(actual);
        }
    }
}
