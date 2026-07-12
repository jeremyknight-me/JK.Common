[Docs](../../README.md) > [JK.Common](../README.md) > OperationBase<TParameterModel>

# OperationBase<TParameterModel>

**Namespace:** `JK.Common.Data`

Provides a base class for operations with parameter models.

**Type Parameter:** `TParameterModel` — The type of the parameter model.

<<<<<<< HEAD
## OperationBase<TParameterModel>

**Summary:** Initializes a new instance of the **OperationBaseT** class.

**Parameters:**

- **connectionFactory** — The connection factory to use.

## Dispose *(Inherited)*

**Signature:** `Dispose()`

**Summary:**

## ConfigureCommand

**Signature:** `ConfigureCommand(IDbCommand command, TParameterModel parameterModel)`
=======
### #ctor

**Signature:** ``#ctor(IAdoConnectionFactory connectionFactory)``

**Summary:**
Initializes a new instance of the **OperationBase`1** class.

**Parameters:**
- **connectionFactory** — The connection factory to use.

**Remarks:**
### Dispose *(Inherited)*

**Signature:** ``Dispose()``

**Summary:**

**Remarks:**
### ConfigureCommand

**Signature:** ``ConfigureCommand(IDbCommand command, TParameterModel parameterModel)``
>>>>>>> initial docs folder changes

**Summary:**
Configures the command with the specified parameter model.

**Parameters:**
<<<<<<< HEAD

- **command** — The command to configure.

- **parameterModel** — The parameter model to use for configuration.

## MakeCommand

**Signature:** `MakeCommand(TParameterModel parameterModel)`
=======
- **command** — The command to configure.
- **parameterModel** — The parameter model to use for configuration.

**Remarks:**
### MakeCommand

**Signature:** ``MakeCommand(TParameterModel parameterModel)``
>>>>>>> initial docs folder changes

**Summary:**
Creates and configures a command using the specified parameter model.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **parameterModel** — The parameter model to use for command configuration.

**Returns:** The configured **IDbCommand** .

<<<<<<< HEAD
## OpenConnection

**Signature:** `OpenConnection()`
=======
**Remarks:**
### OpenConnection

**Signature:** ``OpenConnection()``
>>>>>>> initial docs folder changes

**Summary:**
Opens the database connection if it is not already open.

<<<<<<< HEAD
## EnsureConnection

**Signature:** `EnsureConnection()`
=======
**Remarks:**
### EnsureConnection

**Signature:** ``EnsureConnection()``
>>>>>>> initial docs folder changes

**Summary:**
Ensures the database connection is created.

<<<<<<< HEAD
## ConnectionFactory

**Signature:** `ConnectionFactory`

**Summary:**
Gets the connection factory.
=======
**Remarks:**

### ConnectionFactory

**Signature:** ``ConnectionFactory``

**Summary:**
Gets the connection factory.

**Remarks:**
>>>>>>> initial docs folder changes
