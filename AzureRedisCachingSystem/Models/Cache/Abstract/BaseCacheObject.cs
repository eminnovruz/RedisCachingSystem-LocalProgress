using AzureRedisCachingSystem.Action;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Services.Abstract;
using System;
using System.Text;

namespace AzureRedisCachingSystem.Models.Cache.Abstract
{
    public abstract class BaseCacheObject
    {
        public KValue<object> Value { get; set; }
        public DateTimeOffset ExpireDuration { get; set; }
        public StringBuilder UniqueKey { get; private set; }

        protected SetParams setCacheParams;

        private bool _watch;
        protected readonly IMemoryCaching _cacheService;

        protected BaseCacheObject(IMemoryCaching cacheService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            UniqueKey = new StringBuilder();
            _watch = false;
        }

        public async Task<bool> SetCacheDataAsync()
        {
            if (_watch)
            {
            }

            bool result = await _cacheService.SetCacheData(UniqueKey.ToString(), Value, ExpireDuration);
            return result;
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
    }
}
