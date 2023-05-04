using BlogApp.Application.Features.Blogs.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Blogs.CQRS.Queries
{
    public class GetBlogListQuery : IRequest<List<BlogDto>>
    {
        
    }
}