using BlogApp.Application.Features.Users.DTOs;
using MediatR;


namespace BlogApp.Application.Features.Users.CQRS.Commands
{
    public class Update_UserCommand : IRequest<Unit>
    {
        public Update_UserDto Update_UserDto { get; set; }

    }
}
