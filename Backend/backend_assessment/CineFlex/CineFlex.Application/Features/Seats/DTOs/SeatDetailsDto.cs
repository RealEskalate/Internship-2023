namespace CineFlex.Application.Features.Seats.DTOs;

public class SeatDetailsDto
{
    public int Id { get; set; }
    public int Movie { get; set; }
    public int Cinema { get; set; }
    public string Location { get; set; }
    public bool Taken { get; set; }
}