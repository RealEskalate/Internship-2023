using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Auth.CQRS.Commands;
using CineFlex.Application.Features.Auth.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Auth.CQRS.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseCommandResponse<LoginResponseDto>>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<BaseCommandResponse<LoginResponseDto>> Handle(LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        return _authService.Login(request.LoginUserDto, cancellationToken);
    }
}