using DL.Common.Specifications;
using Xunit;

namespace DL.Common.Tests.Specifications
{
    public class EmailSpecificationTests
    {
        [Theory]
        [InlineData("someemail@domain.com", true)]
        [InlineData("some@email@domain.com", false)]
        public void IsSatisfiedBy(string input, bool expected)
        {
            var specification = new EmailSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
