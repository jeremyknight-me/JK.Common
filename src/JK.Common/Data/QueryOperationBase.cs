using System.Collections.Generic;
using System.Data;

namespace JK.Common.Data;

/// <summary>
/// Provides a base class for query operations with parameter models.
/// </summary>
/// <typeparam name="TQueryModel">The type of the query result model.</typeparam>
/// <typeparam name="TParameterModel">The type of the parameter model.</typeparam>
/// <inheritdoc cref="OperationBase{TParameterModel}"/>
public abstract class QueryOperationBase<TQueryModel, TParameterModel> : OperationBase<TParameterModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QueryOperationBase{TQueryModel, TParameterModel}"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected QueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    /// <summary>
    /// Executes the query operation with the specified parameter model.
    /// </summary>
    /// <param name="parameterModel">The parameter model.</param>
    /// <returns>A read-only list of query result models.</returns>
    public IReadOnlyList<TQueryModel> Execute(TParameterModel parameterModel)
    {
        using IDbCommand command = MakeCommand(parameterModel);
        OpenConnection();
        using IDataReader dataReader = command.ExecuteReader(Behavior);
        List<TQueryModel> items = [];
        IDictionary<string, int> ordinalCache = MakeOrdinalCache(dataReader);
        while (dataReader.Read())
        {
            TQueryModel item = MakeModel(dataReader, ordinalCache);
            items.Add(item);
        }

        return items;
    }

    /// <summary>
    /// Gets the command behavior for the data reader.
    /// </summary>
    protected virtual CommandBehavior Behavior => CommandBehavior.SingleResult | CommandBehavior.CloseConnection;

    /// <summary>
    /// Creates a model instance from the data record and ordinal cache.
    /// </summary>
    /// <param name="dataRecord">The data record to read from.</param>
    /// <param name="ordinalCache">The ordinal cache for column indexes.</param>
    /// <returns>The model instance.</returns>
    protected abstract TQueryModel MakeModel(IDataReader dataRecord, IDictionary<string, int> ordinalCache);

    /// <summary>
    /// Creates the ordinal cache from the data reader.
    /// </summary>
    /// <param name="dataReader">The data reader to use.</param>
    /// <returns>The ordinal cache.</returns>
    protected abstract IDictionary<string, int> MakeOrdinalCache(IDataReader dataReader);
}

/// <summary>
/// Provides a base class for query operations without parameter models.
/// </summary>
/// <typeparam name="TQueryModel">The type of the query result model.</typeparam>
/// <inheritdoc cref="OperationBase"/>
public abstract class QueryOperationBase<TQueryModel> : OperationBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QueryOperationBase{TQueryModel}"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected QueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    /// <summary>
    /// Executes the query operation.
    /// </summary>
    /// <returns>A read-only list of query result models.</returns>
    public IReadOnlyList<TQueryModel> Execute()
    {
        using IDbCommand command = MakeCommand();
        OpenConnection();
        using IDataReader dataReader = command.ExecuteReader(Behavior);
        List<TQueryModel> items = [];
        IDictionary<string, int> ordinalCache = MakeOrdinalCache(dataReader);
        while (dataReader.Read())
        {
            TQueryModel item = MakeModel(dataReader, ordinalCache);
            items.Add(item);
        }

        return items;
    }

    /// <summary>
    /// Gets the command behavior for the data reader.
    /// </summary>
    protected virtual CommandBehavior Behavior => CommandBehavior.SingleResult | CommandBehavior.CloseConnection;

    /// <summary>
    /// Creates a model instance from the data record and ordinal cache.
    /// </summary>
    /// <param name="dataRecord">The data record to read from.</param>
    /// <param name="ordinalCache">The ordinal cache for column indexes.</param>
    /// <returns>The model instance.</returns>
    protected abstract TQueryModel MakeModel(IDataReader dataRecord, IDictionary<string, int> ordinalCache);

    /// <summary>
    /// Creates the ordinal cache from the data reader.
    /// </summary>
    /// <param name="dataReader">The data reader to use.</param>
    /// <returns>The ordinal cache.</returns>
    protected abstract IDictionary<string, int> MakeOrdinalCache(IDataReader dataReader);
}
