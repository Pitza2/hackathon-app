using Database.Models.Helpers;

namespace Database.Models;

public class Domain : IEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}