using AzureRedisCachingSystem.Cache.CustomValues;
using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.HelperServices.Hash;
using AzureRedisCachingSystem.HelperServices.UniqueKey;

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
        if(key is not null)
        {
            throw new Exception("You cannot define params after setting key manually. Try removing key");
        }
        
        UniqueKeyService.GenerateUniqueKeyViaParams(ref key , filterParameter);

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

        HashIfNeeded();

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

    private void HashIfNeeded()
    {
        if (key.Length > 32)
        {
            HashService.HashString(ref key);
        }
    }
    #endregion
}
