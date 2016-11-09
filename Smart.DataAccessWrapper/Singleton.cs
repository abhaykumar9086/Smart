using System;
using System.Collections.Concurrent;

namespace Smart.DataAccessWrapper
{
    /// <summary>
    /// Helps in generating singleton instance for the type specified.
    /// </summary>
    /// <typeparam name="T">Singleton instance reference for the specified type.</typeparam>
    internal sealed class Singleton<T> where T : new()
    {
        #region Private Fields

        /// <summary>
        /// Internal list of singleton instances for each type as instances are requested.
        /// </summary>
        private static ConcurrentDictionary<Type, T> _instances = new ConcurrentDictionary<Type, T>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the singleton instance reference for the type specified.
        /// </summary>
        /// <value>
        /// Instance reference for the type specified.
        /// </value>
        public static T Instance
        {
            get
            {
                return _instances.GetOrAdd(typeof(T), (t) => new T());
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="Singleton{T}"/> class from being created.
        /// </summary>
        private Singleton()
        {
        }

        #endregion
    }
}
