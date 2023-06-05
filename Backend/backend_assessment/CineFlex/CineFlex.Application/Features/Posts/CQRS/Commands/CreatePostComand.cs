using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Commands
{
    public class CreatePostCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreatePostDto CreatePostDto{get;set;}
        
    }
}