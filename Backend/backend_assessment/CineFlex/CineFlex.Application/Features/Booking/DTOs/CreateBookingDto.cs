using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Booking.DTOs
{
    public class CreateBookingDto
    {
       public string? UserId { get; set; }
       public int MovieId { get; set; }
       public int CinemaId { get; set; }
       public List<int> SeatIds { get; set; }

    }
}
