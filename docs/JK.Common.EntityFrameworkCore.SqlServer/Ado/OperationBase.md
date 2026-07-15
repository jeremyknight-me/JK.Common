[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > OperationBase

# OperationBase

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET operations executed through a **DbContext** .

<<<<<<< HEAD
<<<<<<< HEAD
## OperationBase

**Summary:** Initializes a new instance of the **OperationBase** class.

**Parameters:**

- **dbContext** — The database context.

## SetupParameters

**Signature:** `SetupParameters(IDbCommand command)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
### #ctor

**Signature:** ``#ctor(DbContext dbContext)``

**Summary:**
Initializes a new instance of the **OperationBase** class.

**Parameters:**
- **dbContext** — The database context.

**Remarks:**
### SetupParameters

**Signature:** ``SetupParameters(IDbCommand command)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Sets up parameters for the ADO command. Override to add custom parameters.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **command** — The ADO command to configure.

## SetupCommand

**Signature:** `SetupCommand(CommandType commandType, String commandText)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **command** — The ADO command to configure.

**Remarks:**
### SetupCommand

**Signature:** ``SetupCommand(CommandType commandType, String commandText)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Creates and configures an ADO command with the specified command type and text.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **commandType** — The ADO command type.

=======
- **commandType** — The ADO command type.
>>>>>>> initial docs folder changes
=======
- **commandType** — The ADO command type.
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **commandText** — The ADO command text.

**Returns:** A configured **IDbCommand** .

<<<<<<< HEAD
<<<<<<< HEAD
## Context

**Signature:** `Context`

**Summary:**
Gets the database context.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**

### Context

**Signature:** ``Context``

**Summary:**
Gets the database context.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
