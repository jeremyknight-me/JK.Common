using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.DateHelperTests;

public partial class AddWorkDays
{
    [Theory]
    [InlineData("2019-09-16", 5, 23)] // start on monday
    [InlineData("2019-09-16", 4, 20)]
    [InlineData("2019-09-16", -5, 9)]
    public void DateTime_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        var original = DateTime.Parse(startDay);
        var actual = DateHelper.AddWorkDays(original, daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }

    [Theory]
    [InlineData("2019-09-16", 5, 23)] // start on monday
    [InlineData("2019-09-16", 4, 20)]
    [InlineData("2019-09-16", -5, 9)]
    public void DateTimeOffset_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        var original = DateTimeOffset.Parse(startDay);
        var actual = DateHelper.AddWorkDays(original, daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }
}

#if (NET6_0_OR_GREATER)

public partial class AddWorkDays
{
    [Theory]
    [InlineData("2019-09-16", 5, 23)] // start on monday
    [InlineData("2019-09-16", 4, 20)]
    [InlineData("2019-09-16", -5, 9)]
    public void DateOnly_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        var original = DateOnly.Parse(startDay);
        var actual = DateHelper.AddWorkDays(original, daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }
}

#endif
