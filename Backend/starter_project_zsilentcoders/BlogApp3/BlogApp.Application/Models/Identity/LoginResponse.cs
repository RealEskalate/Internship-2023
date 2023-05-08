using BlogApp.Application.Responses;

namespace BlogApp.Application.Models.Identity;

public class LoginResponse: BaseCommandResponse
{
    public string UserId {get; set;} = "";

    public string Email {get; set;} = "";

    public string UserName {get; set;} = "";

    public string Token {get; set;} = "";
}
