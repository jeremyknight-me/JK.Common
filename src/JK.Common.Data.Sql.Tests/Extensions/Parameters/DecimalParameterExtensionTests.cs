using System.Collections.Generic;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class DecimalParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddDecimal_Data))]
    public void AddDecimal_Theories(string name, decimal value, byte precision, byte scale)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDecimal(name, value, precision, scale);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDecimal_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDecimal("foo", null, 10, 3, skipIfNull: false);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddDecimal_Data))]
    public void AddDecimal_NonNull_Theories(string name, decimal? value, byte precision, byte scale)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDecimal(name, value, precision, scale);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDecimal_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDecimal("hi", null, 10, 3, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static IEnumerable<object[]> AddDecimal_Data()
    {
        yield return new object[] { "Foo", 1m, (byte)10, (byte)3 };
        yield return new object[] { "Bar", 2m, (byte)10, (byte)3 };
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Decimal, parameter.DbType);
        Assert.Equal(SqlDbType.Decimal, parameter.SqlDbType);
        Assert.Equal(10, parameter.Precision);
        Assert.Equal(3, parameter.Scale);
    }
}
