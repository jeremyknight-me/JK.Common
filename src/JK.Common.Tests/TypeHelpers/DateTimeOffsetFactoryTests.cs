using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class DateTimeOffsetFactoryTests
{
    [Theory]
    [InlineData("2020-10-01T00:00:00-05:00", "Central Standard Time", "2020-10-01")]
    [InlineData("2020-12-31T00:00:00-06:00", "Central Standard Time", "2020-12-31")]
    [InlineData("2020-10-01T02:30:45-05:00", "Central Standard Time", "2020-10-01 02:30:45")]
    [InlineData("2020-12-31T23:59:59-06:00", "Central Standard Time", "2020-12-31 23:59:59")]
    [InlineData("2020-10-01T00:00:00-04:00", "Eastern Standard Time", "2020-10-01")]
    [InlineData("2020-12-31T00:00:00-05:00", "Eastern Standard Time", "2020-12-31")]
    [InlineData("2020-10-01T02:30:45-04:00", "Eastern Standard Time", "2020-10-01 02:30:45")]
    [InlineData("2020-12-31T23:59:59-05:00", "Eastern Standard Time", "2020-12-31 23:59:59")]
    public void Make_Theories(string expected, string timeZoneId, string input)
    {
        DateTimeOffset actual = DateTimeOffsetFactory.Make(DateTime.Parse(input), timeZoneId);
        Assert.Equal(DateTimeOffset.Parse(expected), actual);
    }
}
