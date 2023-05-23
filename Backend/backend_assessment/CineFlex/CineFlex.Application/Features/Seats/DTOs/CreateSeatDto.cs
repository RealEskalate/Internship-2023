namespace CineFlex.Application.Features.Seats.DTOs;

public class CreateSeatDto
{
    public int Movie { get; set; }
    public int Cinema { get; set; }
    public string Airtime { get; set; }
    public int NumberOfSeats { get; set; }
}