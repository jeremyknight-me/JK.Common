using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class EnumHelperTests
{
    /*
    private enum Colors
    {
        Red = 1,
        Green = 2,
        Blue = 3
    }

    private enum ColorsWithNames
    {
        [Display(Name = "Maroon")]
        Red = 1,
        [Display(Name = "Forest Green")]
        Green = 2,
        [Display(Name = "Navy Blue")]
        Blue = 3
    }
    */

    public enum Colors
    {
        Green = 2,
        [Display(Name = "Cyan")]
        Blue = 3
    }

    [Fact]
    public void ConvertToListItems_Test()
    {
        IEnumerable<ListItem> data = new EnumHelper().ConvertToListItems(typeof(Colors));
        Assert.Equal(2, data.Count());
        Assert.Equal("Green", data.First().Text);
        Assert.Equal("Cyan", data.Last().Text);
    }

    [Fact]
    public void GetAttribute_Exists_Attribute()
    {
        DisplayAttribute actual = new EnumHelper().GetAttribute<DisplayAttribute>(Colors.Blue);
        Assert.NotNull(actual);
        Assert.IsType<DisplayAttribute>(actual);
    }

    [Fact]
    public void GetAttribute_DoesNotExists_Null()
    {
        DisplayAttribute actual = new EnumHelper().GetAttribute<DisplayAttribute>(Colors.Green);
        Assert.Null(actual);
    }

    [Fact]
    public void GetByByte_NonEnumValue_ArgumentException()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new EnumHelper().GetByByte<byte>(0));
        Assert.Equal("T must be an enumerated type", ex.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    public void GetByByte_InvalidValue(byte invalidValue)
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new EnumHelper().GetByByte<Colors>(invalidValue));
    }

    [Fact]
    public void GetByByte_ValidOrdinal()
    {
        Colors actual = new EnumHelper().GetByByte<Colors>(2);
        Assert.Equal(Colors.Green, actual);
    }

    [Fact]
    public void GetByInteger_NonEnumValue_ArgumentException()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new EnumHelper().GetByInteger<int>(0));
        Assert.Equal("T must be an enumerated type", ex.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    public void GetByInteger_InvalidValue(int invalidValue)
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new EnumHelper().GetByInteger<Colors>(invalidValue));
    }

    [Fact]
    public void GetByInteger_ValidOrdinal()
    {
        Colors actual = new EnumHelper().GetByInteger<Colors>(2);
        Assert.Equal(Colors.Green, actual);
    }

    [Theory]
    [MemberData(nameof(BuildDataGetDisplayName))]
    public void GetDisplayName_(Colors enumValue, string expected)
    {
        var actual = new EnumHelper().GetDisplayName(enumValue);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Colors, string> BuildDataGetDisplayName()
        => new()
        {
            { Colors.Blue, "Cyan" },
            { Colors.Green, "Green" }
        };

    [Fact]
    public void GetByte_ValidEnumValue()
    {
        var actual = new EnumHelper().GetByte(Colors.Green);
        Assert.Equal(2, actual);
    }

    [Fact]
    public void GetInteger_ValidEnumValue()
    {
        var actual = new EnumHelper().GetInteger(Colors.Green);
        Assert.Equal(2, actual);
    }

    [Fact]
    public void GetInteger_NullableEnumNull_Null()
    {
        var actual = new EnumHelper().GetInteger((Colors?)null);
        Assert.Null(actual);
    }

    [Fact]
    public void GetInteger_NullableEnumValue_Integer()
    {
        var actual = new EnumHelper().GetInteger((Colors?)Colors.Green);
        Assert.Equal(2, actual);
    }
}
