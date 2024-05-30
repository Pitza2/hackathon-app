namespace Database.Models.Helpers;

public interface IEntity
{
    string Id { get; set; }
    DateTime Created { get; set; }
    DateTime Updated { get; set; }
}