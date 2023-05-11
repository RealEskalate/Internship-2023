using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Commands;

 public class CreateCommentCommand :  IRequest<Result<CommentDto>>
{
    public CreateCommentDto CommentDto{ get; set; }
}