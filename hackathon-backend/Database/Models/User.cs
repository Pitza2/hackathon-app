using Database.Models.Helpers;

namespace Database.Models;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}