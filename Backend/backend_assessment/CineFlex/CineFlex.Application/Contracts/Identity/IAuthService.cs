using CineFlex.Application.Features.Auth.DTOs;
using CineFlex.Application.Responses;

namespace CineFlex.Application.Contracts.Identity;

public interface IAuthService
{
    Task<BaseCommandResponse<LoginResponseDto>> Login(LoginUserDto authRequest, CancellationToken cancellationToken);

    Task<BaseCommandResponse<LoginResponseDto>> Register(RegisterUserDto registrationRequest,
        CancellationToken cancellationToken);
}