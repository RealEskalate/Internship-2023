using CineFlex.Application.Features.MovieBookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.CQRS.Commands
{
    public class CreateMovieBookingCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateMovieBookingDto MovieBookingDto { get; set; }

        public string UserId {get; set;}

        public bool IsAdmin {get; set;}

    }
}
