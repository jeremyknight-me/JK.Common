using JK.Common.Data.Sql.Extensions.Parameters;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class FloatParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", 1.0d)]
    [InlineData("Bar", 2.0d)]
    public void AddAlways_Theories(string name, double value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddFloat(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_Null_Tests()
    {
        using var command = new SqlCommand();
        command.Parameters.AddFloat("foo", (double?)null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [InlineData("Foo", 1.0d)]
    [InlineData("Bar", 2.0d)]
    public void AddIfNonNull_NonNull_Theories(string name, double? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddFloat(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddFloat("hi", (double?)null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Double, parameter.DbType);
        Assert.Equal(SqlDbType.Float, parameter.SqlDbType);
    }
}
