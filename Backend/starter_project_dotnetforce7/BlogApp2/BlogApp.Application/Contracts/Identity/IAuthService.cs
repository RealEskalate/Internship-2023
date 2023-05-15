using BlogApp.Application.Models.Identity;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Contracts.Identity;

public interface IAuthService
{
    Task<Result<AuthResponse>> Login(AuthRequest authRequest);
    Task<Result<RegistrationResponse>> Register(RegistrationRequest registrationRequest);
}