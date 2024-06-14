using CineFlex.Application.Features.Book.CQRS.Commands;
using CineFlex.Application.Features.Book.CQRS.Query;
using CineFlex.Application.Features.Book.DTO;
using CineFlex.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{

    public class BookController : BaseApiController
    {
        private readonly BookService _bookService;
        private readonly IMediator _mediator;

        public BookController(BookService bookService, IMediator mediator)
        {
            _bookService = bookService;
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BookDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetBookListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetBookQuery { Id = id }));
        }
        [HttpPost("CreateBook")]
        public async Task<ActionResult> Post([FromBody] CreateBookDto createBookDto)
        {

            bool canCreateBook = await _bookService.CanCreateBook(createBookDto.MovieId, createBookDto.SeatId, createBookDto.CinemaId);

            if (!canCreateBook)
            {
                return BadRequest("One or more foreign keys do not exist.");
            }
            bool isSeatAvailable = await _bookService.IsSeatAvailable(createBookDto.SeatId);
            if (!isSeatAvailable)
            {
                return BadRequest("This site is Taken");

            }

            var command = new CreateBookCommand { BookDto = createBookDto };
            return HandleResult(await _mediator.Send(command));
        }

        [Authorize]
        [HttpPut("UpdateBook")]
        public async Task<ActionResult> Put([FromBody] UpdateBookDto updateBookDto)
        {
            var command = new UpdateBookCommand { updateBookDto = updateBookDto };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

