using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Commands;

 public class DeleteCommentCommand : IRequest<Result<Unit>>
{
     public DeleteCommentDto? CommentDto;
}
