using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Auth.CQRS.Commands;
using CineFlex.Application.Features.Auth.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Auth.CQRS.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseCommandResponse<UserDto>>
{
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<BaseCommandResponse<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return _authService.Register(request.RegisterUserDto, cancellationToken);
    }
}