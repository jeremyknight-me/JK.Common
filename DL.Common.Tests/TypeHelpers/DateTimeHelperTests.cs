using System;
using DL.Common.TypeHelpers;
using Xunit;

namespace DL.Common.Tests.TypeHelpers
{
    public class DateTimeUtilityTests
    {
        #region CalculateAge() Tests

        [Fact]
        public void CalculateAge_Test()
        {
            var birthday = new DateTime(1983, 3, 15);
            var from = new DateTime(2012, 6, 12);
            var utility = new DateTimeHelper();
            int actual = utility.CalculateAge(from, birthday);
            Assert.Equal(29, actual);
        }

        [Fact]
        public void CalculateAge_LeapYearNotReached()
        {
            var birthday = new DateTime(2000, 2, 29);
            var now = new DateTime(2009, 2, 28);
            var utility = new DateTimeHelper();
            int actual = utility.CalculateAge(now, birthday);
            Assert.Equal(8, actual);
        }

        [Fact]
        public void CalculateAge_LeapYearReached()
        {
            var birthday = new DateTime(2000, 2, 29);
            var now = new DateTime(2009, 3, 1);
            var utility = new DateTimeHelper();
            int actual = utility.CalculateAge(now, birthday);
            Assert.Equal(9, actual);
        }

        #endregion

        #region IsWeekday Tests

        [Fact]
        public void IsWeekday_Weekday_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 18); // Tuesday Jan 18, 2011
            var utility = new DateTimeHelper();
            bool actual = utility.IsWeekday(testDate);
            Assert.True(actual);
        }

        [Fact]
        public void IsWeekday_NotWeekday_ReturnsFalse()
        {
            var testDate = new DateTime(2011, 1, 15); // Saturday Jan 15, 2011
            var utility = new DateTimeHelper();
            bool actual = utility.IsWeekday(testDate);
            Assert.False(actual);
        }

        #endregion

        #region IsWeekend Tests

        [Fact]
        public void IsWeekend_Weekend_ReturnsTrue()
        {
            var testDate = new DateTime(2011, 1, 15); // Saturday Jan 15, 2011
            var utility = new DateTimeHelper();
            bool actual = utility.IsWeekend(testDate);
            Assert.True(actual);
        }

        [Fact]
        public void IsWeekend_NotWeekend_ReturnsFalse()
        {
            var testDate = new DateTime(2011, 1, 18); // Tuesday Jan 18, 2011
            var utility = new DateTimeHelper();
            bool actual = utility.IsWeekend(testDate);
            Assert.False(actual);
        }

        #endregion
    }
}
