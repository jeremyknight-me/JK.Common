using System.Collections.Generic;
using System.Data;

namespace JK.Common.Data.Ado;

public abstract class QueryOperationBase<TQueryModel, TParameterModel> : OperationBase<TParameterModel>
{
    protected QueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public IReadOnlyList<TQueryModel> Execute(TParameterModel parameterModel)
    {
        using var command = this.MakeCommand(parameterModel);
        this.OpenConnection();
        using var dataReader = command.ExecuteReader(this.Behavior);
        var items = new List<TQueryModel>();
        var ordinalCache = this.MakeOrdinalCache(dataReader);
        while (dataReader.Read())
        {
            var item = this.MakeModel(dataReader, ordinalCache);
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
        using var command = this.MakeCommand();
        this.OpenConnection();
        using var dataReader = command.ExecuteReader(this.Behavior);
        var items = new List<TQueryModel>();
        var ordinalCache = this.MakeOrdinalCache(dataReader);
        while (dataReader.Read())
        {
            var item = this.MakeModel(dataReader, ordinalCache);
            items.Add(item);
        }

        return items;
    }

    protected virtual CommandBehavior Behavior => CommandBehavior.SingleResult | CommandBehavior.CloseConnection;

    protected abstract TQueryModel MakeModel(IDataReader dataRecord, IDictionary<string, int> ordinalCache);
    protected abstract IDictionary<string, int> MakeOrdinalCache(IDataReader dataReader);
}
