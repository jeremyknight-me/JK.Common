using System.Collections.Generic;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class TinyIntParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddTinyInt_Data))]
    public void AddTinyInt_Theories(string name, byte value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddTinyInt_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt("foo", null, skipIfNull: false);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddTinyInt_Data))]
    public void AddTinyInt_NonNull_Theories(string name, byte? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddTinyInt_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static IEnumerable<object[]> AddTinyInt_Data()
    {
        yield return new object[] { "Foo", (byte)1 };
        yield return new object[] { "Bar", (byte)2 };
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Byte, parameter.DbType);
        Assert.Equal(SqlDbType.TinyInt, parameter.SqlDbType);
    }
}
