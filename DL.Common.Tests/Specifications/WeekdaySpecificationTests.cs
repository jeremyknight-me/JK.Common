using System;
using DL.Common.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Specifications
{
    [TestClass]
    public class WeekdaySpecificationTests
    {
        private WeekdaySpecification specification;

        [TestInitialize]
        public void TestInitialize()
        {
            this.specification = new WeekdaySpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_MondayDate_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 17); // Monday Jan 17, 2011
            bool actual = this.specification.IsSatisfiedBy(testDate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_TuesdayDate_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 18); // Tuesday Jan 18, 2011
            bool actual = this.specification.IsSatisfiedBy(testDate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_WednesdayDate_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 19); // Wednesday Jan 19, 2011
            bool actual = this.specification.IsSatisfiedBy(testDate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_ThursdayDate_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 20); // Thursday Jan 20, 2011
            bool actual = this.specification.IsSatisfiedBy(testDate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_FridayDate_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 21); // Friday Jan 21, 2011
            bool actual = this.specification.IsSatisfiedBy(testDate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_SaturdayDate_ReturnsFalse()
        {
            var testDate = new DateTime(2011, 1, 22); // Saturday Jan 22, 2011
            bool actual = this.specification.IsSatisfiedBy(testDate);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsSatisfiedBy_SundayDate_ReturnsFalse()
        {
            var testDate = new DateTime(2011, 1, 23); // Sunday Jan 23, 2011
            bool actual = this.specification.IsSatisfiedBy(testDate);
            Assert.IsFalse(actual);
        }
    }
}
