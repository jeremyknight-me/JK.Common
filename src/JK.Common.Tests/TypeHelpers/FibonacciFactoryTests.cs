using System.Collections.Generic;
using System.Linq;
using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class FibonacciFactoryTests
{
    [Fact]
    public void Fibonacci()
    {
        IEnumerable<long> actual = FibonacciFactory.Make(0, 1, 8);
        var actualDelimited = string.Join(",", actual.Select(x => $"{x}"));
        Assert.Equal("0,1,1,2,3,5,8,13,21", actualDelimited);
    }
}
