using System.Text.Json.Serialization;
using Database.Models.Helpers;

namespace Database.Models;

public class Domain : IEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    [JsonIgnore]
    public List<MentorProfile> MentorProfiles { get; set; }
    [JsonIgnore]
    public List<ParticipantProfile> ParticipantProfiles { get; set; }
    [JsonIgnore]
    public List<Issue> Issues { get; set; }
}