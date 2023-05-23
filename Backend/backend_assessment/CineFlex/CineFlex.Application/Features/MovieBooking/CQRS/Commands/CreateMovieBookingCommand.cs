using CineFlex.Application.Features.MovieBooking.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.MovieBooking.CQRS.Commands;

public class CreateMovieBookingCommand : IRequest<BaseCommandResponse<MovieBookingDto>>
{
    public CreateMovieBookingDto CreateMovieBookingDto = null!;
    public string UserId { get; set; } = null!;
}