using System.Net;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    public class BookingController: BaseApiController
    {
        public BookingController(IMediator mediator): base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse<int>>> Post([FromBody] CreateTicketDto createTicketDto)
        {
            var result = await _mediator.Send(new BookTicketCommand { CreateTicketDto = createTicketDto });
            
            var status = result.Success ? HttpStatusCode.Created: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<int>>(status, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {   
            var result = await _mediator.Send(new CancelBookingCommand { TicketID = id });
            
            var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<Unit>>(status, result);
            
        }

    }
}

