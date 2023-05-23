using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO
{
    public interface ISeatDto
    {
        public int SeatNumber {get; set;}    
        public bool IsBooked {get; set;} 
    }
}