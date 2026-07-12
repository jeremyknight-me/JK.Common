using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class BooleanConverterTests
{
    [Theory]
    [InlineData(" TRUE ", true)]
    [InlineData("TRUE", true)]
    [InlineData("True", true)]
    [InlineData("true", true)]
    [InlineData(1, true)]
    [InlineData("1", true)]
    [InlineData(" FALSE ", false)]
    [InlineData("FALSE", false)]
    [InlineData("False", false)]
    [InlineData("false", false)]
    [InlineData(0, false)]
    [InlineData("0", false)]
    public void Convert_Theories(object value, bool expected)
    {
        var sut = new BooleanConverter();
        var actual = sut.Convert(value);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Convert_UnsupportedValue_ThrowsArgumentException()
    {
        var sut = new BooleanConverter();
        Assert.Throws<ArgumentException>(() => sut.Convert("maybe"));
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", null)]
    [InlineData(" TRUE ", true)]
    [InlineData("TRUE", true)]
    [InlineData("True", true)]
    [InlineData("true", true)]
    [InlineData(1, true)]
    [InlineData("1", true)]
    [InlineData(" FALSE ", false)]
    [InlineData("FALSE", false)]
    [InlineData("False", false)]
    [InlineData("false", false)]
    [InlineData(0, false)]
    [InlineData("0", false)]
    public void ConvertToNullable_Theories(object value, bool? expected)
    {
        var sut = new BooleanConverter();
        var actual = sut.ConvertToNullable(value);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertToNullable_UnsupportedValue_ThrowsArgumentException()
    {
        var sut = new BooleanConverter();
        Assert.Throws<ArgumentException>(() => sut.ConvertToNullable("perhaps"));
    }
}
