using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

#if (NET6_0_OR_GREATER)

public class DateHelperTests_DateOnly
{
    [Theory]
    [InlineData("2019-09-16", 5, 23)] // start on monday
    [InlineData("2019-09-16", 4, 20)]
    [InlineData("2019-09-16", -5, 9)]
    public void AddWorkDays_DateOnly_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        var original = DateOnly.Parse(startDay);
        var actual = DateHelper.AddWorkDays(original, daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }

    [Theory]
    [InlineData(29, "1983-03-15", "2012-06-12")]
    [InlineData(8, "2000-02-29", "2009-02-28")] // leap year not reached
    [InlineData(9, "2000-02-29", "2009-03-01")] // leap year reached
    public void CalculateAge_Theories(int expected, string birthday, string now)
    {
        var birthdayDate = DateOnly.Parse(birthday);
        var nowDate = DateOnly.Parse(now);
        var actual = DateHelper.CalculateAge(nowDate, birthdayDate);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "2020-10-01", "2020-10-31", "2020-10-20", "2020-11-30")]
    [InlineData(false, "2020-10-01", "2020-10-31", "2020-11-01", "2020-11-30")]
    public void DoesOverlap_DateOnly_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateHelper.DoesOverlap(DateOnly.Parse(startOne), DateOnly.Parse(endOne), DateOnly.Parse(startTwo), DateOnly.Parse(endTwo));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
    [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
    public void IsBetween_DateOnly_Theories(bool expected, string date, string start, string end)
    {
        var actual = DateHelper.IsBetween(DateOnly.Parse(date), DateOnly.Parse(start), DateOnly.Parse(end));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, "1700-01-18")]
    [InlineData(true, "2011-01-15")]
    public void IsSqlDate_Theories(bool expected, string dateInput)
    {
        var date = DateOnly.Parse(dateInput);
        var actual = DateHelper.IsSqlDate(date);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "2011-01-18")] // Tuesday Jan 18, 2011
    [InlineData(false, "2011-01-15")] // Saturday Jan 15, 2011
    public void IsWeekday_Theories(bool expected, string dateInput)
    {
        var date = DateOnly.Parse(dateInput);
        Assert.Equal(expected, DateHelper.IsWeekday(date));
        Assert.Equal(!expected, DateHelper.IsWeekend(date));
    }
}

#endif
