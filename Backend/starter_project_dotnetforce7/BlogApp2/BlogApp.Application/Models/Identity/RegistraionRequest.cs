using System.ComponentModel.DataAnnotations;

namespace BlogApp.Application.Models.Identity;
public class RegistrationRequest
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Username { get; set; }

    [Required]
    public string Lastname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [RegularExpression(@"^(?=.*[\d\W]).+$", ErrorMessage = "The password must contain at least one special character and one number.")] 
    public string Password { get; set; }
} 