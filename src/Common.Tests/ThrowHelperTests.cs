namespace JK.Common.Tests;

public class ThrowHelperTests
{
    [Theory]
    [InlineData(null)]
    public void IfNull_ValueIsNull_Throws(object value)
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => ThrowHelper.IfNull(value, nameof(value)));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData("")]
    [InlineData("not null")]
    public void IfNull_ValueIsNotNull_DoesNotThrow(object value)
    {
        ThrowHelper.IfNull(value, nameof(value));
        Assert.True(true); // If no exception is thrown, the test passes
    }

    [Fact]
    public void IfNullOrEmpty_ValueIsNull_Throws()
    {
        string value = null;
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => ThrowHelper.IfNullOrEmpty(value, nameof(value)));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Fact]
    public void IfNullOrEmpty_ValueIsEmpty_Throws()
    {
        var value = "";
        ArgumentException exception = Assert.Throws<ArgumentException>(() => ThrowHelper.IfNullOrEmpty(value, nameof(value)));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData(" ")]
    public void IfNullOrEmpty_ValueIsNotNullOrEmpty_DoesNotThrow(string value)
    {
        ThrowHelper.IfNullOrEmpty(value, nameof(value));
        Assert.True(true); // If no exception is thrown, the test passes
    }

    [Fact]
    public void IfNullOrWhiteSpace_ValueIsNull_Throws()
    {
        string value = null;
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => ThrowHelper.IfNullOrWhiteSpace(value, nameof(value)));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void IfNullOrWhiteSpace_ValueIsEmptyOrWhiteSpace_Throws(string value)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => ThrowHelper.IfNullOrWhiteSpace(value, nameof(value)));
        Assert.Equal(nameof(value), exception.ParamName);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("a b c")]
    public void IfNullOrWhiteSpace_ValueIsNotNullOrWhiteSpace_DoesNotThrow(string value)
    {
        ThrowHelper.IfNullOrWhiteSpace(value, nameof(value));
        Assert.True(true); // If no exception is thrown, the test passes
    }
}
