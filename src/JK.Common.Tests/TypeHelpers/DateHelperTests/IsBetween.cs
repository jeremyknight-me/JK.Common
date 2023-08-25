using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.DateHelperTests;

public partial class IsBetween
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
}

#if (NET6_0_OR_GREATER)

public partial class IsBetween
{
    [Theory]
    [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
    [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
    public void DateOnly_Theories(bool expected, string date, string start, string end)
    {
        var actual = DateHelper.IsBetween(DateOnly.Parse(date), DateOnly.Parse(start), DateOnly.Parse(end));
        Assert.Equal(expected, actual);
    }
}

#endif
