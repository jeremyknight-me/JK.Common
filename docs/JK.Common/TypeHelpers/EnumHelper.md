[Docs](../../README.md) > [JK.Common](../README.md) > EnumHelper

# EnumHelper

**Namespace:** `JK.Common.TypeHelpers`

Class which contains enum utility methods.

<<<<<<< HEAD
## ConvertToListItems

**Signature:** `ConvertToListItems(Type type)`
=======
### ConvertToListItems

**Signature:** ``ConvertToListItems(Type type)``
>>>>>>> initial docs folder changes

**Summary:**
Gets a list of the items within an enum. Values will be filled with 
            the constant given to each enum value and the Display will be filled with
            either the enum value or the ComponentModel DescriptionAttribute.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **type** — Enum Type to use. Ex: typeof(EnumTypeName

**Returns:** A list of ListItem for the given enum.

<<<<<<< HEAD
## GetAttribute

**Signature:** `GetAttribute<T>(Enum enumVal)`
=======
**Remarks:**
### GetAttribute`

**Signature:** ``GetAttribute`(Enum@ enumVal)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the first attribute of the specified type applied to the given enum value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **enumVal** — The enum value to inspect.

**Returns:** The first attribute of type T if found; otherwise, null.

<<<<<<< HEAD
## GetDisplayName

**Signature:** `GetDisplayName<T>(T value)`
=======
**Remarks:**
### GetDisplayName`

**Signature:** ``GetDisplayName`(``0@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the display name for the specified enum value, using the DisplayAttribute if present.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — The enum value.

**Returns:** The display name if found; otherwise, the enum value name.

<<<<<<< HEAD
## GetByByte(Byte value)

**Signature:** `GetByByte<T>(Byte value)`
=======
**Remarks:**
### GetByByte`

**Signature:** ``GetByByte`(Byte@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets an Enumeration value by its associated byte value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — Byte value.

**Returns:** Enumeration value of type T.

<<<<<<< HEAD
## GetByByte(Nullable<Byte> value)

**Signature:** `GetByByte<T>(Nullable<Byte> value)`
=======
**Remarks:**
### GetByByte`

**Signature:** ``GetByByte`(Byte}@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets an Enumeration value by its associated nullable byte value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — Nullable byte value.

**Returns:** Enumeration value of type T, or null if value is null.

<<<<<<< HEAD
## GetByte(T value)

**Signature:** `GetByte<T>(T value)`
=======
**Remarks:**
### GetByte`

**Signature:** ``GetByte`(``0@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the byte value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — Enumeration type value.

**Returns:** Byte value.

<<<<<<< HEAD
## GetByte(Nullable<T> value)

**Signature:** `GetByte<T>(Nullable<T> value)`
=======
**Remarks:**
### GetByte`

**Signature:** ``GetByte`(Nullable{``0}@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the nullable byte value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — Nullable enumeration type value.

**Returns:** Nullable byte value.

<<<<<<< HEAD
## GetByInteger(Int32 value)

**Signature:** `GetByInteger<T>(Int32 value)`
=======
**Remarks:**
### GetByInteger`

**Signature:** ``GetByInteger`(Int32@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets an Enumeration value by its associated integer value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — Integer value.

**Returns:** Enumeration value of type T.

<<<<<<< HEAD
## GetByInteger(Nullable<Int32> value)

**Signature:** `GetByInteger<T>(Nullable<Int32> value)`
=======
**Remarks:**
### GetByInteger`

**Signature:** ``GetByInteger`(Int32}@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets an Enumeration value by its associated nullable integer value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — Nullable integer value.

**Returns:** Enumeration value of type T, or null if value is null.

<<<<<<< HEAD
## GetInteger(T value)

**Signature:** `GetInteger<T>(T value)`
=======
**Remarks:**
### GetInteger`

**Signature:** ``GetInteger`(``0@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the integer value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **value** — Enumeration type value.

**Returns:** Integer value.

<<<<<<< HEAD
## GetInteger(Nullable<T> value)

**Signature:** `GetInteger<T>(Nullable<T> value)`
=======
**Remarks:**
### GetInteger`

**Signature:** ``GetInteger`(Nullable{``0}@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the nullable integer value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD

- **value** — Nullable enumeration type value.

**Returns:** Nullable integer value.
=======
- **value** — Nullable enumeration type value.

**Returns:** Nullable integer value.

**Remarks:**
>>>>>>> initial docs folder changes
