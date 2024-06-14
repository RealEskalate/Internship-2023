

using CineFlex.Application.Features.Authentication.DTOs;

namespace CineFlex.Application.Contracts.Identity;

public interface IAuthService
{
    Task<SignupResponse> RegisterUserAsync(SignupFromDto signupForm);
    Task<SigninResponse> LoginUserAsync(SigninFormDto signinForm);
}
