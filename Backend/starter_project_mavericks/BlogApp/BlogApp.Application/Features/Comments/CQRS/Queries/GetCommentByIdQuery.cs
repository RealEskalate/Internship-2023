using BlogApp.Application.Features.Comments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.CQRS.Queries
{
    public class GetCommentByIdQuery : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}
