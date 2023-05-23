using CineFlex.Application.Features.Common;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Seat.DTOs
{
    public class CreateSeatDto : BaseDto, ISeatDto
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsReserved { get; set; }
        public SeatLevel Level { get; set; }
    }
}
