using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Features.Blogs.CQRS.Commands;

namespace BlogApp.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
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
        public async Task<ActionResult<BlogDto>> Get(int id)
        {
            var blog = await _mediator.Send(new GetBlogDetailQuery { Id = id });
            if(blog == null){
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBlogDto createBlog)
        {
    

            var command = new CreateBlogCommand { BlogDto = createBlog };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] BlogDto blogDto)
        {

      
            var command = new UpdateBlogCommand { BlogDto = blogDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
