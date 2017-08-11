using DL.Common.Math;
using Xunit;

namespace DL.Common.Tests.Math
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
            var utility = new MathHelper();
            bool actual = utility.IsPrime(input);
            Assert.Equal(expected, actual);
        }
    }
}
