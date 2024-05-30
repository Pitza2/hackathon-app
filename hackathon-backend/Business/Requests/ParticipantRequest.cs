namespace Business.Requests;

public class ParticipantRequest
{
    public string UserId { get; set; }
    public List<string> DomainIds { get; set; }
    public string Table { get; set; }
}