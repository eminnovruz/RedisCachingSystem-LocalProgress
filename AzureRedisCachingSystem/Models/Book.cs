using AzureRedisCachingSystem.Models.Common;

namespace AzureRedisCachingSystem.Models;

public class Book : BaseEntity 
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string AuthorFullName  { get; set; }
    public int Price { get; set; }
}
