[Docs](../../README.md) > [JK.Common](../README.md) > EnumHelper

# EnumHelper

**Namespace:** `JK.Common.TypeHelpers`

Class which contains enum utility methods.

<<<<<<< HEAD
<<<<<<< HEAD
## ConvertToListItems

**Signature:** `ConvertToListItems(Type type)`
=======
### ConvertToListItems

**Signature:** ``ConvertToListItems(Type type)``
>>>>>>> initial docs folder changes
=======
### ConvertToListItems

**Signature:** ``ConvertToListItems(Type type)``
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets a list of the items within an enum. Values will be filled with 
            the constant given to each enum value and the Display will be filled with
            either the enum value or the ComponentModel DescriptionAttribute.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **type** — Enum Type to use. Ex: typeof(EnumTypeName

**Returns:** A list of ListItem for the given enum.

<<<<<<< HEAD
<<<<<<< HEAD
## GetAttribute

**Signature:** `GetAttribute<T>(Enum enumVal)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetAttribute`

**Signature:** ``GetAttribute`(Enum@ enumVal)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the first attribute of the specified type applied to the given enum value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **enumVal** — The enum value to inspect.

**Returns:** The first attribute of type T if found; otherwise, null.

<<<<<<< HEAD
<<<<<<< HEAD
## GetDisplayName

**Signature:** `GetDisplayName<T>(T value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetDisplayName`

**Signature:** ``GetDisplayName`(``0@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the display name for the specified enum value, using the DisplayAttribute if present.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — The enum value.

**Returns:** The display name if found; otherwise, the enum value name.

<<<<<<< HEAD
<<<<<<< HEAD
## GetByByte(Byte value)

**Signature:** `GetByByte<T>(Byte value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetByByte`

**Signature:** ``GetByByte`(Byte@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets an Enumeration value by its associated byte value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Byte value.

**Returns:** Enumeration value of type T.

<<<<<<< HEAD
<<<<<<< HEAD
## GetByByte(Nullable<Byte> value)

**Signature:** `GetByByte<T>(Nullable<Byte> value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetByByte`

**Signature:** ``GetByByte`(Byte}@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets an Enumeration value by its associated nullable byte value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Nullable byte value.

**Returns:** Enumeration value of type T, or null if value is null.

<<<<<<< HEAD
<<<<<<< HEAD
## GetByte(T value)

**Signature:** `GetByte<T>(T value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetByte`

**Signature:** ``GetByte`(``0@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the byte value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Enumeration type value.

**Returns:** Byte value.

<<<<<<< HEAD
<<<<<<< HEAD
## GetByte(Nullable<T> value)

**Signature:** `GetByte<T>(Nullable<T> value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetByte`

**Signature:** ``GetByte`(Nullable{``0}@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the nullable byte value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Nullable enumeration type value.

**Returns:** Nullable byte value.

<<<<<<< HEAD
<<<<<<< HEAD
## GetByInteger(Int32 value)

**Signature:** `GetByInteger<T>(Int32 value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetByInteger`

**Signature:** ``GetByInteger`(Int32@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets an Enumeration value by its associated integer value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Integer value.

**Returns:** Enumeration value of type T.

<<<<<<< HEAD
<<<<<<< HEAD
## GetByInteger(Nullable<Int32> value)

**Signature:** `GetByInteger<T>(Nullable<Int32> value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetByInteger`

**Signature:** ``GetByInteger`(Int32}@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets an Enumeration value by its associated nullable integer value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Nullable integer value.

**Returns:** Enumeration value of type T, or null if value is null.

<<<<<<< HEAD
<<<<<<< HEAD
## GetInteger(T value)

**Signature:** `GetInteger<T>(T value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetInteger`

**Signature:** ``GetInteger`(``0@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the integer value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Enumeration type value.

**Returns:** Integer value.

<<<<<<< HEAD
<<<<<<< HEAD
## GetInteger(Nullable<T> value)

**Signature:** `GetInteger<T>(Nullable<T> value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetInteger`

**Signature:** ``GetInteger`(Nullable{``0}@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the nullable integer value associated with the given enumeration type value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **value** — Nullable enumeration type value.

**Returns:** Nullable integer value.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — Nullable enumeration type value.

**Returns:** Nullable integer value.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
