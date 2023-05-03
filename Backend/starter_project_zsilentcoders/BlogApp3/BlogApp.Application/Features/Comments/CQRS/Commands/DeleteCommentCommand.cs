using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Commands;

 public class DeleteCommentCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
