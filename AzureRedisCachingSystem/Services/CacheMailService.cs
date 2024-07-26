using AzureRedisCachingSystem.Services.Abstract;

namespace AzureRedisCachingSystem.Services;

public class CacheMailService : ICacheMailService
{
    public Task<bool> NotifyNewCacheObject()
    {
        throw new NotImplementedException();
    }

    public Task<bool> NotifyUnusedCache()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SendCustom()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SendMetrics()
    {
        throw new NotImplementedException();
    }
}
