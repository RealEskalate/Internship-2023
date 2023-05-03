using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Identity;

namespace BlogApp.Identity.Services;

public class AuthService : IAuthService
{
    public Task<ConfirmEmailResponse> ConfirmEmail(string token, string email)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponse> Login(LoginModel request)
    {
        throw new NotImplementedException();
    }

    public Task<RegistrationResponse> Register(RegistrationModel request)
    {
        throw new NotImplementedException();
    }

    public Task<ResetPasswordResponse> ResetPassword(ResetPasswordModel resetPasswordModel)
    {
        throw new NotImplementedException();
    }

    public Task<ForgotPasswordResponse> ResetPasswordRequest(string Email)
    {
        throw new NotImplementedException();
    }
}
