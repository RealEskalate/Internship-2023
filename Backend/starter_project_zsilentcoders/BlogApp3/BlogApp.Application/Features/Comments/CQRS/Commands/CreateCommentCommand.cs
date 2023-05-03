using BlogApp.Application.Features.Comments.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Commands;

 public class CreateCommentCommand :  IRequest<int>
{
    public CreateCommentDto CommentDto{ get; set; }
}