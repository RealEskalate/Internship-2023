using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.CQRS.Commands
{
    public class Delete_IndexCommand : IRequest
    {
        public int Id { get; set; }
    }
}
