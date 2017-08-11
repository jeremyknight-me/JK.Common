using DL.Common.Specifications;
using Xunit;

namespace DL.Common.Tests.Specifications
{
    public class AlphabeticalSpecificationTests
    {
        [Theory]
        [InlineData("abc", true)]
        [InlineData("asdf234", false)]
        public void IsSatisfiedBy(string input, bool expected)
        {
            var specification = new AlphabeticalSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
