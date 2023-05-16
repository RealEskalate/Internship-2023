using System.ComponentModel.DataAnnotations;

namespace BlogApp.Application.Models.Identity;
public class RegistrationResponse
{
    public string UserId { get; set;}
    public int blogUserId {get; set;}
}  