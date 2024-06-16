using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class MovieBooking : BaseDomainEntity
{
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public int UserId { get; set; }
    public DateTime BookingDate { get; set; }
    public Movie Movie { get; set; } 
    public CinemaEntity CinemaEntity { get; set; }
    public List<Seat> Seats { get; set; }
 

}
