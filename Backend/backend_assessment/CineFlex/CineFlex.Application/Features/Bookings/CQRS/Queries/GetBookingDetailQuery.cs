using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Queries
{
    public class GetBookingDetailQuery : IRequest<BaseCommandResponse<BookingDetailDto>>
    {
        public int Id { get; set; }
    }
}
