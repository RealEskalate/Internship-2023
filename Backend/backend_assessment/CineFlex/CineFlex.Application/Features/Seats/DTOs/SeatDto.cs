using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs;

public class SeatDto : BaseDto, ISeatDto
{
    public string Name { get; init; } = null!;
    public int CinemaId { get; set; }
}