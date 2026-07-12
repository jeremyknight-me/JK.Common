using System.Data;
using System.Data.Common;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

/// <summary>
/// Base class for ADO.NET operations executed through a <see cref="DbContext"/>.
/// </summary>
public abstract class OperationBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperationBase"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    protected OperationBase(DbContext dbContext)
    {
        Context = dbContext;
    }

    /// <summary>
    /// Gets the database context.
    /// </summary>
    protected DbContext Context { get; }

    /// <summary>
    /// Sets up parameters for the ADO command. Override to add custom parameters.
    /// </summary>
    /// <param name="command">The ADO command to configure.</param>
    protected virtual void SetupParameters(IDbCommand command)
    {
    }

    /// <summary>
    /// Creates and configures an ADO command with the specified command type and text.
    /// </summary>
    /// <param name="commandType">The ADO command type.</param>
    /// <param name="commandText">The ADO command text.</param>
    /// <returns>A configured <see cref="IDbCommand"/>.</returns>
    protected IDbCommand SetupCommand(CommandType commandType, string commandText)
    {
        DbConnection connection = Context.Database.GetDbConnection();
        DbCommand command = connection.CreateCommand();
        command.CommandText = commandText;
        command.CommandType = commandType;
        SetupParameters(command);
        return command;
    }
}
