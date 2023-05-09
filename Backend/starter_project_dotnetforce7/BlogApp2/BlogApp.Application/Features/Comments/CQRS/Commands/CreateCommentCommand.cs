using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.CQRS.Commands
{
    public class CreateCommentCommand: IRequest<Result<int>>
    {
        public CreateCommentDto CommentDto { get; set; }
    }
}
