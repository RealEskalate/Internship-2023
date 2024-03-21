using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Application.Responses;
using MediatR;


namespace BlogApp.Application.Features.Users.CQRS.Commands
{
    public class Create_UserCommand: IRequest<BaseCommandResponse>
    {
        public Create_UserDto Create_UserDto { get; set; }
    }
}
