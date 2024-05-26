using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class Booking : BaseDomainEntity
    {
        public DateTime BookingTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
