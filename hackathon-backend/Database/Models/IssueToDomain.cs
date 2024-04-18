using Database.Models.Helpers;

namespace Database.Models;

public class IssueToDomain: IEntity
{
    public string Id { get; set; }
    public Issue Issue { get; set; }
    public Domain Domain { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}