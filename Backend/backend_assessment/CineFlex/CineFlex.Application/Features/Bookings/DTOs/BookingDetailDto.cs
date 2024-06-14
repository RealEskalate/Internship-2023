using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Seats.DTOs;

namespace CineFlex.Application.Features.Bookings.DTOs
{
    public class BookingDetailDto
    {
        public CinemaProfile Cinema { get; set; }
        public ICollection<SeatProfile> Seats { get; set; }
        public MovieDto Movie { get; set; }
    }
}
