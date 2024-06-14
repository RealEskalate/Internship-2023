
using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class CreateSeatDto: BaseDto
    {
        public string Name { get; set; }
        public int CinemaID { get; set; }
    }
}