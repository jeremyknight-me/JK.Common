using System.Collections.Generic;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.SqlParameterCollection;

public class DecimalParameterTests
{
    [Theory]
    [MemberData(nameof(AddAlways_Data))]
    public void AddAlways_Theories(string name, decimal value, byte precision, byte scale)
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways(name, value, precision, scale);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbType(parameter);
    }

    [Fact]
    public void AddAlways_Null_Tests()
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways("foo", (decimal?)null, 10, 3);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbType(parameter);
    }

    [Theory]
    [MemberData(nameof(AddAlways_Data))]
    public void AddIfNonNull_NonNull_Theories(string name, decimal? value, byte precision, byte scale)
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull(name, value, precision, scale);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbType(parameter);
    }

    [Fact]
    public void AddIfNonNull_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull("hi", (decimal?)null, 10, 3);
        Assert.Empty(command.Parameters);
    }

    public static IEnumerable<object[]> AddAlways_Data()
    {
        yield return new object[] { "Foo", 1m, (byte)10, (byte)3 };
        yield return new object[] { "Bar", 2m, (byte)10, (byte)3 };
    }

    private void AssertDbType(SqlParameter parameter)
    {
        Assert.Equal(DbType.Decimal, parameter.DbType);
        Assert.Equal(SqlDbType.Decimal, parameter.SqlDbType);
        Assert.Equal(10, parameter.Precision);
        Assert.Equal(3, parameter.Scale);
    }
}
