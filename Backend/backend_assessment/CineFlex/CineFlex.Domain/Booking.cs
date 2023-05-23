using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Booking:BaseDomainEntity
    {
        public AppUser Owner { get; set; }
        public CinemaEntity Cinema { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public Movie Movie { get; set; }
    }
}
