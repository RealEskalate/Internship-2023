using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;


namespace CineFlex.Application.Features.Seats.CQRS.Commands
{
    public class CancelBookingCommand: IRequest<BaseCommandResponse<Unit>>
    {   
        public int TicketID { get; set; }
    }
}   