using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class NonQueryOperationBase : OperationBase
{
    protected NonQueryOperationBase(IDatabase database) : base(database)
    {
    }

    public int Run()
    {
        using var transaction = new TransactionScope();
        using var command = this.MakeCommand();
        var count = this.Database.RunExecuteNonQuery(command);
        transaction.Complete();
        return count;
    }
}
