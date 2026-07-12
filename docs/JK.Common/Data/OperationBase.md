[Docs](../../README.md) > [JK.Common](../README.md) > OperationBase

# OperationBase

**Namespace:** `JK.Common.Data`

Provides a base class for operations without parameter models.

<<<<<<< HEAD
## OperationBase

**Summary:** Initializes a new instance of the **OperationBase** class.

**Parameters:**

- **connectionFactory** — The connection factory to use.

## Dispose *(Inherited)*

**Signature:** `Dispose()`

**Summary:**

## ConfigureCommand

**Signature:** `ConfigureCommand(IDbCommand command)`
=======
### #ctor

**Signature:** ``#ctor(IAdoConnectionFactory connectionFactory)``

**Summary:**
Initializes a new instance of the **OperationBase** class.

**Parameters:**
- **connectionFactory** — The connection factory to use.

**Remarks:**
### Dispose *(Inherited)*

**Signature:** ``Dispose()``

**Summary:**

**Remarks:**
### ConfigureCommand

**Signature:** ``ConfigureCommand(IDbCommand command)``
>>>>>>> initial docs folder changes

**Summary:**
Configures the command.

**Parameters:**
<<<<<<< HEAD

- **command** — The command to configure.

## MakeCommand

**Signature:** `MakeCommand()`
=======
- **command** — The command to configure.

**Remarks:**
### MakeCommand

**Signature:** ``MakeCommand()``
>>>>>>> initial docs folder changes

**Summary:**
Creates and configures a command.

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
