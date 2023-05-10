using BlogApp.Application.Features._Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.CQRS.Commands
{
    public class updateTagCommand : IRequest<BaseResponse<Unit>>
    {
        public updateTagDto _TagDto { get; set; }
    }
}
