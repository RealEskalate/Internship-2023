using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;

namespace CineFlex.Application.Contracts.Identity;

public interface IAuthService
{
    Task<BaseCommandResponse<AuthResponse>> Login(AuthRequest authRequest);
    Task<BaseCommandResponse<RegistrationResponse>> Register(RegistrationRequest registrationRequest);
}