using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO
{
    public interface ISeatDto
    {
        int RowNumber { get; set; }
        int SeatNumber { get; set; }
        string SeatType { get; set; }
        bool Availability { get; set; }
        decimal Price { get; set; }
    }
}
