using CineFlex.Application.Features.Auth.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Auth.CQRS.Commands;

public class LoginUserCommand : IRequest<BaseCommandResponse<LoginResponseDto>>
{
    public LoginUserDto LoginUserDto { get; set; } = null!;
}