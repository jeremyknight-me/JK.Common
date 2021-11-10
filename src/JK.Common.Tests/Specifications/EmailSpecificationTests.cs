using JK.Common.Specifications;

namespace JK.Common.Tests.Specifications;

public class EmailSpecificationTests
{
    [Theory]
    [InlineData("someemail@domain.com", true)]
    [InlineData("some@email@domain.com", false)]
    public void IsSatisfiedBy(string input, bool expected)
    {
        var specification = new EmailSpecification();
        var actual = specification.IsSatisfiedBy(input);
        Assert.Equal(expected, actual);
    }
}
