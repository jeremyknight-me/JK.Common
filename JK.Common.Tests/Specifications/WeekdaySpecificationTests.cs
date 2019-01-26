using System;
using JK.Common.Specifications;
using Xunit;

namespace JK.Common.Tests.Specifications
{
    public class WeekdaySpecificationTests
    {
        [Theory]
        [InlineData(2011, 1, 17, true)] // Monday Jan 17, 2011
        [InlineData(2011, 1, 18, true)] // Tuesday Jan 18, 2011
        [InlineData(2011, 1, 19, true)] // Wednesday Jan 19, 2011
        [InlineData(2011, 1, 20, true)] // Thursday Jan 20, 2011
        [InlineData(2011, 1, 21, true)] // Friday Jan 21, 2011
        [InlineData(2011, 1, 22, false)] // Saturday Jan 22, 2011
        [InlineData(2011, 1, 23, false)] // Sunday Jan 23, 2011
        public void IsSatisfiedBy(int year, int month, int day, bool expected)
        {
            var testDate = new DateTime(year, month, day);
            var specification = new WeekdaySpecification();
            bool actual = specification.IsSatisfiedBy(testDate);
            Assert.Equal(expected, actual);
        }
    }
}
