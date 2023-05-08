using BlogApp.Application.Responses;

namespace BlogApp.Application.Models.Identity;

public class RegistrationResponse: BaseCommandResponse
{
    public string UserId {get; set;} = "";
}
