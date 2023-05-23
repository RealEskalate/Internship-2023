namespace CineFlex.Application.Features.Seats.DTO;

public class CreateSeatDto : ISeatDto
{
    public string SeatNumber { get; set; }
    public int CinemaId { get; set; }
    public bool isHold { get; set; } = false;

}
