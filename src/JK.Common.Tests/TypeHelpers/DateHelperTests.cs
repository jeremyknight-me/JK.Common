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
        [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
        [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
        [InlineData(true, "2020-10-26 12:00:00", "2020-10-26 11:59:59", "2020-10-26 12:00:01")]
        [InlineData(false, "2020-10-26 11:59:58", "2020-10-26 11:59:59", "2020-10-26 12:00:01")]
        public void IsBetween_DateTime_Theories(bool expected, string date, string start, string end)
        {
            var actual = DateHelper.IsBetween(DateTime.Parse(date), DateTime.Parse(start), DateTime.Parse(end));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
        [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
        [InlineData(true, "2020-10-26 12:00:00-04:00", "2020-10-26 11:59:59-04:00", "2020-10-26 12:00:01-04:00")]
        [InlineData(false, "2020-10-26 11:59:58-04:00", "2020-10-26 11:59:59-04:00", "2020-10-26 12:00:01-04:00")]
        [InlineData(true, "2020-10-26 12:00:00-05:00", "2020-10-26 11:59:59-04:00", "2020-10-26 12:00:01-06:00")]
        [InlineData(false, "2020-10-26 11:59:58-04:00", "2020-10-26 11:59:59-05:00", "2020-10-26 12:00:01-05:00")]
        public void IsBetween_DateTimeOffset_Theories(bool expected, string date, string start, string end)
        {
            var actual = DateHelper.IsBetween(DateTimeOffset.Parse(date), DateTimeOffset.Parse(start), DateTimeOffset.Parse(end));
            Assert.Equal(expected, actual);
        }

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
