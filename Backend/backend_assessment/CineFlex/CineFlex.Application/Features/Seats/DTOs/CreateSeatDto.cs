using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class CreateSeatDto
    {
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public DateTime lastBooked { get; set; }
    }
}
