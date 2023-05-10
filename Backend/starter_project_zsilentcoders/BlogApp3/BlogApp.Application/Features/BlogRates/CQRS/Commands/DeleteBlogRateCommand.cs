using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Commands
{
    public class DeleteBlogRateCommand : IRequest
    {
        public int Id { get; set; }
    }
}
