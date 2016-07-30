using System;
using System.Web;
using System.Web.Caching;

namespace DL.Core.Web
{
    /// <summary>
    /// This class allows application wide access to the Session and Application stores.
    /// </summary>
    public abstract class DataPersistenceBase
    {
        private static HttpContext Context
        {
            get { return HttpContext.Current; }
        }

        #region Protected Methods - Application Variable Methods

        /// <summary>Gets an object from the application store.</summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="key">Key of application store object to retrieve.</param>
        /// <returns>Correctly typed object from the application store.</returns>
        protected T GetFromApplication<T>(string key)
        {
            object item = Context.Application[key];

            if (item == null)
            {
                return default(T);
            }

            return (T)item;
        }

        /// <summary>Sets a value into the application store.</summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="key">Key to use when setting the object in the application store.</param>
        /// <param name="value">Value to set the object in the application store.</param>
        protected void SetInApplication<T>(string key, T value)
        {
            Context.Application[key] = value;
        }

        /// <summary>Removes an object from the application store.</summary>
        /// <param name="key">Key of application store object to remove.</param>
        protected void RemoveFromApplication(string key)
        {
            Context.Application.Remove(key);
        }

        #endregion

        #region Protected Methods - Cache Methods

        /// <summary>Gets an object from the cache store.</summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="key">Key of cache store object to retrieve.</param>
        /// <returns>Correctly typed object from the cache store.</returns>
        protected T GetFromCache<T>(string key)
        {
            object item = Context.Cache[key];

            if (item == null)
            {
                return default(T);
            }

            return (T)item;
        }

        /// <summary>Sets a value into the cache store.</summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="key">Key to use when setting the object in the cache store.</param>
        /// <param name="value">Value to set the object in the cache store.</param>
        /// <param name="absoluteExpirationMinutes">Number of minutes to keep the cached object alive.</param>
        protected void SetInCache<T>(string key, T value, int absoluteExpirationMinutes = 30)
        {
            Context.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(absoluteExpirationMinutes), Cache.NoSlidingExpiration);
        }

        /// <summary>Sets a value into the cache store.</summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="key">Key to use when setting the object in the cache store.</param>
        /// <param name="value">Value to set the object in the cache store.</param>
        /// <param name="absoluteExpirationMinutes">Number of minutes to keep the cached object alive.</param>
        /// /// <param name="slidingExpirationMinutes">Number of minutes to add to the objects lifespan upon access.</param>
        protected void SetInCache<T>(string key, T value, int absoluteExpirationMinutes, int slidingExpirationMinutes)
        {
            Context.Cache.Insert(
                key, value, null, DateTime.Now.AddMinutes(absoluteExpirationMinutes), TimeSpan.FromMinutes(slidingExpirationMinutes));
        }

        /// <summary>Removes an object from the cache store.</summary>
        /// <param name="key">Key of cache store object to remove.</param>
        protected void RemoveFromCache(string key)
        {
            Context.Cache.Remove(key);
        }

        #endregion

        #region Protected Methods - Session Methods

        /// <summary>Gets an object from the session.</summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="key">Key of session object to retrieve.</param>
        /// <returns>Correctly typed object from the session.</returns>
        protected T GetFromSession<T>(string key)
        {
            if (Context.Session != null)
            {
                var item = Context.Session[key];

                if (item != null)
                {
                    return (T)item;
                }
            }

            return default(T);
        }

        /// <summary>Sets a value into the session.</summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="key">Key to use when setting the object in the session.</param>
        /// <param name="value">Value to set the object in the session.</param>
        protected void SetInSession<T>(string key, T value)
        {
            if (Context.Session != null)
            {
                Context.Session[key] = value;
            }
        }

        /// <summary>Removes an object from the session.</summary>
        /// <param name="key">Key in session to remove.</param>
        protected void RemoveFromSession(string key)
        {
            if (Context.Session != null)
            {
                Context.Session.Remove(key);
            }
        }

        #endregion
    }
}
