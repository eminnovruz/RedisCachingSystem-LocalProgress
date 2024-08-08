using AzureRedisCachingSystem.Cache.Metrics;

namespace AzureRedisCachingSystem.Services.Abstract;

public interface IMetricsService
{
    Task CreateMetrics(CacheMetrics metrics);
    Task<bool> HandleCacheHit(string key);
    Task<bool> HandleCacheMiss(string key);
    Task<bool> RemoveMetrics();
}
