

namespace CineFlex.Application.Models.DTOs;

public class UserCreationDto
{
    public string roles  {get;set;} = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
   
}