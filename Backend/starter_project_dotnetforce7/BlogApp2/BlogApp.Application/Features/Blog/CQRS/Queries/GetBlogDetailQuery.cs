using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Application.Features.Blogs.CQRS.Queries
{
    public class GetBlogDetailQuery : IRequest<Result<BlogDto>>
    {
        public int Id { get; set; }
    }
}
