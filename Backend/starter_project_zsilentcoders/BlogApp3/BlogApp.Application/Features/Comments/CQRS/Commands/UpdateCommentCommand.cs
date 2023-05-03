using BlogApp.Application.Features.Comments.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Commands;

public class UpdateCommentCommand : IRequest<Unit>
{
    public UpdateCommentDto CommentDto{ get; set; }
}
