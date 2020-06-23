using JK.Common.Specifications;
using Xunit;

namespace JK.Common.Tests.Specifications
{
    public class InternetProtocolAddressSpecificationTests
    {
        [Theory]
        [InlineData("255.255.255.255", true)]
        [InlineData("300.300.300.300", false)]
        [InlineData("255.255.255", false)]
        public void IsSatisfiedBy(string input, bool expected)
        {
            var specification = new InternetProtocolAddressSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
