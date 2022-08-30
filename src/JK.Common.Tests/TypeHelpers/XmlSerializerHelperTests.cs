using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class XmlSerializationFacadeTests
{
    [Fact]
    public void DeserializeString_Test()
    {
        var xml = "<SimpleObject><Id>1</Id><Title>ABC</Title></SimpleObject>";
        var actual = XmlSerializerHelper.DeserializeString<SimpleObject>(xml);
        Assert.Equal(1, actual.Id);
        Assert.Equal("ABC", actual.Title);
    }

    [Fact]
    public void Serialize_Test()
    {
        var simple = new SimpleObject { Id = 1, Title = "ABC" };
        var actual = XmlSerializerHelper.Serialize(simple);
        var expected = "<SimpleObject><Id>1</Id><Title>ABC</Title></SimpleObject>";
        Assert.Equal(expected, actual);
    }
}
