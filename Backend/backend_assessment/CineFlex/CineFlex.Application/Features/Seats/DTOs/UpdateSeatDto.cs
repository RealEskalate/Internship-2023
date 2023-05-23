using CineFlex.Application.Features.Common;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class UpdateSeatDto : BaseDto, ISeatDto
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsReserved { get; set; }
        public string SeatLevel { get; set; }
        public int CinemaId { get; set; }
    }
}
