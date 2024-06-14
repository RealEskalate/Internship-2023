using CineFlex.Application.Features.Common;
using CineFlex.Application.Features.Seat.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.MovieBookings.DTO
{
    public class MovieBookingDto : BaseDto
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
