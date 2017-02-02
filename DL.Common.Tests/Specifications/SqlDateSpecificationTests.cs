using System;
using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class SqlDateSpecificationTests
    {
        private SqlDateSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new SqlDateSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_LessThan1753_ReturnsFalse()
        {
            var date = new DateTime(1752, 12, 31);
            bool actual = this.specification.IsSatisfiedBy(date);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_EqualTo1753_ReturnsTrue()
        {
            var date = new DateTime(1753, 1, 1);
            bool actual = this.specification.IsSatisfiedBy(date);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_GreaterThan1753_ReturnsTrue()
        {
            var date = new DateTime(1754, 1, 1);
            bool actual = this.specification.IsSatisfiedBy(date);
            Assert.IsTrue(actual);
        }
    }
}
