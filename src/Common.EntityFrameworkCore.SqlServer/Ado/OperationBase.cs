using System.Data;
using System.Data.Common;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class OperationBase
{
    protected OperationBase(DbContext dbContext)
    {
        Context = dbContext;
    }

    protected DbContext Context { get; }

    protected virtual void SetupParameters(IDbCommand command)
    {
    }

    protected IDbCommand SetupCommand(CommandType commandType, string commandText)
    {
        DbConnection connection = Context.Database.GetDbConnection();
        DbCommand command = connection.CreateCommand();
        command.CommandText = commandText;
        command.CommandType = commandType;
        SetupParameters(command);
        return command;
    }
}
