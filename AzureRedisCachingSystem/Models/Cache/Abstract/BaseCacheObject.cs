using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Services.Abstract;
using Serilog;
using System;
using System.Text;

namespace AzureRedisCachingSystem.Models.Cache.Abstract
{
    public abstract class BaseCacheObject
    {
        public KValue<object> Value { get; set; }
        public DateTimeOffset ExpireDuration { get; set; }
        public StringBuilder UniqueKey { get;  set; }
        public IMemoryCaching CacheService { get; }

        private bool _watch;

        protected bool _hashFlag;
        protected readonly IMemoryCaching _cacheService;
        protected readonly IHashService _hashService;

        protected BaseCacheObject(IMemoryCaching cacheService, IHashService hashService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _hashService = hashService;
            
            UniqueKey = new StringBuilder();

            _watch = false;

            _hashFlag = true; // default
        }

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

        public BaseCacheObject SetKey(string key)
        {
            UniqueKey.Clear().Append(key);
            return this;
        }


        public BaseCacheObject SetValue(object value)
        {
            Value = new KValue<object>(value);
            return this;
        }
        
        public async Task<KValue<T>> GetValueAsync<T>(string key = null)
        {
            key ??= UniqueKey.ToString();
            KValue<T> value = await _cacheService.GetCacheData<KValue<T>>(key);
            return value;
        }

        public BaseCacheObject SetDurationWithSeconds(int seconds)
        {
            ExpireDuration = DateTimeOffset.UtcNow.AddSeconds(seconds);
            return this;
        }

        public BaseCacheObject SetDurationWithMinutes(int minutes)
        {
            ExpireDuration = DateTimeOffset.UtcNow.AddMinutes(minutes);
            return this;
        }

        public BaseCacheObject SetDurationWithMonths(int months)
        {
            ExpireDuration = DateTimeOffset.UtcNow.AddMonths(months);
            return this;
        }

        public BaseCacheObject ActivateTimer()
        {
            _watch = true;
            return this;
        }

        public BaseCacheObject HashBefore(bool flag = true)
        {
            _hashFlag = flag;
            return this;
        }
    }
}
