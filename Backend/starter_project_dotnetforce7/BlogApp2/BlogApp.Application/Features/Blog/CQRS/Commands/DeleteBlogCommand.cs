using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Application.Features.Blogs.CQRS.Commands

{
    public class DeleteBlogCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
