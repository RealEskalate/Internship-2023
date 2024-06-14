namespace CineFlex.Application.Features.Seat.DTO
{
    public class SeatDto : ISeatDto
    {
        public string Number { get; set; }
        public bool IsAvailable { get ; set ; }
        public int CinemaId { get ; set ; }
    }
}
