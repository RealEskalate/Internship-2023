using CineFlex.Application.Features.Common;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Seat.DTOs;

public class UpdateSeatDto : BaseDto
{
    public string SeatNumber { get; set; }
    public SeatType SeatType { get; set; }
    public Availability Availability { get; set; }
}