using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class Seat: BaseDomainEntity
    {
       public int CinemaId { get; set; }
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }
    public bool IsOccupied { get; set; }
    public string SeatType { get; set; }
    public decimal Price { get; set; }

    }
}
