namespace CineFlex.Application.Features.Seats.DTOs;

public class CreateSeatDto : ISeatDto
{
    public string Name { get; init; } = null!;
    public int CinemaId { get; set; }
}