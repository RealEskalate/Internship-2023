using BlogApp.Application.Features._Indices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.CQRS.Commands
{
    public class Update_IndexCommand : IRequest<Unit>
    {
        public _IndexDto _IndexDto { get; set; }

    }
}
