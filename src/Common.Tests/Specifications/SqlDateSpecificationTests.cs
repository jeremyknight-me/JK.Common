using JK.Common.Specifications;

namespace JK.Common.Tests.Specifications;

public class SqlDateSpecificationTests
{
    [Theory]
    [InlineData(1752, 12, 31, false)] // < 1753
    [InlineData(1753, 1, 1, true)] // = 1753
    [InlineData(1754, 1, 1, true)] // > 1753
    public void IsSatisfiedBy(int year, int month, int day, bool expected)
    {
        var date = new DateTime(year, month, day);
        var specification = new SqlDateSpecification();
        var actual = specification.IsSatisfiedBy(date);
        Assert.Equal(expected, actual);
    }
}
