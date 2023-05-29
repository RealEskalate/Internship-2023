using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.MoviesBooking.CQRS.Commands;

public class DeleteMovieBookingCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
