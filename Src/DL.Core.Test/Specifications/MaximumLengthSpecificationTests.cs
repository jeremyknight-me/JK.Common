using DL.Core.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Specifications
{
    [TestClass]
    public class MaximumLengthSpecificationTests
    {
        private MaximumLengthSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new MaximumLengthSpecification(20);
        }

        [TestMethod]
        public void IsSatisfiedBy_LessThanMax_ReturnsTrue()
        {
            string stringToValidate = string.Empty.PadRight(15);
            bool actual = this.specification.IsSatisfiedBy(stringToValidate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_EqualToMax_ReturnsTrue()
        {
            string stringToValidate = string.Empty.PadRight(20);
            bool actual = this.specification.IsSatisfiedBy(stringToValidate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_GreaterThanMax_ReturnsTrue()
        {
            string stringToValidate = string.Empty.PadRight(25);
            bool actual = this.specification.IsSatisfiedBy(stringToValidate);
            Assert.IsFalse(actual);
        }
    }
}
