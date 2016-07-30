using System;
using DL.Core.TypeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.TypeExtensions
{
    [TestClass]
    public class DateTimeUtilityTests
    {
        #region CalculateAge() Tests

        [TestMethod]
        public void CalculateAge_Test()
        {
            var birthday = new DateTime(1983, 3, 15);
            var from = new DateTime(2012, 6, 12);
            var utility = new DateTimeUtility();
            int actual = utility.CalculateAge(from, birthday);
            Assert.AreEqual(29, actual);
        }

        [TestMethod]
        public void CalculateAge_LeapYearNotReached()
        {
            var birthday = new DateTime(2000, 2, 29);
            var now = new DateTime(2009, 2, 28);
            var utility = new DateTimeUtility();
            int actual = utility.CalculateAge(now, birthday);
            Assert.AreEqual(8, actual);
        }

        [TestMethod]
        public void CalculateAge_LeapYearReached()
        {
            var birthday = new DateTime(2000, 2, 29);
            var now = new DateTime(2009, 3, 1);
            var utility = new DateTimeUtility();
            int actual = utility.CalculateAge(now, birthday);
            Assert.AreEqual(9, actual);
        }

        #endregion

        #region IsWeekday Tests

        [TestMethod]
        public void IsWeekday_Weekday_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 18); // Tuesday Jan 18, 2011
            var utility = new DateTimeUtility();
            bool actual = utility.IsWeekday(testDate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsWeekday_NotWeekday_ReturnsFalse()
        {
            var testDate = new DateTime(2011, 1, 15); // Saturday Jan 15, 2011
            var utility = new DateTimeUtility();
            bool actual = utility.IsWeekday(testDate);
            Assert.IsFalse(actual);
        }

        #endregion

        #region IsWeekend Tests

        [TestMethod]
        public void IsWeekend_Weekend_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 15); // Saturday Jan 15, 2011
            var utility = new DateTimeUtility();
            bool actual = utility.IsWeekend(testDate);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsWeekend_NotWeekend_ReturnsFalse()
        {
            var testDate = new DateTime(2011, 1, 18); // Tuesday Jan 18, 2011
            var utility = new DateTimeUtility();
            bool actual = utility.IsWeekend(testDate);
            Assert.IsFalse(actual);
        }

        #endregion
    }
}
