
using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class SeatListDto: BaseDto
    {
        public string Name { get; set; }
        public bool Available { get; set; }
    }
}