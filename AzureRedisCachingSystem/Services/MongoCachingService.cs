using AzureRedisCachingSystem.Services.Abstract;

namespace AzureRedisCachingSystem.Services;

public class MongoCachingService : IMemoryCaching
{
    public MongoCachingService(string connectionString)
    { }

    public Task<bool> CheckIfExist(string Key)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetCacheData<T>(string key)
    {
        throw new NotImplementedException();
    }

    public Task<object> RemoveData(string key)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expireTime)
    {
        throw new NotImplementedException();
    }
}
