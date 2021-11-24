using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class NonQueryOperationBase : OperationBase
{
    private readonly CommandType commandType;
    private readonly string commandText;

    protected NonQueryOperationBase(DbContext context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        this.commandType = adoCommandType;
        this.commandText = adoCommandText;
    }

    public void Execute()
    {
        using (var command = this.SetupCommand(this.commandType, this.commandText))
        {
            this.Context.Database.OpenConnection();
            command.ExecuteNonQuery();
        }
    }
}
