using System;
using System.Data;

namespace JK.Common.Data.Ado;

/// <summary>
/// Abstract base database context class 
/// </summary>
public abstract class DatabaseBase : IDisposable
{
    private IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseBase"/> class.
    /// </summary>
    /// <param name="connectionString">Connection string to be used.</param>
    protected DatabaseBase(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public string ConnectionString { get; }

    public IDbConnection Connection
    {
        get
        {
            this.connection ??= this.MakeConnection();
            return this.connection;
        }
    }

    public void Dispose()
    {
        this.connection?.Dispose();
    }

    public void OpenConnection()
    {
        if (this.Connection.State != ConnectionState.Open)
        {
            this.Connection.Open();
        }
    }

    public void CloseConnection()
    {
        if (this.Connection.State != ConnectionState.Closed)
        {
            this.Connection.Close();
        }
    }

    protected abstract IDbConnection MakeConnection();
}
