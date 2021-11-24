using System.Collections.Generic;
using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

public abstract class QueryOperationBase<T> : OperationBase
{
    private readonly CommandType commandType;
    private readonly string commandText;

    protected QueryOperationBase(DbContext dbContext, CommandType adoCommandType, string adoCommandText)
        : base(dbContext)
    {
        this.commandType = adoCommandType;
        this.commandText = adoCommandText;
    }

    public IEnumerable<T> Execute()
    {
        var items = new List<T>();
        using (var command = this.SetupCommand(this.commandType, this.commandText))
        {
            this.Context.Database.OpenConnection();
            using (var dataReader = command.ExecuteReader(CommandBehavior.SingleResult))
            {
                while (dataReader.Read())
                {
                    var item = this.ParseRecord(dataReader);
                    items.Add(item);
                }
            }
        }

        return items;
    }

    protected abstract T ParseRecord(IDataRecord dataRecord);
}
