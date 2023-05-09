using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Commands
{
    public class CreateCommentCommand: IRequest<Result<int>>
    {
        public CreateCommentDto CommentDto { get; set; }
    }
}
