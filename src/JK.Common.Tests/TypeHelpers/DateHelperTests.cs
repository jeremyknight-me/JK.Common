using System;
using System.Collections.Generic;
using JK.Common.TypeHelpers;
using Xunit;

namespace JK.Common.Tests.TypeHelpers
{
    public class DateHelperTests
    {
        [Theory]
        [InlineData("2019-09-16", 5, 23)] // start on monday
        [InlineData("2019-09-16", 4, 20)]
        [InlineData("2019-09-16", -5, 9)]
        public void AddWorkDays_Theories(string startDay, int daysToAdd, int expectedDay)
        {
            var original = DateTime.Parse(startDay);
            var actual = DateHelper.AddWorkDays(original, daysToAdd);
            Assert.Equal(expectedDay, actual.Day);
        }

        [Theory]
        [InlineData(29, "1983-03-15", "2012-06-12")]
        [InlineData(8,  "2000-02-29", "2009-02-28")] // leap year not reached
        [InlineData(9,  "2000-02-29", "2009-03-01")] // leap year reached
        public void CalculateAge_Theories(int expected, string birthday, string now)
        {
            var birthdayDate = DateTime.Parse(birthday);
            var nowDate = DateTime.Parse(now);
            var actual = DateHelper.CalculateAge(nowDate, birthdayDate);
            Assert.Equal(expected, actual);
        }

        #region DoesOverlap() Tests

        [Theory]
        [MemberData(nameof(DoesOverlap_Data))]
        public void DoesOverlap_Theories(bool expected, DateTime startOne, DateTime endOne, DateTime startTwo, DateTime endTwo)
        {
            var actual = DateHelper.DoesOverlap(startOne, endOne, startTwo, endTwo);
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
            var actual = DateHelper.IsBetween(date, start, end);
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
        [InlineData(false, "1700-01-18")]
        [InlineData(true, "2011-01-15")]
        public void IsSqlDate_Theories(bool expected, string dateInput)
        {
            var date = DateTime.Parse(dateInput);
            var actual = DateHelper.IsSqlDate(date);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true,  "2011-01-18")] // Tuesday Jan 18, 2011
        [InlineData(false, "2011-01-15")] // Saturday Jan 15, 2011
        public void IsWeekday_Theories(bool expected, string dateInput)
        {
            var date = DateTime.Parse(dateInput);
            Assert.Equal(expected, DateHelper.IsWeekday(date));
            Assert.Equal(!expected, DateHelper.IsWeekend(date));
        }
    }
}
