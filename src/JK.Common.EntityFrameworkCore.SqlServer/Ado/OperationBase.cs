using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class OperationBase
{
    protected OperationBase(DbContext dbContext)
    {
        this.Context = dbContext;
    }

    protected DbContext Context { get; }

    protected virtual void SetupParameters(IDbCommand command)
    {
    }

    protected IDbCommand SetupCommand(CommandType commandType, string commandText)
    {
        var connection = this.Context.Database.GetDbConnection();
        var command = connection.CreateCommand();
        command.CommandText = commandText;
        command.CommandType = commandType;
        this.SetupParameters(command);
        return command;
    }
}
