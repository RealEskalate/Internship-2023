using MediatR;
using CineFlex.Application.Models.DTOs;

namespace CineFlex.Application.Features.Auth.CQRS.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
            public LoginRequest loginRequest { get; set; }  
    }
}
