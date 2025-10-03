using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.DateExtensionTests;

public class IsWeekday
{
    [Theory]
    [MemberData(nameof(Data))]
    public void DateTime_Theories(bool expected, string dateInput)
    {
        var date = DateTime.Parse(dateInput);
        Assert.Equal(expected, date.IsWeekday());
        Assert.Equal(!expected, date.IsWeekend());
    }

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(Data))]
    public void DateOnly_Theories(bool expected, string dateInput)
    {
        var date = DateOnly.Parse(dateInput);
        Assert.Equal(expected, date.IsWeekday());
        Assert.Equal(!expected, date.IsWeekend());
    }
#endif

    public static TheoryData<bool, string> Data()
        => new()
        {
            { true, "2011-01-18" }, // Tuesday Jan 18, 2011
            { false, "2011-01-15" } // Saturday Jan 15, 2011
        };
}
