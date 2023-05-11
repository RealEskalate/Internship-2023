using BlogApp.Api.Controllers;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using BlogApp.Application.Features.BlogRates.CQRS.Queries;
using BlogApp.Application.Features.BlogRates.DTOs;

using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BlogRatesController : BaseController
    {
        private readonly IBlogRateRepository _blogRateRepository;
        private readonly IMediator _mediator;

        public BlogRatesController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

    [HttpGet("{blogId}")]
    public async Task<ActionResult<List<BlogRateDto>>> Get(int blogId)
    {
        var command = new GetBlogRateListByBlogRequest { BlogId = blogId };
            var blogRates = await _mediator.Send(command);
            
        return HandleResult(blogRates);
    }
        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] CreateBlogRateDto createBlogRateDto)
        {
            var command = new CreateBlogRateCommand { CreateBlogRateDto = createBlogRateDto };
            var response = await _mediator.Send(command);
            return HandleResult(response);


        }

        [HttpDelete]

        public async Task<ActionResult<Unit>> Delete([FromBody] DeleteBlogRateDto deleteBlogRateDto)
        {
            var command = new DeleteBlogRateCommand { DeleteBlogRateDto = deleteBlogRateDto };
            var response = await _mediator.Send(command);

            return HandleResult(response);


        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Update([FromBody] BlogRateDto blogRateDto)
        {
            var command = new UpdateBlogRateCommand { BlogRateDto = blogRateDto };
            var response = await _mediator.Send(command); 
            return HandleResult(response); 
        }





    



     
    }
}
