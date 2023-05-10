using System.ComponentModel.DataAnnotations;

namespace BlogApp.Application.Models.Identity;

public class RegistrationModel
{
    [Required]
    [EmailAddress]
    public string Email {get; set;} = "";

    [Required]
    public string UserName {get; set;} = "";

    [Required]
    public string Password{get; set;} = "";

    [Required]
    public ICollection<string> Roles {get; set;}
}
