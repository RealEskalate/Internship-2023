﻿using CineFlex.Application.Features.Common;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class CreateSeatDto : BaseDto, ISeatDto
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsReserved { get; set; }
        public string SeatLevel { get; set; }
        public int CinemaId { get; set; }
    }
}
