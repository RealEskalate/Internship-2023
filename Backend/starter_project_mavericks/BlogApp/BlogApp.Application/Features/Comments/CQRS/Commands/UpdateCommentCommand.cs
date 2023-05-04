using BlogApp.Application.Features.Comments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.CQRS.Commands
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        
        public int Id { get; set; }
        public UpdateCommentDto updateCommentDto { get; set; }

    }
}
