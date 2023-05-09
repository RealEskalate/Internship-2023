using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Commands
{
    public class CreateTagCommand : IRequest<Result<int>>
    {
        public CreateTagDto TagDto {get; set;}
        
    }
}