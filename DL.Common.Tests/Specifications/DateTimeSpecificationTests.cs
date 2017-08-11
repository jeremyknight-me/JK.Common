using DL.Common.Specifications;
using Xunit;

namespace DL.Common.Tests.Specifications
{
    public class DateTimeSpecificationTests
    {
        [Theory]
        [InlineData("hello world", false)]
        [InlineData("2008-05-01 7:34:42Z", true)]
        [InlineData("2008-05-01T07:34:42-5:00", true)]
        [InlineData("Thu, 01 May 2008 07:34:42 GMT", true)]
        [InlineData("2/16/2008 12:15:12 PM", true)]
        [InlineData("16/02/2008 12:15:12", false)]
        public void IsSatisfiedBy(string input, bool expected)
        {
            var specification = new DateTimeSpecification();
            bool actual = specification.IsSatisfiedBy(input);
            Assert.Equal(expected, actual);
        }        
    }
}
