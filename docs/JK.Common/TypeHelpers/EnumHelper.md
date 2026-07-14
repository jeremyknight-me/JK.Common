[Docs](../../README.md) > [JK.Common](../README.md) > EnumHelper

# EnumHelper

**Namespace:** `JK.Common.TypeHelpers`

Class which contains enum utility methods.

### ConvertToListItems

**Signature:** `ConvertToListItems(Type type)`

**Summary:**
Gets a list of the items within an enum. Values will be filled with 
            the constant given to each enum value and the Display will be filled with
            either the enum value or the ComponentModel DescriptionAttribute.

**Parameters:**

- **type** — Enum Type to use. Ex: typeof(EnumTypeName

**Returns:** A list of ListItem for the given enum.

### GetAttribute

**Signature:** `GetAttribute(Enum enumVal)`

**Summary:**
Gets the first attribute of the specified type applied to the given enum value.

**Parameters:**

- **enumVal** — The enum value to inspect.

**Returns:** The first attribute of type T if found; otherwise, null.

### GetDisplayName

**Signature:** `GetDisplayName(T value)`

**Summary:**
Gets the display name for the specified enum value, using the DisplayAttribute if present.

**Parameters:**

- **value** — The enum value.

**Returns:** The display name if found; otherwise, the enum value name.

### GetByByte

**Signature:** `GetByByte(Byte value)`

**Summary:**
Gets an Enumeration value by its associated byte value.

**Parameters:**

- **value** — Byte value.

**Returns:** Enumeration value of type T.

### GetByByte

**Signature:** `GetByByte(Byte> value)`

**Summary:**
Gets an Enumeration value by its associated nullable byte value.

**Parameters:**

- **value** — Nullable byte value.

**Returns:** Enumeration value of type T, or null if value is null.

### GetByte

**Signature:** `GetByte(T value)`

**Summary:**
Gets the byte value associated with the given enumeration type value.

**Parameters:**

- **value** — Enumeration type value.

**Returns:** Byte value.

### GetByte

**Signature:** `GetByte(Nullable<T> value)`

**Summary:**
Gets the nullable byte value associated with the given enumeration type value.

**Parameters:**

- **value** — Nullable enumeration type value.

**Returns:** Nullable byte value.

### GetByInteger

**Signature:** `GetByInteger(Int32 value)`

**Summary:**
Gets an Enumeration value by its associated integer value.

**Parameters:**

- **value** — Integer value.

**Returns:** Enumeration value of type T.

### GetByInteger

**Signature:** `GetByInteger(Int32> value)`

**Summary:**
Gets an Enumeration value by its associated nullable integer value.

**Parameters:**

- **value** — Nullable integer value.

**Returns:** Enumeration value of type T, or null if value is null.

### GetInteger

**Signature:** `GetInteger(T value)`

**Summary:**
Gets the integer value associated with the given enumeration type value.

**Parameters:**

- **value** — Enumeration type value.

**Returns:** Integer value.

### GetInteger

**Signature:** `GetInteger(Nullable<T> value)`

**Summary:**
Gets the nullable integer value associated with the given enumeration type value.

**Parameters:**

- **value** — Nullable enumeration type value.

**Returns:** Nullable integer value.