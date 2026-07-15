[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > OperationBase

# OperationBase

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET operations executed through a **DbContext** .

## OperationBase

**Summary:** Initializes a new instance of the **OperationBase** class.

**Parameters:**

- **dbContext** — The database context.

## SetupParameters

**Signature:** `SetupParameters(IDbCommand command)`

**Summary:**
Sets up parameters for the ADO command. Override to add custom parameters.

**Parameters:**

- **command** — The ADO command to configure.

## SetupCommand

**Signature:** `SetupCommand(CommandType commandType, String commandText)`

**Summary:**
Creates and configures an ADO command with the specified command type and text.

**Parameters:**

- **commandType** — The ADO command type.

- **commandText** — The ADO command text.

**Returns:** A configured **IDbCommand** .

## Context

**Signature:** `Context`

**Summary:**
Gets the database context.