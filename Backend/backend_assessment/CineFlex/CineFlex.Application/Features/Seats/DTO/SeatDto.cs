namespace CineFlex.Application.Features.Seats.DTO;

public class SeatDto : BaseDto,IMovieDto
{
    public string SeatNumber { get; set; }
    public int CinemaId { get; set; }
    public bool isHold { get; set; } = false;
}
