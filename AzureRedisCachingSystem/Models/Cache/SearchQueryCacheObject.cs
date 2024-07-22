using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;
using System.Text;

namespace AzureRedisCachingSystem.Models.Cache;

public class SearchQueryCacheObject : BaseCacheObject
{
    private readonly IHashService _hashService;

    public SearchQueryCacheObject(IMemoryCaching cacheService, IHashService hashService, string query) 
        : base(cacheService)
    {
        _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        
        UniqueKey = new System.Text.StringBuilder(query);
    }

    private string HashUniqueKey()
    {
        return _hashService.HashString(UniqueKey.ToString());
    }
}
