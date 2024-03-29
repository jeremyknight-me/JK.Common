﻿namespace JK.Common.Data;

public abstract class ScalarOperationBase<TValue, TParameterModel> : OperationBase<TParameterModel>
{
    protected ScalarOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public TValue Execute(TParameterModel parameterModel)
    {
        using var command = this.MakeCommand(parameterModel);
        this.OpenConnection();
        var scalar = command.ExecuteScalar();
        return (TValue)(scalar is null ? null : scalar);
    }
}

public abstract class ScalarOperationBase<TValue> : OperationBase
{
    protected ScalarOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public TValue Execute()
    {
        using var command = this.MakeCommand();
        this.OpenConnection();
        var scalar = command.ExecuteScalar();
        return (TValue)(scalar is null ? null : scalar);
    }
}
