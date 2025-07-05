using System;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class DateTimeParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddDateTime_Data))]
    public void AddDateTime_Theories(string name, DateTime value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTime_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime("foo", null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddDateTime_Data))]
    public void AddDateTime_NonNull_Theories(string name, DateTime value)
    {
        DateTime? nullableDateTime = value;
        using var command = new SqlCommand();
        command.Parameters.AddDateTime(name, nullableDateTime);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(nullableDateTime, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTime_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static TheoryData<string, DateTime> AddDateTime_Data()
        => new()
        {
            { "Foo", new DateTime(2022, 12, 31) },
            { "Bar", new DateTime(2022, 11, 1) }
        };

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.DateTime, parameter.DbType);
        Assert.Equal(SqlDbType.DateTime, parameter.SqlDbType);
    }
}
