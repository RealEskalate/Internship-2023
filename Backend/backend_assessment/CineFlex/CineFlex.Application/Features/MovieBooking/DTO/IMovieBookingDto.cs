using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seat.DTO;

namespace CineFlex.Application.Features.MovieBookings.DTO
{
    public interface IMovieBookingDto
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
