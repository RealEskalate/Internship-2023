using MediatR;


namespace BlogApp.Application.Features.Users.CQRS.Commands
{
    public class Delete_UserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
