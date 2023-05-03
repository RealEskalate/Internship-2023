using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers;

public class BlogsController: BaseController
{
    private IMediator _mediator { get; set; }

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult> Get(int id)
    {
        var blog = await _mediator.Send(new GetBlogDetailsQuery { Id = id });
        return blog == null ? NotFound() : Ok(blog);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateBlog([FromBody] CreateBlogDto createBlogDto)
    {
        var blog = await _mediator.Send(new CreateBlogCommand { CreateBlogDto = createBlogDto });
        
        return blog == null ?
            new ObjectResult(new { message = "Invalid data!" }) { StatusCode = 422 } :
            Ok(blog);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBlog(int id)
    {
        bool result = await _mediator.Send(new DeleteBlogCommand { DeleteBlogDto = new DeleteBlogDto{Id = id} });
        return result ? NoContent() : NotFound();
    }
}