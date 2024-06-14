using CineFlex.Application.Features.Common;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Bookings.DTOs
{
    public class BookingDto : BaseDto
    {
        public string CinemaName { get; set; }
        public ICollection<int> Seats { get; set; }
        public string MovieName { get; set; }

    }
}
