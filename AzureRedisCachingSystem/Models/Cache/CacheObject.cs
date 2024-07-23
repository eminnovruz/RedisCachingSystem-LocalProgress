using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;
using System;
using System.Text;
using System.Threading.Tasks;

public class CacheObject : BaseCacheObject
{
    public CacheObject(IMemoryCaching _cacheService)
        :base(_cacheService)
    {
    }
}
