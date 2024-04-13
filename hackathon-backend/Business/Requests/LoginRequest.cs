using System.ComponentModel.DataAnnotations;

namespace Business.Requests;

public class LoginRequest
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required] [MinLength(6)] public string Password { get; set; }
}