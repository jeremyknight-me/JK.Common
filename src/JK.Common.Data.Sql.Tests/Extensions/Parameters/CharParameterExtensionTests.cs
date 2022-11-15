using System;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class CharParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", "123", 3)]
    [InlineData("Bar", "2345", 4)]
    public void AddAlways_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways(name, value, SqlDbType.Char, size);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        Assert.Equal(size, parameter.Size);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways("foo", (string)null, SqlDbType.Char, 2);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_InvalidSize_Exception()
    {
        using var command = new SqlCommand();
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            command.Parameters.AddAlways("foo", (string)null, SqlDbType.Char);
        });
        Assert.StartsWith("Data type 'char' must be positive value between 0 and 8000", exception.Message);
    }

    [Theory]
    [InlineData("Foo", "123", 3)]
    [InlineData("Bar", "2345", 4)]
    public void AddIfNonNull_NonNull_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull(name, value, SqlDbType.Char, size);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull("hi", (string)null, SqlDbType.Char, 2);
        Assert.Empty(command.Parameters);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.AnsiStringFixedLength, parameter.DbType);
        Assert.Equal(SqlDbType.Char, parameter.SqlDbType);
    }
}
