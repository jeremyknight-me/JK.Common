using System.Data;
using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class NonQueryOperationBase : OperationBase
{
    private readonly CommandType commandType;
    private readonly string commandText;

    protected NonQueryOperationBase(DatabaseBase context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        this.commandType = adoCommandType;
        this.commandText = adoCommandText;
    }

    public int Execute()
    {
        var count = 0;
        using (var scope = new TransactionScope())
        {
            using (var connection = this.Context.Connection)
            using (var command = this.SetupCommand(connection, this.commandType, this.commandText))
            {
                this.Context.OpenConnection();
                count = command.ExecuteNonQuery();
            }

            scope.Complete();
        }

        return count;
    }
}
