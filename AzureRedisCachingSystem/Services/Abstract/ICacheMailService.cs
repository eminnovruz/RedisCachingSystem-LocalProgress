namespace AzureRedisCachingSystem.Services.Abstract;

public interface ICacheMailService
{
    Task<bool> NotifyNewCacheObject();
    Task<bool> NotifyUnusedCache();
    Task<bool> SendCustom(string subject, string body);
    Task<bool> SendMetrics(string metrics);
}
