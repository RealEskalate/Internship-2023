using MBApp.Application.Features.Seats.DTOs;
using MBApp.Application.Responses;
using MediatR;

namespace MBApp.Application.Features.Seats.CQRS.Commands
{
    public class CreateSeatCommand: IRequest<Result<int>>
    {
        public CreateSeatDto SeatDto { get; set; }
    }
}
