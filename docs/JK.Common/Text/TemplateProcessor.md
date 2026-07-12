[Docs](../../README.md) > [JK.Common](../README.md) > TemplateProcessor

# TemplateProcessor

**Namespace:** `JK.Common.Text`

Class which places values from objects into a given template.

### #ctor

**Signature:** ``#ctor(String template)``

**Summary:**
Initializes a new instance of the **TemplateProcessor** class.

**Parameters:**
- **template** — Template place data values into.

**Remarks:**
### #ctor

**Signature:** ``#ctor(String template, String tokenStart, String tokenEnd)``

**Summary:**
Initializes a new instance of the **TemplateProcessor** class.

**Parameters:**
- **template** — Template place data values into.
- **tokenStart** — Starting value of the tokens used in the template.
- **tokenEnd** — Ending value of the tokens used in the template.

**Remarks:**
### ProcessTemplate

**Signature:** ``ProcessTemplate()``

**Summary:**
Processes the template using the given objects.

**Returns:** Template format with data inserted where tokens existed.

**Remarks:**

### Objects

**Signature:** ``Objects``

**Summary:**
Gets or sets the list of objects containing the data to be used in the template.

**Remarks:**
### TokenStart

**Signature:** ``TokenStart``

**Summary:**
Gets or sets the starting value of the tokens used in the template.

**Remarks:**
### TokenEnd

**Signature:** ``TokenEnd``

**Summary:**
Gets or sets the ending value of the tokens used in the template.

**Remarks:**