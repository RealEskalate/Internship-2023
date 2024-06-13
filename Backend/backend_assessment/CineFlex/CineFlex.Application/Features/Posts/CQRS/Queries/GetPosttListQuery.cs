using CineFlex.Application.Features.Posts.DTOs;
using MediatR;
using CineFlex.Application.Responses;

namespace CineFlex.Application.Features.Posts.CQRS.Queries
{
    public class GetPostListQuery: IRequest<BaseCommandResponse<List<PostDto>>>
    {
    }
}
