using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.DateHelperTests;

public partial class DoesOverlap
{
    [Theory]
    [InlineData(true, "2020-10-01", "2020-10-31", "2020-10-20", "2020-11-30")]
    [InlineData(false, "2020-10-01", "2020-10-31", "2020-11-01", "2020-11-30")]
    public void DateTime_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateHelper.DoesOverlap(DateTime.Parse(startOne), DateTime.Parse(endOne), DateTime.Parse(startTwo), DateTime.Parse(endTwo));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "2020-10-01", "2020-10-31", "2020-10-20", "2020-11-30")]
    [InlineData(false, "2020-10-01", "2020-10-31", "2020-11-01", "2020-11-30")]
    public void DateTimeOffset_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateHelper.DoesOverlap(DateTimeOffset.Parse(startOne), DateTimeOffset.Parse(endOne), DateTimeOffset.Parse(startTwo), DateTimeOffset.Parse(endTwo));
        Assert.Equal(expected, actual);
    }
}

#if (NET6_0_OR_GREATER)

public partial class DoesOverlap
{
    [Theory]
    [InlineData(true, "2020-10-01", "2020-10-31", "2020-10-20", "2020-11-30")]
    [InlineData(false, "2020-10-01", "2020-10-31", "2020-11-01", "2020-11-30")]
    public void DateOnly_Theories(bool expected, string startOne, string endOne, string startTwo, string endTwo)
    {
        var actual = DateHelper.DoesOverlap(DateOnly.Parse(startOne), DateOnly.Parse(endOne), DateOnly.Parse(startTwo), DateOnly.Parse(endTwo));
        Assert.Equal(expected, actual);
    }
}

#endif
