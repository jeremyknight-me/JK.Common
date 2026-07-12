[Docs](../../README.md) > [JK.Common](../README.md) > XmlSerializerHelper

# XmlSerializerHelper

**Namespace:** `JK.Common.TypeHelpers`

Wrapper/facade for XML Serialization/Deserialization functionality of .NET.

### DeserializeString`

**Signature:** ``DeserializeString`(String xml)``

**Summary:**
Uses XML serialization to convert an XML string to its object representation.

**Parameters:**
- **xml** — XML string to turn into an object

**Returns:** An object of the given type loaded from the given string.

**Remarks:**
### Serialize`

**Signature:** ``Serialize`(``0@ entity)``

**Summary:**
Uses XML serialization to convert an object into its XML representation.

**Parameters:**
- **entity** — Object to turn into XML.

**Returns:** An XML representation of an object as a string.

**Remarks:**