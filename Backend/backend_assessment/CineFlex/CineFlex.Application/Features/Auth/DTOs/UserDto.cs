using CineFlex.Domain;

namespace CineFlex.Application.Features.Auth.DTOs;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public static UserDto FromUser(AppUser user)
    {
        return new UserDto()
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email
        };
    }
}