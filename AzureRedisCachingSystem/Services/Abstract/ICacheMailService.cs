namespace AzureRedisCachingSystem.Services.Abstract;

public interface ICacheMailService
{
    Task<bool> NotifyUnusedCache();
    Task<bool> SendMetrics();
    Task<bool> NotifyNewCacheObject();
    Task<bool> SendCustom();
}
