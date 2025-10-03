using JK.Common.Converters;

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
    public void Convert(object value, bool expected)
    {
        var sut = new BooleanConverter();
        var actual = sut.Convert(value);
        Assert.Equal(expected, actual);
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
    public void ConvertToNullable(object value, bool? expected)
    {
        var sut = new BooleanConverter();
        var actual = sut.ConvertToNullable(value);
        Assert.Equal(expected, actual);
    }
}
