using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.CQRS.Queries
{
    public class GetPostListQuery : IRequest<BaseCommandResponse<List<PostDto>>>
    {
    }
}
