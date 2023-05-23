namespace CineFlex.Application.Features.Auth.DTOs;

public class LoginResponseDto
{
    public UserDto User { get; set; } = null!;
    public string Token { get; set; } = null!;
}