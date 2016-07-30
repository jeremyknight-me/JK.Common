using DL.Core.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Specifications
{
    [TestClass]
    public class NotEmptySpecificationTests
    {
        private NotEmptySpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new NotEmptySpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_Empty_ReturnsFalse()
        {
            string target = string.Empty;
            bool actual = this.specification.IsSatisfiedBy(target);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Null_ReturnsFalse()
        {
            string target = null;
            bool actual = this.specification.IsSatisfiedBy(target);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Whitespace_ReturnsFalse()
        {
            const string target = "  ";
            bool actual = this.specification.IsSatisfiedBy(target);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ContainsText_ReturnsTrue()
        {
            const string target = "something";
            bool actual = this.specification.IsSatisfiedBy(target);
            Assert.IsTrue(actual);
        }
    }
}
