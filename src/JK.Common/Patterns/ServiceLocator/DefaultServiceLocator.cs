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

    /// <inheritdoc/>
    public T Locate<T>() => (T)_services[typeof(T)];

    /// <inheritdoc/>
    public void Register<T>(T service) => _services.Add(typeof(T), service);

    /// <inheritdoc/>
    public void Unregister<T>()
    {
        Type type = typeof(T);
        _services.Remove(type);
    }
}
