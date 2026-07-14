[Docs](../../README.md) > [JK.Common](../README.md) > OperationBase

# OperationBase

**Namespace:** `JK.Common.Data`

Provides a base class for operations without parameter models.

### OperationBase

**Summary:** Initializes a new instance of the **OperationBase** class.

**Parameters:**

- **connectionFactory** — The connection factory to use.

### Dispose *(Inherited)*

**Signature:** `Dispose()`

**Summary:**

### ConfigureCommand

**Signature:** `ConfigureCommand(IDbCommand command)`

**Summary:**
Configures the command.

**Parameters:**

- **command** — The command to configure.

### MakeCommand

**Signature:** `MakeCommand()`

**Summary:**
Creates and configures a command.

**Returns:** The configured **IDbCommand** .

### OpenConnection

**Signature:** `OpenConnection()`

**Summary:**
Opens the database connection if it is not already open.

### EnsureConnection

**Signature:** `EnsureConnection()`

**Summary:**
Ensures the database connection is created.

### ConnectionFactory

**Signature:** `ConnectionFactory`

**Summary:**
Gets the connection factory.