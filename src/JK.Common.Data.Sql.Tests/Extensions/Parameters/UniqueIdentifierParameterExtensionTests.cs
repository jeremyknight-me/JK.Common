using System;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class UniqueIdentifierParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddUniqueIdentifier_Data))]
    public void AddAlways_Theories(string name, Guid value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddUniqueIdentifier(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddUniqueIdentifier("foo", null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddUniqueIdentifier_Data))]
    public void AddIfNonNull_NonNull_Theories(string name, Guid value)
    {
        Guid? nullableGuid = value;
        using var command = new SqlCommand();
        command.Parameters.AddUniqueIdentifier(name, nullableGuid);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(nullableGuid, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddUniqueIdentifier("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static TheoryData<string, Guid> AddUniqueIdentifier_Data()
        => new()
        {
            { "Foo", Guid.Parse("9df7c774-027e-4ae8-bf82-c158052987f7") },
            { "Bar", Guid.Parse("ca6293b4-deb6-4d45-b119-c892d5e1c549") }
        };

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Guid, parameter.DbType);
        Assert.Equal(SqlDbType.UniqueIdentifier, parameter.SqlDbType);
    }
}
