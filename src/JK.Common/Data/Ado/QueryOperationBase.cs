using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class QueryOperationBase<T> : OperationBase
{
    protected QueryOperationBase(IAdoDatabase database) : base(database)
    {
    }

    public IEnumerable<T> Execute(CommandBehavior behavior)
    {
        using var transaction = new TransactionScope();
        using var command = this.MakeCommand();
        using var dataReader = this.Database.RunExecuteReader(command, behavior);
        var items = new List<T>();
        while (dataReader.Read())
        {
            var item = this.GetObjectFromDataReader(dataReader);
            items.Add(item);
        }

        transaction.Complete();
        return items;
    }

    protected abstract T GetObjectFromDataReader(IDataRecord dataRecord);
}
