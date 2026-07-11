using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

/// <summary>
/// Base class for ADO.NET non-query operations (INSERT, UPDATE, DELETE) executed through a <see cref="DbContext"/>.
/// </summary>
public abstract class NonQueryOperationBase : OperationBase
{
    private readonly CommandType _commandType;
    private readonly string _commandText;

    /// <summary>
    /// Initializes a new instance of the <see cref="NonQueryOperationBase"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="adoCommandType">The ADO command type.</param>
    /// <param name="adoCommandText">The ADO command text.</param>
    protected NonQueryOperationBase(DbContext context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        _commandType = adoCommandType;
        _commandText = adoCommandText;
    }

    /// <summary>
    /// Executes the non-query command against the database.
    /// </summary>
    public void Execute()
    {
        using (IDbCommand command = SetupCommand(_commandType, _commandText))
        {
            Context.Database.OpenConnection();
            command.ExecuteNonQuery();
        }
    }
}
