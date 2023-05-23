using CineFlex.Application.Features.Users.DTOs;
using MediatR;


namespace CineFlex.Application.Features.Users.CQRS.Commands
{
    public class Update_UserCommand : IRequest<Unit>
    {
        public Update_UserDto Update_UserDto { get; set; }

    }
}
