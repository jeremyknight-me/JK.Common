using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class ScalarOperationBase<T> : OperationBase
{
    protected ScalarOperationBase(IDatabase database) : base(database)
    {
    }

    public T Execute()
    {
        using var transaction = new TransactionScope();
        using var command = this.MakeCommand();
        var scalar = this.Database.RunExecuteScaler(command);
        var value = (T)scalar;
        transaction.Complete();
        return value;
    }
}
