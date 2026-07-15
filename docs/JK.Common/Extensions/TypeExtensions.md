[Docs](../../README.md) > [JK.Common](../README.md) > TypeExtensions

# TypeExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **Type** .

## DoesImplement *(Inherited)*

**Signature:** `DoesImplement<T>(Type)`

**Summary:**
Determines whether or not a type implements the given interface.

**Returns:** True if implemented, otherwise false.

## GetTypeFromEntity *(Inherited)*

**Signature:** `GetTypeFromEntity(Type)`

**Summary:**
Attempts to get the underlying **Type** from an Entity Framework proxied type.

**Returns:** Underlying entity **Type** .

## IsNullable(Type) *(Inherited)*

**Signature:** `IsNullable(Type)`

**Summary:**
Determines whether or not a type is nullable (including **Nullable&lt;T&gt;** , aka T?)

**Returns:** True if nullable, otherwise false

## IsNullable(Type) *(Inherited)*

**Signature:** `IsNullable<T>(Type)`

**Summary:**
Determines whether or not a type is nullable (including **Nullable&lt;T&gt;** , aka T?)

**Returns:** True if nullable, otherwise false

## IsNullableT *(Inherited)*

**Signature:** `IsNullableT(Type)`

**Summary:**
Determines whether the specified type is a nullable value type (i.e., Nullable<T>).

**Returns:** True if the type is a nullable value type; otherwise, false.