[Docs](../../README.md) > [JK.Common](../README.md) > TypeExtensions

# TypeExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **Type**.

## DoesImplement

**Signature:** `DoesImplement<T>(Type)`

**Summary:**
Determines whether or not a type implements the given interface.

**Returns:** True if implemented, otherwise false.

## GetTypeFromEntity

**Signature:** `GetTypeFromEntity(Type)`

**Summary:**
Attempts to get the underlying **Type** from an Entity Framework proxied type.

**Returns:** Underlying entity **Type**.

## IsNullable(Type)

**Signature:** `IsNullable(Type)`

**Summary:**
Determines whether or not a type is nullable (including **`Nullable<T>`**, aka T?)

**Returns:** True if nullable, otherwise false

## IsNullable<T>(Type)

**Signature:** `IsNullable<T>(Type)`

**Summary:**
Determines whether or not a type is nullable (including **`Nullable<T>`**, aka T?)

**Returns:** True if nullable, otherwise false

## IsNullableT

**Signature:** `IsNullableT(Type)`

**Summary:**
Determines whether the specified type is a nullable value type (i.e., Nullable<T>).

**Returns:** True if the type is a nullable value type; otherwise, false.