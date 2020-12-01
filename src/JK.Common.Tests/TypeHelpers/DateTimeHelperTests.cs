using System;
using System.Collections.Generic;
using JK.Common.TypeHelpers;
using Xunit;

namespace JK.Common.Tests.TypeHelpers
{
    public class DateTimeHelperTests
    {
        [Theory]
        [InlineData(16, 5, 23)] // start on monday
        [InlineData(16, 4, 20)]
        [InlineData(16, -5, 9)]
        public void AddWorkDays_Theories(int startDay, int daysToAdd, int expectedDay)
        {
            var original = new DateTime(2019, 9, startDay); // monday
            var helper = new DateTimeHelper();
            var actual = helper.AddWorkDays(original, daysToAdd);
            Assert.Equal(expectedDay, actual.Day);
        }

        [Theory]
        [InlineData(29, 1983, 3, 15, 2012, 6, 12)]
        [InlineData(8, 2000, 2, 29, 2009, 2, 28)] // leap year not reached
        [InlineData(9, 2000, 2, 29, 2009, 3, 1)] // leap year reached
        public void CalculateAge_Theories(int expected, int bdayYear, int bdayMonth, int bdayDay, int nowYear, int nowMonth, int nowDay)
        {
            var birthday = new DateTime(bdayYear, bdayMonth, bdayDay);
            var now = new DateTime(nowYear, nowMonth, nowDay);
            var sut = new DateTimeHelper();
            int actual = sut.CalculateAge(now, birthday);
            Assert.Equal(expected, actual);
        }


        #region DoesOverlap() Tests

        [Theory]
        [MemberData(nameof(DoesOverlap_Data))]
        public void DoesOverlap_Theories(bool expected, DateTime startOne, DateTime endOne, DateTime startTwo, DateTime endTwo)
        {
            var sut = new DateTimeHelper();
            var actual = sut.DoesOverlap(startOne, endOne, startTwo, endTwo);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> DoesOverlap_Data =>
            new List<object[]>
            {
                new object[] { true, new DateTime(2020, 10, 1), new DateTime(2020, 10, 31), new DateTime(2020, 10, 20), new DateTime(2020, 11, 30) },
                new object[] { false, new DateTime(2020, 10, 1), new DateTime(2020, 10, 31), new DateTime(2020, 11, 1), new DateTime(2020, 11, 30) }
            };

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

        [Theory]
        [InlineData(true, 2011, 1, 18)] // Tuesday Jan 18, 2011
        [InlineData(false, 2011, 1, 15)] // Saturday Jan 15, 2011
        public void IsWeekday_Theories(bool expected, int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var sut = new DateTimeHelper();
            var actual = sut.IsWeekday(date);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, 2011, 1, 18)] // Tuesday Jan 18, 2011
        [InlineData(true, 2011, 1, 15)] // Saturday Jan 15, 2011
        public void IsWeekend_Theories(bool expected, int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var sut = new DateTimeHelper();
            var actual = sut.IsWeekend(date);
            Assert.Equal(expected, actual);
        }
    }
}
