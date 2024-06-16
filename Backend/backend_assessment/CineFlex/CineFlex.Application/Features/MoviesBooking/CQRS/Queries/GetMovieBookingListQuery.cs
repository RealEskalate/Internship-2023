using CineFlex.Application.Features.MoviesBooking.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.MoviesBooking.CQRS.Queries;

public class GetMovieBookingListQuery : IRequest<BaseCommandResponse<List<MovieBookingDto>>>
{
    
}