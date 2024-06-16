using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTO
{
    public class UpdateSeatDto : BaseDto, ISeatDto
    {
         public int SeatNumber {get; set;}    
        public bool IsBooked {get; set;} 
        
    }
}