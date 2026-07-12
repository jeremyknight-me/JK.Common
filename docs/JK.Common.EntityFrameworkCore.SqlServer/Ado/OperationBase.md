[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > OperationBase

# OperationBase

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET operations executed through a **DbContext** .

<<<<<<< HEAD
## OperationBase

**Summary:** Initializes a new instance of the **OperationBase** class.

**Parameters:**

- **dbContext** — The database context.

## SetupParameters

**Signature:** `SetupParameters(IDbCommand command)`
=======
### #ctor

**Signature:** ``#ctor(DbContext dbContext)``

**Summary:**
Initializes a new instance of the **OperationBase** class.

**Parameters:**
- **dbContext** — The database context.

**Remarks:**
### SetupParameters

**Signature:** ``SetupParameters(IDbCommand command)``
>>>>>>> initial docs folder changes

**Summary:**
Sets up parameters for the ADO command. Override to add custom parameters.

**Parameters:**
<<<<<<< HEAD

- **command** — The ADO command to configure.

## SetupCommand

**Signature:** `SetupCommand(CommandType commandType, String commandText)`
=======
- **command** — The ADO command to configure.

**Remarks:**
### SetupCommand

**Signature:** ``SetupCommand(CommandType commandType, String commandText)``
>>>>>>> initial docs folder changes

**Summary:**
Creates and configures an ADO command with the specified command type and text.

**Parameters:**
<<<<<<< HEAD

- **commandType** — The ADO command type.

=======
- **commandType** — The ADO command type.
>>>>>>> initial docs folder changes
- **commandText** — The ADO command text.

**Returns:** A configured **IDbCommand** .

<<<<<<< HEAD
## Context

**Signature:** `Context`

**Summary:**
Gets the database context.
=======
**Remarks:**

### Context

**Signature:** ``Context``

**Summary:**
Gets the database context.

**Remarks:**
>>>>>>> initial docs folder changes
