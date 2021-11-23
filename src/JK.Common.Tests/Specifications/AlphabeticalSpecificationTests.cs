using JK.Common.Specifications;

namespace JK.Common.Tests.Specifications;

public class AlphabeticalSpecificationTests
{
    [Theory]
    [InlineData("abc", true)]
    [InlineData("asdf234", false)]
    public void IsSatisfiedBy(string input, bool expected)
    {
        var specification = new AlphabeticalSpecification();
        var actual = specification.IsSatisfiedBy(input);
        Assert.Equal(expected, actual);
    }
}
