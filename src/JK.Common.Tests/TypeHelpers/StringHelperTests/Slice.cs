#if (NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER)

using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.StringHelperTests;

public class Slice
{
    [Fact]
    public void Slice_Start_Test()
    {
        const string s = "Bacon ipsum dolor amet meatball";
        var actual = StringHelper.Slice(s, 23);
        Assert.Equal("meatball", actual.ToString());
    }

    [Fact]
    public void Slice_StartLength_Test()
    {
        const string s = "Bacon ipsum dolor amet meatball";
        var actual = StringHelper.Slice(s, 0, 5);
        Assert.Equal("Bacon", actual.ToString());
    }    
}

#endif
