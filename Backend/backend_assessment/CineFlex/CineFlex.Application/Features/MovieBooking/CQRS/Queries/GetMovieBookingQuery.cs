using CineFlex.Application.Features.MovieBookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Queries
{
    public class GetMovieBookingQuery: IRequest<BaseCommandResponse<MovieBookingDto>>
    {
        public int Id { get; set; }
    }
}
