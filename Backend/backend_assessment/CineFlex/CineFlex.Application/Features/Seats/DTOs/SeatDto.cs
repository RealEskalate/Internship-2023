using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class SeatDto : BaseDto, ISeatDto
    {
        public int SeatNo { get; set; }
        public bool Free { get; set; }
        public CinemaProfile Cinema { get; set; }

    }
}
