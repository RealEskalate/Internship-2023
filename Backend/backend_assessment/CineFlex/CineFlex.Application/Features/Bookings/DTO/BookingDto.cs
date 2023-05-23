using CineFlex.Application.Features.Common;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.DTO
{
    public class BookingDto : BaseDto, IBookingDto
    {
        public DateTime BookingTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int MovieId { get; set; }
        public List<int> SeatIds { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }


    }
}
    