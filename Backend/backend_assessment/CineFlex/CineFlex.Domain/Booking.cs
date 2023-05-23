using System;
using System.Collections.Generic;
using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Booking: BaseDomainEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CinemaId { get; set; }
        public CinemaEntity Cinema { get; set; }
        public DateTime BookingTime { get; set; }
        public ICollection<SeatEntity> Seats { get; set; }
    }

    // Rest of the models remain the same...
}
