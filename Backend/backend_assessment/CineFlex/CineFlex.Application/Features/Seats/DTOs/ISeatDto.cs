namespace CineFlex.Application.Features.Seats.DTOs
{
    public interface ISeatDto
    {
        public int SeatNo { get; set; }
        public bool Free { get; set; }
    }
}