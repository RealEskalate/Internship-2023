using CineFlex.Domain;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public interface ISeatDto
    {
        int Row { get; set; }
        int Number { get; set; }
        bool IsReserved { get; set; }
        SeatLevel Level { get; set; }
        
    }
}
