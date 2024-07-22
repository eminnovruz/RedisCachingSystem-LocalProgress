using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services;

class Program
{
    static async Task Main(string[] args)
    {
        AppDbContext _dbContext = new AppDbContext();
        string _conStr = DbService.GetConnectionString();
        
        List<BaseCacheObject> cacheObjects = new List<BaseCacheObject>()
        {
            new CacheObject(new RedisCachingService(_conStr))
            {
                CacheData = _dbContext.Users.ToList(),
                ExpireDuration = DateTimeOffset.UtcNow.AddSeconds(300),
            },

            new CacheObject(new RedisCachingService(_conStr))
            {
                CacheData = _dbContext.Books.ToList(),
                ExpireDuration = DateTimeOffset.UtcNow.AddDays(3)
            },

            new SearchQueryCacheObject(new MongoCachingService(_conStr), new HashService(), "applicationda/userin/secdiyi/filterlerle/yaranan/query")
            {
                CacheData = _dbContext.Faculties.ToList(),
                ExpireDuration = DateTimeOffset.UtcNow.AddDays(30),
            }
        };

        //cacheObjects.MuqavileModulu
        //cacheObjects.MuqavileModulu.SetKeyData(new FilterData(plantId,filterdata1,filterdata2)).SetData(data);
        //cacheObjects.MuqavileModulu.GetData(new FilterData(plantId,filterdata1,filterdata2));
        //
        //
        //a = new Measurement(cacheObjects.MuqavileModulu.GetData(new FilterData(plantId,filterdata1,filterdata2)));
        //a.Invoke();
        //a.value. a.Duration
        //
        //List<Car>
        //Dataset
        //List<Human>
        //IValue<List<Human>>
        //IValue
        {
            string unieuqName;

        }
    }
}
