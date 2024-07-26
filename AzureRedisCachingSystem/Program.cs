using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models;
using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models.ModelFilters;
using AzureRedisCachingSystem.Repositories;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Services;
using AzureRedisCachingSystem.Services.Abstract;

class Program
{
    static async Task Main(string[] args)
    {
        string _conStr = AppService.GetConnectionString();

        AppDbContext _context = new AppDbContext();

        ICacheObjectRepository _repo = new CacheObjectRepository();
        IMemoryCaching _cache = new RedisCachingService(_conStr);
        IHashService _hash = new HashService();

        _repo.UserCacheObject = new CacheObject<UserModelFilter>(_cache, _hash)
            .SetParams(new UserModelFilter()
            {
                Name = "Emin",
                Surname = "Novruz",
                Age = 16,
                Email = "novruzemin693@gmail.com",
                FacultyId = "555",
                Id = "shouldbesamefortesting",
                PhoneNumber = "0552554459",
                From = new DateTime(2022, 01, 01),
                To = new DateTime(2024, 08, 01)
            })
            .ActivateTimer()
            .SetDurationWithMinutes(2)
            .SetValue(_context.Users.ToList());

        _repo.BookCacheObject = new CacheObject<Book>(_cache, _hash)
            .SetParams(new Book()
            {
                Title = "101 Nagil",
                Description = "Kuleylenib",
                Price = 16,
                AuthorFullName = "Mirze",
            })
            .ActivateTimer()
            .SetDurationWithMinutes(2)
            .SetValue(_context.Users.ToList());

        await _repo.UserCacheObject.BuildCache();
        await _repo.BookCacheObject.BuildCache();

        // GET

        for (int i = 0; i < 3; i++)
        {
            await _repo.UserCacheObject.GetValueAsync<object>();
            await _repo.BookCacheObject.GetValueAsync<object>();
        }
    }
}
