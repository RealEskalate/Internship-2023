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
    public class TagController :   BaseController
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [HttpGet]
    public async Task<ActionResult<List<TagListDto>>> Get()
    {
        return HandleResult(await _mediator.Send(new GetTagListQuery()));
    }


         [HttpGet("{id:int}")]
    public async Task<ActionResult> Get(int id)
    {
        return HandleResult(await _mediator.Send(new GetTagDetailsQuery { Id = id }));
    }

        [HttpPost]
        public async Task<ActionResult<Result<CreateTagDto>>> Post([FromBody] CreateTagDto createTagDto)
        {
            var command = new CreateTagCommand { CreateTagDto = createTagDto };
            var repsonse = await _mediator.Send(command);
            return HandleResult(repsonse);
        }

        [HttpPut]
    public async Task<ActionResult> UpdateTag([FromBody] UpdateTagDto updateTagDto)
    {
        return HandleResult(await _mediator.Send(new UpdateTagCommand() { UpdateTagDto = updateTagDto }));
    }

       [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTag(int id)
    {
        return HandleResult(
            await _mediator.Send(new DeleteTagCommand { DeleteTagDto = new DeleteTagDto { Id = id } }));
    }
    }
}
