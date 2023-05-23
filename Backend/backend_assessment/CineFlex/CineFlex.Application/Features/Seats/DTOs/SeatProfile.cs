using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class SeatProfile : BaseDto, ISeatDto
    {
        public int SeatNo { get; set; }
        public bool Free { get; set; }

    }
}
