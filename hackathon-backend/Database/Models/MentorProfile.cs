using Database.Models.Helpers;

namespace Database.Models;

public class MentorProfile : IEntity
{
    public User User { get; set; }
    public string Id { get; set; }
    public List<Domain> Domains { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}