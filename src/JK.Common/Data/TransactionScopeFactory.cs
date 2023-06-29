using System.Transactions;

namespace JK.Common.Data;

public static class TransactionScopeFactory
{
    public static TransactionScope Create()
        => Create(IsolationLevel.ReadCommitted);

    public static TransactionScope Create(IsolationLevel isolationLevel)
    {
        var options = new TransactionOptions
        {
            IsolationLevel = isolationLevel,
            Timeout = TransactionManager.MaximumTimeout
        };
        return new TransactionScope(TransactionScopeOption.Required, options);
    }
}
