using System.Data;

namespace JK.Common.Data.Ado;

/// <summary>
/// Abstract base database context class 
/// </summary>
public abstract class Database<TConnection> : IDatabase
    where TConnection : IDbConnection
{
    private readonly string connectionString;
    private TConnection connection;

    protected Database(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Dispose()
    {
        this.connection?.Dispose();
    }

    public IDbCommand MakeCommand() => this.connection.CreateCommand();

    public int RunExecuteNonQuery(IDbCommand command)
    {
        this.OpenConnection();
        return command.ExecuteNonQuery();
    }

    public IDataReader RunExecuteReader(IDbCommand command, CommandBehavior behavior)
    {
        this.OpenConnection();
        return command.ExecuteReader(behavior);
    }

    public object? RunExecuteScaler(IDbCommand command)
    {
        this.OpenConnection();
        return command.ExecuteScalar();
    }

    protected abstract TConnection MakeConnection(string connectionString);

    private void OpenConnection()
    {
        this.connection ??= this.MakeConnection(this.connectionString);
        if (this.connection.State != ConnectionState.Open)
        {
            this.connection.Open();
        }
    }
}
