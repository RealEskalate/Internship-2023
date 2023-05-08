using System.ComponentModel.DataAnnotations;

namespace BlogApp.Application.Models.Identity;

public class RegistrationModel
{
    [Required]
    public string Email {get; set;} = "";

    [Required]
    public string UserName {get; set;} = "";

    [Required]
    public string Password{get; set;} = "";

    [Required]
    public ICollection<string> Roles {get; set;}
}
