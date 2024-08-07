using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Services.Abstract;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCachingSystem.Models.Cache.Abstract
{
    public abstract class BaseCacheObject
    {
        public StringBuilder UniqueKey { get; set; }
        public KValue<object> Value { get; set; }

        protected readonly IMemoryCaching _cacheService;
        protected readonly IHashService _hashService;


        protected BaseCacheObject(IMemoryCaching cacheService, IHashService hashService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _hashService = hashService;

            UniqueKey = new StringBuilder();
        }


        public async Task<BaseCacheObject> BuildCache(DateTimeOffset expire)
        {
            bool result = await _cacheService.SetCacheData(UniqueKey.ToString(), Value, expire);
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
    }
}
