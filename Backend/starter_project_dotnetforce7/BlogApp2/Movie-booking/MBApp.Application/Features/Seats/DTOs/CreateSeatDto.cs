using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBApp.Application.Features.Seats.DTOs;

namespace MBApp.Application.Features.Seats.DTOs
{
    public class CreateSeatDto : ISeatDto
    {
        public string SeatNumber { get; set; }
		public string SeatType { get; set; } // regular, VIP, recliner.
		public bool isAvailable { get; set; } //available, not_available.
		public Cinema Cinema { get; set; } 
    }
}
