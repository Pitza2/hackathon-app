namespace Database.Models.Helpers;

public interface IOrderableEntity
{
    string Id { get; set; }
    int DisplayOrder { get; set; }
    DateTime Created { get; set; }
    DateTime Updated { get; set; }
    
}