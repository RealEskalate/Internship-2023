using BlogApp.Application.Features.BlogRates.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Commands
{
    public class UpdateBlogRateCommand : IRequest<Unit>
    {
        public BlogRateDto BlogRateDto { get; set; }
    }
}
