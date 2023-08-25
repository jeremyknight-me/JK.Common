using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.DateHelperTests;

public partial class IsWeekday
{
    [Theory]
    [InlineData(true, "2011-01-18")] // Tuesday Jan 18, 2011
    [InlineData(false, "2011-01-15")] // Saturday Jan 15, 2011
    public void DateTime_Theories(bool expected, string dateInput)
    {
        var date = DateTime.Parse(dateInput);
        Assert.Equal(expected, DateHelper.IsWeekday(date));
        Assert.Equal(!expected, DateHelper.IsWeekend(date));
    }
}

#if (NET6_0_OR_GREATER)

public partial class IsWeekday
{
    [Theory]
    [InlineData(true, "2011-01-18")] // Tuesday Jan 18, 2011
    [InlineData(false, "2011-01-15")] // Saturday Jan 15, 2011
    public void DateOnly_Theories(bool expected, string dateInput)
    {
        var date = DateOnly.Parse(dateInput);
        Assert.Equal(expected, DateHelper.IsWeekday(date));
        Assert.Equal(!expected, DateHelper.IsWeekend(date));
    }
}

#endif
