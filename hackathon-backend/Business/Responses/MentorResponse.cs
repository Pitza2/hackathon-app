using Database.Models;

namespace Business.Responses;

public class MentorResponse
{
    public string Id { get; set; }
    public UserResponse User { get; set; }
    public List<Domain> Domains { get; set; }
}