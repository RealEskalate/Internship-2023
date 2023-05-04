using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Commands;

 public class DeleteCommentCommand : IRequest
{
    public int Id { get; set; }
}
