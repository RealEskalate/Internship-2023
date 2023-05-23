using System.Security.Claims;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CineFlex.API.Controllers
{
    [Authorize]
    public class CinemaController: BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userServise;

        public CinemaController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userServise = userService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CinemaDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetCinemaListQuery()));
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaDto>> Get(int id)
        {
             return HandleResult(await _mediator.Send(new GetCinemaQuery { Id = id }));
        }


        [HttpPost("CreateCinema")]
        public async Task<ActionResult> Post([FromBody] CreateCinemaDto createCinemaDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });


            var command = new CreateCinemaCommand { CinemaDto = createCinemaDto };
            return HandleResult(await _mediator.Send(command));
        }


        [HttpPut("UpdateCinema")]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDto updateCinemaDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new UpdateCinemaCommand { updateCinemaDto = updateCinemaDto };
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new DeleteCinemaCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

