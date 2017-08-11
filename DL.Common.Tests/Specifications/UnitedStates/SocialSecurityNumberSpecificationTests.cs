using DL.Common.Specifications.UnitedStates;
using Xunit;

namespace DL.Common.Tests.Specifications.UnitedStates
{
    public class SocialSecurityNumberSpecificationTests
    {
        [Theory]
        [InlineData("078051120", true)] 
        [InlineData("078 05 1120", true)]
        [InlineData("078-05-1120", true)]
        [InlineData("899-05-1120", true)] // left less than 900
        [InlineData("000000000", false)] 
        [InlineData("000 00 0000", false)]
        [InlineData("000-00-0000", false)]
        [InlineData("111-00-1111", false)] // middle all 0
        [InlineData("111-11-0000", false)] // right all 0
        [InlineData("666-12-4321", false)] // left 666
        [InlineData("900-12-4321", false)] // left greater than equal 900
        public void IsSatisfiedBy(string input, bool expected)
        {
            var specification = new SocialSecurityNumberSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
