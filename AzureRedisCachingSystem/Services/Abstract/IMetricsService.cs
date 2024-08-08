namespace AzureRedisCachingSystem.Services.Abstract;

public interface IMetricsService
{
    Task<bool> CraeteMetrics();
    Task<bool> HandleCacheHit();
    Task<bool> HandleCacheMiss();
    Task<bool> RemoveMetrics();
}
