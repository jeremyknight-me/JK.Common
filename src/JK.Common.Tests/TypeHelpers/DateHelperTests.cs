using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class DateHelperTests
{
    #region AddWorkDays() Tests

    [Theory]
    [InlineData("2019-09-16", 5, 23)] // start on monday
    [InlineData("2019-09-16", 4, 20)]
    [InlineData("2019-09-16", -5, 9)]
    public void AddWorkDays_DateTime_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        var original = DateTime.Parse(startDay);
        var actual = DateHelper.AddWorkDays(original, daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }

    [Theory]
    [InlineData("2019-09-16", 5, 23)] // start on monday
    [InlineData("2019-09-16", 4, 20)]
    [InlineData("2019-09-16", -5, 9)]
    public void AddWorkDays_DateTimeOffset_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        var original = DateTimeOffset.Parse(startDay);
        var actual = DateHelper.AddWorkDays(original, daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }

    #endregion

    [Theory]
    [InlineData(29, "1983-03-15", "2012-06-12")]
    [InlineData(8, "2000-02-29", "2009-02-28")] // leap year not reached
    [InlineData(9, "2000-02-29", "2009-03-01")] // leap year reached
    public void CalculateAge_Theories(int expected, string birthday, string now)
    {
        var birthdayDate = DateTime.Parse(birthday);
        var nowDate = DateTime.Parse(now);
        var actual = DateHelper.CalculateAge(nowDate, birthdayDate);
        Assert.Equal(expected, actual);
    }

    #region DoesOverlap() Tests

    [Theory]
    [InlineData(true, "2020-10-01", "2020-10-31", "2020-10-20", "2020-11-30")]
    [InlineData(false, "2020-10-01", "2020-10-31", "2020-11-01", "2020-11-30")]
    public void DoesOverlap_DateTime_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateHelper.DoesOverlap(DateTime.Parse(startOne), DateTime.Parse(endOne), DateTime.Parse(startTwo), DateTime.Parse(endTwo));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "2020-10-01", "2020-10-31", "2020-10-20", "2020-11-30")]
    [InlineData(false, "2020-10-01", "2020-10-31", "2020-11-01", "2020-11-30")]
    public void DoesOverlap_DateTimeOffset_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateHelper.DoesOverlap(DateTimeOffset.Parse(startOne), DateTimeOffset.Parse(endOne), DateTimeOffset.Parse(startTwo), DateTimeOffset.Parse(endTwo));
        Assert.Equal(expected, actual);
    }

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
    [InlineData(true, "2011-01-18")] // Tuesday Jan 18, 2011
    [InlineData(false, "2011-01-15")] // Saturday Jan 15, 2011
    public void IsWeekday_Theories(bool expected, string dateInput)
    {
        var date = DateTime.Parse(dateInput);
        Assert.Equal(expected, DateHelper.IsWeekday(date));
        Assert.Equal(!expected, DateHelper.IsWeekend(date));
    }
}
