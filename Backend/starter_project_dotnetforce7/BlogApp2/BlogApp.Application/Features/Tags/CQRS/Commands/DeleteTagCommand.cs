using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Commands
{
    public class DeleteTagCommand : IRequest<Result<Unit>>
    {
        public int Id {get; set;}
    }
}