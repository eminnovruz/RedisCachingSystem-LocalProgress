using AzureRedisCachingSystem.Cache.CustomValues;

namespace AzureRedisCachingSystem.Cache.Entries;

public class CacheEntry
{
    public string Key { get; set; }
    public CacheValue Value { get; set; }
}
