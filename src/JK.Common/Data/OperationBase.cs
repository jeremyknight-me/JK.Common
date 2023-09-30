using System;
using System.Data;

namespace JK.Common.Data;

public abstract class OperationBase<TParameterModel> : IDisposable
{
    private IDbConnection connection;

    protected OperationBase(IAdoConnectionFactory connectionFactory)
    {
        this.ConnectionFactory = connectionFactory;
    }

    protected IAdoConnectionFactory ConnectionFactory { get; }

    public void Dispose() => this.connection?.Dispose();

    protected abstract void ConfigureCommand(IDbCommand command, TParameterModel parameterModel);

    protected IDbCommand MakeCommand(TParameterModel parameterModel)
    {
        this.EnsureConnection();
        var command = this.connection.CreateCommand();
        this.ConfigureCommand(command, parameterModel);
        return command;
    }

    protected void OpenConnection()
    {
        this.EnsureConnection();
        if (this.connection.State != ConnectionState.Open)
        {
            this.connection.Open();
        }
    }

    protected void EnsureConnection() => this.connection ??= this.ConnectionFactory.Make();
}

public abstract class OperationBase : IDisposable
{
    private IDbConnection connection;

    protected OperationBase(IAdoConnectionFactory connectionFactory)
    {
        this.ConnectionFactory = connectionFactory;
    }

    protected IAdoConnectionFactory ConnectionFactory { get; }

    public void Dispose() => this.connection?.Dispose();

    protected abstract void ConfigureCommand(IDbCommand command);

    protected IDbCommand MakeCommand()
    {
        this.EnsureConnection();
        var command = this.connection.CreateCommand();
        this.ConfigureCommand(command);
        return command;
    }

    protected void OpenConnection()
    {
        this.EnsureConnection();
        if (this.connection.State != ConnectionState.Open)
        {
            this.connection.Open();
        }
    }

    protected void EnsureConnection() => this.connection ??= this.ConnectionFactory.Make();
}
