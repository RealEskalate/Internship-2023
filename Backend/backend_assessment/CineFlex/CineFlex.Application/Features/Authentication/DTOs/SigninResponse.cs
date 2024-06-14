namespace CineFlex.Application.Features.Authentication.DTOs;

public class SigninResponse: SignupResponse
{
    public string Token { get; set; } = null!;
}