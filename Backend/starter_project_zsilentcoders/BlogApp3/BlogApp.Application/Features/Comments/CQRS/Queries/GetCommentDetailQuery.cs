using BlogApp.Application.Features.Comments.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Queries;

public class GetCommentDetailQuery : IRequest<CommentDto>
{
    public int Id { get; set; }
}
