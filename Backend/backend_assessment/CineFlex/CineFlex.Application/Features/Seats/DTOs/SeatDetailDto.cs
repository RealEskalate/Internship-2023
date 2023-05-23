using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class SeatDetailDto: BaseDto
    {
        public int CinemaId {get; set;}

        public CinemaDto Cinema {get; set;}

        public string SeatLocation { get; set; }

        public bool Available {get; set;}

    }
}
