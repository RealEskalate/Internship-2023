using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Commands
{
    public class UpdateCommentCommand : IRequest<Result<Unit>>
    {
        
        public UpdateCommentDto CommentDto { get; set; }
    }
}