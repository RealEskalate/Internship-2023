using CineFlex.Application.Features.Seats.DTOs;

namespace CineFlex.Application.Features.MoviesBooking.DTOs;

public class MovieBookingDto : IMovieBookingDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public List<ISeatDto> Seats { get; set; }
    public int UserId { get; set; }
    public DateTime BookingDate { get; set; }
}