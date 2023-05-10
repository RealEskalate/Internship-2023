using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Queries;

public class GetCommentListQuery : IRequest<Result<List<CommentDto>>>
{
}
 