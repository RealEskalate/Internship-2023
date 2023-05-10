using BlogApp.Application.Features._Tags.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.CQRS.Queries
{
    public class Get_TagDetailQuery : IRequest<_TagDto>
    {
        public int Id { get; set; }
    }
}
