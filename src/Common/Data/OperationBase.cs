using System.Data;

namespace JK.Common.Data;

/// <summary>
/// Provides a base class for operations with parameter models.
/// </summary>
/// <typeparam name="TParameterModel">The type of the parameter model.</typeparam>
public abstract class OperationBase<TParameterModel> : IDisposable
{
    private IDbConnection _connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationBase{TParameterModel}"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected OperationBase(IAdoConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    /// <summary>
    /// Gets the connection factory.
    /// </summary>
    protected IAdoConnectionFactory ConnectionFactory { get; }

    /// <inheritdoc/>
    public void Dispose()
    {
        _connection?.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Configures the command with the specified parameter model.
    /// </summary>
    /// <param name="command">The command to configure.</param>
    /// <param name="parameterModel">The parameter model to use for configuration.</param>
    protected abstract void ConfigureCommand(IDbCommand command, TParameterModel parameterModel);

    /// <summary>
    /// Creates and configures a command using the specified parameter model.
    /// </summary>
    /// <param name="parameterModel">The parameter model to use for command configuration.</param>
    /// <returns>The configured <see cref="IDbCommand"/>.</returns>
    protected IDbCommand MakeCommand(TParameterModel parameterModel)
    {
        EnsureConnection();
        IDbCommand command = _connection.CreateCommand();
        ConfigureCommand(command, parameterModel);
        return command;
    }

    /// <summary>
    /// Opens the database connection if it is not already open.
    /// </summary>
    protected void OpenConnection()
    {
        EnsureConnection();
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
    }

    /// <summary>
    /// Ensures the database connection is created.
    /// </summary>
    protected void EnsureConnection() => _connection ??= ConnectionFactory.Make();
}

/// <summary>
/// Provides a base class for operations without parameter models.
/// </summary>
public abstract class OperationBase : IDisposable
{
    private IDbConnection _connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationBase"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected OperationBase(IAdoConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    /// <summary>
    /// Gets the connection factory.
    /// </summary>
    protected IAdoConnectionFactory ConnectionFactory { get; }

    /// <inheritdoc/>
    public void Dispose()
    {
        _connection?.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Configures the command.
    /// </summary>
    /// <param name="command">The command to configure.</param>
    protected abstract void ConfigureCommand(IDbCommand command);

    /// <summary>
    /// Creates and configures a command.
    /// </summary>
    /// <returns>The configured <see cref="IDbCommand"/>.</returns>
    protected IDbCommand MakeCommand()
    {
        EnsureConnection();
        IDbCommand command = _connection.CreateCommand();
        ConfigureCommand(command);
        return command;
    }

    /// <summary>
    /// Opens the database connection if it is not already open.
    /// </summary>
    protected void OpenConnection()
    {
        EnsureConnection();
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
    }

    /// <summary>
    /// Ensures the database connection is created.
    /// </summary>
    protected void EnsureConnection() => _connection ??= ConnectionFactory.Make();
}
