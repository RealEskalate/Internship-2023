using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.DTO
{
    public class CreateBookingDto
    {
        public int MovieId { get; set; }
        public List<int> SeatIds { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
