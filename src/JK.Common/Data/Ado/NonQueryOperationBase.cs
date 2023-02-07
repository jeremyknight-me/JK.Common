using System.Data;
using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class NonQueryOperationBase<TParameterModel> : OperationBase
{
    protected NonQueryOperationBase(IAdoDatabase database) : base(database)
    {
    }

    protected IAdoDatabase Database { get; }

    public int Run(TParameterModel model)
    {
        using var transaction = new TransactionScope();
        using var command = this.MakeCommand(model);
        var count = this.Database.RunExecuteNonQuery(command);
        transaction.Complete();
        return count;
    }

    protected abstract IDbCommand MakeCommand(TParameterModel model);
}
