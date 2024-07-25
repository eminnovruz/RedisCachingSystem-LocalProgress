using AzureRedisCachingSystem.Services.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace AzureRedisCachingSystem.Services
{
    /// <summary>
    /// Implements <see cref="IMemoryCaching"/> using Redis as the caching mechanism.
    /// </summary>
    public class RedisCachingService : IMemoryCaching
    {
        private readonly IDatabase _db;
        private readonly IConnectionMultiplexer _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisCachingService"/> class with the specified Redis connection string.
        /// </summary>
        /// <param name="connectionString">The Redis connection string.</param>
        public RedisCachingService(string connectionString)
        {
            _connection = ConnectionMultiplexer.Connect(connectionString);
            _db = _connection.GetDatabase();
        }

        /// <summary>
        /// Asynchronously retrieves the cache data for the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the cached value.</typeparam>
        /// <param name="key">The key to retrieve the cache data for.</param>
        /// <returns>A task representing the asynchronous operation, with the cached value as the result.</returns>
        public async Task<T> GetCacheData<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }

        /// <summary>
        /// Asynchronously removes the cache data for the specified key.
        /// </summary>
        /// <param name="key">The key to remove the cache data for.</param>
        /// <returns>A task representing the asynchronous operation, with a boolean indicating success or failure.</returns>
        public async Task<object> RemoveData(string key)
        {
            var exists = await _db.KeyExistsAsync(key);
            if (exists)
                return await _db.KeyDeleteAsync(key);
            return false;
        }

        /// <summary>
        /// Asynchronously sets the cache data for the specified key with an expiration time.
        /// </summary>
        /// <typeparam name="T">The type of the value to cache.</typeparam>
        /// <param name="key">The key to set the cache data for.</param>
        /// <param name="value">The value to cache.</param>
        /// <param name="expireTime">The expiration time for the cache data.</param>
        /// <returns>A task representing the asynchronous operation, with a boolean indicating whether the data was set successfully.</returns>
        public async Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expireTime)
        {
            TimeSpan timeToLive = expireTime.DateTime.Subtract(DateTime.UtcNow);
            var isSet = await _db.StringSetAsync(key, JsonConvert.SerializeObject(value));
            await _db.KeyExpireAsync(key, timeToLive);
            return isSet;
        }

        /// <summary>
        /// Asynchronously checks if the cache data for the specified key exists.
        /// </summary>
        /// <param name="key">The key to check for existence.</param>
        /// <returns>A task representing the asynchronous operation, with a boolean indicating whether the key exists.</returns>
        public async Task<bool> CheckIfExist(string key)
        {
            return await _db.KeyExistsAsync(key);
        }
    }
}
