using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.DTO
{
    public interface IBookingDto
    {
        int Id { get; set; }
        DateTime BookingTime { get; set; }
        decimal TotalPrice { get; set; }
        int MovieId { get; set; }
        List<int> SeatIds { get; set; }
        string CustomerName { get; set; }
        string CustomerEmail { get; set; }
    }
}
