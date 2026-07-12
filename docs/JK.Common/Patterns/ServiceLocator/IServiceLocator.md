[Docs](../../../README.md) > [JK.Common](../../README.md) > IServiceLocator

# IServiceLocator

**Namespace:** `JK.Common.Patterns.ServiceLocator`

Service Locator design pattern interface.

### Locate`

**Signature:** ``Locate`()``

**Summary:**
Locates and returns a service if registered.

**Returns:** Service of type T if found.

**Remarks:**
### Register`

**Signature:** ``Register`(``0 service)``

**Summary:**
Registers a service of the given type.

**Parameters:**
- **service** — Service to register.

**Remarks:**
### Unregister`

**Signature:** ``Unregister`()``

**Summary:**
Unregisters, or removes, a service from the Service Locator.

**Remarks:**