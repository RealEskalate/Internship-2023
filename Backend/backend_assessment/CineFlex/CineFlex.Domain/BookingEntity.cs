using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class BookingEntity: BaseDomainEntity
    {
        public String UserId { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public List<int> SeatIds { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Movie Movie { get; set; }
        public CinemaEntity Cinema { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
