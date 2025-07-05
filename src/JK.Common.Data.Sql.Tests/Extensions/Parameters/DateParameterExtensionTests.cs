using System;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class DateParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddDate_Data))]
    public void AddDate_Theories(string name, DateTime value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDate(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDate_NoSkipNull_Tests()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDate("foo", null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddDate_Data))]
    public void AddDate_NonNull_Theories(string name, DateTime value)
    {
        DateTime? nullableDateTime = value;
        using var command = new SqlCommand();
        command.Parameters.AddDate(name, nullableDateTime);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(nullableDateTime, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDate_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDate("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static TheoryData<string, DateTime> AddDate_Data()
        => new()
        {
            { "Foo", new DateTime(2022, 12, 31) },
            { "Bar", new DateTime(2022, 11, 1) }
        };

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Date, parameter.DbType);
        Assert.Equal(SqlDbType.Date, parameter.SqlDbType);
    }
}
