using AzureRedisCachingSystem.Action;
using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;

namespace AzureRedisCachingSystem.Models.Cache;

public class UserCacheObject : BaseCacheObject
{
    public UserCacheObject(IMemoryCaching cacheService) : base(cacheService)
    {
        setCacheParams = new SetUserParamsDelegate(SetUserParams);
    }

    public BaseCacheObject SetUserParams(User user)
    {
        return this;
    }
}
