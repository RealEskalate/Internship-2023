using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TagController :   ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDto>>> Get()
        {
            var Tags = await _mediator.Send(new GetTagListQuery());
            return Ok(Tags);
        }
        































        // 

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> Get(int id)
        {
            var Tags = await _mediator.Send(new GetTagDetailQuery { Id = id });
            return Ok(Tags);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTagDto createTagDto)
        {
            var command = new CreateTagCommand { TagDto = createTagDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateTagDto tagDto)
        {
            var command = new UpdateTagCommand { TagDto = tagDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTagCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
