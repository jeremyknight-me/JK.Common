using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.StringHelperTests;

public class StripXml
{
    [Fact]
    public void StripXml_Test()
    {
        const string s = "<xml>Inner Text</xml>";
        var actual = StringHelper.StripXml(s);
        Assert.Equal("Inner Text", actual);
    }
}
