using System.Collections.Generic;
using System.Data;

namespace JK.Common.Data;

public abstract class QueryOperationBase<TQueryModel, TParameterModel> : OperationBase<TParameterModel>
{
    protected QueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

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

    protected virtual CommandBehavior Behavior => CommandBehavior.SingleResult | CommandBehavior.CloseConnection;

    protected abstract TQueryModel MakeModel(IDataReader dataRecord, IDictionary<string, int> ordinalCache);
    protected abstract IDictionary<string, int> MakeOrdinalCache(IDataReader dataReader);
}

public abstract class QueryOperationBase<TQueryModel> : OperationBase
{
    protected QueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

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

    protected virtual CommandBehavior Behavior => CommandBehavior.SingleResult | CommandBehavior.CloseConnection;

    protected abstract TQueryModel MakeModel(IDataReader dataRecord, IDictionary<string, int> ordinalCache);
    protected abstract IDictionary<string, int> MakeOrdinalCache(IDataReader dataReader);
}
