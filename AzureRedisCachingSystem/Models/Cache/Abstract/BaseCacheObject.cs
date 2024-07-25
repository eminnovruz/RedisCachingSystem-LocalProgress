using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Services.Abstract;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCachingSystem.Models.Cache.Abstract
{
    /// <summary>
    /// Abstract base class for cache objects, providing methods for cache management.
    /// </summary>
    public abstract class BaseCacheObject
    {
        /// <summary>
        /// Gets or sets the cache value.
        /// </summary>
        public KValue<object> Value { get; set; }

        /// <summary>
        /// Gets or sets the cache expiration duration.
        /// </summary>
        public DateTimeOffset ExpireDuration { get; set; }

        /// <summary>
        /// Gets or sets the unique cache key.
        /// </summary>
        public StringBuilder UniqueKey { get; set; }

        /// <summary>
        /// The cache service used for caching operations.
        /// </summary>
        public IMemoryCaching CacheService { get; }

        private bool _watch;
        protected bool _hashFlag;
        protected readonly IMemoryCaching _cacheService;
        protected readonly IHashService _hashService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCacheObject"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="hashService">The hash service.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="cacheService"/> is null.</exception>
        protected BaseCacheObject(IMemoryCaching cacheService, IHashService hashService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _hashService = hashService;

            UniqueKey = new StringBuilder();
            _watch = false;
            _hashFlag = true; // default
        }

        /// <summary>
        /// Builds the cache by setting the cache data and logs the result.
        /// </summary>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public async Task<BaseCacheObject> BuildCache()
        {
            long elapsedMilliseconds = 0;

            if (_watch)
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                bool result = await _cacheService.SetCacheData(UniqueKey.ToString(), Value, ExpireDuration);
                stopwatch.Stop();
                elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                Log.Information($"Build Cache method result: {result} ({elapsedMilliseconds} ms)");
            }
            else
            {
                bool result = await _cacheService.SetCacheData(UniqueKey.ToString(), Value, ExpireDuration);
                Log.Information($"Build Cache method result: {result}");
            }

            return this;
        }

        /// <summary>
        /// Sets the cache key.
        /// </summary>
        /// <param name="key">The key to set.</param>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public BaseCacheObject SetKey(string key)
        {
            UniqueKey.Clear().Append(key);
            return this;
        }

        /// <summary>
        /// Sets the cache value.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public BaseCacheObject SetValue(object value)
        {
            Value = new KValue<object>(value);
            return this;
        }

        /// <summary>
        /// Asynchronously retrieves the cached value for the given key.
        /// </summary>
        /// <typeparam name="T">The type of the cached value.</typeparam>
        /// <param name="key">The key to retrieve the value for. If null, uses the current <see cref="UniqueKey"/>.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="KValue{T}"/> result.</returns>
        public async Task<KValue<T>> GetValueAsync<T>(string key = null)
        {
            key ??= UniqueKey.ToString();
            KValue<T> value = await _cacheService.GetCacheData<KValue<T>>(key);
            return value;
        }

        /// <summary>
        /// Sets the cache expiration duration in seconds.
        /// </summary>
        /// <param name="seconds">The expiration duration in seconds.</param>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public BaseCacheObject SetDurationWithSeconds(int seconds)
        {
            ExpireDuration = DateTimeOffset.UtcNow.AddSeconds(seconds);
            return this;
        }

        /// <summary>
        /// Sets the cache expiration duration in minutes.
        /// </summary>
        /// <param name="minutes">The expiration duration in minutes.</param>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public BaseCacheObject SetDurationWithMinutes(int minutes)
        {
            ExpireDuration = DateTimeOffset.UtcNow.AddMinutes(minutes);
            return this;
        }

        /// <summary>
        /// Sets the cache expiration duration in months.
        /// </summary>
        /// <param name="months">The expiration duration in months.</param>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public BaseCacheObject SetDurationWithMonths(int months)
        {
            ExpireDuration = DateTimeOffset.UtcNow.AddMonths(months);
            return this;
        }

        /// <summary>
        /// Activates the timer for measuring cache build duration.
        /// </summary>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public BaseCacheObject ActivateTimer()
        {
            _watch = true;
            return this;
        }

        /// <summary>
        /// Sets the flag for hashing before caching.
        /// </summary>
        /// <param name="flag">True to enable hashing, false to disable.</param>
        /// <returns>The current instance of <see cref="BaseCacheObject"/>.</returns>
        public BaseCacheObject HashBefore(bool flag = true)
        {
            _hashFlag = flag;
            return this;
        }
    }
}
