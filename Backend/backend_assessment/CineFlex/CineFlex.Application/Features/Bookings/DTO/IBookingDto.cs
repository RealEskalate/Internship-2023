using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.DTO
{
    public interface IBookingDto
    {

        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public DateTime BookingTime { get; set; }

        public ICollection<int> SeatNumbers { get; set; }

    }
}
