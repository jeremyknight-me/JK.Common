using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class LongitudeSpecificationTests
    {
        private LongitudeSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new LongitudeSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_LessThanNegative180_ReturnsFalse()
        {
            const decimal longitudeToTest = -181;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_EqualToNegative180_ReturnsTrue()
        {
            const decimal longitudeToTest = -180;
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
        public void IsSatisfiedBy_EqualTo180_ReturnsTrue()
        {
            const decimal longitudeToTest = 180;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_GreaterThan180_ReturnsFalse()
        {
            const decimal longitudeToTest = 181;
            bool actual = this.specification.IsSatisfiedBy(longitudeToTest);
            Assert.IsFalse(actual);
        }
    }
}
