#if NET7_0_OR_GREATER

using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public class SpanExtensionsTests
{
    [Fact]
    public void Parse_Int()
    {
        ReadOnlySpan<char> value = "1".AsSpan();
        var actual = value.Parse<int>();
        Assert.Equal(1, actual);
    }

    [Fact]
    public void Parse_Decimal()
    {
        ReadOnlySpan<char> value = "1.2".AsSpan();
        var actual = value.Parse<decimal>();
        Assert.Equal(1.2m, actual);
    }

    [Fact]
    public void Parse_DateTime()
    {
        ReadOnlySpan<char> value = "2023-05-18".AsSpan();
        DateTime actual = value.Parse<DateTime>();
        Assert.Equal(new DateTime(2023, 5, 18), actual);
    }
}

#endif
