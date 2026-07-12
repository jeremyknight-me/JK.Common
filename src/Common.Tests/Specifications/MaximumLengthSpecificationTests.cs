using JK.Common.Specifications;

namespace JK.Common.Tests.Specifications;

public class MaximumLengthSpecificationTests
{
    [Theory]
    [InlineData("xxxxx", true)] // 5
    [InlineData("xxxxxxxxxx", true)] // 10 
    [InlineData("xxxxxxxxxxxxxxx", false)] // 15
    public void IsSatisfiedBy(string input, bool expected)
    {
        var specification = new MaximumLengthSpecification(10);
        var actual = specification.IsSatisfiedBy(input);
        Assert.Equal(expected, actual);
    }
}
