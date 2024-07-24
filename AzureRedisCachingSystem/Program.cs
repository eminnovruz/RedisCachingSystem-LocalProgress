using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Repositories;
using AzureRedisCachingSystem.Services;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        
        AppDbContext _dbContext = new AppDbContext();
        string _conStr = AppService.GetConnectionString();

        ICacheObjectRepository _cacheObjectRepo = new CacheObjectRepository();
    }
}
