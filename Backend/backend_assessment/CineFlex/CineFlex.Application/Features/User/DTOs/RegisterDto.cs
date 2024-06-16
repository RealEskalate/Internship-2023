namespace CineFlex.Application.Features.User.DTOs;

public class RegisterDto
{
    
    public string Email {get; set;}

    public string UserName {get; set;}

    public string Password{get; set;}

    public ICollection<string> Roles {get; set;}
}
