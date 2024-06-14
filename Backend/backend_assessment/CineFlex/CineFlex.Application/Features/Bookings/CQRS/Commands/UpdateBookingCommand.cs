using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Commands
{
    public class UpdateBookingCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public UpdateBookingDto BookingDto { get; set; }

    }
}
