using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seat.DTO
{
    public class UpdateSeatDto : BaseDto , ISeatDto
    {
        public string SeatType { get; set; }


        public bool Available { get; set; }


        public decimal Price { get; set; }


    }
}