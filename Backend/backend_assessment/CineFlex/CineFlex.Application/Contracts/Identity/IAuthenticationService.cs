using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;

namespace CineFlex.Application.Contracts.Identity;

public interface IAuthenticationService
{
    public Task<BaseCommandResponse<RegistrationResponse>> Register(RegistrationModel request);

    public Task<BaseCommandResponse<LoginResponse>> Login(LoginModel request);

}
