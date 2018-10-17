using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ElementIoT.Particle.Operational.Caching
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Operational.Caching.ICachePolicy" />
    public class MemoryCachePolicy : ICachePolicy
    {
        #region Fields

        /// <summary>
        /// The cache scopes
        /// </summary>
        private static HashSet<string> cacheScopes = new HashSet<string>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the cache service.
        /// </summary>
        /// <value>
        /// The cache service.
        /// </value>
        public IMemoryCache CacheService
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCachePolicy"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service.</param>
        public MemoryCachePolicy(IMemoryCache cacheService)
        {
            this.CacheService = cacheService;
        }

        #endregion

        #region Metohds

        /// <summary>
        /// Creates the scope.
        /// </summary>
        /// <param name="scope">The scope.</param>
        public void CreateScope(string scope)
        {
            if (!cacheScopes.Contains(scope))
            {
                cacheScopes.Add(scope);
            }
        }

        /// <summary>
        /// Sets the specified value in the key amd scope.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope">The scope.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public T Set<T>(string scope, string key, T value) where T : class
        {
            if (!scope.Contains(scope))
            {
                throw new InvalidOperationException($"Cannot set the object under the scope {scope}.  The scope does not exist.");
            }

            if (value != null)
                return this.CacheService.Set($"{scope}{key}", value);
            else
                return null;
        }


        /// <summary>
        /// Gets the specified value from the key and scope.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope">The scope.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public T Get<T>(string scope, string key) where T : class
        {
            if (!scope.Contains(scope))
            {
                throw new InvalidOperationException($"Cannot get the object under the scope {scope}.  The scope does not exist.");
            }

            T value = null;

            this.CacheService.TryGetValue<T>($"{scope}{key}", out value);

            return value;
        }

        /*
        ICacheEntry CreateEntry(object key);
        void Remove(object key);
        bool TryGetValue(object key, out object value);
        */

        #endregion
    }
}
