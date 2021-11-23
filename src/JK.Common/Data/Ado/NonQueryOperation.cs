using System.Data;
using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class NonQueryOperation : OperationBase
{
    private readonly CommandType commandType;
    private readonly string commandText;

    protected NonQueryOperation(DataContextBase context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        this.commandType = adoCommandType;
        this.commandText = adoCommandText;
    }

    public void Execute()
    {
        using (var scope = new TransactionScope())
        {
            using (var connection = this.Context.Connection)
            using (var command = this.SetupCommand(connection, this.commandType, this.commandText))
            {
                this.Context.OpenConnection();
                command.ExecuteNonQuery();
            }

            scope.Complete();
        }
    }
}
