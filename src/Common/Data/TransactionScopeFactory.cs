using System.Transactions;

namespace JK.Common.Data;

/// <summary>
/// Factory for creating <see cref="TransactionScope"/> instances with default or specified isolation levels.
/// </summary>
public static class TransactionScopeFactory
{
    /// <summary>
    /// Creates a <see cref="TransactionScope"/> with the default isolation level (ReadCommitted).
    /// </summary>
    /// <returns>A new <see cref="TransactionScope"/> instance.</returns>
    public static TransactionScope Create()
        => Create(IsolationLevel.ReadCommitted);

    /// <summary>
    /// Creates a <see cref="TransactionScope"/> with the specified isolation level.
    /// </summary>
    /// <param name="isolationLevel">The isolation level to use for the transaction.</param>
    /// <returns>A new <see cref="TransactionScope"/> instance.</returns>
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
