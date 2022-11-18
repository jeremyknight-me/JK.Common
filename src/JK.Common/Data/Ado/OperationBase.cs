using System.Data;

namespace JK.Common.Data.Ado;

public abstract class OperationBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperationBase"/> class.
    /// </summary>
    /// <param name="context">The ADO base data context to use.</param>
    protected OperationBase(IDatabase database)
    {
        this.Database = database;
    }

    protected IDatabase Database { get; }
    protected abstract IDbCommand MakeCommand();
}
