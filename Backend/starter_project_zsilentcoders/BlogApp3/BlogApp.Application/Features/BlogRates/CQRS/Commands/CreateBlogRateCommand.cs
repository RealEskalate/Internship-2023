using BlogApp.Application.Features.BlogRates.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace BlogApp.Application.Features.BlogRates.CQRS.Commands
{
    public class CreateBlogRateCommand : IRequest<BaseCommandResponse>
    {
        public CreateBlogRateDto CreateBlogRateDto { get; set; }
       
    }
}
