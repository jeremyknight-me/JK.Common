using System;
using System.Collections.Generic;

namespace JK.Common.Patterns.ServiceLocator;

/// <summary>
/// Implementation of Service Locator design pattern.
/// </summary>
public class DefaultServiceLocator : IServiceLocator
{
    private static readonly object _threadLock = new();

    private static DefaultServiceLocator _instance;

    private DefaultServiceLocator()
    {
        _services = [];
    }

    public static DefaultServiceLocator Instance
    {
        get
        {
            lock (_threadLock)
            {
                _instance ??= new DefaultServiceLocator();
            }

            return _instance;
        }
    }

    private readonly Dictionary<Type, object> _services;

    /// <summary>
    /// Locates and returns a service if registered.
    /// </summary>
    /// <typeparam name="T">Interface type to find.</typeparam>
    /// <returns>Service of type T if found. Otherwise, KeyNotFoundException.</returns>
    public T Locate<T>() => (T)_services[typeof(T)];

    /// <summary>
    /// Registers a service of the given type.
    /// </summary>
    /// <typeparam name="T">Interface type of the service.</typeparam>
    /// <param name="service">Service to register.</param>
    public void Register<T>(T service) => _services.Add(typeof(T), service);

    /// <summary>
    /// Unregisters, or removes, a service from the Service Locator.
    /// </summary>
    /// <typeparam name="T">Interface type to remove.</typeparam>
    public void Unregister<T>()
    {
        Type type = typeof(T);
        _services.Remove(type);
    }
}
