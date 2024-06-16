using CineFlex.Application.Features.MoviesBooking.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.MoviesBooking.CQRS.Commands;

public class UpdateMovieBookingCommand : IRequest<Unit>
    {
        public UpdateMovieBookingDto UpdateMovieBookingDto { get; set; }

    }