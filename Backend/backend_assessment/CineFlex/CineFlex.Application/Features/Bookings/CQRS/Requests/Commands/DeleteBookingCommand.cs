using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Bookings.CQRS.Requests.Commands;

public class DeleteBookingCommand: IRequest<BaseCommandResponse<BookingDetailDto?>>
{
    public int Id { get; set; }
}