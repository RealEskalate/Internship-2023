

namespace CineFlex.Application.Features.Seats.DTO
{
    public class CreateSeatDto : ISeatDto
    {
         public int SeatNumber {get; set;}    
        public bool IsBooked {get; set;} 
    }
}