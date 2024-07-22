using AzureRedisCachingSystem.Services.Abstract;
using System.Text;

namespace AzureRedisCachingSystem.Models.Cache.Abstract;

public abstract class BaseCacheObject
{
    public object CacheData { get; set; }
    public DateTimeOffset ExpireDuration { get; set; }
    public StringBuilder UniqueKey { get;  set; }

    protected readonly IMemoryCaching _cacheService;

    protected BaseCacheObject(IMemoryCaching cacheService)
    {
        _cacheService = cacheService ?? throw new ArgumentNullException(nameof(_cacheService));
    }

    protected async Task<bool> SetCacheData()
    {
        bool result = await _cacheService.SetCacheData(UniqueKey.ToString(), CacheData, ExpireDuration);

        return result;
    }
}
