using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class _IndexController : ControllerBase
    {
        private readonly IMediator _mediator;

        public _IndexController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<_IndexDto>>> Get()
        {
            var indices = await _mediator.Send(new Get_IndexListQuery());
            return Ok(indices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<_IndexDto>> Get(int id)
        {
            var indices = await _mediator.Send(new Get_IndexDetailQuery { Id = id });
            return Ok(indices);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] Create_IndexDto create_IndexDto)
        {
            var command = new Create_IndexCommand { _IndexDto = create_IndexDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] _IndexDto indexDto)
        {
            var command = new Update_IndexCommand { _IndexDto = indexDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new Delete_IndexCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
