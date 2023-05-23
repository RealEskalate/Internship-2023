using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class Booking : BaseDomainEntity
{
    public CinemaEntity Cinema {get; set;}
    public Movie Movie{ get; set; }
    public ICollection<Seat> Seats { get; set; }
    
}
