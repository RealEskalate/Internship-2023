using BlogApp.Application.Models.Identity;

namespace BlogApp.Application.Contracts.Identity;
public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest authRequest);
    Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
}