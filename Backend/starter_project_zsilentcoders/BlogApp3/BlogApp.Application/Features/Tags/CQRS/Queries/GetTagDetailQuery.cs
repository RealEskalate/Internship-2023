using BlogApp.Application.Features.Tags.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.CQRS.Queries
{
    public class GetTagDetailQuery : IRequest<TagDto>
    {
        public int Id { get; set; }
    }
}
