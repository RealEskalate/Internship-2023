using CineFlex.Application.Features.Auth.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Auth.CQRS.Commands;

public class RegisterUserCommand : IRequest<BaseCommandResponse<UserDto>>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}