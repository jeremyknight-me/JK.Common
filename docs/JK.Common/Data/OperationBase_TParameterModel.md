[Docs](../../README.md) > [JK.Common](../README.md) > OperationBase<TParameterModel>

# OperationBase<TParameterModel>

**Namespace:** `JK.Common.Data`

Provides a base class for operations with parameter models.

**Type Parameter:** `TParameterModel` — The type of the parameter model.

### OperationBase<TParameterModel>

**Summary:** Initializes a new instance of the **OperationBase`1** class.

**Parameters:**

- **connectionFactory** — The connection factory to use.

### Dispose *(Inherited)*

**Signature:** `Dispose()`

**Summary:**

### ConfigureCommand

**Signature:** `ConfigureCommand(IDbCommand command, TParameterModel parameterModel)`

**Summary:**
Configures the command with the specified parameter model.

**Parameters:**

- **command** — The command to configure.

- **parameterModel** — The parameter model to use for configuration.

### MakeCommand

**Signature:** `MakeCommand(TParameterModel parameterModel)`

**Summary:**
Creates and configures a command using the specified parameter model.

**Parameters:**

- **parameterModel** — The parameter model to use for command configuration.

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