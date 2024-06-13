using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class MovieBooking: BaseDomainEntity
    {
        public string UserId {get; set;}
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public int SeatId { get; set; }

    }
}
