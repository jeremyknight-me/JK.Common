using DL.Common.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Text
{
    [TestClass]
    public class StringDelimiterTests
    {
        [TestMethod]
        public void DelimitedText_FirstAddition_TextWithoutDelimiter()
        {
            string addition = "first";
            string delimiter = "|";
            var stringDelimiter = new StringDelimiter(delimiter);
            stringDelimiter.AddText(addition);

            string actual = stringDelimiter.DelimitedText;
            string expected = "first";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
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
            Assert.AreEqual(expected, actual);
        }
    }
}
