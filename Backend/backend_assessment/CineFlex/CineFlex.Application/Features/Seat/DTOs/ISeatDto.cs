using CineFlex.Domain;

namespace CineFlex.Application.Features.Seat.DTOs;

public interface ISeatDto 
{
    public string SeatNumber { get; set; }
    public SeatType SeatType { get; set; }
    public Availability Availability { get; set; }
}
