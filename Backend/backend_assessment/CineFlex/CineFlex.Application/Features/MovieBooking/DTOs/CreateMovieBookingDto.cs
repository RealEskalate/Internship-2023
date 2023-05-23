namespace CineFlex.Application.Features.MovieBooking.DTOs;

public class CreateMovieBookingDto
{
    public int MovieId { get; init; }
    public int CinemaId { get; init; }
    public List<int> SeatIds { get; init; } = null!;
}