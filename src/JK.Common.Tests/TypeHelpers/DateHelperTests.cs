using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public  class DateHelperTests
{
    public class AddWorkDays
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void DateTime_Theories(string startDay, int daysToAdd, int expectedDay)
        {
            DateTime original = DateTime.Parse(startDay);
            DateTime actual = DateHelper.AddWorkDays(original, daysToAdd);
            Assert.Equal(expectedDay, actual.Day);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void DateTimeOffset_Theories(string startDay, int daysToAdd, int expectedDay)
        {
            DateTimeOffset original = DateTimeOffset.Parse(startDay);
            DateTimeOffset actual = DateHelper.AddWorkDays(original, daysToAdd);
            Assert.Equal(expectedDay, actual.Day);
        }

#if NET6_0_OR_GREATER
        [Theory]
        [MemberData(nameof(Data))]
        public void DateOnly_Theories(string startDay, int daysToAdd, int expectedDay)
        {
            DateOnly original = DateOnly.Parse(startDay);
            DateOnly actual = DateHelper.AddWorkDays(original, daysToAdd);
            Assert.Equal(expectedDay, actual.Day);
        }
#endif

        public static TheoryData<string, int, int> Data()
            => new()
            {
                { "2019-09-16", 5, 23 }, // start on monday
                { "2019-09-16", 4, 20 },
                { "2019-09-16", -5, 9 }
            };
    }

    public class CalculateAge
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void DateTime_Theories(int expected, string birthday, string now)
        {
            var birthdayDate = DateTime.Parse(birthday);
            var nowDate = DateTime.Parse(now);
            var actual = DateHelper.CalculateAge(nowDate, birthdayDate);
            Assert.Equal(expected, actual);
        }

#if NET6_0_OR_GREATER
        [Theory]
        [MemberData(nameof(Data))]
        public void DateOnly_Theories(int expected, string birthday, string now)
        {
            var birthdayDate = DateOnly.Parse(birthday);
            var nowDate = DateOnly.Parse(now);
            var actual = DateHelper.CalculateAge(nowDate, birthdayDate);
            Assert.Equal(expected, actual);
        }
#endif

        public static TheoryData<int, string, string> Data()
            => new()
            {
                { 29, "1983-03-15", "2012-06-12" },
                { 8, "2000-02-29", "2009-02-28" }, // leap year not reached
                { 9, "2000-02-29", "2009-03-01" } // leap year reached
            };
    }

    public class DoesOverlap
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void DateTime_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
        {
            var actual = DateHelper.DoesOverlap(DateTime.Parse(startOne), DateTime.Parse(endOne), DateTime.Parse(startTwo), DateTime.Parse(endTwo));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void DateTimeOffset_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
        {
            var actual = DateHelper.DoesOverlap(DateTimeOffset.Parse(startOne), DateTimeOffset.Parse(endOne), DateTimeOffset.Parse(startTwo), DateTimeOffset.Parse(endTwo));
            Assert.Equal(expected, actual);
        }

#if NET6_0_OR_GREATER
        [Theory]
        [MemberData(nameof(Data))]
        public void DateOnly_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
        {
            var actual = DateHelper.DoesOverlap(DateOnly.Parse(startOne), DateOnly.Parse(endOne), DateOnly.Parse(startTwo), DateOnly.Parse(endTwo));
            Assert.Equal(expected, actual);
        }
#endif

        public static TheoryData<bool, string, string, string, string> Data()
            => new()
            {
                { true, "2020-10-01", "2020-10-31", "2020-10-20", "2020-11-30" }, // Overlapping
                { false, "2020-10-01", "2020-10-31", "2020-11-01", "2020-11-30" } // Non-overlapping
            };
    }

    public class IsBetween
    {
        [Theory]
        [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
        [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
        [InlineData(true, "2020-10-26 12:00:00", "2020-10-26 11:59:59", "2020-10-26 12:00:01")]
        [InlineData(false, "2020-10-26 11:59:58", "2020-10-26 11:59:59", "2020-10-26 12:00:01")]
        public void DateTime_Theories(bool expected, string date, string start, string end)
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
        public void DateTimeOffset_Theories(bool expected, string date, string start, string end)
        {
            var actual = DateHelper.IsBetween(DateTimeOffset.Parse(date), DateTimeOffset.Parse(start), DateTimeOffset.Parse(end));
            Assert.Equal(expected, actual);
        }

#if NET6_0_OR_GREATER
        [Theory]
        [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
        [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
        public void DateOnly_Theories(bool expected, string date, string start, string end)
        {
            var actual = DateHelper.IsBetween(DateOnly.Parse(date), DateOnly.Parse(start), DateOnly.Parse(end));
            Assert.Equal(expected, actual);
        }
#endif
    }

    public class IsSqlDate
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void DateTime_Theories(bool expected, string dateInput)
        {
            var date = DateTime.Parse(dateInput);
            var actual = DateHelper.IsSqlDate(date);
            Assert.Equal(expected, actual);
        }

#if NET6_0_OR_GREATER
        [Theory]
        [MemberData(nameof(Data))]
        public void DateOnly_Theories(bool expected, string dateInput)
        {
            var date = DateOnly.Parse(dateInput);
            var actual = DateHelper.IsSqlDate(date);
            Assert.Equal(expected, actual);
        }
#endif

        public static TheoryData<bool, string> Data()
            => new()
            {
                { false, "1700-01-18" }, // Before SQL Server's minimum date
                { true, "2011-01-15" } // Within SQL Server's valid date range
            };
    }

    public class IsWeekday
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void DateTime_Theories(bool expected, string dateInput)
        {
            var date = DateTime.Parse(dateInput);
            Assert.Equal(expected, DateHelper.IsWeekday(date));
            Assert.Equal(!expected, DateHelper.IsWeekend(date));
        }

#if NET6_0_OR_GREATER
        [Theory]
        [MemberData(nameof(Data))]
        public void DateOnly_Theories(bool expected, string dateInput)
        {
            var date = DateOnly.Parse(dateInput);
            Assert.Equal(expected, DateHelper.IsWeekday(date));
            Assert.Equal(!expected, DateHelper.IsWeekend(date));
        }
#endif

        public static TheoryData<bool, string> Data()
            => new()
            {
                { true, "2011-01-18" }, // Tuesday Jan 18, 2011
                { false, "2011-01-15" } // Saturday Jan 15, 2011
            };
    }
}
