using JK.Common.Specifications;

namespace JK.Common.Tests.Specifications;

public class NumericSpecificationTests
{
    [Theory]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData("abc", false)]
    [InlineData("123", true)]
    [InlineData("123.456", true)]
    public void IsSatisfiedBy(string input, bool expected)
    {
        var specification = new NumericSpecification();
        var actual = specification.IsSatisfiedBy(input);
        Assert.Equal(expected, actual);
    }
}
