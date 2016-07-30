using DL.Core.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Specifications
{
    [TestClass]
    public class DateTimeSpecificationTests
    {
        private DateTimeSpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new DateTimeSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidDate_ReturnsFalse()
        {
            const string datestamp = "hello world";
            bool actual = this.specification.IsSatisfiedBy(datestamp);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Format01_ReturnsTrue()
        {
            const string datestamp = "2008-05-01 7:34:42Z";
            bool actual = this.specification.IsSatisfiedBy(datestamp);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Format02_ReturnsTrue()
        {
            const string datestamp = "2008-05-01T07:34:42-5:00";
            bool actual = this.specification.IsSatisfiedBy(datestamp);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Format03_ReturnsTrue()
        {
            const string datestamp = "Thu, 01 May 2008 07:34:42 GMT";
            bool actual = this.specification.IsSatisfiedBy(datestamp);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Format04_ReturnsTrue()
        {
            const string datestamp = "2/16/2008 12:15:12 PM";
            bool actual = this.specification.IsSatisfiedBy(datestamp);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_Format05_ReturnsFalse()
        {
            const string datestamp = "16/02/2008 12:15:12";
            bool actual = this.specification.IsSatisfiedBy(datestamp);
            Assert.IsFalse(actual);
        }
    }
}
