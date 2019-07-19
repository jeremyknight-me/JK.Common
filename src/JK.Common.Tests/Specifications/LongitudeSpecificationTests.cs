using JK.Common.Specifications;
using Xunit;

namespace JK.Common.Tests.Specifications
{
    public class LongitudeSpecificationTests
    {
        [Theory]
        [InlineData(-181, false)]
        [InlineData(-180, true)]
        [InlineData(0, true)]
        [InlineData(180, true)]
        [InlineData(181, false)]
        public void IsSatisfiedBy(double input, bool expected)
        {
            var specification = new LongitudeSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }
    }
}
