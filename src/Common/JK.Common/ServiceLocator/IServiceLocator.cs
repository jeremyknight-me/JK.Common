namespace JK.Common.ServiceLocator
{
    /// <summary>
    /// Service Locator design pattern interface.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Locates and returns a service if registered.
        /// </summary>
        /// <typeparam name="T">Interface type to find.</typeparam>
        /// <returns>Service of type T if found.</returns>
        T Locate<T>();

        /// <summary>
        /// Registers a service of the given type.
        /// </summary>
        /// <typeparam name="T">Interface type of the service.</typeparam>
        /// <param name="service">Service to register.</param>
        void Register<T>(T service);

        /// <summary>
        /// Unregisters, or removes, a service from the Service Locator.
        /// </summary>
        /// <typeparam name="T">Interface type to remove.</typeparam>
        void Unregister<T>();
    }
}
