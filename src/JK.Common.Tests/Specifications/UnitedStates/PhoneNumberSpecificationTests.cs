using JK.Common.Specifications.UnitedStates;
using Xunit;

namespace JK.Common.Tests.Specifications.UnitedStates
{
    public class PhoneNumberSpecificationTests
    {
        [Theory]
        [InlineData("5555551234", true)]
        [InlineData("(555) 555-1234", true)]
        [InlineData("555-555-1234", true)]
        [InlineData("5551234", true)]
        [InlineData("555-1234", true)]
        public void IsSatisfiedBy(string input, bool expected)
        {
            var specification = new PhoneNumberSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
