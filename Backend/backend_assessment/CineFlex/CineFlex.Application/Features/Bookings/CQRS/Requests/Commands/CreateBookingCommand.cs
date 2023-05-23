using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Requests.Commands;

public class CreateBookingCommand: IRequest<BaseCommandResponse<BookingDetailDto?>>
{
    public CreateBookingDto CreateBookingDto { get; set; }
}