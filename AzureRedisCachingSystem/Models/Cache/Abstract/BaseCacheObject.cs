using AzureRedisCachingSystem.Services.Abstract;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCachingSystem.Models.Cache.Abstract
{
    public abstract class BaseCacheObject
    {
        public object CacheData { get; set; }
        public DateTimeOffset ExpireDuration { get; set; }
        public StringBuilder UniqueKey { get; private set; }

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

            bool result = await _cacheService.SetCacheData(UniqueKey.ToString(), CacheData, ExpireDuration);
            return result;
        }

        public BaseCacheObject SetKey(string key)
        {
            UniqueKey.Clear().Append(key);
            return this;
        }

        public BaseCacheObject SetValue(object value)
        {
            CacheData = value;
            return this;
        }

        public async Task<T> GetValueAsync<T>(string key = null)
        {
            T value = await _cacheService.GetCacheData<T>(key == null ? UniqueKey.ToString() : key);
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
