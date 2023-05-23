using CineFlex.Application.Features.Books.CQRS.Commands;
using CineFlex.Application.Features.Books.CQRS.Queries;
using CineFlex.Application.Features.Books.DTO;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

public class BooksController : BaseApiController
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetBookListQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mediator.Send(new GetBookDetailQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateBookDto createBookDto)
    {
        var command = new CreateBookCommand { CreateBookDto = createBookDto };
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateBookDto updateBookDto)
    {
        var command = new UpdateBookCommand { UpdateBookDto = updateBookDto };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteBookCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
