using Database.Models.Helpers;

namespace Database.Models;

public class Issue : IOrderableEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    public ParticipantProfile Profile { get; set; }
    public List<Domain> Domains { get; set; }
    public bool IsSolved { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}