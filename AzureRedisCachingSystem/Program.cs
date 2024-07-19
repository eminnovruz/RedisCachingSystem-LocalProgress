using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models;
using AzureRedisCachingSystem.Services;
using AzureRedisCachingSystem.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
   
    private static readonly TimeSpan CacheExpiration = TimeSpan.FromSeconds(120);

    static async Task Main(string[] args)
    {
        //string connectionString = DbService.GetConnectionString();
        //IMemoryCaching cache = new RedisCachingService(connectionString);

        //Stopwatch stopwatch = new Stopwatch();

        //if (await cache.CheckIfExist("Users"))
        //{
        //    stopwatch.Start();
        //    await DisplayCachedUsers(cache);
        //    stopwatch.Stop();
        //    Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");
        //}
        //else
        //{
        //    stopwatch.Start();
        //    await FetchAndCacheUsers(cache);
        //    stopwatch.Stop();
        //    Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");
        //}
    }

    private static async Task DisplayCachedUsers(IMemoryCaching cache)
    {
        var users = await cache.GetCacheData<List<User>>("Users");
        PrintUserList(users);
        Console.WriteLine("Accessed from cache");
    }

    private static async Task FetchAndCacheUsers(IMemoryCaching cache)
    {
        using (var dbContext = new AppDbContext())
        {
            var users = await dbContext.Users.ToListAsync();
            var result = await cache.SetCacheData("Users", users, DateTimeOffset.UtcNow.Add(CacheExpiration));
            Console.WriteLine("Cached: " + result);
            PrintUserList(users);
            Console.WriteLine("Accessed from database");
        }
    }

    private static void PrintUserList(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name} / {user.Surname}");
        }
    }
}
