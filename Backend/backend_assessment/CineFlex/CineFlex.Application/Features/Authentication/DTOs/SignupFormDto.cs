namespace CineFlex.Application.Features.Authentication.DTOs;

public class SignupFromDto: SigninFormDto
{
    public string FullName { get; set; } = null!;
}