using CineFlex.Application.Features.Seats.DTOs;

namespace CineFlex.Application.Features.MoviesBooking.DTOs;

public class CreateMovieBookingDto 
{
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public List<CreateSeatDto> Seats { get; set; }
    public int UserId { get; set; }
    public DateTime BookingDate { get; set; }
    
}
