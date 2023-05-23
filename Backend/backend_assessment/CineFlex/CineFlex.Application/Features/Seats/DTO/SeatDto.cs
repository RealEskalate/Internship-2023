using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.Dtos
{
    public class SeatDto : BaseDto
    {
       public int SeatNumber { get; set; }
        public int CinemaId { get; set; }
    }
}
