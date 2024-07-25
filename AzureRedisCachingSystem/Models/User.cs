using AzureRedisCachingSystem.Models.Common;

namespace AzureRedisCachingSystem.Models;

public class User : BaseEntity
{

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; } 
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string FacultyId { get; set; }
}

