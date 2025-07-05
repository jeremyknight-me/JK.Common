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
    public void AddChar_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddChar(name, value, size);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        Assert.Equal(size, parameter.Size);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddChar_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddChar("foo", null, 2, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddChar_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddChar("hi", null, 2, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    [Theory]
    [InlineData(9000)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void AddChar_InvalidSizeException_Theories(int size)
    {
        using var command = new SqlCommand();
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            command.Parameters.AddChar("foo", null, size);
        });
        Assert.StartsWith("Data type 'char' must be positive value between 0 and 8000", exception.Message);
    }

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.AnsiStringFixedLength, parameter.DbType);
        Assert.Equal(SqlDbType.Char, parameter.SqlDbType);
    }
}
