[Docs](../../../README.md) > [JK.Common](../../README.md) > DefaultServiceLocator

# DefaultServiceLocator

**Namespace:** `JK.Common.Patterns.ServiceLocator`

Implementation of Service Locator design pattern.

## Locate *(Inherited)*

**Signature:** `Locate<T>()`

**Summary:**
Locates and returns a service if registered.

**Returns:** Service of type T if found.

## Register *(Inherited)*

**Signature:** `Register<T>(T service)`

**Summary:**
Registers a service of the given type.

**Parameters:**

- **service** — Service to register.

## Unregister *(Inherited)*

**Signature:** `Unregister<T>()`

**Summary:**
Unregisters, or removes, a service from the Service Locator.