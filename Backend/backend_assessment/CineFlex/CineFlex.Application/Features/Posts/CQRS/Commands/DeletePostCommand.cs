using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.CQRS.Commands
{
    public class DeletePostCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public int Id { get; set; } 
    }
}
