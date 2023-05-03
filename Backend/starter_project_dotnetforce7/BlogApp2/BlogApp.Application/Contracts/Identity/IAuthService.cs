using BlogApp.Application.Models.Identity;

namespace BlogApp.Application.Contracts.Identity;
public interface IAuthService
{
    Task<AuthRequest> Login(AuthRequest authRequest);
    Task<RegistrationRequest> Register(RegistrationRequest registrationRequest);
}