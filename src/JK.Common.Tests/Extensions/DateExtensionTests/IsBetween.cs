using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.DateExtensionTests;

public class IsBetween
{
    [Theory]
    [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
    [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
    [InlineData(true, "2020-10-26 12:00:00", "2020-10-26 11:59:59", "2020-10-26 12:00:01")]
    [InlineData(false, "2020-10-26 11:59:58", "2020-10-26 11:59:59", "2020-10-26 12:00:01")]
    public void DateTime_Theories(bool expected, string date, string start, string end)
    {
        var actual = DateTime.Parse(date).IsBetween(DateTime.Parse(start), DateTime.Parse(end));
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
        var actual = DateTimeOffset.Parse(date).IsBetween(DateTimeOffset.Parse(start), DateTimeOffset.Parse(end));
        Assert.Equal(expected, actual);
    }

#if NET6_0_OR_GREATER
    [Theory]
    [InlineData(true, "2020-10-26", "2020-10-20", "2020-10-30")]
    [InlineData(false, "2020-10-15", "2020-10-20", "2020-10-30")]
    public void DateOnly_Theories(bool expected, string date, string start, string end)
    {
        var actual = DateOnly.Parse(date).IsBetween(DateOnly.Parse(start), DateOnly.Parse(end));
        Assert.Equal(expected, actual);
    }
#endif
}
