namespace CineFlex.Application.Features.Users.DTOs;

public class RegisterDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Email {get; set;}

    public string UserName {get; set;}

    public string Password{get; set;}

    public ICollection<string> Roles {get; set;}
}
