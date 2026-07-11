using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class ScalarOperationBase<T> : OperationBase
{
    private readonly CommandType _commandType;
    private readonly string _commandText;

    protected ScalarOperationBase(DbContext context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        _commandText = adoCommandText;
        _commandType = adoCommandType;
    }

    public T Execute()
    {
        using IDbCommand command = SetupCommand(_commandType, _commandText);
        Context.Database.OpenConnection();
        var scalar = command.ExecuteScalar();
        return (T)scalar;
    }
}
