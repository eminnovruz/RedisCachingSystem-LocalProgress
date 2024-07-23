using AzureRedisCachingSystem.Models;
using AzureRedisCachingSystem.Models.Cache.Abstract;

namespace AzureRedisCachingSystem.Action;

public delegate BaseCacheObject SetUserParamsDelegate(User _user);

public delegate BaseCacheObject SetBooksParamsDelegate(Book _books);


