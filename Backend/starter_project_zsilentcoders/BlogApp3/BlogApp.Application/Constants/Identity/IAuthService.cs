using BlogApp.Application.Models.Identity;

namespace BlogApp.Application.Contracts.Identity;

public interface IAuthService
{
    public Task<RegistrationResponse> Register(RegistrationModel request);

    public Task<LoginResponse> Login(LoginModel request);

    public  Task<ConfirmEmailResponse> ConfirmEmail(string token, string email);
    
    public  Task<ForgotPasswordResponse> ResetPasswordRequest(string Email);

    public  Task<ResetPasswordResponse> ResetPassword(ResetPasswordModel resetPasswordModel);


}
