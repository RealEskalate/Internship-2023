using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Queries
{
    public class GetPostListQuery: IRequest<BaseCommandResponse<List<PostDto>>>
    {
        
    }
}