using System;
using System.Data;

namespace JK.Common.Data;

public abstract class OperationBase<TParameterModel> : IDisposable
{
    private IDbConnection _connection;

    protected OperationBase(IAdoConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    protected IAdoConnectionFactory ConnectionFactory { get; }

    public void Dispose()
    {
        _connection?.Dispose();
        GC.SuppressFinalize(this);
    }

    protected abstract void ConfigureCommand(IDbCommand command, TParameterModel parameterModel);

    protected IDbCommand MakeCommand(TParameterModel parameterModel)
    {
        EnsureConnection();
        IDbCommand command = _connection.CreateCommand();
        ConfigureCommand(command, parameterModel);
        return command;
    }

    protected void OpenConnection()
    {
        EnsureConnection();
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
    }

    protected void EnsureConnection() => _connection ??= ConnectionFactory.Make();
}

public abstract class OperationBase : IDisposable
{
    private IDbConnection _connection;

    protected OperationBase(IAdoConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    protected IAdoConnectionFactory ConnectionFactory { get; }

    public void Dispose()
    {
        _connection?.Dispose();
        GC.SuppressFinalize(this);
    }

    protected abstract void ConfigureCommand(IDbCommand command);

    protected IDbCommand MakeCommand()
    {
        EnsureConnection();
        IDbCommand command = _connection.CreateCommand();
        ConfigureCommand(command);
        return command;
    }

    protected void OpenConnection()
    {
        EnsureConnection();
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
    }

    protected void EnsureConnection() => _connection ??= ConnectionFactory.Make();
}
