namespace CineFlex.Application.Features.Seats.DTOs
{
    public class CreateSeatDto : ISeatDto
    {
        public int SeatNo { get; set; }
        public bool Free { get; set; }
        public int CinemaId { get; set; }
    }
}
