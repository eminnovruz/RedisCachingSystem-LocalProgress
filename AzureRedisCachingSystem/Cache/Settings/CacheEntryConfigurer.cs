using AzureRedisCachingSystem.Cache.CustomValues;
using AzureRedisCachingSystem.Cache.Entries;

namespace AzureRedisCachingSystem.Cache.Settings;

public class CacheEntryConfigurer
{
    private string key;
    private CacheValue value;
    private DateTimeOffset expire;

    public CacheEntryConfigurer SetKey(string key)
    {
        this.key = key;

        return this;
    }

    public CacheEntryConfigurer SetValue(CacheValue value)
    {
        this.value = value;

        return this;
    }

    public CacheEntryConfigurer SetParams(object filterParameter)
    {
        return this;
    }

    public CacheEntryConfigurer SetExpire(DateTimeOffset expire)
    {
        this.expire = expire;

        return this;
    }

    public CacheEntry BuildCacheEntry()
    {
        if(!CheckIfSettingsIsConfigured())
        {
            throw new Exception("Once configure settings before build.");
        }

        CacheEntry cacheEntry = new CacheEntry()
        {
            Key = key,
            Value = value,
            BuildDate = DateTime.Now,
            Expire = expire,
        };  

        return cacheEntry;
    }

    #region Helper Methods
    private bool CheckIfSettingsIsConfigured()
    {
        if (this.value == null || this.key == null)
            return false;

        return true;
    }
    #endregion
}
