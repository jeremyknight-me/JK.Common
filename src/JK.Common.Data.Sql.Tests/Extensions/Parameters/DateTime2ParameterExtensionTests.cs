using System;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class DateTime2ParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddDateTime2_Data))]
    public void AddDateTime2_Theories(string name, DateTime value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime2(name, value, 2);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTime2_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime2("foo", null, 2, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddDateTime2_Data))]
    public void AddDateTime2_NonNull_Theories(string name, DateTime value)
    {
        DateTime? nullableDateTime = value;
        using var command = new SqlCommand();
        command.Parameters.AddDateTime2(name, nullableDateTime, 2);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(nullableDateTime, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTime2_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime2("hi", null, 2, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static TheoryData<string, DateTime> AddDateTime2_Data()
        => new()
        {
            { "Foo", new DateTime(2022, 12, 31) },
            { "Bar", new DateTime(2022, 11, 1) }
        };

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.DateTime2, parameter.DbType);
        Assert.Equal(SqlDbType.DateTime2, parameter.SqlDbType);
        Assert.Equal(2, parameter.Precision);
    }
}
