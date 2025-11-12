using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.StringExtensionTests;

public class ExtensionTests
{
    [Theory]
    [InlineData("", 2, "")]
    [InlineData("Test", 2, "st")]
    [InlineData("Test", 4, "Test")]
    [InlineData("Test", 6, "Test")]
    public void Right_Theories(string input, int length, string expected)
    {
        var actual = input.Right(length);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Reverse_Test()
    {
        const string s = "Sample Text";
        var actual = s.Reverse();
        Assert.Equal("txeT elpmaS", actual);
    }

    [Theory]
    [InlineData("$1,000,000.00", "1000000.00")]
    [InlineData("1000.00", "1000.00")]
    [InlineData("$,", "0")]
    public void RemoveUnitedStatesCurrencyFormat_WithCharacters(string input, string expected)
    {
        var actual = input.RemoveUnitedStatesCurrencyFormat();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("<xml>Inner Text</xml>", "Inner Text")]
    [InlineData("Inner Text", "Inner Text")]
    public void RemoveXml_Test(string input, string expected)
    {
        var actual = input.RemoveXml();
        Assert.Equal(expected, actual);
    }
}
