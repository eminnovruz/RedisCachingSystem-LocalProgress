using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;
using Serilog;
using System;
using System.Text;

namespace AzureRedisCachingSystem.Models.Cache
{
    /// <summary>
    /// Represents a cache object with a generic type parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter used to set cache object properties.</typeparam>
    public class CacheObject<T> : BaseCacheObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheObject{T}"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="hashService">The hash service.</param>
        public CacheObject(IMemoryCaching cacheService, IHashService hashService)
            : base(cacheService, hashService)
        {
        }

        /// <summary>
        /// Sets parameters for the cache object using the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter object used to set cache object properties.</param>
        /// <returns>The current instance of <see cref="CacheObject{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="parameter"/> is null.</exception>
        public CacheObject<T> SetParams(T parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            var properties = parameter.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(parameter);

                if (value is DateTime dateTimeValue)
                {
                    value = dateTimeValue.ToString("dd.MM.yyyy");
                }

                UniqueKey.Append($"{prop.Name.ToLower()}:{value?.ToString().ToLower()}&*");
            }

            UniqueKey = new StringBuilder(_hashService.HashString(UniqueKey.ToString()));

            Log.Information("Params set to cache object");

            return this;
        }
    }
}
