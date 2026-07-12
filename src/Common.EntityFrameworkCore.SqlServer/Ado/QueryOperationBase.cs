using System.Collections.Generic;
using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

/// <summary>
/// Base class for ADO.NET query operations that return a collection of results.
/// </summary>
/// <typeparam name="T">The type of items returned by the query.</typeparam>
public abstract class QueryOperationBase<T> : OperationBase
{
    private readonly CommandType _commandType;
    private readonly string _commandText;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryOperationBase{T}"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    /// <param name="adoCommandType">The ADO command type.</param>
    /// <param name="adoCommandText">The ADO command text.</param>
    protected QueryOperationBase(DbContext dbContext, CommandType adoCommandType, string adoCommandText)
        : base(dbContext)
    {
        _commandType = adoCommandType;
        _commandText = adoCommandText;
    }

    /// <summary>
    /// Executes the query and returns the results.
    /// </summary>
    /// <returns>A collection of items returned by the query.</returns>
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

    /// <summary>
    /// Parses a data record into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="dataRecord">The data record to parse.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    protected abstract T ParseRecord(IDataRecord dataRecord);
}
