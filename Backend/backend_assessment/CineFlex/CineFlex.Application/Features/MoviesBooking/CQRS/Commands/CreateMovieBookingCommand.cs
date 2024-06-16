using CineFlex.Application.Features.MoviesBooking.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.MoviesBooking.CQRS.Commands;

public class CreateMovieBookingCommand : IRequest<BaseCommandResponse<int>>
    { 
        public CreateMovieBookingDto CreateMovieBookingDto { get; set; }
    }