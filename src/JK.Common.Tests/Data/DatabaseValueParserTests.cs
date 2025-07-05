using JK.Common.Data;

namespace JK.Common.Tests.Data;

public class DatabaseValueParserTests
{
    [Fact]
    public void GetValueOrDefault_DbNullInt()
    {
        object target = DBNull.Value;
        var actual = DatabaseValueParser.GetValueOrDefault<int>(target);
        Assert.Equal(0, actual);
    }

    [Fact]
    public void GetValueOrDefault_NonDbNullInt()
    {
        object target = 123;
        var actual = DatabaseValueParser.GetValueOrDefault<int>(target);
        Assert.Equal(123, actual);
    }

    [Fact]
    public void GetValueOrNull_NullString()
    {
        string target = null;
        var actual = DatabaseValueParser.GetValueOrNull<string>(target);
        Assert.Null(actual);
    }

    [Fact]
    public void GetValueOrNull_NonNullString()
    {
        var actual = DatabaseValueParser.GetValueOrNull<string>("abc123");
        Assert.Equal("abc123", actual);
    }
}
