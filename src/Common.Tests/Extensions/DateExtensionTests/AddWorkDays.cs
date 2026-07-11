using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.DateExtensionTests;

public class AddWorkDays
{
    [Theory]
    [MemberData(nameof(Data))]
    public void DateTime_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        DateTime original = DateTime.Parse(startDay);
        DateTime actual = original.AddWorkDays(daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void DateTimeOffset_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        DateTimeOffset original = DateTimeOffset.Parse(startDay);
        DateTimeOffset actual = original.AddWorkDays(daysToAdd);
        Assert.Equal(expectedDay, actual.Day);
    }

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(Data))]
    public void DateOnly_Theories(string startDay, int daysToAdd, int expectedDay)
    {
        DateOnly original = DateOnly.Parse(startDay);
        DateOnly actual = original.AddWorkDays(daysToAdd);
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
