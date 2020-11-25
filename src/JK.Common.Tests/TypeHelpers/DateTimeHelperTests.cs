using System;
using System.Collections.Generic;
using JK.Common.TypeHelpers;
using Xunit;

namespace JK.Common.Tests.TypeHelpers
{
    public class DateTimeHelperTests
    {
        #region AddWorkDays() Tests

        [Theory]
        [InlineData(16, 5, 23)] // start on monday
        [InlineData(16, 4, 20)]
        [InlineData(16, -5, 9)]
        public void AddWorkDays_Tests(int startDay, int daysToAdd, int expectedDay)
        {
            var original = new DateTime(2019, 9, startDay); // monday
            var helper = new DateTimeHelper();
            var actual = helper.AddWorkDays(original, daysToAdd);
            Assert.Equal(expectedDay, actual.Day);
        }

        #endregion

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

        #region IsBetween() Tests

        [Theory]
        [MemberData(nameof(IsBetween_Data))]
        public void IsBetween_Theories(bool expected, DateTime date, DateTime start, DateTime end)
        {
            var sut = new DateTimeHelper();
            var actual = sut.IsBetween(date, start, end);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> IsBetween_Data =>
            new List<object[]>
            {
                new object[] { true, new DateTime(2020, 10, 26), new DateTime(2020, 10, 20), new DateTime(2020, 10, 30) },
                new object[] { false, new DateTime(2020, 10, 15), new DateTime(2020, 10, 20), new DateTime(2020, 10, 30) },
                new object[] { true, new DateTime(2020, 10, 26, 12, 0, 0), new DateTime(2020, 10, 26, 11, 59, 59), new DateTime(2020, 10, 26, 12, 0, 1) },
                new object[] { false, new DateTime(2020, 10, 26, 11, 59, 58), new DateTime(2020, 10, 26, 11, 59, 59), new DateTime(2020, 10, 26, 12, 0, 1) }
            };

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
