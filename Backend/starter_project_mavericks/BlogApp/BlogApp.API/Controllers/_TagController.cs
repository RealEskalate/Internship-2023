using BlogApp.Application.Features._Tags.CQRS.Commands;
using BlogApp.Application.Features._Tags.CQRS.Queries;
using BlogApp.Application.Features._Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class _TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public _TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<_TagDto>>> Get()
        {
            var Tags = await _mediator.Send(new getTagListQuery());
            return Ok(Tags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<_TagDto>> Get(int id)
        {
            var Tags = await _mediator.Send(new getTagDetailQuery { Id = id });
            return Ok(Tags);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] createTagDto create_TagDto)
        {
            var command = new createTagCommand { _TagDto = create_TagDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] updateTagDto tagDto)
        {
            var command = new updateTagCommand { _TagDto = tagDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new deleteTagCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
