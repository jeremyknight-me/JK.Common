using System.Collections.Generic;
using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class QueryOperationBase<T> : OperationBase
{
    private readonly CommandType _commandType;
    private readonly string _commandText;

    protected QueryOperationBase(DbContext dbContext, CommandType adoCommandType, string adoCommandText)
        : base(dbContext)
    {
        _commandType = adoCommandType;
        _commandText = adoCommandText;
    }

    public IEnumerable<T> Execute()
    {
        List<T> items = [];
        using (IDbCommand command = SetupCommand(_commandType, _commandText))
        {
            Context.Database.OpenConnection();
            using (IDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleResult))
            {
                while (dataReader.Read())
                {
                    T item = ParseRecord(dataReader);
                    items.Add(item);
                }
            }
        }

        return items;
    }

    protected abstract T ParseRecord(IDataRecord dataRecord);
}
