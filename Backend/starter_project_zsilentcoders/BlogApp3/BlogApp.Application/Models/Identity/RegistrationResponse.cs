using BlogApp.Application.Models.Mail;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Models.Identity;

public class RegistrationResponse
{
    public string UserId {get; set;} = "";

    public string email {get; set;}
}
