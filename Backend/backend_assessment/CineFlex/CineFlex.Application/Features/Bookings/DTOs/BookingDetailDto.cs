namespace CineFlex.Application.Features.Bookings.DTOs;

public class BookingDetailDto
{
    public int Id { get; set; }
    public int Seat { get; set; }
    public int User { get; set; } = 0;
}