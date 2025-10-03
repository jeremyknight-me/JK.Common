using System.Data;

namespace JK.Common.Data;

/// <summary>
/// Provides a base class for non-query operations with parameter models.
/// </summary>
/// <typeparam name="TParameterModel">The type of the parameter model.</typeparam>
/// <inheritdoc cref="OperationBase{TParameterModel}"/>
public abstract class NonQueryOperationBase<TParameterModel> : OperationBase<TParameterModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NonQueryOperationBase{TParameterModel}"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected NonQueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    /// <summary>
    /// Executes the non-query operation with the specified parameter model.
    /// </summary>
    /// <param name="parameterModel">The parameter model.</param>
    /// <returns>The number of rows affected.</returns>
    public int Execute(TParameterModel parameterModel)
    {
        using IDbCommand command = MakeCommand(parameterModel);
        OpenConnection();
        var count = command.ExecuteNonQuery();
        return count;
    }
}

/// <summary>
/// Provides a base class for non-query operations without parameter models.
/// </summary>
/// <inheritdoc cref="OperationBase"/>
public abstract class NonQueryOperationBase : OperationBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NonQueryOperationBase"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected NonQueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    /// <summary>
    /// Executes the non-query operation.
    /// </summary>
    /// <returns>The number of rows affected.</returns>
    public int Execute()
    {
        using IDbCommand command = MakeCommand();
        OpenConnection();
        var count = command.ExecuteNonQuery();
        return count;
    }
}
