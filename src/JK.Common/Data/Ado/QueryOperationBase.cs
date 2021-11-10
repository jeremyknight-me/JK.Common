using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace JK.Common.Data.Ado;

public abstract class QueryOperationBase<T> : OperationBase
{
    private readonly CommandType commandType;
    private readonly string commandText;

    protected QueryOperationBase(DataContextBase context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        this.commandType = adoCommandType;
        this.commandText = adoCommandText;
    }

    public IEnumerable<T> Execute()
    {
        var items = new List<T>();
        using (var scope = new TransactionScope())
        {
            using (var connection = this.Context.Connection)
            using (var command = this.SetupCommand(connection, this.commandType, this.commandText))
            {
                this.Context.OpenConnection();
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var item = this.GetObjectFromDataReader(dataReader);
                        items.Add(item);
                    }
                }
            }

            scope.Complete();
        }

        return items;
    }

    protected abstract T GetObjectFromDataReader(IDataRecord dataRecord);
}
