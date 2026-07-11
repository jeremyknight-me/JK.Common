using JK.Common.Text;

namespace JK.Common.Tests.Text;

public class StringDelimiterTests
{
    [Fact]
    public void DelimitedText_FirstAddition_TextWithoutDelimiter()
    {
        var addition = "first";
        var delimiter = "|";
        var stringDelimiter = new StringDelimiter(delimiter);
        stringDelimiter.AddText(addition);

        var actual = stringDelimiter.DelimitedText;
        var expected = "first";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DelimitedText_AddWithPriorData_DelimitedText()
    {
        var original = "data";
        var delimiter = "|";
        var addition = "first";

        var stringDelimiter = new StringDelimiter(delimiter);
        stringDelimiter.AddText(original);
        stringDelimiter.AddText(addition);

        var expected = "data|first";
        var actual = stringDelimiter.DelimitedText;
        Assert.Equal(expected, actual);
    }
}
