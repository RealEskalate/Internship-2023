using BlogApp.Application.Features.Comments.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Queries;

public class GetCommentListQuery : IRequest<List<CommentDto>>
{
}
 