[Docs](../../README.md) > [JK.Common](../README.md) > TransactionScopeFactory

# TransactionScopeFactory

**Namespace:** `JK.Common.Data`

Factory for creating **TransactionScope** instances with default or specified isolation levels.

## Create()

**Signature:** `Create()`

**Summary:**
Creates a **TransactionScope** with the default isolation level (ReadCommitted).

**Returns:** A new **TransactionScope** instance.

## Create(IsolationLevel isolationLevel)

**Signature:** `Create(IsolationLevel isolationLevel)`

**Summary:**
Creates a **TransactionScope** with the specified isolation level.

**Parameters:**

- **isolationLevel** — The isolation level to use for the transaction.

**Returns:** A new **TransactionScope** instance.