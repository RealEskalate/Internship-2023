using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public interface ISeatDto
    {
        public int CinemaId {get; set;}

        public string SeatLocation { get; set; }

        public bool Available {get; set;}
        
    }
}