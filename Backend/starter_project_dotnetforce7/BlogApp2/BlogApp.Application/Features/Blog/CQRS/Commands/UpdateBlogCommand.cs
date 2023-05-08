using BlogApp.Application.Features.Blogs.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Blogs.CQRS.Commands
{
    public class UpdateBlogCommand : IRequest<Result<Unit>>
    {
        public UpdateBlogDto BlogDto { get; set; }

    }
}
