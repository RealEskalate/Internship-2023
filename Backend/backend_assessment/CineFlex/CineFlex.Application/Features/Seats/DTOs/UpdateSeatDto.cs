using CineFlex.Application.Features.Common;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class UpdateSeatDto: BaseDto, ISeatDto
    {
        public string Movie { get; set; }
        public string cinemaEntity { get; set; }
        public int RowNumber { get; set; }
        public SeatType SeatType { get; set; }
        public SeatStatus SeatStatus { get; set; }
        public decimal SeatPrice { get; set; }
        public string SeatDescription { get; set; }
        public DateTime DateTime { get; set; }
    }
}
