using System.Data;

namespace JK.Common.EntityFrameworkCore.SqlServer.Ado;

/// <summary>
/// Base class for ADO.NET operations that return a single scalar value.
/// </summary>
/// <typeparam name="T">The type of the scalar result.</typeparam>
public abstract class ScalarOperationBase<T> : OperationBase
{
    private readonly CommandType _commandType;
    private readonly string _commandText;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScalarOperationBase{T}"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="adoCommandType">The ADO command type.</param>
    /// <param name="adoCommandText">The ADO command text.</param>
    protected ScalarOperationBase(DbContext context, CommandType adoCommandType, string adoCommandText)
        : base(context)
    {
        _commandText = adoCommandText;
        _commandType = adoCommandType;
    }

    /// <summary>
    /// Executes the command and returns the scalar result.
    /// </summary>
    /// <returns>The scalar value returned by the command.</returns>
    public T Execute()
    {
        using IDbCommand command = SetupCommand(_commandType, _commandText);
        Context.Database.OpenConnection();
        var scalar = command.ExecuteScalar();
        return (T)scalar;
    }
}
