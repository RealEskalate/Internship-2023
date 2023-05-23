using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO
{
    public class CreateSeatDto : ISeatDto
    {
        public int SeatNumber { get; set; }
        public int CinemaId { get; set; }


    }
}
