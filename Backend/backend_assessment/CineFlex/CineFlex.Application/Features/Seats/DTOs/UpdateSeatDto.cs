using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class UpdateSeatDto : BaseDto
    {
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public DateTime lastBooked { get; set; }
    }
}
