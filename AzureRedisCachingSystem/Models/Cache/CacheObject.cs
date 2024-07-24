using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;

namespace AzureRedisCachingSystem.Models.Cache;

public class CacheObject<T> : BaseCacheObject
{
    public CacheObject(IMemoryCaching cacheService) : base(cacheService)
    {

    }

    public BaseCacheObject SetParams(T parameter)
    {
        return this;
    }
}
