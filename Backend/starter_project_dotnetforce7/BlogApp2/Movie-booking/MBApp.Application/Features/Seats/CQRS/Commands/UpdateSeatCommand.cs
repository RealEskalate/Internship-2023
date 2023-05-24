using MBApp.Application.Features.Seats.DTOs;
using MBApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Seat.CQRS.Commands
{
    public class UpdateSeatCommand : IRequest<Result<Unit>>
    {
        
        public UpdateSeatDto SeatDto { get; set; }
    }
}