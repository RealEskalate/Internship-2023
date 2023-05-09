using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using API.Controllers;

namespace BlogApp.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BlogsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogDto>>> Get()
        {
            var blogs = await _mediator.Send(new GetBlogListQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
        return HandleResult(await _mediator.Send(new GetBlogDetailQuery { Id = id }));
          
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBlogDto createBlog)
        {
            var command = new CreateBlogCommand { BlogDto = createBlog };
            return  HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBlogDto blogDto)
        {

      
            var command = new UpdateBlogCommand { BlogDto = blogDto };
            return HandleResult( await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
