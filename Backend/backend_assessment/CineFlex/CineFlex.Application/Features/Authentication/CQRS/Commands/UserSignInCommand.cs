using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Authentication.CQRS.Commands
{
    public class UserSignInCommand: IRequest<BaseCommandResponse<string>>
    {   
        public UserSignInDTO SignInDTO { get; set; }
    }
}   