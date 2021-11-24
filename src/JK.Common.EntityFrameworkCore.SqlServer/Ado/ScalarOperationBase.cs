using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class ScalarOperationBase<T> : OperationBase
{
    private readonly CommandType commandType;
    private readonly string commandText;

    protected ScalarOperationBase(DbContext context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        this.commandText = adoCommandText;
        this.commandType = adoCommandType;
    }

    public T Execute()
    {
        using var command = this.SetupCommand(this.commandType, this.commandText);
        this.Context.Database.OpenConnection();
        var scalar = command.ExecuteScalar();
        return (T)scalar;
    }
}
