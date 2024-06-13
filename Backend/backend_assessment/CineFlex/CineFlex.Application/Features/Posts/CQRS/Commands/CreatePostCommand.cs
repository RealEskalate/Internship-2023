using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Commands
{
    public class CreatePostCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreatePostDto PostDto { get; set; }

    }
}