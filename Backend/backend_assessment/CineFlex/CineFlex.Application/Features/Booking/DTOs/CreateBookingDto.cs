using CineFlex.Domain;

namespace CineFlex.Application.Features.Booking.DTOs;

public class CreateBookingDto
{
    public int Id {get; set;}
    public CinemaEntity Cinema {get; set;}
    public Movie Movie { get; set; }
    public ICollection<Domain.Seat> Seats { get; set; }
}
