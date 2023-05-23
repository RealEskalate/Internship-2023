using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Authentication.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Models.Identity;

namespace CineFlex.Application.Features.Authentication.CQRS.Handlers;
public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationResponse>
{
    private readonly IAuthService _authService;
    public RegistrationCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<RegistrationResponse> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var registrationResponse = await _authService.RegisterAsync(request.RegistrationRequest);
        return registrationResponse;
    }
}
