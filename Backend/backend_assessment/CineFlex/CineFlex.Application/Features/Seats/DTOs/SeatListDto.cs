using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class SeatListDto : BaseDto
    {
        public int CinemaId {get; set;}

        public string SeatLocation { get; set; }

        public bool Available {get; set;}

    }
}
