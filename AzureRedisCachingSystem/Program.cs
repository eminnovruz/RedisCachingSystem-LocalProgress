using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Repositories;
using AzureRedisCachingSystem.Services;
using Serilog;
using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models;
using AzureRedisCachingSystem.Models.ModelFilters;
using Microsoft.Extensions.Caching.Memory;
using AzureRedisCachingSystem.Services.Abstract;

class Program
{
    static async Task Main(string[] args)
    {
        AppService.ConfigureLogging();

        AppDbContext _dbContext = new AppDbContext();
        string _conStr = AppService.GetConnectionString();

        ICacheObjectRepository _cacheObjectRepo = new CacheObjectRepository();
        IMemoryCaching _cacheSystem = new RedisCachingService(_conStr);
        IHashService _hashService = new HashService();

        _cacheObjectRepo.UserCacheObject = new CacheObject<UserModelFilter>(_cacheSystem, _hashService).SetParams(new UserModelFilter()
        {
            Name = "emin",
            Surname = "novruz",
            Age = 16,
            Email = "novruzemin693@gmail.com",
            FacultyId = "555",
            Id = Guid.NewGuid().ToString(),
            PhoneNumber = "0552554459",
            From = new DateTime(1999, 01, 01),
            To = new DateTime(2024, 01, 01)
        }).ActivateTimer()
        .HashBefore(true)
        .SetValue(_dbContext.Users.ToList())
        .SetDurationWithMinutes(2);

        await _cacheObjectRepo.UserCacheObject.BuildCache();
    }

}
    