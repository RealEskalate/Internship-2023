using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Commands
{
    public class DeleteReviewCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
    }
}