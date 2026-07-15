[Docs](../../README.md) > [JK.Common](../README.md) > OperationBase

# OperationBase

**Namespace:** `JK.Common.Data`

Provides a base class for operations without parameter models.

<<<<<<< HEAD
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
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
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
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Configures the command.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **command** — The command to configure.

## MakeCommand

**Signature:** `MakeCommand()`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **command** — The command to configure.

**Remarks:**
### MakeCommand

**Signature:** ``MakeCommand()``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Creates and configures a command.

**Returns:** The configured **IDbCommand** .

<<<<<<< HEAD
<<<<<<< HEAD
## OpenConnection

**Signature:** `OpenConnection()`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### OpenConnection

**Signature:** ``OpenConnection()``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Opens the database connection if it is not already open.

<<<<<<< HEAD
<<<<<<< HEAD
## EnsureConnection

**Signature:** `EnsureConnection()`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### EnsureConnection

**Signature:** ``EnsureConnection()``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Ensures the database connection is created.

<<<<<<< HEAD
<<<<<<< HEAD
## ConnectionFactory

**Signature:** `ConnectionFactory`

**Summary:**
Gets the connection factory.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**

### ConnectionFactory

**Signature:** ``ConnectionFactory``

**Summary:**
Gets the connection factory.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
