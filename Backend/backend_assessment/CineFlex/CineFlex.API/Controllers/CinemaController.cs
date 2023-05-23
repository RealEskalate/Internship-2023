using System.Net;
using CineFlex.Application.Features.Cinemas.CQRS.Commands;
using CineFlex.Application.Features.Cinemas.CQRS.Queries;
using CineFlex.Application.Features.Cinemas.DTO;
using CineFlex.Application.Features.Cinemas.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CinemaController: BaseApiController
    {
        public CinemaController(IMediator mediator): base(mediator)
        {
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<BaseCommandResponse<List<CinemaDto>>>> Get()
        {
            var result = await _mediator.Send(new GetCinemaListQuery());
            
            var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.NotFound;
            return getResponse<BaseCommandResponse<List<CinemaDto>>>(status, result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<CinemaDto>> Get(int id)
        {
            var result = await _mediator.Send(new GetCinemaQuery { Id = id });
            
            var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.NotFound;
            return getResponse<BaseCommandResponse<CinemaDto>>(status, result);
        }
        [HttpPost("CreateCinema")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Post([FromBody] CreateCinemaDto createCinemaDto)
        {
            var result = await _mediator.Send(new CreateCinemaCommand { CinemaDto = createCinemaDto });
            
            var status = result.Success ? HttpStatusCode.Created: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<int>>(status, result);
        }
        [HttpPut("UpdateCinema")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDto updateCinemaDto)
        {
            var result = await _mediator.Send(new UpdateCinemaCommand { updateCinemaDto = updateCinemaDto });
            
            var status = result.Success ? HttpStatusCode.NoContent: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<Unit>>(status, result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {   
            var result = await _mediator.Send(new DeleteCinemaCommand { Id = id });
            
            var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<Unit>>(status, result);
            
        }
    }
}

