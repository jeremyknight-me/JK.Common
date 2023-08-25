using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.StringHelperTests;

public class Reverse
{
    [Fact]
    public void Reverse_Test()
    {
        const string s = "Sample Text";
        var actual = StringHelper.Reverse(s);
        Assert.Equal("txeT elpmaS", actual);
    }
}
