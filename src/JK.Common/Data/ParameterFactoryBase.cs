using System;
using System.Collections.Generic;
using System.Data;

namespace JK.Common.Data;

[Obsolete("Moving this functionality to extension methods on the parameter collection classes")]
public abstract class ParameterFactoryBase<TDbType> : IParameterFactory where TDbType : struct, IConvertible
{
    private readonly IDbCommand command;
    private Dictionary<Type, TDbType> strategies;

    protected ParameterFactoryBase(IDbCommand commandToUse)
    {
        this.command = commandToUse;
    }

    protected Dictionary<Type, TDbType> Strategies
    {
        get
        {
            if (this.strategies is null)
            {
                this.strategies = new Dictionary<Type, TDbType>();
                this.DefineStrategies();
            }

            return this.strategies;
        }
    }

    public abstract IDbDataParameter Make(string name, TDbType databaseType, ParameterDirection direction);

    /// <summary>
    /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
    /// </summary>
    /// <typeparam name="T">Generic type to use.</typeparam>
    /// <param name="name">Name of parameter.</param>
    /// <param name="value">Value to insert into parameter.</param>
    /// <param name="direction">Parameter direction. Defaults to 'input'</param>
    /// <returns>DbParameter object for the provider.</returns>
    public IDbDataParameter Make<T>(string name, T value, ParameterDirection direction = ParameterDirection.Input)
    {
        var databaseType = this.Strategies[typeof(T)];
        var parameter = this.Make(name, databaseType, direction);
        parameter.Value = value;
        return parameter;
    }

    /// <summary>
    /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
    /// </summary>
    /// <typeparam name="T">Generic type to use.</typeparam>
    /// <param name="name">Name of parameter.</param>
    /// <param name="value">Value to insert into parameter.</param>
    /// <param name="direction">Parameter direction. Defaults to 'input'</param>
    /// <returns>DbParameter object for the provider.</returns>
    public IDbDataParameter Make<T>(string name, T? value, ParameterDirection direction = ParameterDirection.Input) where T : struct
    {
        var databaseType = this.Strategies[typeof(T)];
        var parameter = this.Make(name, databaseType, direction);
        parameter.Value = this.LoadValue(value);
        return parameter;
    }

    /// <summary>
    /// Uses the ADO DbProviderFactory to create a String DbParameter.
    /// </summary>
    /// <param name="name">Name of parameter.</param>
    /// <param name="value">String value to insert into parameter.</param>
    /// <param name="direction">Parameter direction. Defaults to 'input'</param>
    /// <returns>DbParameter object for the provider.</returns>
    public IDbDataParameter Make(string name, string value, ParameterDirection direction = ParameterDirection.Input)
    {
        var parameter = this.Make(name, direction);
        parameter.DbType = DbType.String;
        parameter.Value = this.LoadValue(value);
        return parameter;
    }

    protected abstract void DefineStrategies();

    protected IDbDataParameter Make(string name, ParameterDirection direction)
    {
        var parameter = this.command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Direction = direction;
        return parameter;
    }

    private object LoadValue(string value) => !string.IsNullOrEmpty(value) ? value : (object)DBNull.Value;

    private object LoadValue<T>(T? value) where T : struct => value.HasValue ? (object)value.Value : DBNull.Value;
}
