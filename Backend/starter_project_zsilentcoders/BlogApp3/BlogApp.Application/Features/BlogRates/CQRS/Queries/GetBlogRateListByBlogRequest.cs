using BlogApp.Application.Features.BlogRates.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Queries
{
    public class GetBlogRateListByBlogRequest : IRequest<List<BlogRateDto>>
    {
        public int BlogId { get; set; }
    }
}
