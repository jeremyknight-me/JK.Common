using JK.Common.Xml;

namespace JK.Common.Tests.Xml
{
    public class XmlSerializationFacadeTests
    {
        [Fact]
        public void GetXmlAsString_Test()
        {
            var simple = new SimpleObject { Id = 1, Title = "ABC" };
            var sut = new XmlSerializationFacade();
            var actual = sut.GetXmlAsString(simple);
            var expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SimpleObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>1</Id><Title>ABC</Title></SimpleObject>";
            Assert.Equal(expected, actual);
        }
    }
}
