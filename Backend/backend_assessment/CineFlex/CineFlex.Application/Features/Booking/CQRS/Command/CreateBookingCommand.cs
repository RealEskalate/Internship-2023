using CineFlex.Application.Features.Booking.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Booking.CQRS.Command;

public class CreateBookingCommand : IRequest<BaseCommandResponse<int>>
{
    public CreateBookingDto createBookingDto {get; set;}
}
