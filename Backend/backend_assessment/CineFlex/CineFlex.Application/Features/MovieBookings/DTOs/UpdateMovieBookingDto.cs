using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.DTOs
{
    public class UpdateMovieBookingDto : BaseDto, IMovieBookingDto
    {
        public string UserId {get; set;}
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public int SeatId { get; set; }

    }
}
