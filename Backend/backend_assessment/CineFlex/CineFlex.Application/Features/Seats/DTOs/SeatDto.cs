using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs;

public class SeatDto : BaseDto, ISeatDto
{
    public int CinemaId { get; set; }
    public string Name { get; init; } = null!;
}