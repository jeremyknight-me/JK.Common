using System;
using System.Data;

namespace JK.Common.Data.Ado;

/// <summary>
/// Class which created and sets up DbParameters for ADO use.
/// </summary>
public class AdoParameterFactory : ParameterFactoryBase<DbType>
{
    /// <summary>
    /// Initializes a new instance of the DbParameterFactory class.
    /// </summary>
    /// <param name="commandToUse">The ADO DB Command.</param>
    public AdoParameterFactory(IDbCommand commandToUse)
        : base(commandToUse)
    {
    }

    /// <summary>
    /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
    /// </summary>
    /// <param name="name">Name of parameter.</param>
    /// <param name="databaseType">Database type of parameter.</param>
    /// <param name="direction">Parameter direction. Defaults to 'input'.</param>
    /// <returns>DbParameter object for the provider.</returns>
    public override IDbDataParameter Make(string name, DbType databaseType, ParameterDirection direction = ParameterDirection.Input)
    {
        var parameter = this.Make(name, direction);
        parameter.DbType = databaseType;
        return parameter;
    }

    protected override void DefineStrategies()
    {
        this.Strategies.Add(typeof(bool), DbType.Boolean);
        this.Strategies.Add(typeof(DateTime), DbType.DateTime);
        this.Strategies.Add(typeof(DateTimeOffset), DbType.DateTimeOffset);
        this.Strategies.Add(typeof(decimal), DbType.Decimal);
        this.Strategies.Add(typeof(double), DbType.Double);
        this.Strategies.Add(typeof(Guid), DbType.Guid);
        this.Strategies.Add(typeof(int), DbType.Int32);
        this.Strategies.Add(typeof(string), DbType.String);
    }
}
