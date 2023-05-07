using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Commands
{
    public class DeleteReviewCommand: IRequest
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
    }
}