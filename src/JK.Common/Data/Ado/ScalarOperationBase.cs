using System.Data;
using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class ScalarOperationBase<T> : OperationBase
{
    private readonly CommandType commandType;
    private readonly string commandText;

    protected ScalarOperationBase(DataContextBase context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        this.commandText = adoCommandText;
        this.commandType = adoCommandType;
    }

    public T Execute()
    {
        T value;
        using (var scope = new TransactionScope())
        {
            using (var connection = this.Context.Connection)
            using (var command = this.SetupCommand(connection, this.commandType, this.commandText))
            {
                this.Context.OpenConnection();
                var scalar = command.ExecuteScalar();
                value = (T)scalar;
            }

            scope.Complete();
        }

        return value;
    }
}
