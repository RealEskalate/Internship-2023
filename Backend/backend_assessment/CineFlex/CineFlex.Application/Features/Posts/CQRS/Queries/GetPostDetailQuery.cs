using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;

using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Queries
{
    public class GetPostDetailQuery : IRequest<BaseCommandResponse<PostDto>>
	{
		public int Id { get; set; }
	}
}
