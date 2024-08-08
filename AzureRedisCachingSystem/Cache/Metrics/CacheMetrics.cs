namespace AzureRedisCachingSystem.Cache.Metrics;

public class CacheMetrics
{
    public string Key { get; set; }
    public int CacheHits { get;  set; }
    public int CacheMisses { get;  set; }
    public DateTime LastAccessed { get;  set; }
}
