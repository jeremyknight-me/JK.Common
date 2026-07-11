using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class DateRangeHelperTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void DateTime_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateRangeHelper.DoesOverlap(DateTime.Parse(startOne), DateTime.Parse(endOne), DateTime.Parse(startTwo), DateTime.Parse(endTwo));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void DateTimeOffset_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateRangeHelper.DoesOverlap(DateTimeOffset.Parse(startOne), DateTimeOffset.Parse(endOne), DateTimeOffset.Parse(startTwo), DateTimeOffset.Parse(endTwo));
        Assert.Equal(expected, actual);
    }

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(Data))]
    public void DateOnly_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateRangeHelper.DoesOverlap(DateOnly.Parse(startOne), DateOnly.Parse(endOne), DateOnly.Parse(startTwo), DateOnly.Parse(endTwo));
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
