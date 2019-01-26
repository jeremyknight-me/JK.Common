using JK.Common.Text;
using Xunit;

namespace JK.Common.Tests.Text
{
    public class StringDelimiterTests
    {
        [Fact]
        public void DelimitedText_FirstAddition_TextWithoutDelimiter()
        {
            string addition = "first";
            string delimiter = "|";
            var stringDelimiter = new StringDelimiter(delimiter);
            stringDelimiter.AddText(addition);

            string actual = stringDelimiter.DelimitedText;
            string expected = "first";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DelimitedText_AddWithPriorData_DelimitedText()
        {
            string original = "data";
            string delimiter = "|";
            string addition = "first";

            var stringDelimiter = new StringDelimiter(delimiter);
            stringDelimiter.AddText(original);
            stringDelimiter.AddText(addition);
            
            string expected = "data|first";
            string actual = stringDelimiter.DelimitedText;
            Assert.Equal(expected, actual);
        }
    }
}
