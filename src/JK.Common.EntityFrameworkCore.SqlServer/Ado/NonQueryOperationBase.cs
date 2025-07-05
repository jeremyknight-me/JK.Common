using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class NonQueryOperationBase : OperationBase
{
    private readonly CommandType _commandType;
    private readonly string _commandText;

    protected NonQueryOperationBase(DbContext context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        _commandType = adoCommandType;
        _commandText = adoCommandText;
    }

    public void Execute()
    {
        using (IDbCommand command = SetupCommand(_commandType, _commandText))
        {
            Context.Database.OpenConnection();
            command.ExecuteNonQuery();
        }
    }
}
