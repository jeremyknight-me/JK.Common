#if NET7_0_OR_GREATER

using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public class StringExtensionsTest
{
    

    [Fact]
    public void Parse_Int()
    {
        var value = "1";
        var actual = value.Parse<int>();
        Assert.Equal(1, actual);
    }

    [Fact]
    public void Parse_Decimal()
    {
        var value = "1.2";
        var actual = value.Parse<decimal>();
        Assert.Equal(1.2m, actual);
    }

    [Fact]
    public void Parse_DateTime()
    {
        var value = "2023-05-18";
        var actual = value.Parse<DateTime>();
        Assert.Equal(new DateTime(2023, 5, 18), actual);
    }
}

#endif
