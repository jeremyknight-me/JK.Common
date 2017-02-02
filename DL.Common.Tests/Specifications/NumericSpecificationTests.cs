using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class NumericSpecificationTests
    {
        private NumericSpecification target;

        [TestInitialize]
        public void TestInitialize()
        {
            this.target = new NumericSpecification();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.target = null;
        }

        [TestMethod]
        public void IsSatisfiedBy_Null_False()
        {
            var actual = this.target.IsSatisfiedBy(null);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Empty_False()
        {
            var actual = this.target.IsSatisfiedBy(string.Empty);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Whitespace_False()
        {
            var actual = this.target.IsSatisfiedBy("   ");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Alpha_False()
        {
            var actual = this.target.IsSatisfiedBy("abc");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Integer_True()
        {
            var actual = this.target.IsSatisfiedBy("123");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GetNullableDecimal_Decimal_Number()
        {
            var actual = this.target.IsSatisfiedBy("123.456");
            Assert.IsTrue(actual);
        }
    }
}
