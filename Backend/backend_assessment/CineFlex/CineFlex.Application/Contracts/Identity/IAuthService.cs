using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;

namespace CineFlex.Application.Contracts.Identity;

public interface IAuthService
{
    public Task<Result<RegistrationResponse>> Register(RegistrationRequest request);
    public Task<Result<LoginResponse>> Login(LoginRequest request);
    public Task<bool> DeleteUser(string Email);

}
