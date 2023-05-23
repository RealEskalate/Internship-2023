using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Commands
{
    public class CreateBookingCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateBookingDto BookingDto { get; set; }
    }
}
