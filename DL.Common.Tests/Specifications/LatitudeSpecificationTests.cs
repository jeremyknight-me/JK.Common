using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class LatitudeSpecificationTests
    {
        private LatitudeSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new LatitudeSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_LessThanNegative90_ReturnsFalse()
        {
            const decimal longitudeToTest = -91;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_EqualToNegative90_ReturnsTrue()
        {
            const decimal longitudeToTest = -90;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_BetweenNegative180And180_ReturnsTrue()
        {
            const decimal longitudeToTest = 0;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_EqualTo90_ReturnsTrue()
        {
            const decimal longitudeToTest = 90;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_GreaterThan90_ReturnsFalse()
        {
            const decimal longitudeToTest = 91;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsFalse(actual);
        }
    }
}
