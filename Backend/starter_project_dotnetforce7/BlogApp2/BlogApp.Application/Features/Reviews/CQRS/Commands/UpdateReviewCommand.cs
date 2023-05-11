using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.CQRS.Commands
{
    public class UpdateReviewCommand : IRequest<Result<Unit>>
    { 
        public UpdateReviewDto ReviewDto { get; set; }

    }
}
