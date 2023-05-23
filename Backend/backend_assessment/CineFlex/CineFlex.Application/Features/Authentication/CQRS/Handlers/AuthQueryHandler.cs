using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Authentication.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Models.Identity;

namespace CineFlex.Application.Features.Authentication.CQRS.Handlers;
public class AuthQueryHandler : IRequestHandler<AuthQuery, AuthResponse>
{
    private readonly IAuthService _authService;
    public AuthQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<AuthResponse> Handle(AuthQuery request, CancellationToken cancellationToken)
    {

        var authResponse = await _authService.LoginAsync(request.AuthRequest);
        return authResponse;
    }
}
