using CineFlex.Application.Features.Users.DTOs;
using CineFlex.Application.Responses;

using MediatR;


namespace CineFlex.Application.Features.Users.CQRS.Commands
{
    public class Create_UserCommand: IRequest<BaseCommandResponse<int>>
    {
        public Create_UserDto Create_UserDto { get; set; }
    }
}
