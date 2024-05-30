using Database.Models.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Database.Models;

public class Role : IdentityRole, IEntity
{
    public string Name { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
