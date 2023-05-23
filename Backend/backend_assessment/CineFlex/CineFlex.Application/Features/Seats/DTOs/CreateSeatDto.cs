namespace CineFlex.Application.Features.Seats.DTOs;

public class CreateSeatDto : ISeatDto
{
    public int CinemaId { get; set; }
    public string Name { get; init; } = null!;
}