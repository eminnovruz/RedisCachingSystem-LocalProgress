using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;
using System.Text;

namespace AzureRedisCachingSystem.Models.Cache;

public class SearchQueryCacheObject : BaseCacheObject
{
    private readonly IHashService _hashService;

    public SearchQueryCacheObject(IMemoryCaching cacheService, IHashService hashService) 
        : base(cacheService)
    {
        _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
    }

    public BaseCacheObject SetKey(string _plantId, params string[] filters)
    {
        UniqueKey.Append(_plantId);
        
        foreach (var item in filters)
        {
            UniqueKey.Append(item + "&*");
        }

        return this;
    }

}
