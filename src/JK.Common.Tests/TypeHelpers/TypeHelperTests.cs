using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class TypeHelperTests
{
    [Theory]
    [MemberData(nameof(IsNullableT_Data))]
    public void IsNullableT_Theories(Type type, bool expected)
    {
        var actual = TypeHelper.IsNullableT(type);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Type, bool> IsNullableT_Data()
        => new()
        {
            { typeof(int), false },
            { typeof(int?), true },
            { typeof(string), false },
            { typeof(ComplexObject), false },
        };

    [Theory]
    [MemberData(nameof(IsNullable_Data))]
    public void IsNullable_Theories(Type type, bool expected)
    {
        var actual = TypeHelper.IsNullable(type);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Type, bool> IsNullable_Data()
        => new()
        {
            { typeof(int), false },
            { typeof(int?), true },
            { typeof(string), true },
            { typeof(ComplexObject), true }
        };
}
