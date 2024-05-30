using Database.Models;

namespace Business.Requests;

public class IssueRequest
{
    public string ParticipantProfileId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string>? DomainIds { get; set; }
    public bool IsSolved { get; set; }
}