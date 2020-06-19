using JK.Common.Specifications;
using Xunit;

namespace JK.Common.Tests.Specifications
{
    public class AlphanumericSpecificationTests
    {
        [Theory]
        [InlineData("abc123", true)]
        [InlineData("asdf234*@#asdf", false)]
        public void IsSatisfiedBy(string input, bool expected)
        {
            var specification = new AlphanumericSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
