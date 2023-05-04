using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.CQRS.Commands
{
    public class DeleteTagCommand : IRequest
    {
        public int Id { get; set; }
    }
}
