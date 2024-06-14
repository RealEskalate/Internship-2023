using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seat.DTO
{
    public class UpdateSeatDto : BaseDto, ISeatDto
    {
        public string Number { get ; set ; }
        public bool IsAvailable { get ; set ; }
        public int CinemaId { get ; set ; }
    }
}
