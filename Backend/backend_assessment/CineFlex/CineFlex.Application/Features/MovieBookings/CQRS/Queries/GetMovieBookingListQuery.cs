using CineFlex.Application.Features.MovieBookings.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Queries
{
    public class GetMovieBookingListQuery : IRequest<BaseCommandResponse<List<MovieBookingDto>>>
    {

    }
}
