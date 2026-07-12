using System.Data;

namespace JK.Common.Data;

/// <summary>
/// Provides a base class for scalar operations with parameter models.
/// </summary>
/// <typeparam name="TValue">The type of the scalar result.</typeparam>
/// <typeparam name="TParameterModel">The type of the parameter model.</typeparam>
/// <inheritdoc cref="OperationBase{TParameterModel}"/>
public abstract class ScalarOperationBase<TValue, TParameterModel> : OperationBase<TParameterModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScalarOperationBase{TValue, TParameterModel}"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected ScalarOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    /// <summary>
    /// Executes the scalar operation with the specified parameter model.
    /// </summary>
    /// <param name="parameterModel">The parameter model.</param>
    /// <returns>The scalar result.</returns>
    public TValue Execute(TParameterModel parameterModel)
    {
        using IDbCommand command = MakeCommand(parameterModel);
        OpenConnection();
        var scalar = command.ExecuteScalar();
        return (TValue)(scalar is null ? null : scalar);
    }
}

/// <summary>
/// Provides a base class for scalar operations without parameter models.
/// </summary>
/// <typeparam name="TValue">The type of the scalar result.</typeparam>
/// <inheritdoc cref="OperationBase"/>
public abstract class ScalarOperationBase<TValue> : OperationBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScalarOperationBase{TValue}"/> class.
    /// </summary>
    /// <param name="connectionFactory">The connection factory to use.</param>
    protected ScalarOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    /// <summary>
    /// Executes the scalar operation.
    /// </summary>
    /// <returns>The scalar result.</returns>
    public TValue Execute()
    {
        using IDbCommand command = MakeCommand();
        OpenConnection();
        var scalar = command.ExecuteScalar();
        return (TValue)(scalar is null ? null : scalar);
    }
}
