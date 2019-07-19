using JK.Common.TypeHelpers;
using Xunit;

namespace JK.Common.Tests.TypeHelpers
{
    public class MathHelperTests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(8, false)]
        [InlineData(17, true)]
        [InlineData(6857, true)]
        public void IsPrime(int input, bool expected)
        {
            var helper = new MathHelper();
            bool actual = helper.IsPrime(input);
            Assert.Equal(expected, actual);
        }
    }
}
