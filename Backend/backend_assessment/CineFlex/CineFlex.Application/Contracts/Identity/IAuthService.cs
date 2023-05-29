using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;

namespace CineFlex.Application.Contracts.Identity;

public interface IAuthService
{
    public Task<RegistrationResponse> Register(RegistrationRequest request);
    public Task<LoginResponse> Login(LoginRequest request);
    public Task<bool> DeleteUser(string Email);

}
