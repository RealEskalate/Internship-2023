using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Commands
{
    public class UpdatePostCommand : IRequest<BaseCommandResponse<Unit>>
    {
        
        public UpdatePostDto updatePostDto { get; set; }
    }
}