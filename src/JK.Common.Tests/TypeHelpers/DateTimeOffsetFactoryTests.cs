using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JK.Common.TypeHelpers;
using Xunit;

namespace JK.Common.Tests.TypeHelpers
{
    public class DateTimeOffsetFactoryTests
    {
        [Theory]
        [InlineData("2020-10-01T00:00:00-05:00", "Central Standard Time", "2020-10-01")]
        [InlineData("2020-12-31T00:00:00-06:00", "Central Standard Time", "2020-12-31")]
        [InlineData("2020-10-01T02:30:45-05:00", "Central Standard Time", "2020-10-01 02:30:45")]
        [InlineData("2020-12-31T23:59:59-06:00", "Central Standard Time", "2020-12-31 23:59:59")]
        [InlineData("2020-10-01T00:00:00-04:00", "Eastern Standard Time", "2020-10-01")]
        [InlineData("2020-12-31T00:00:00-05:00", "Eastern Standard Time", "2020-12-31")]
        [InlineData("2020-10-01T02:30:45-04:00", "Eastern Standard Time", "2020-10-01 02:30:45")]
        [InlineData("2020-12-31T23:59:59-05:00", "Eastern Standard Time", "2020-12-31 23:59:59")]
        public void Make_Theories(string expected, string timeZoneId, string input)
        {
            var sut = new DateTimeOffsetFactory();
            var actual = sut.Make(DateTime.Parse(input), timeZoneId);
            Assert.Equal(DateTimeOffset.Parse(expected), actual);
        }
    }
}
