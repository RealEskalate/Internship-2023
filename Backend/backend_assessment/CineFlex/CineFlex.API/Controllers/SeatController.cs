using System.Security.Claims;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SeatController : BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userServise;

        public SeatController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userServise = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeatListDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetSeatListQuery()));
        }

        [HttpGet("Available")]
        public async Task<ActionResult<List<SeatListDto>>> GetAvailable()
        {
            return HandleResult(await _mediator.Send(new GetAvailableSeatsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetSeatDetailQuery { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSeatDto createSeat)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new CreateSeatCommand { SeatDto = createSeat };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSeatDto SeatDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new UpdateSeatCommand { SeatDto = SeatDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst(type: ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new DeleteSeatCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
