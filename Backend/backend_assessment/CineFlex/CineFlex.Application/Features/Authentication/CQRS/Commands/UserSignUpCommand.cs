using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Authentication.CQRS.Commands
{
    public class UserSignUpCommand: IRequest<BaseCommandResponse<UserDTO>>
    {   
        public UserSignUpDTO SignUpDTO { get; set; }
    }
}   