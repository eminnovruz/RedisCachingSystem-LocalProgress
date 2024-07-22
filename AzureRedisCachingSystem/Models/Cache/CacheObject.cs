using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;
using System;
using System.Text;
using System.Threading.Tasks;

public class CacheObject : BaseCacheObject
{
    public CacheObject(IMemoryCaching _cacheService, string defaultKeyName = "default_key")
        :base(_cacheService)
    {

        UniqueKey = new StringBuilder(defaultKeyName);
    }
}
