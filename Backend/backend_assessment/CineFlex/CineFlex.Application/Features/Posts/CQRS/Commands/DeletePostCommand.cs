using CineFlex.Application.Responses;
using MediatR;


namespace CineFlex.Application.Features.Posts.CQRS.Commands
{
    public class DeletePostCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
