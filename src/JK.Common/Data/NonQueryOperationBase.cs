using System.Data;

namespace JK.Common.Data;

public abstract class NonQueryOperationBase<TParameterModel> : OperationBase<TParameterModel>
{
    protected NonQueryOperationBase(IAdoConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public int Execute(TParameterModel parameterModel)
    {
        using IDbCommand command = MakeCommand(parameterModel);
        OpenConnection();
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
        using IDbCommand command = MakeCommand();
        OpenConnection();
        var count = command.ExecuteNonQuery();
        return count;
    }
}
