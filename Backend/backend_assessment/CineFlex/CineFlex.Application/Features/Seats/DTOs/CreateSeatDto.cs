using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class CreateSeatDto : ISeatDto
    {
        public int SeatNumber { get; set; }
		public string SeatType { get; set; } // regular, VIP, recliner.
		public bool isAvailable { get; set; } //available, not_available.
		public int CinemaId { get; set; } 
    }
}
