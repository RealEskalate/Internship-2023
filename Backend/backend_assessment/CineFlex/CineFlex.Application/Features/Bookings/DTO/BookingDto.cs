using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.Dtos
{
    public class BookingDto : BaseDto, IBookingDto
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public DateTime BookingTime { get; set; }

        public ICollection<int> SeatNumbers { get; set; }
    }
}
