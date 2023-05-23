﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO
{
    public class CreateSeatDto
    {
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public string SeatType { get; set; }
        public bool Availability { get; set; }
        public decimal Price { get; set; }
        public int CinemaHallId { get; set; }
        public int? BookingId { get; set; }

    }
}
