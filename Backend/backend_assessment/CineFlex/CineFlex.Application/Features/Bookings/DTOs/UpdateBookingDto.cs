using CineFlex.Application.Features.Common;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Bookings.DTOs
{
    public class UpdateBookingDto : BaseDto
    {
        public ICollection<Seat> Seats { get; set; }
    }
}
