using System;
using System.Collections.Generic;

namespace JK.Common.ServiceLocator;

/// <summary>
/// Implementation of Service Locator design pattern.
/// </summary>
public class DefaultServiceLocator : IServiceLocator
{
    #region Singleton Implementation    

    private static readonly object threadLock = new object();

    private static DefaultServiceLocator instance;

    private DefaultServiceLocator()
    {
        this.services = new Dictionary<Type, object>();
    }

    public static DefaultServiceLocator Instance
    {
        get
        {
            lock (threadLock)
            {
                if (instance == null)
                {
                    instance = new DefaultServiceLocator();
                }
            }

            return instance;
        }
    }

    #endregion

    private readonly Dictionary<Type, object> services;

    /// <summary>
    /// Locates and returns a service if registered.
    /// </summary>
    /// <typeparam name="T">Interface type to find.</typeparam>
    /// <returns>Service of type T if found. Otherwise, KeyNotFoundException.</returns>
    public T Locate<T>() => (T)this.services[typeof(T)];

    /// <summary>
    /// Registers a service of the given type.
    /// </summary>
    /// <typeparam name="T">Interface type of the service.</typeparam>
    /// <param name="service">Service to register.</param>
    public void Register<T>(T service) => this.services.Add(typeof(T), service);

    /// <summary>
    /// Unregisters, or removes, a service from the Service Locator.
    /// </summary>
    /// <typeparam name="T">Interface type to remove.</typeparam>
    public void Unregister<T>()
    {
        Type type = typeof(T);
        if (this.services.ContainsKey(type))
        {
            this.services.Remove(type);
        }
    }
}
