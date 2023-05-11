using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Queries;

public class GetCommentDetailQuery : IRequest<Result<CommentDto>>
{
    public int Id { get; set; }
}
