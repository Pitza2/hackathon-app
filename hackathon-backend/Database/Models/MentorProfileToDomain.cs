using Database.Models.Helpers;

namespace Database.Models;

public class MentorProfileToDomain : IEntity
{
    public string Id { get; set; }
    public MentorProfile Mentor { get; set; }
    public Domain Domain { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}