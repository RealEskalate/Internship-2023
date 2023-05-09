using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Features.Blog.DTOs;
// using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers;

public class BlogsController : BaseController
{
    private IMediator _mediator { get; set; }

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<List<BlogListDto>>> Get()
    {
        return HandleResult(await _mediator.Send(new GetBlogListQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> Get(int id)
    {
        return HandleResult(await _mediator.Send(new GetBlogDetailsQuery { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult> CreateBlog([FromBody] CreateBlogDto createBlogDto)
    {
        return HandleResult(await _mediator.Send(new CreateBlogCommand { CreateBlogDto = createBlogDto }));
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBlog(int id)
    {
        return HandleResult(
            await _mediator.Send(new DeleteBlogCommand { DeleteBlogDto = new DeleteBlogDto { Id = id } }));
    }


    [HttpPut]
    public async Task<ActionResult> UpdateBlog([FromBody] UpdateBlogDto updateBlogDto)
    {
        return HandleResult(await _mediator.Send(new UpdateBlogCommand() { UpdateBlogDto = updateBlogDto }));
    }

}