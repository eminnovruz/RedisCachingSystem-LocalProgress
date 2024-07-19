namespace AzureRedisCachingSystem.Services.Abstract;

public interface IMemoryCaching
{
    Task<T> GetCacheData<T>(string key);
    Task<object> RemoveData(string key);
    Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expireTime);
    Task<bool> CheckIfExist(string Key);
    
}
