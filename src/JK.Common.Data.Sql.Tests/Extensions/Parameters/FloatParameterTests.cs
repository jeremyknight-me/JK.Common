using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class FloatParameterTests
{
    [Theory]
    [InlineData("Foo", 1.0d)]
    [InlineData("Bar", 2.0d)]
    public void AddAlways_Theories(string name, double value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_Null_Tests()
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways("foo", (double?)null);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [InlineData("Foo", 1.0d)]
    [InlineData("Bar", 2.0d)]
    public void AddIfNonNull_NonNull_Theories(string name, double? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull("hi", (double?)null);
        Assert.Empty(command.Parameters);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Double, parameter.DbType);
        Assert.Equal(SqlDbType.Float, parameter.SqlDbType);
    }
}
