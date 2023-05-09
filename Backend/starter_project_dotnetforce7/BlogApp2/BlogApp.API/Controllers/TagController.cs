using API.Controllers;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : BaseApiController
    {

        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDto>>> Get()
        {
             return  HandleResult( await _mediator.Send(new GetTagListQuery()));
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> Get(int id)
        {
            return  HandleResult(await _mediator.Send(new GetTagDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTagDto createTagDto)
        {
             return HandleResult(await _mediator.Send(new CreateTagCommand { TagDto = createTagDto }));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TagDto tagDto)
        {
            return HandleResult(await _mediator.Send(new UpdateTagCommand { TagDto = tagDto }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           return HandleResult( await _mediator.Send(new DeleteTagCommand { Id = id }));
        }
    }

}
