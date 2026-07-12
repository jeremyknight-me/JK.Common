using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class RegexHelperTests
{
    [Theory]
    [InlineData("abc", true)]
    [InlineData("asdf234", false)]
    public void IsAlphabetical_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsAlphabetical(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("abc123", true)]
    [InlineData("asdf234*@#asdf", false)]
    public void IsAlphanumeric_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsAlphanumeric(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("12", true)]
    [InlineData("12.00", true)]
    [InlineData("0.34", true)]
    [InlineData("00.34", true)]
    [InlineData("12.34", true)]
    [InlineData("$12.34", false)]
    [InlineData("-$12.34", false)]
    [InlineData("$-12.34", false)]
    [InlineData("$1,234", false)]
    [InlineData("$1,234.56", false)]
    [InlineData("1a", false)]
    [InlineData("1a.00", false)]
    [InlineData("0a.34", false)]
    [InlineData("1a.34", false)]
    [InlineData("$1a.34", false)]
    public void IsDecimal_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsDecimal(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("12", true)]
    [InlineData("12.00", true)]
    [InlineData("0.34", true)]
    [InlineData("00.34", true)]
    [InlineData("12.34", true)]
    [InlineData("$12.34", true)]
    [InlineData("-$12.34", true)]
    [InlineData("$-12.34", true)]
    [InlineData("$1,234", true)]
    [InlineData("$1,234.56", true)]
    [InlineData("1a", false)]
    [InlineData("1a.00", false)]
    [InlineData("0a.34", false)]
    [InlineData("1a.34", false)]
    [InlineData("$1a.34", false)]
    public void IsDecimalOrCurrency_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsDecimalOrCurrency(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("someemail@domain.com", true)]
    [InlineData("some@email@domain.com", false)]
    public void IsEmailAddress_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsEmailAddress(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("12", true)]
    [InlineData("-12", true)]
    [InlineData("12.00", false)]
    [InlineData("1a", false)]
    public void IsInteger_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsInteger(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("255.255.255.255", true)]
    [InlineData("300.300.300.300", false)]
    [InlineData("255.255.255", false)]
    public void IsIPv4_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsIPv4(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("078051120", true)]
    [InlineData("078 05 1120", true)]
    [InlineData("078-05-1120", true)]
    [InlineData("899-05-1120", true)] // left less than 900
    [InlineData("000000000", false)]
    [InlineData("000 00 0000", false)]
    [InlineData("000-00-0000", false)]
    [InlineData("111-00-1111", false)] // middle all 0
    [InlineData("111-11-0000", false)] // right all 0
    [InlineData("666-12-4321", false)] // left 666
    [InlineData("900-12-4321", false)] // left greater than equal 900
    public void IsSocialSecurityNumber_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsSocialSecurityNumber(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("5555551234", true)]
    [InlineData("(555) 555-1234", true)]
    [InlineData("555-555-1234", true)]
    [InlineData("5551234", true)]
    [InlineData("555-1234", true)]
    public void IsUnitedStatesPhoneNumber_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsUnitedStatesPhoneNumber(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("12345", true)]
    [InlineData("12X45", false)]
    [InlineData("12345-6789", true)]
    [InlineData("12X45-6789", false)]
    [InlineData("12345-67X9", false)]
    public void IsZipCode_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsZipCode(input);
        Assert.Equal(expected, actual);
    }
}
