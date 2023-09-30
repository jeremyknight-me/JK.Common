namespace JK.Common.Data.Ado;

public abstract class NonQueryOperationBase<TParameterModel> : OperationBase<TParameterModel>
{
    protected NonQueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public int Execute(TParameterModel parameterModel)
    {
        using var command = this.MakeCommand(parameterModel);
        this.OpenConnection();
        var count = command.ExecuteNonQuery();
        return count;
    }
}

public abstract class NonQueryOperationBase : OperationBase
{
    protected NonQueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public int Execute()
    {
        using var command = this.MakeCommand();
        this.OpenConnection();
        var count = command.ExecuteNonQuery();
        return count;
    }
}
