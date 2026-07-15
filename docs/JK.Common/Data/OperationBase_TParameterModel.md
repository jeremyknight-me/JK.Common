[Docs](../../README.md) > [JK.Common](../README.md) > OperationBase<TParameterModel>

# OperationBase<TParameterModel>

**Namespace:** `JK.Common.Data`

Provides a base class for operations with parameter models.

**Type Parameter:** `TParameterModel` — The type of the parameter model.

<<<<<<< HEAD
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
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
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
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Configures the command with the specified parameter model.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **command** — The command to configure.

- **parameterModel** — The parameter model to use for configuration.

## MakeCommand

**Signature:** `MakeCommand(TParameterModel parameterModel)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **command** — The command to configure.
- **parameterModel** — The parameter model to use for configuration.

**Remarks:**
### MakeCommand

**Signature:** ``MakeCommand(TParameterModel parameterModel)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Creates and configures a command using the specified parameter model.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **parameterModel** — The parameter model to use for command configuration.

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
