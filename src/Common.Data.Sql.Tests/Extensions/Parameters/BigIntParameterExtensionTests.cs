using JK.Common.Data.Sql.Extensions.Parameters;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class BigIntParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", 1)]
    [InlineData("Bar", 2)]
    public void AddBigInt_Theories(string name, long value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddBigInt(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddBigInt_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddBigInt("foo", (long?)null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [InlineData("Foo", 1L)]
    [InlineData("Bar", 2L)]
    public void AddBigInt_NonNull_Theories(string name, long? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddBigInt(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddBigInt_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddBigInt("hi", (long?)null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Int64, parameter.DbType);
        Assert.Equal(SqlDbType.BigInt, parameter.SqlDbType);
    }
}
