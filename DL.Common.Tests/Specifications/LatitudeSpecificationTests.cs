using DL.Common.Specifications;
using Xunit;

namespace DL.Common.Tests.Specifications
{
    public class LatitudeSpecificationTests
    {
        [Theory]
        [InlineData(-91, false)]
        [InlineData(-90, true)]
        [InlineData(0, true)]
        [InlineData(90, true)]
        [InlineData(91, false)]
        public void IsSatisfiedBy(decimal input, bool expected)
        {
            var specification = new LatitudeSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
