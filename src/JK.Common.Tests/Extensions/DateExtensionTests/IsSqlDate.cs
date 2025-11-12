using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.DateExtensionTests;

public class IsSqlDate
{
    [Theory]
    [MemberData(nameof(Data))]
    public void DateTime_Theories(bool expected, string dateInput)
    {
        var date = DateTime.Parse(dateInput);
        var actual = date.IsSqlDate;
        Assert.Equal(expected, actual);
    }

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(Data))]
    public void DateOnly_Theories(bool expected, string dateInput)
    {
        var date = DateOnly.Parse(dateInput);
        var actual = date.IsSqlDate;
        Assert.Equal(expected, actual);
    }
#endif

    public static TheoryData<bool, string> Data()
        => new()
        {
                { false, "1700-01-18" }, // Before SQL Server's minimum date
                { true, "2011-01-15" } // Within SQL Server's valid date range
        };
}
