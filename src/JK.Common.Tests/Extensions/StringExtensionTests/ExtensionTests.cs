using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.StringExtensionTests;

public class ExtensionTests
{
    [Fact]
    public void IsNull_TrueWhenNull()
    {
        string input = null;
        Assert.True(input.IsNull());
    }

    [Theory]
    [InlineData("John")]
    [InlineData("")]
    [InlineData(" ")]
    public void IsNull_FalseTheories(string input)
    {
        Assert.False(input.IsNull());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void IsNullOrEmpty_TrueTheories(string input)
    {
        Assert.True(input.IsNullOrEmpty());
    }

    [Theory]
    [InlineData("John")]
    [InlineData(" ")]
    public void IsNullOrEmpty_FalseTheories(string input)
    {
        Assert.False(input.IsNullOrEmpty());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\n ")]
    public void IsNullOrWhiteSpace_TrueTheories(string input)
    {
        Assert.True(input.IsNullOrWhiteSpace());
    }

    [Theory]
    [InlineData("John")]
    [InlineData("123")]
    [InlineData(".")]
    public void IsNullOrWhiteSpace_FalseTheories(string input)
    {
        Assert.False(input.IsNullOrWhiteSpace());
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

    [Theory]
    [InlineData("abc", "a", "bc")]
    [InlineData("abc abc", "a", "bc bc")]
    [InlineData("abc", "d", "abc")]
    public void ReplaceWithEmpty_Theories(string input, string replace, string expected)
    {
        var actual = input.ReplaceWithEmpty(replace);
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
    [InlineData("", 2, "")]
    [InlineData("Test", 2, "st")]
    [InlineData("Test", 4, "Test")]
    [InlineData("Test", 6, "Test")]
    public void Right_Theories(string input, int length, string expected)
    {
        var actual = input.Right(length);
        Assert.Equal(expected, actual);
    }
}
