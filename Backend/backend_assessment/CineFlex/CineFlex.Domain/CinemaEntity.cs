using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class CinemaEntity: BaseDomainEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }

        public int TotalSeats { get; set; }

        public ICollection<SeatEntity> Seats { get; set; } = new List<SeatEntity>();
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
